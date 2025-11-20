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
        private readonly byte[] _picture;
        private byte[] _tempPicture;
        public byte[] NewPicture { get; set; }
        public FrmPicture(byte[] picture) {
            InitializeComponent();
            _picture = picture;
        }
        //
        protected override Task LoadComponentsAsync() {
            switch (CurrentFormMode) {
                case FormMode.Add:
                    break;
                case FormMode.Update:
                    pictureBoxImage.BackgroundImage = _picture.ToImage();
                    NewPicture = _picture;
                    break;
            }
            return Task.CompletedTask;
        }
        protected override async Task<bool> OnSaveNewDataAsync() {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    string imagePath = ofd.FileName;
                    _tempPicture = File.ReadAllBytes(imagePath);
                    pictureBoxImage.BackgroundImage = _tempPicture.ToImage();
                }
            }
            return await Task.FromResult(false);
        }
        protected override async Task<bool> OnSaveDataAsync() {
            return await Task.FromResult(true);
        }
        protected override async Task<bool> OnUpdateDataAsync() {
            NewPicture = _tempPicture != null ? _tempPicture : _picture;
            return await Task.FromResult(true);
        }
    }
}
