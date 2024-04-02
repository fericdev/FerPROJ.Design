
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms
{
    public partial class FrmConf : Form
    {

        private string configFilePath = "connString.txt";
        private string configFilePathEntity = "entityConnString.txt";
        private string connSettings;
        Dictionary<string, string> settings = new Dictionary<string, string>();

        public string DatabaseName;
        public string Port;
        public string Username;
        public string Password;
        public string Hostname;

        public FrmConf()
        {
            InitializeComponent();
        }

        private void saveConfigCustomButton_Click(object sender, EventArgs e)
        {
            if (CShowMessage.Ask("Save?", "Confirmation"))
            {
                string sslMode = cbSSL.Checked ? "SslMode=None;" : "SslMode=Preferred;";
                this.connSettings = $"Server={hostnameCustomTextBox.Text};Port={portCustomTextBox.Text};Database={databaseNameCustomTextBox.Text};Uid={usernameCustomTextBox.Text};Pwd={passwordCustomTextBox.Text};{sslMode}";
                CSet.SetEntityConnectionString(hostnameCustomTextBox.Text, usernameCustomTextBox.Text, passwordCustomTextBox.Text, portCustomTextBox.Text, databaseNameCustomTextBox.Text, sslMode);
                UpdateConfigurationFile();
                this.Close();
            }
        }

        private void FrmConnectionSettings_Load(object sender, EventArgs e)
        {
            
            if (File.Exists(configFilePath))
            {
                string configFileContent = File.ReadAllText(configFilePath);
                string decryptedText = CEnryption.Decrypt(configFileContent);
                foreach (var setting in decryptedText.Split(';'))
                {
                    var keyValue = setting.Split('=');
                    if (keyValue.Length == 2)
                    {
                        settings[keyValue[0]] = keyValue[1];
                    }
                }
                //
                databaseNameCustomTextBox.Text = settings["Database"];
                portCustomTextBox.Text = settings["Port"];
                usernameCustomTextBox.Text = settings["Uid"];
                passwordCustomTextBox.Text = settings["Pwd"];
                hostnameCustomTextBox.Text = settings["Server"];
                cbSSL.Checked = settings["SslMode"] == "None";
                //
            }
            else
            {
                databaseNameCustomTextBox.Text = "";
                portCustomTextBox.Text = "";
                usernameCustomTextBox.Text = "";
                passwordCustomTextBox.Text = "";
                hostnameCustomTextBox.Text = "";
                cbSSL.Checked = false;
            }
        }
        private void UpdateConfigurationFile()
        {
            string encryptedText = CEnryption.Encrypt(connSettings);
            string encryptedEntityText = CEnryption.Encrypt(CStaticVariable.entityConnString);
            File.WriteAllText(configFilePath, encryptedText);
            File.WriteAllText(configFilePathEntity, encryptedEntityText);
            CShowMessage.Info("Database Configuration Updated Successfully!", "Info");
        }

    }
}
