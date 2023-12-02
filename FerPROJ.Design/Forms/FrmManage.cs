using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms
{
    public partial class FrmManage : Form
    {
        public bool CurrentFormResult { get; set; }
        public string Manage_IdTrack { get; set; }
        private FormMode _currentFormMode = FormMode.Add;
        public event EventHandler FormModeChanged;
        private bool hideFunction;
        private bool hideHeader;
        private bool hideFooter;
        private string onSaveNewName = "Save and New";
        private string onSaveName = "Save";
        private string onUpdateName = "Update";
        private string onCloseName = "Cancel";
        private string titleText = "Management Hub";
        private string descText = "Centralized control and insights for efficient operations.";
        private Image formIcon = null;
        public Dictionary<Keys, Action> keyboardShortcuts = new Dictionary<Keys, Action>();
        public Dictionary<Keys, Func<bool>> boolKeyboardShortcuts = new Dictionary<Keys, Func<bool>>();

        public enum FormMode
        {
            Add,
            Update,
            ReadOnly
        }
        public FormMode CurrentFormMode
        {
            get { return _currentFormMode; }
            set
            {
                _currentFormMode = value;
                OnFormModeChanged();
            }
        }
        protected virtual void OnFormModeChanged()
        {
            FormModeChanged?.Invoke(this, EventArgs.Empty);
        }

        public FrmManage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            CurrentFormMode = FormMode.Add; // Default to ReadOnly mode
            FormModeChanged += FrmManageMain_FormModeChanged;
            this.KeyPreview = true;
            this.KeyDown += OnKeyDown;
            ConstantShortcuts();
            InitializeKeyboardShortcuts();

        }
        private void ConstantShortcuts()
        {
            boolKeyboardShortcuts[Keys.Enter] = OnSaveData;
            keyboardShortcuts[Keys.Escape] = CloseForm;
        }

        protected virtual void InitializeKeyboardShortcuts()
        {

        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (keyboardShortcuts.ContainsKey(e.KeyCode))
            {
                keyboardShortcuts[e.KeyCode]?.Invoke();
            }
            else if (boolKeyboardShortcuts.ContainsKey(e.KeyCode))
            {
                if (boolKeyboardShortcuts[e.KeyCode]())
                {
                    CurrentFormResult = true;
                    this.Close();
                }
            }
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                if (OnSaveNewData())
                {
                    CurrentFormResult = true;
                }
            }
        }
        private void FrmManageMain_FormModeChanged(object sender, EventArgs e)
        {
            // Update button visibility based on the new CurrentFormMode
            if (CurrentFormMode == FormMode.Add)
            {
                baseButtonSave.Visible = true;
                baseButtonUpdate.Visible = false;
                LoadComponents();
            }
            else if (CurrentFormMode == FormMode.Update)
            {
                baseButtonSave.Visible = false;
                baseButtonUpdate.Visible = true;
                baseButtonAddNew.Visible = false;
                LoadComponents();
            }
            else
            {
                baseButtonSave.Visible = false;
                baseButtonUpdate.Visible = false;
                baseButtonAddNew.Visible = false;
                LoadComponents();
            }
        }
        private void CloseForm()
        {
            if(CShowMessage.Ask("Are you sure to close?", "Confirmation"))
            {
                this.Close();
            }
        }
        private void baseButtonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void btnSaveMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnSaveData())
                {
                    CurrentFormResult = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CShowMessage.Warning(ex.Message, "Error");

            }

        }
        private void btnUpdateMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnUpdateData())
                {
                    CurrentFormResult = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CShowMessage.Warning(ex.Message, "Error");

            }
        }
        protected virtual bool OnSaveData()
        {
            return CurrentFormResult;
        }
        protected virtual bool OnUpdateData()
        {
            return CurrentFormResult;
        }
        protected virtual bool OnSaveNewData()
        {
            return OnSaveData();
        }
        protected virtual void LoadComponents()
        {


        }

        private void baseButtonAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnSaveNewData())
                {
                    CurrentFormResult = true;
                    ClearAllTextBoxes(this);
                }
            }
            catch (Exception ex)
            {
                CShowMessage.Warning(ex.Message, "Error");

            }
        }
        private void ClearAllTextBoxes(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is CTextBox textBox)
                {
                    textBox.TextProperty = null;
                }
                else if (childControl.HasChildren)
                {
                    ClearAllTextBoxes(childControl);
                }
            }
        }
        public bool HideSaveNew
        {
            get { return hideFunction; }
            set
            {
                hideFunction = value;
                HideSaveNewFunction();
            }
        }
        public string OnSaveName
        {
            get
            {
                return onSaveName;
            }
            set
            {
                onSaveName = value;
                baseButtonSave.Text = onSaveName;
            }
        }
        public string OnUpdateName
        {
            get
            {
                return onUpdateName;
            }
            set
            {
                onUpdateName = value;
                baseButtonUpdate.Text = onUpdateName;
            }
        }
        public string OnSaveNewName
        {
            get
            {
                return onSaveNewName;
            }
            set
            {
                onSaveNewName = value;
                baseButtonAddNew.Text = onSaveNewName;
            }
        }
        public string OnCloseName
        {
            get
            {
                return onCloseName;
            }
            set
            {
                onCloseName = value;
                baseButtonCancel.Text = onCloseName;
            }
        }
        public bool HideHeader
        {
            get
            {
                return hideHeader;
            }
            set
            {
                hideHeader = value;
                panelMain1.Visible = !hideHeader;
            }
        }
        public bool HideFooter
        {
            get
            {
                return hideFooter;
            }
            set
            {
                hideFooter = value;
                basePnl1.Visible = !hideFooter;
            }
        }
        private void HideSaveNewFunction()
        {
            baseButtonAddNew.Visible = !hideFunction;
        }
        public string FormTitle
        {
            get { return titleText; }
            set
            {
                titleText = value;
                customLabelDescMain1.Text = titleText;
            }
        }
        public string FormDescription
        {
            get { return descText; }
            set
            {
                descText = value;
                customLabelDescMain2.Text = descText;
            }
        }
        public Image FormIcon
        {
            get { return formIcon; }
            set
            {
                formIcon = value;
                pictureBoxMain1.BackgroundImage = formIcon;
                pictureBoxMain1.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
    }
}
