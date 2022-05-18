using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal_Editor
{
    public class CoreCommonEvent
    {
						
		public byte[] data_array; //This starts the array.
		public string SaveLoad = "Empty"; //This just defines this string to be used later. It lets
		public string TextName = "Dummy";
		private int Start = 0; //Leagth from start of file to the byte where the first row / data starts. The first byte is #0, most hex editors count byte0 so they should be accurate...probably.
		private int Row = 0; //Leagth of a row of data. The first byte is #1 not #0, so if a row starts at column 0 and is 29 long, then input 30.  This is used in every load and save of data to the array.
		public int Column = 0;
		public CoreCommonEvent(int start, int row) { Start = start; Row = row; }
		

		public void MoveData(TreeView tree, Control.ControlCollection control)
        {
            if (this.SaveLoad == "Load")
			{
				SetText(control, TextName, this.data_array[Start + (tree.SelectedNode.Index * Row) + Column].ToString("D") );
			}

            if (this.SaveLoad == "Save")
			{ 
				Byte.TryParse(GetText( control, TextName), out byte value8); 
				{ 
					TitleForm.ByteWriter(value8, data_array, Start + (tree.SelectedNode.Index * Row) + Column); 
				} 
			}
        }

		public void MoveDataReverse4(TreeView tree, Control.ControlCollection control)
		{
			if (this.SaveLoad == "Load")
			{
				Array.Reverse(data_array, Start + (tree.SelectedNode.Index * Row) + Column, 4);
				SetText(control, TextName, this.data_array[Start + (tree.SelectedNode.Index * Row) + Column].ToString("D"));
				Array.Reverse(data_array, Start + (tree.SelectedNode.Index * Row) + Column, 4);
			}

			if (this.SaveLoad == "Save")
			{
				Byte.TryParse(GetText(control, TextName), out byte value8);
				{
					TitleForm.ByteWriter(value8, data_array, Start + (tree.SelectedNode.Index * Row) + Column);
					Array.Reverse(data_array, Start + (tree.SelectedNode.Index * Row) + Column, 4);
				}
			}
		}

		public void MoveDataReverse2(TreeView tree, Control.ControlCollection control)
		{
			if (this.SaveLoad == "Load")
			{
				Array.Reverse(data_array, Start + (tree.SelectedNode.Index * Row) + Column, 2);
				SetText(control, TextName, this.data_array[Start + (tree.SelectedNode.Index * Row) + Column].ToString("D"));
				Array.Reverse(data_array, Start + (tree.SelectedNode.Index * Row) + Column, 2);
			}

			if (this.SaveLoad == "Save")
			{
				Byte.TryParse(GetText(control, TextName), out byte value8);
				{
					TitleForm.ByteWriter(value8, data_array, Start + (tree.SelectedNode.Index * Row) + Column);
					Array.Reverse(data_array, Start + (tree.SelectedNode.Index * Row) + Column, 2);
				}
			}
		}



		//The following must be here, it was made by some guy on stackoverflow,  then modififed by starkelp in twitch chat :)
		//It takes things named TitleForm[X] where X is a variable with a string, and lets you use the string as a textboxes name with .text at the end.
		//This lets you use a variable in place of a textbox.text property, so you can refer to them indirectly.
		public string GetText(Control.ControlCollection control, string name, string defaultText = null) //this Form form, string name, string defaultText = null
		{
			return control.ContainsKey(name) ?
				control[name].Text :
				(defaultText ?? string.Empty);
		}

		public void SetText(Control.ControlCollection control, string name, string text) //this Form form, string name, string text
		{
			if (control.ContainsKey(name))
			{
				var control2 = control[name];
				control2.Text = text;
			}
		}

	
	}
}
