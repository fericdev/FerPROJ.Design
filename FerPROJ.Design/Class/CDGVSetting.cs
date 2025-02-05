
using FerPROJ.Design.Controls;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CDGVSettings {
        public static bool GetSelectedValue(this CDatagridview dgv, int columnIndex, out string value) {
            value = null;

            if (dgv.SelectedRows.Count > 0) {
                int rowIndex = dgv.SelectedRows[0].Index;

                if (columnIndex >= 0 && columnIndex < dgv.Columns.Count) {
                    DataGridViewCell cell = dgv.Rows[rowIndex].Cells[columnIndex];
                    value = cell.Value?.ToString();
                    return true;
                }
            }

            return false;
        }
        public static bool GetSelectedValues(this CDatagridview dgv, int columnIndex, out List<object> values) {

            values = new List<object>();

            if (dgv.SelectedRows.Count > 0) {
                foreach (DataGridViewRow selectedRow in dgv.SelectedRows) {
                    int rowIndex = selectedRow.Index;

                    if (columnIndex >= 0 && columnIndex < dgv.Columns.Count) {
                        DataGridViewCell cell = dgv.Rows[rowIndex].Cells[columnIndex];
                        string cellValue = cell.Value?.ToString();

                        if (!string.IsNullOrEmpty(cellValue)) {
                            values.Add(cellValue);
                        }
                    }
                }

                return values.Count > 0; // Return true if at least one value is added to the list
            }

            return false;
        }

        public static bool IsMultipleSelected(this CDatagridview dgv) {
            // Return true if more than one row is selected
            return dgv.SelectedRows.Count > 1;
        }
        public static void SetWrapMode(this CDatagridview dgv, DataGridViewTriState state) {
            var row = dgv.RowsDefaultCellStyle;
            row.WrapMode = state;
        }
        public static void SetMultiSelect(this CDatagridview dgv, bool state) {
            dgv.MultiSelect = state;
        }
        public static void SetColumnSizing(this CDatagridview dgv) {
            foreach (DataGridViewColumn column in dgv.Columns) {
                int maxWidth = TextRenderer.MeasureText(column.HeaderText, dgv.Font).Width;

                foreach (DataGridViewRow row in dgv.Rows) {
                    if (row.Cells[column.Index].Value != null) {
                        int cellWidth = TextRenderer.MeasureText(row.Cells[column.Index].Value.ToString(), dgv.Font).Width;
                        maxWidth = Math.Max(maxWidth, cellWidth);
                    }
                }

                column.Width = maxWidth + 100; // Adding some padding to avoid truncation
            }
        }
        public static double GetColumnTotal(this CDatagridview dgv, int columnIndex) {
            double sum = 0.0;
            // Check if the column index is valid
            if (columnIndex >= 0 && columnIndex < dgv.Columns.Count) {
                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in dgv.Rows) {
                    // Check if the cell value is a valid double
                    if (row.Cells[columnIndex].Value != null && double.TryParse(row.Cells[columnIndex].Value.ToString(), out double cellValue)) {
                        // Add the cell value to the sum
                        sum += cellValue;
                    }
                }
            }
            else {
                // Handle the case when the column index is out of range
                MessageBox.Show("Invalid column index: " + columnIndex);
            }

            return sum;
        }
        public static T GetItemDTO<T>(this CDatagridview dgv) where T : class {
            if (dgv.CurrentRow != null) {
                return dgv.CurrentRow.DataBoundItem as T;
            }

            return null;
        }
        public static void SearchDGVWithBackgroundWorker(this CDatagridview dgv, string searchValue) {
            // Initialize BackgroundWorker
            var worker = new BackgroundWorker {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            FrmSplasherLoading.ShowSplashAsync().RunTaskAsync();
            // Define the DoWork event handler
            worker.DoWork += (sender, e) => {
                string trimValue = searchValue.Trim(); // Trim the search value
                var visibleRows = new List<DataGridViewRow>();
                int rowCount = dgv.Rows.Count;
                int matchedCount = 0;

                for (int i = 0; i < rowCount; i++) {
                    if (worker.CancellationPending) {
                        e.Cancel = true;
                        return;
                    }

                    DataGridViewRow row = dgv.Rows[i];

                    // Check if any cell contains the search value
                    bool rowVisible = row.Cells.Cast<DataGridViewCell>()
                                               .Any(cell => cell?.Value != null && cell.Value.ToString().SearchFor(trimValue));

                    if (rowVisible) {
                        visibleRows.Add(row);
                        matchedCount++;
                    }

                    // Report progress every 10 rows
                    if (i % 10 == 0 || i == rowCount - 1) {
                        worker.ReportProgress(i * 100 / rowCount, matchedCount);
                    }
                }

                e.Result = visibleRows;
            };

            // Define the ProgressChanged event handler
            worker.ProgressChanged += (sender, e) => {
                // Update progress bar (you can replace this with any progress UI element)
                int percentage = e.ProgressPercentage;
                int matchedCount = (int)e.UserState;
                FrmSplasherLoading.SetLoadingText(percentage, $"Found: {matchedCount} | {percentage}%");
            };

            // Define the RunWorkerCompleted event handler
            worker.RunWorkerCompleted += (sender, e) => {
                var visibleRows = (List<DataGridViewRow>)e.Result;

                dgv.Invoke((Action)(() => {
                    foreach (DataGridViewRow row in dgv.Rows) {
                        // Make rows visible only if they match the search criteria
                        CurrencyManager currencyManager = (CurrencyManager)dgv.BindingContext[dgv.DataSource];
                        currencyManager.SuspendBinding();
                        row.Visible = visibleRows.Contains(row);
                        // Resume binding to CurrencyManager
                        currencyManager.ResumeBinding();

                    }
                }));
                FrmSplasherLoading.SetLoadingText(100, $"Found: {visibleRows.Count} | 100%");
                FrmSplasherLoading.CloseSplash();
            };
            worker.RunWorkerAsync();
        }
        public static async Task SearchDGVAsync(this CDatagridview dgv, string searchValue) {
            try {
                string trimValue = searchValue.Trim(); // Trim the search value
                var visibleRows = new List<DataGridViewRow>();

                // Run the search operation on a background thread
                await Task.Run(() => {
                    // Use parallelism cautiously and only if necessary
                    foreach (DataGridViewRow row in dgv.Rows) {
                        // Check if any cell contains the search value
                        bool rowVisible = row.Cells.Cast<DataGridViewCell>()
                                                   .Any(cell => cell?.Value != null && cell.Value.ToString().SearchFor(trimValue));

                        if (rowVisible) {
                            // If the row should be visible, add it to the list
                            visibleRows.Add(row);
                        }
                    }
                });

                // Update the row visibility in bulk on the UI thread (only once)
                dgv.Invoke((Action)(() => {
                    foreach (DataGridViewRow row in dgv.Rows) {
                        // Make rows visible only if they match the search criteria
                        row.Visible = visibleRows.Contains(row);
                    }
                }));
            }
            catch (Exception ex) {
                // Handle any exceptions here (optional)
                // CShowMessage.Warning(ex.Message, "Error");
            }
        }

        public static void SearchDGV(this CDatagridview dgv, CTextBox searchValue) {
            try {
                string trimValue = searchValue.Text.Trim(); // Trim the search value

                foreach (DataGridViewRow row in dgv.Rows) {
                    bool rowVisible = false;

                    foreach (DataGridViewCell cell in row.Cells) {
                        if (cell.Value != null && cell.Value.ToString().IndexOf(trimValue, StringComparison.OrdinalIgnoreCase) >= 0) {
                            rowVisible = true; // Show row if any cell matches the search
                            break; // No need to check other cells in this row
                        }
                    }

                    // Suspend binding to CurrencyManager to avoid the error
                    CurrencyManager currencyManager = (CurrencyManager)dgv.BindingContext[dgv.DataSource];
                    currencyManager.SuspendBinding();

                    row.Visible = rowVisible;

                    // Resume binding to CurrencyManager
                    currencyManager.ResumeBinding();
                }
            }
            catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }
        public static void FormatBooleanColumn(this CDatagridview dgv, int columnIndex, string trueText = "Yes", string falseText = "No") {
            // Subscribe to the CellFormatting event
            dgv.CellFormatting += (sender, e) => {
                // Check if the current column is the one specified by the index
                if (e.ColumnIndex == columnIndex) {
                    if (e.Value is bool value) {
                        // Set the cell value to "Yes" or "No"
                        e.Value = value ? trueText : falseText;
                        e.FormattingApplied = true;
                    }
                }
            };
        }
        public static void FormatImageColumn(this DataGridView dgv, int columnIndex, int imageWidth = 50, int imageHeight = 50) {
            // Set the column type to DataGridViewImageColumn
            if (dgv.Columns[columnIndex] is DataGridViewImageColumn) {
                // Set the ImageLayout to Zoom to ensure images are resized properly in cells
                ((DataGridViewImageColumn)dgv.Columns[columnIndex]).ImageLayout = DataGridViewImageCellLayout.Zoom;

                // Subscribe to the CellFormatting event to resize the image
                dgv.CellFormatting += (sender, e) => {
                    // Check if the current column is the one specified by the index and if the value is an image
                    if (e.ColumnIndex == columnIndex && e.Value is Image img) {
                        // Resize the image to the specified width and height
                        var resizedImage = new Bitmap(img, new Size(imageWidth, imageHeight));

                        // Set the resized image as the cell's value
                        e.Value = resizedImage;
                        e.FormattingApplied = true;
                    }
                };

                // Explicitly set the row height for each row, including the first
                // Adjust the height to fit the image with some padding
                foreach (DataGridViewRow row in dgv.Rows) {
                    row.Height = imageHeight + 5; // Set the height for each row
                }
                dgv.RowTemplate.Height = imageHeight + 5;
            }
            else {
                throw new ArgumentException("The specified column is not an image column.");
            }
        }
        public static void HideColumns(this DataGridView dgv, bool hide = true, params int[] columnIndices) {
            if (dgv == null) throw new ArgumentNullException(nameof(dgv));

            foreach (var columnIndex in columnIndices) {
                // Ensure the column index is within the valid range
                if (columnIndex >= 0 && columnIndex < dgv.Columns.Count) {
                    dgv.Columns[columnIndex].Visible = !hide;
                }
            }
        }
        public static void SetColumnEditable(this CDatagridview dgv, int columnIndex, bool editable = true) {
            if (dgv.Columns[columnIndex] is DataGridViewTextBoxColumn column) {
                // Set the column read-only property
                dgv.ReadOnly = !editable;
                dgv.Columns[columnIndex].ReadOnly = !editable;

                // Apply style to each cell in the column
                foreach (DataGridViewRow row in dgv.Rows) {
                    if (!row.IsNewRow) // Skip the new row placeholder if present
                    {
                        var cell = row.Cells[columnIndex];
                        cell.Style.BackColor = editable ? Color.LightGreen : Color.Black;
                        cell.Style.ForeColor = Color.Black;
                        cell.Style.SelectionBackColor = editable ? Color.LightGreen : Color.Black; // Selection color
                        cell.Style.SelectionForeColor = Color.Black;
                    }
                }

                // Optionally, redraw the DataGridView
                dgv.Invalidate();
            }
            else if (dgv.Columns[columnIndex] is DataGridViewCheckBoxColumn columnCheckBox) {
                // Set the column read-only property
                dgv.ReadOnly = !editable;
                dgv.Columns[columnIndex].ReadOnly = !editable;

                // Optionally, redraw the DataGridView
                dgv.Invalidate();
            }
        }

        public static void TrackChangesAndCallMethod(this CDatagridview dgv, int columnIndex, Action onColumnValueChanged) {
            if (dgv == null) throw new ArgumentNullException(nameof(dgv));
            if (onColumnValueChanged == null) throw new ArgumentNullException(nameof(onColumnValueChanged));
            if (columnIndex < 0 || columnIndex >= dgv.Columns.Count)
                throw new ArgumentOutOfRangeException(nameof(columnIndex), "Invalid column index.");

            dgv.CellValueChanged += (sender, e) => {
                // Trigger only if the changed cell belongs to the specified column index
                if (e.ColumnIndex == columnIndex) {
                    onColumnValueChanged();
                }
            };
        }
        public static void ApplyCustomAttribute(this CDatagridview dgv, Type typeOfDTO) {
            // Loop through the properties of the DTO
            foreach (var property in typeOfDTO.GetProperties()) {

                // Find all columns matching the DataPropertyName
                var matchingColumns = dgv.Columns.Cast<DataGridViewColumn>()
                                                 .Where(c => c.DataPropertyName == property.Name)
                                                 .ToList();

                // If duplicates exist, remove all but the first column
                if (matchingColumns.Count > 1) {
                    for (int i = 1; i < matchingColumns.Count; i++) {
                        dgv.Columns.Remove(matchingColumns[i]);
                    }
                }

                // Get the custom attribute, if applied
                var attribute = property.GetCustomAttribute<CDGVAttr>();

                if (attribute != null) {
                    // Get the first column (if any) to apply the attribute changes
                    var column = matchingColumns.FirstOrDefault();
                    if (column != null) {
                        // Remove the column if IsExcluded is true
                        if (attribute.IsExcluded) {
                            dgv.Columns.Remove(column);
                        }
                        else {
                            // Set visibility based on IsVisible
                            column.Visible = attribute.IsVisible;
                        }
                    }
                }
            }

        }


    }
}

