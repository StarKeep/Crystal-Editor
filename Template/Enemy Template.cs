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
using System.Diagnostics;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Crystal_Editor
{

    

    public partial class EnemyTemplateForm : Form
    {
        private CoreCommonEvent events = new CoreCommonEvent(start: 37,row: 38);
        //int RevNum = 0; //Used in Array Reverse to simplify looking at it and reduce input mistakes.



        
        public EnemyTemplateForm()
        {
            InitializeComponent();
            string FileLocation = Properties.Settings.Default.SpotTemplateFolder + "\\Template Editor\\EnemyTemplate"; //Sets a string called File Location to the location of where the game file were gonna mod / edit is.  Used to be Data_Location
            int Data_Length = (int)(new FileInfo(FileLocation).Length);   //Sets the entire file as the leagth of the array.   Used to be EnemyData_Leagth
            events.data_array = File.ReadAllBytes(FileLocation);  //loads an array with whatever is in the path
            

            Tree.Nodes.Add("Goblin");
            Tree.Nodes.Add("Slime");
            Tree.Nodes.Add("Enemy Mage M");
            Tree.Nodes.Add("Enemy Mage F");
            Tree.Nodes.Add("Berserker");
            Tree.Nodes.Add("King Slime");
            Tree.Nodes.Add("King Slime Baby");
            Tree.Nodes.Add("Mimic");
            Tree.Nodes.Add("Reimu & Marisa (Duo-Battle)");
            Tree.Nodes.Add("Ezreal");
            Tree.Nodes.Add("Blue Eyes White Dragon");
            Tree.Nodes.Add("Dark Magician");
            Tree.Nodes.Add("Werewolf");
            Tree.Nodes.Add("Attack Helicopter");
            Tree.Nodes.Add("Ultimate God of Destruction");
            Tree.Nodes.Add("Ultimate God of Destruction (Post-game)");

            TreeNodeCollection nodeCollect = Tree.Nodes;
            Tree.SelectedNode = nodeCollect[0];
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            events.SaveLoad = "Load";
            Editor();
        }
        private void Button6_Click(object sender, EventArgs e) //Load Button
        {
            events.SaveLoad = "Load";
            Editor();
        }
        private void Button5_Click(object sender, EventArgs e) //Save Button
        {
            events.SaveLoad = "Save";
            Editor();
        }
               


        public void Editor()
        {
            //Numbers start from Left and read to right Right (normal?) Endianese.
            //Final number is the column the data is from / how many bytes into a row the data is from. The first byte is byte 1 not byte 0.

            events.TextName = "richTextBoxID"; events.Column = 1; events.MoveData(Tree, Controls); //1 Byte
            events.TextName = "richTextBoxStr"; events.Column = 17; events.MoveData(Tree, Controls); //4 Byte
            events.TextName = "richTextBoxMag"; events.Column = 21; events.MoveData(Tree, Controls); //4 Byte
            events.TextName = "richTextBoxDef"; events.Column = 25; events.MoveData(Tree, Controls); //2 Byte
            events.TextName = "richTextBoxRes"; events.Column = 27; events.MoveData(Tree, Controls); //2 Byte
            events.TextName = "richTextBoxTP"; events.Column = 15; events.MoveData(Tree, Controls); //1 Byte

            events.TextName = "richTextBoxRev4"; events.Column = 2; events.MoveDataReverse4(Tree, Controls); //4R Byte
            events.TextName = "richTextBoxRev2"; events.Column = 10; events.MoveDataReverse2(Tree, Controls); //2R Byte

        }


        


        /*

        public void EditorReverse()
        {
            //Reverese Right to Left Endianese.
            //Semi-Final number is the column the data is from / how many bytes into a row the data is from. The first byte is byte 1 not byte 0.   The final number for array reverses is how many bytes to reverse.
            //4 Byte Reverse
            if (SaveLoad == "Load") {
                Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + 2, 4);
                richTextBoxRev4.Text = BitConverter.ToUInt32(data_array, Start + (Tree.SelectedNode.Index * Row) + 2).ToString("D"); }  
                Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + 2, 4);
            if (SaveLoad == "Save") { UInt32.TryParse(richTextBoxRev4.Text, out uint value32); { TitleForm.ByteWriter(value32, data_array, Start + (Tree.SelectedNode.Index * Row) + 2);
                Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + 2, 4); } }

            //2 Byte Reverse
            if (SaveLoad == "Load") {
                Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + 10, 2);
                richTextBoxRev2.Text = BitConverter.ToUInt16(data_array, Start + (Tree.SelectedNode.Index * Row) + 10).ToString("D"); }  // Read 4 Byte       //NameOfArray  //IgnoreFirstXBytes   //RowLeagth  //ByteInRow
                Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + 10, 2);
            if (SaveLoad == "Save") { UInt32.TryParse(richTextBoxRev2.Text, out uint value16); { TitleForm.ByteWriter(value16, data_array, Start + (Tree.SelectedNode.Index * Row) + 10);
                Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + 10, 2); } } 
        }

        */


        private void Tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        
        

        private void EnemyTemplateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
