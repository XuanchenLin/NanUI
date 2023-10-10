using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinimalWinFormiumApp;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        Label label = new (){
            Text = "Click to open WinFormium",
        };

        label.Click += (_, _) =>
        {
            var window = new MyWindow();
            window.Show();
        };

        Controls.Add(label);


    }
}
