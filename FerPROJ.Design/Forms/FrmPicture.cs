using FerPROJ.DBHelper.DBCrud;
using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FerPROJ.Design.Class.CBaseEnums;

namespace FerPROJ.Design.Forms {
    public partial class FrmPicture : FrmManageKrypton {
        private byte[] _tempPicture;
        public PictureModel model { get; set; }
        public FrmPicture() {
            InitializeComponent();
        }
        //
        protected override Task LoadComponentsAsync() {
            switch (CurrentFormMode) {
                case FormMode.Add:
                    break;
                case FormMode.Update:
                    pictureBoxImage.BackgroundImage = model.PictureImage;
                    break;
            }
            return Task.CompletedTask;
        }
        protected override async Task<(bool Result, bool CloseForm)> OnSaveNewDataAsync() {
            if (CDialogManager.Ask("Open Camera?")) {
                FrmSplasherLoading.CloseSplash();
                await CFormLayer.ManageAsync<FrmCamera>(parameters: c => c.model = model);
            }
            else {
                using (OpenFileDialog ofd = new OpenFileDialog()) {
                    if (ofd.ShowDialog() == DialogResult.OK) {
                        string imagePath = ofd.FileName;
                        _tempPicture = File.ReadAllBytes(imagePath);
                        model.Picture = _tempPicture;
                        pictureBoxImage.BackgroundImage = _tempPicture.ToImage();
                    }
                }
            }
            return (await Task.FromResult(false), false);
        }
        protected override async Task<bool> OnSaveDataAsync() {
            return await Task.FromResult(true);
        }
        protected override async Task<bool> OnUpdateDataAsync() {
            return await CRepositoryManager.ExecuteApiMethodAsync<bool>(model.RepositoryType, "SavePictureAsync", model.Id, model.Picture, "Picture");
        }
    }
}
