using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessFormStyleDemoApp
{
	public partial class Form3 : NetDimension.WinForm.ModernUIForm
	{
		public Form3():base(true)
		{
			InitializeComponent();
		}
	}
}
