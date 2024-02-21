using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls
{
    public class CDatagridview : DataGridView
    {
        private static Color headerColor = Color.WhiteSmoke; // Store the header color



        public CDatagridview()
        {
            InitializeDGV();
            CellPainting += CustomDataGridView_CellPainting;
        }
        public Color HeaderColor
        {
            get { return headerColor; }
            set
            {
                headerColor = value;
                UpdateHeaderColor();
            }
        }

        private void UpdateHeaderColor()
        {
            DataGridViewCellStyle headerStyle = ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = headerColor;
        }
        public Font CustomHeaderFontStyle
        {
            get { return ColumnHeadersDefaultCellStyle.Font; }
            set
            {
                ColumnHeadersDefaultCellStyle.Font = value;
                DefaultCellStyle.Font = value;
            }
        }
        public Color CustomHeaderForeColor
        {
            get { return ColumnHeadersDefaultCellStyle.ForeColor; }
            set
            {
                ColumnHeadersDefaultCellStyle.ForeColor = value;
                DefaultCellStyle.ForeColor = value;
            }
        }
        public Font CustomRowFontStyle
        {
            get { return RowsDefaultCellStyle.Font; }
            set
            {
                RowsDefaultCellStyle.Font = value;
                DefaultCellStyle.Font = value;
            }
        }
        public Color SelectionColor
        {
            get { return RowsDefaultCellStyle.SelectionBackColor; }
            set { RowsDefaultCellStyle.SelectionBackColor = value;
                ColumnHeadersDefaultCellStyle.SelectionBackColor = HeaderColor;
            }
        }
        public Color AlternatingRowColor
        {
            get { return AlternatingRowsDefaultCellStyle.BackColor; }
            set { AlternatingRowsDefaultCellStyle.BackColor = value; }
        }
        private void CustomDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                              e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top,
                          e.CellBounds.Right - 1, e.CellBounds.Top);
                }

                e.Handled = true;
            }
        }
        private void InitializeDGV()
        {
            // Set the background color and border style
            BackgroundColor = Color.FromArgb(240, 240, 240);
            BorderStyle = BorderStyle.None;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 128, 255);
            RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Set the column header style
            DataGridViewCellStyle headerStyle = ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = headerColor;
            headerStyle.ForeColor = Color.Black;
            headerStyle.Font = new Font("Poppins", 10, FontStyle.Regular);
            headerStyle.Padding = new Padding(0, 0, 0, 0);

            AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
   

            foreach (DataGridViewColumn column in Columns)
            {
                int maxWidth = TextRenderer.MeasureText(column.HeaderText, Font).Width;

                foreach (DataGridViewRow row in Rows)
                {
                    if (row.Cells[column.Index].Value != null)
                    {
                        int cellWidth = TextRenderer.MeasureText(row.Cells[column.Index].Value.ToString(), Font).Width;
                        maxWidth = Math.Max(maxWidth, cellWidth);
                    }
                }

                column.Width = maxWidth + 100; // Adding some padding to avoid truncation
            }

            // Set the row style
            DataGridViewCellStyle rowStyle = RowsDefaultCellStyle;
            rowStyle.BackColor = Color.WhiteSmoke;
            rowStyle.ForeColor = Color.Black;
            rowStyle.Font = new Font("Poppins", 8, FontStyle.Regular);
            rowStyle.WrapMode = DataGridViewTriState.False;

            // Set the alternating row style
            AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            ReadOnly = true;

            // Enable visual styles for better rendering
            EnableHeadersVisualStyles = false;
            AllowUserToResizeColumns = true;
            AllowUserToResizeRows = false;
            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = true;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            AutoResizeRows();

            // Handle the CellFormatting event to apply custom row color
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

    }
}
