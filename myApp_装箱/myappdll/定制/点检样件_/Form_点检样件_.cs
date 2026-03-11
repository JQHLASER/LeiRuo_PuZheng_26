using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myappdll
{
    public partial class Form_点检样件_ : Sunny25.UIForm
    {
        public Form_点检样件_()
        {
            InitializeComponent();
        }

        private void Form_点检样件__Load(object sender, EventArgs e)
        {
            this.uiTextBox1.Clear();
            string xt = "";
            foreach (var s in 点检样件 .Config .点检数据 )
            {
                xt += $"{s}\r\n";
            }
            this.uiTextBox1 .Text = xt;

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            string[] beff=this.uiTextBox1 .Text.Split(new string[] { "\r\n"},StringSplitOptions.None);

            foreach (var s in beff)
            {
                if (!string.IsNullOrEmpty (s))
                {
                    lst.Add (s);
                }
            }
            点检样件 .Config .点检数据 =lst.ToArray ();
            点检样件.Cfg(0);

            Sunny25.Messagebox.Show("OK");




        }
    }
}
