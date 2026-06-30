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
        private bool _closing;
        //
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
            LoadCameras();
            cameraSourceCComboBoxKrypton.TrackIndexChangesAndCallMethod(StartCameraAsync);
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
        private void LoadCameras() {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            cameraSourceCComboBoxKrypton.Items.Clear();

            foreach (FilterInfo camera in _videoDevices) {
                cameraSourceCComboBoxKrypton.Items.Add(camera.Name);
            }

            if (cameraSourceCComboBoxKrypton.Items.Count > 0) {
                cameraSourceCComboBoxKrypton.SelectedIndex = 0;
            }
        }
        private async Task StartCameraAsync() {
            var index = cameraSourceCComboBoxKrypton.SelectedIndex;

            StopCamera();

            if (_videoDevices == null || _videoDevices.Count == 0) {
                return;
            }

            _videoSource = new VideoCaptureDevice(_videoDevices[index].MonikerString);
            _videoSource.NewFrame += VideoSource_NewFrame;
            _videoSource.Start();

            await Task.CompletedTask;
        }
        private void StopCamera() {
            if (_videoSource != null) {
                _videoSource.NewFrame -= VideoSource_NewFrame;

                if (_videoSource.IsRunning) {
                    _videoSource.SignalToStop();
                    _videoSource.WaitForStop();
                }

                _videoSource = null;
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            if (_closing) {
                return;
            }

            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            if (_closing || pictureBoxImage.IsDisposed) {
                frame.Dispose();
                return;
            }

            pictureBoxImage.BeginInvoke(new Action(() =>
            {
                if (_closing || pictureBoxImage.IsDisposed) {
                    frame.Dispose();
                    return;
                }

                pictureBoxImage.Image?.Dispose();
                pictureBoxImage.Image = (Bitmap)frame.Clone();
            }));

            _currentFrame?.Dispose();
            _currentFrame = frame;
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            _closing = true;
            StopCamera();
            base.OnFormClosing(e);
        }
    }
}
