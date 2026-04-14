using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public class CToolstrip : ToolStrip{
        public ToolStripButton AddButton { get; set; }
        public string AddButtonText { get; set; } = "Add";
        public ToolStripButton EditButton { get; set; }
        public string EditButtonText { get; set; } = "Edit";
        public ToolStripButton DeleteButton { get; set; }
        public string DeleteButtonText { get; set; } = "Delete";
        public ToolStripButton RefreshButton { get; set; }
        public string RefreshButtonText { get; set; } = "Refresh";
        // Separator
        public ToolStripSeparator sAdd { get; set; } = new ToolStripSeparator();
        public ToolStripSeparator sEdit { get; set; } = new ToolStripSeparator();
        public ToolStripSeparator sDelete { get; set; } = new ToolStripSeparator();

        // Add event for the button click
        public event EventHandler AddButtonClick;
        public event EventHandler EditButtonClick;
        public event EventHandler DeleteButtonClick;
        public event EventHandler RefreshButtonClick;

        public CToolstrip() {
            GripStyle = ToolStripGripStyle.Hidden;
            BackColor = Color.WhiteSmoke;
            Height = 25;
            AutoSize = false;
            GripMargin = new Padding(2, 2, 2, 2);
            // Set the custom renderer
            Renderer = new CustomToolStripRenderer();
        }

        public void InitializeButtons() {
            // Add Button
            AddButton = new ToolStripButton("Add", Properties.Resources.AddIcon); // Replace Properties.Resources.AddIcon with your own image
            AddButton.ToolTipText = AddButtonText;
            AddButton.Text = AddButtonText;
            AddButton.Name = "tsbAdd";
            AddButton.Click += (sender, e) => OnAddButtonClick();

            // Edit Button
            EditButton = new ToolStripButton("Edit", Properties.Resources.EditIcon); // Replace Properties.Resources.EditIcon with your own image
            EditButton.ToolTipText = EditButtonText;
            EditButton.Text = EditButtonText;
            EditButton.Name = "tsbEdit";
            EditButton.Click += (sender, e) => OnEditButtonClick();

            // Delete Button
            DeleteButton = new ToolStripButton("Delete", Properties.Resources.CloseIcon); // Replace Properties.Resources.DeleteIcon with your own image
            DeleteButton.ToolTipText = DeleteButtonText;
            DeleteButton.Text = DeleteButtonText;
            DeleteButton.Name = "tsbDelete";
            DeleteButton.Click += (sender, e) => OnDeleteButtonClick();

            // refresh Button
            RefreshButton = new ToolStripButton("Refresh", Properties.Resources.RefreshIcon); // Replace Properties.Resources.DeleteIcon with your own image
            RefreshButton.ToolTipText = RefreshButtonText;
            RefreshButton.Text = RefreshButtonText;
            RefreshButton.Name = "tsbRefresh";
            RefreshButton.Click += (sender, e) => OnRefreshButtonClick();

            // Set display style to show only images
            AddButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            EditButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            DeleteButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            RefreshButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

            // Set Alignment
            RefreshButton.Alignment = ToolStripItemAlignment.Right;

            // Add buttons to the ToolStrip
            Items.Add(sAdd);
            Items.Add(AddButton);
            Items.Add(sEdit);
            Items.Add(EditButton);
            Items.Add(sDelete);
            Items.Add(DeleteButton);
            Items.Add(RefreshButton);
        }

        private void OnAddButtonClick() {
            // Raise the AddButtonClick event with the identifier
            AddButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void OnEditButtonClick() {
            // Raise the AddButtonClick event with the identifier
            EditButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void OnDeleteButtonClick() {
            // Raise the AddButtonClick event with the identifier
            DeleteButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void OnRefreshButtonClick() {
            // Raise the AddButtonClick event with the identifier
            RefreshButtonClick?.Invoke(this, EventArgs.Empty);
        }
        public class CustomToolStripRenderer : ToolStripProfessionalRenderer {
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
                // Custom border color
                using (var pen = new Pen(Color.WhiteSmoke, 1)) // Set your desired border color and width here
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(Point.Empty, e.ToolStrip.Size - new Size(1, 1)));
                }
            }
        }
    }
}
