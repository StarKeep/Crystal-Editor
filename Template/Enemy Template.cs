namespace Crystal_Editor
{
    public partial class EnemyTemplateForm : Form
    {
        private CoreCommonEvent events;
        //int RevNum = 0; //Used in Array Reverse to simplify looking at it and reduce input mistakes.

        public EnemyTemplateForm()
        {
            InitializeComponent();
            events = new CoreCommonEvent(fileLocation: Properties.Settings.Default.SpotTemplateFolder + "\\Template Editor\\EnemyTemplate", start: 37, row: 38);

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
            Editor(CoreCommonEvent.MoveRequest.Load);
        }
        private void Button6_Click(object sender, EventArgs e) //Load Button
        {
            Editor(CoreCommonEvent.MoveRequest.Load);
        }
        private void Button5_Click(object sender, EventArgs e) //Save Button
        {
            Editor(CoreCommonEvent.MoveRequest.Save);
        }



        public void Editor(CoreCommonEvent.MoveRequest requestType)
        {
            //Numbers start from Left and read to right Right (normal?) Endianese.
            //Final number is the column the data is from / how many bytes into a row the data is from. The first byte is byte 1 not byte 0.

            events.MoveData(Tree, Controls, textName: "richTextBoxID", column: 1, requestType); //1 Byte
            events.MoveData(Tree, Controls, textName: "richTextBoxStr", column: 17, requestType); //4 Byte
            events.MoveData(Tree, Controls, textName: "richTextBoxMag", column: 21, requestType); //4 Byte
            events.MoveData(Tree, Controls, textName: "richTextBoxDef", column: 25, requestType); //2 Byte
            events.MoveData(Tree, Controls, textName: "richTextBoxRes", column: 27, requestType); //2 Byte
            events.MoveData(Tree, Controls, textName: "richTextBoxTP", column: 15, requestType); //1 Byte

            events.MoveDataReverse(Tree, Controls, textName: "richTextBoxRev4", column: 2, requestType, length: 4); //4R Byte
            events.MoveDataReverse(Tree, Controls, textName: "richTextBoxRev2", column: 10, requestType, length: 2); //2R Byte

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
