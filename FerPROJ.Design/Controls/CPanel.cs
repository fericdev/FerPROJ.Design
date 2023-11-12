
using System.Drawing;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms
{
    public class CPanel : Panel
    {
        private Color shadowColor = Color.DarkGray;
        private int shadowThickness = 20;
        private int shadowSize = 10;
        private bool showTopShadow = true;
        private bool showBottomShadow = true;
        private bool showLeftShadow = true;
        private bool showRightShadow = true;
        private Color backColor;

        private Bitmap buffer; // Double buffering buffer

        public Color PanelBackColor
        {
            get { return backColor; }
            set { backColor = value; BackColor = backColor; }
        }

        public Color ShadowColor
        {
            get { return shadowColor; }
            set { shadowColor = value; Invalidate(); }
        }

        public int ShadowThickness
        {
            get { return shadowThickness; }
            set { shadowThickness = value; Invalidate(); }
        }

        public int ShadowSize
        {
            get { return shadowSize; }
            set { shadowSize = value; Invalidate(); }
        }

        public bool ShowTopShadow
        {
            get { return showTopShadow; }
            set { showTopShadow = value; Invalidate(); }
        }

        public bool ShowBottomShadow
        {
            get { return showBottomShadow; }
            set { showBottomShadow = value; Invalidate(); }
        }

        public bool ShowLeftShadow
        {
            get { return showLeftShadow; }
            set { showLeftShadow = value; Invalidate(); }
        }

        public bool ShowRightShadow
        {
            get { return showRightShadow; }
            set { showRightShadow = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (buffer == null || buffer.Size != ClientSize)
            {
                if (buffer != null)
                {
                    buffer.Dispose();
                }
                buffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            }

            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.Clear(BackColor);
                DrawShadow(g);
            }

            e.Graphics.DrawImageUnscaled(buffer, Point.Empty);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                buffer?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawShadow(Graphics g)
        {
            if (showLeftShadow)
            {
                for (int i = 1; i <= shadowSize; i++)
                {
                    int offset = shadowThickness + i - 1;
                    using (Pen pen = new Pen(Color.FromArgb(30, shadowColor), shadowThickness))
                    {
                        g.DrawRectangle(pen, new Rectangle(
                            ClientRectangle.Left - offset, ClientRectangle.Top,
                            shadowThickness, Height));
                    }
                }
            }

            if (showRightShadow)
            {
                for (int i = 1; i <= shadowSize; i++)
                {
                    int offset = shadowThickness + i - 1;
                    using (Pen pen = new Pen(Color.FromArgb(30, shadowColor), shadowThickness))
                    {
                        g.DrawRectangle(pen, new Rectangle(
                            ClientRectangle.Right - 1 + offset - shadowThickness, ClientRectangle.Top,
                            shadowThickness, Height));
                    }
                }
            }

            if (showBottomShadow)
            {
                for (int i = 1; i <= shadowSize; i++)
                {
                    int offset = shadowThickness + i - 1;
                    using (Pen pen = new Pen(Color.FromArgb(30, shadowColor), shadowThickness))
                    {
                        g.DrawRectangle(pen, new Rectangle(
                            ClientRectangle.Left, ClientRectangle.Bottom - 1 + offset - shadowThickness,
                            Width, shadowThickness));
                    }
                }
            }

            if (showTopShadow)
            {
                for (int i = 1; i <= shadowSize; i++)
                {
                    int offset = shadowThickness + i - 1;
                    using (Pen pen = new Pen(Color.FromArgb(30, shadowColor), shadowThickness))
                    {
                        g.DrawRectangle(pen, new Rectangle(
                            ClientRectangle.Left, ClientRectangle.Top - offset,
                            Width, shadowThickness));
                    }
                }
            }
        }
    }
}
