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

namespace UseEmbeddedResourcesDemoApp
{
	public partial class Form1 : Formium
	{
		public Form1() :
			base("http://my.resource.local/index.html", false)
		{

			InitializeComponent();
		}
	}
}
