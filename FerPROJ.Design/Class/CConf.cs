
using FerPROJ.Design.Forms;


namespace FerPROJ.Design.Class
{
    public static class CConf
    {
        public static void ConnectToDatabase()
        {
            using (var frm = new FrmConf())
            {
                frm.ShowDialog();
            }
        }
    }
}
