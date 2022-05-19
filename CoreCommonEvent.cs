namespace Crystal_Editor
{
    public class CoreCommonEvent
    {
        public enum MoveRequest
        {
            Save,
            Load
        }

        public byte[] data_array; //This starts the array.
        private int Start = 0; //Leagth from start of file to the byte where the first row / data starts. The first byte is #0, most hex editors count byte0 so they should be accurate...probably.
        private int Row = 0; //Leagth of a row of data. The first byte is #1 not #0, so if a row starts at column 0 and is 29 long, then input 30.  This is used in every load and save of data to the array.
        private TreeView Tree;
        private Control.ControlCollection Controls;

        public CoreCommonEvent(string fileLocation, int start, int row, TreeView tree, Control.ControlCollection controls)
        {
            data_array = File.ReadAllBytes(fileLocation);
            Start = start;
            Row = row;
            Tree = tree;
            Controls = controls;
        }

        public void MoveData(string textName, int column, MoveRequest requestType)
        {
            switch (requestType)
            {
                case MoveRequest.Save:
                    Byte.TryParse(GetText(textName), out byte value8);
                    TitleForm.ByteWriter(value8, data_array, Start + (Tree.SelectedNode.Index * Row) + column);
                    break;
                case MoveRequest.Load:
                    SetText(textName, this.data_array[Start + (Tree.SelectedNode.Index * Row) + column].ToString("D"));
                    break;
            }
        }

        public void MoveDataReverse(string textName, int column, MoveRequest requestType, int length)
        {
            switch (requestType)
            {
                case MoveRequest.Save:
                    Byte.TryParse(GetText(textName), out byte value8);
                    TitleForm.ByteWriter(value8, data_array, Start + (Tree.SelectedNode.Index * Row) + column);
                    Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + column, length);
                    break;
                case MoveRequest.Load:
                    Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + column, length);
                    SetText(textName, this.data_array[Start + (Tree.SelectedNode.Index * Row) + column].ToString("D"));
                    Array.Reverse(data_array, Start + (Tree.SelectedNode.Index * Row) + column, length);
                    break;
            }
        }

        //The following must be here, it was made by some guy on stackoverflow,  then modififed by starkelp in twitch chat :)
        //It takes things named TitleForm[X] where X is a variable with a string, and lets you use the string as a textboxes name with .text at the end.
        //This lets you use a variable in place of a textbox.text property, so you can refer to them indirectly.
        public string GetText(string name, string? defaultText = null) //this Form form, string name, string defaultText = null
        {
            return Controls.ContainsKey(name) ?
                Controls[name].Text :
                (defaultText ?? string.Empty);
        }

        public void SetText(string name, string text) //this Form form, string name, string text
        {
            if (Controls.ContainsKey(name))
            {
                var control2 = Controls[name];
                control2.Text = text;
            }
        }
    }
}
