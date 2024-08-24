using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public class CToolstrip : ToolStrip{
        public ToolStripButton AddButton { get; private set; }
        public ToolStripButton EditButton { get; private set; }
        public ToolStripButton DeleteButton { get; private set; }
        public ToolStripButton RefreshButton { get; private set; }

        // Add event for the button click
        public event EventHandler AddButtonClick;
        public event EventHandler EditButtonClick;
        public event EventHandler DeleteButtonClick;
        public event EventHandler RefreshButtonClick;

        public CToolstrip() {
            InitializeButtons();
            GripStyle = ToolStripGripStyle.Hidden;
        }

        private void InitializeButtons() {
            // Add Button
            AddButton = new ToolStripButton("Add Item", Properties.Resources.AddIcon); // Replace Properties.Resources.AddIcon with your own image
            AddButton.ToolTipText = "Add";
            AddButton.Name = "tsbAdd";
            AddButton.Click += (sender, e) => OnAddButtonClick();

            // Edit Button
            EditButton = new ToolStripButton("Edit Item", Properties.Resources.EditIcon); // Replace Properties.Resources.EditIcon with your own image
            EditButton.ToolTipText = "Edit";
            EditButton.Name = "tsbEdit";
            EditButton.Click += (sender, e) => OnEditButtonClick();

            // Delete Button
            DeleteButton = new ToolStripButton("Delete Item", Properties.Resources.CloseIcon); // Replace Properties.Resources.DeleteIcon with your own image
            DeleteButton.ToolTipText = "Delete";
            DeleteButton.Name = "tsbDelete";
            DeleteButton.Click += (sender, e) => OnDeleteButtonClick();

            // refresh Button
            RefreshButton = new ToolStripButton("Refresh", Properties.Resources.RefreshIcon); // Replace Properties.Resources.DeleteIcon with your own image
            RefreshButton.ToolTipText = "Refresh";
            RefreshButton.Name = "tsbRefresh";
            RefreshButton.Click += (sender, e) => OnRefreshButtonClick();

            // Set display style to show only images
            AddButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            EditButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            DeleteButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            RefreshButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

            // Set Alignment
            RefreshButton.Alignment = ToolStripItemAlignment.Right;

            // Separator
            ToolStripSeparator s1 = new ToolStripSeparator();
            ToolStripSeparator s2 = new ToolStripSeparator();
            ToolStripSeparator s3 = new ToolStripSeparator();

            // Add buttons to the ToolStrip
            Items.Add(s1);
            Items.Add(AddButton);
            Items.Add(s2);
            Items.Add(EditButton);
            Items.Add(s3);
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
    }
}
