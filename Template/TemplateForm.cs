using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Crystal_Editor
{
    public partial class TemplateForm : Form
    {
        public TemplateForm()
        {
            InitializeComponent();
        }

        
        private void Button1_Click(object sender, EventArgs e) //Set Directory Button
        {
            System.Windows.Forms.MessageBox.Show("Please select the Template Editor folder. \r\n" +
                "Crystal Editor will remember this location in the future. \r\n" +
                "Note: Backup your files before modding them!\r\n" +
                "\r\n" +
                "For the best modding experience on 3DS Games: \r\n" +
                "1 Right click the game in Citra and select Dump RomFS.\r\n" +
                "2 Right click the game in Citra and open mods folder. \r\n" +
                "3 Move the dumped RomFS folder there.\r\n" +
                "4 Select this location as the directory in Crystal Editor. \r\n" +
                "\r\n" +
                "With this, the moment you make a change in Crystal Editor, \r\n" +
                "you can boot/restart the game, and changes will apply instantly.\r\n" +
                "Don't forget to backup your files now and then to avoid mistakes!");
                


            CommonOpenFileDialog d_LoadFolderDialog = new()
            {

                IsFolderPicker = true,
                Title = "Select The TemplateEditor Folder"
            };
            if (d_LoadFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                Properties.Settings.Default.SpotTemplateFolder = Path.GetDirectoryName(d_LoadFolderDialog.FileName);
                Properties.Settings.Default.Save();



            }
        }

        private void Button2_Click(object sender, EventArgs e) //Clear Directory Button
        {
            Properties.Settings.Default.SpotTemplateFolder = "";
            Properties.Settings.Default.Save();
        }

        // ================ Directory Buttons End Here ===================
        //
        // ================ Editor Buttons Start Here ===================

        private void Button3_Click(object sender, EventArgs e) //Enemy Editor Button
        {
            if (File.Exists(Properties.Settings.Default.SpotTemplateFolder + "\\Template Editor\\EnemyTemplate")) //First location is the selected folder. Final thing includes file format like .tbl in the name.
            {
                EnemyTemplateForm f2 = new() { StartPosition = FormStartPosition.Manual, Location = this.Location}; //First part creates new form. //Inside {} first part grabs current window location, //second sets new window at same location.
                f2.Show(); //Show the new window
                this.Close(); //Close the current window
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("The mod directory is not set");
            }
        }
    }
}
