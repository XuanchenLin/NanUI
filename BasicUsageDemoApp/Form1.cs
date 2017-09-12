using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;

namespace BasicUsageDemoApp
{
	public partial class Form1 : Formium
	{
		public Form1()
			: base("https://www.html5test.com", false)
		{
			InitializeComponent();

			
		}
	}
}
