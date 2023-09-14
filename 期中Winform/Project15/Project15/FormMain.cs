using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project15
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void 影片資訊ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FormMediaInfo().Show();
		}

		private void 影片類型ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
		}

		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			(Owner as FormLogin).Show();
		}
	}
}
