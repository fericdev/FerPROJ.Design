
using FerPROJ.Design.Controls;
using Microsoft.Office.Interop.Word;
using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FerPROJ.Design.Class
{
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
            } else {
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
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }
        public static void FormatBooleanColumn(this CDatagridview dgv, int columnIndex, string trueText = "Yes", string falseText = "No") {
            // Subscribe to the CellFormatting event
            dgv.CellFormatting += (sender, e) =>
            {
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

    }


}

