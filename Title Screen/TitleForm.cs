using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystal_Editor
{

	


	public partial class TitleForm : Form
    {

		static byte[] data_array; //This starts the array.
		static String SaveLoad = "Empty"; //This just defines this string to be used later. It lets
		static int Start = 37; //Leagth from start of file to the byte where the first row / data starts. The first byte is #0, most hex editors count byte0 so they should be accurate...probably.
		static int Row = 38; //Leagth of a row of data. The first byte is #1 not #0, so if a row starts at column 0 and is 29 long, then input 30.  This is used in every load and save of data to the array.
		static int Column = 0;
		static String TextName = "Dummy";

		string this[string name]
		{
			get
			{
				return this.Controls.ContainsKey(name) ?
					this.Controls[name].Text :
					null;
			}

			set
			{
				if (this.Controls.ContainsKey(name))
				{
					var control = this.Controls[name];
					control.Text = value;
				}
			}
		}


		public TitleForm()
        {
            InitializeComponent();
        }

		//The following is written by violentlycar to deal with writing/saving mult-byte hex to files. 
		//it is not used here, but in other files, pretty much every editor uses this.
		//it is used via the following command
		//ByteWriter(value, destination_array, offset)
		//a semi-pratical example is ByteWriter(value, enemydata_array, 0x38 + (treeView1.SelectedNode.Index * 0x38) + 4)

		static public void ByteWriter<T>(T val, byte[] d_array, int start_offset)  //This is the Violently car byte load/save hex method.
		{
			if (val is byte || val is sbyte) // avoid using this one
			{
				d_array[start_offset] = Convert.ToByte(val);
			}
			else if (val is short)
			{
				short c_val = Convert.ToInt16(val);
				d_array[start_offset] = (byte)(c_val & 0xFF);
				d_array[start_offset + 1] = (byte)((c_val & 0xFF00) >> 8);
			}
			else if (val is ushort)
			{
				ushort c_val = Convert.ToUInt16(val);
				d_array[start_offset] = (byte)(c_val & 0xFF);
				d_array[start_offset + 1] = (byte)((c_val & 0xFF00) >> 8);
			}
			else if (val is int)
			{
				int c_val = Convert.ToInt32(val);
				d_array[start_offset] = (byte)(c_val & 0xFF);
				d_array[start_offset + 1] = (byte)((c_val & 0xFF00) >> 8);
				d_array[start_offset + 2] = (byte)((c_val & 0xFF0000) >> 16);
				d_array[start_offset + 3] = (byte)((c_val & 0xFF000000) >> 24);
			}
			else if (val is uint)
			{
				uint c_val = Convert.ToUInt32(val);
				d_array[start_offset] = (byte)(c_val & 0xFF);
				d_array[start_offset + 1] = (byte)((c_val & 0xFF00) >> 8);
				d_array[start_offset + 2] = (byte)((c_val & 0xFF0000) >> 16);
				d_array[start_offset + 3] = (byte)((c_val & 0xFF000000) >> 24);
			}
			else if (val is string)
			{
				byte[] str_bytes = Encoding.ASCII.GetBytes(Convert.ToString(val));
				for (int x = 0; x < str_bytes.Length; x++)
				{
					d_array[start_offset + x] = str_bytes[x];
				}
			}
			else
			{
				throw new Exception("Value passed was not one of supported type: byte, sbyte, ushort, short, uint, int, string.");
			}
		}


		

		//public void MoveData()
		//{
		//	if (SaveLoad == "Load") { this[TextName] = data_array[Start + (Tree.SelectedNode.Index * Row) + Column].ToString("D"); }
		//	if (SaveLoad == "Save") { Byte.TryParse(this[TextName], out byte value8); { TitleForm.ByteWriter(value8, data_array, Start + (Tree.SelectedNode.Index * Row) + Column); } }
		//}


		private void button1_Click(object sender, EventArgs e)
        {
            //Go to form 2
            //this.Hide(); //Hides this form
            //this.Close();
            TemplateForm f2 = new TemplateForm(); //Create the new form
            f2.StartPosition = FormStartPosition.Manual;  //Grab current windows location
            f2.Location = this.Location; //Create the new window at the same location as current one
            f2.Show();
            //f2.ShowDialog(); //Show the new form

            //f2 = null; //When the new form is closed
            //this.Show(); //we show form1 again
        }

        private void TitleForm_Load(object sender, EventArgs e)
        {

        }
    }


	


}
