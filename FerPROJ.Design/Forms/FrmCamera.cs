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
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace FerPROJ.Design.Forms {
    public partial class FrmCamera : FrmManageKrypton {

        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private Bitmap _currentFrame;
        public PictureModel model { get; set; } = new PictureModel();

        public FrmCamera() {
            InitializeComponent();
        }
        //
        protected override Task LoadComponentsAsync() {
            switch (CurrentFormMode) {
                case FormMode.Add:
                    break;
                case FormMode.Update:
                    break;
            }
            return Task.CompletedTask;
        }
        protected override async Task InitializeFormPropertiesAsync() {
            OnSaveNewName = "Capture";
            StartCamera();
            await base.InitializeFormPropertiesAsync();
        }
        protected override async Task<(bool Result, bool CloseForm)> OnSaveNewDataAsync() {
            if (_currentFrame == null) {
                CDialogManager.Info("No image preview displayed.");
                return (await Task.FromResult(false), false);
            }

            using (MemoryStream ms = new MemoryStream()) {
                _currentFrame.Save(ms, ImageFormat.Jpeg);
                model.Picture = ms.ToArray();
            }

            return (await Task.FromResult(true), true);
        }
        protected override async Task<bool> OnSaveDataAsync() {
            return await Task.FromResult(true);
        }

        private void StartCamera() {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (_videoDevices.Count == 0) {
                CDialogManager.Warning("No camera detected.");
                return;
            }

            _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _videoSource.NewFrame += VideoSource_NewFrame;
            _videoSource.Start();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            pictureBoxImage.Invoke(new Action(() => {
                pictureBoxImage.Image?.Dispose();
                pictureBoxImage.Image = (Bitmap)frame.Clone();
            }));

            _currentFrame?.Dispose();
            _currentFrame = frame;
        }
    }
}
