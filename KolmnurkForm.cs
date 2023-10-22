using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace formid
{
    public partial class KolmnurkForm: Form
    {
        TreeView kolmnurk;
        ListView ListViewkolmnurkList;
        Button btn,btn1;
        TextBox txt,txt1,txt2;
        PictureBox pb;

        public KolmnurkForm()
        {



            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementidega";
            kolmnurk = new TreeView();
            kolmnurk.Dock = DockStyle.Left;
            kolmnurk.BorderStyle = BorderStyle.Fixed3D;
            ListViewkolmnurkList = new ListView();
            ListViewkolmnurkList.Height= 400;
            ListViewkolmnurkList.Width= 500;
            ListViewkolmnurkList.Columns.Add("väli", 50);
            ListViewkolmnurkList.Columns.Add("tähtsus", 50);
            ListViewkolmnurkList.View = View.Details;
            this.Controls.Add(ListViewkolmnurkList);
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Lülita sisse";
            btn.Location = new Point(150, ListViewkolmnurkList.Bottom);
            btn.Click += Btn_Click;
            btn.Visible = true;
            this.Controls.Add(btn);
            btn1 = new Button();
            btn1.Height = 40;
            btn1.Width = 100;
            btn1.Text = "Start";
            btn1.Location = new Point(300, ListViewkolmnurkList.Bottom);
            btn1.Click += Btn_Click1;
            btn1.Visible = true;
            this.Controls.Add(btn1);
            txt = new TextBox();
            txt.Height = 40;
            txt.Width = 100;
            txt.Location= new Point(150,btn.Bottom);
            txt.Visible= true;
            this.Controls.Add(txt);
            txt1 = new TextBox();
            txt1.Height = 40;
            txt1.Width = 100;
            txt1.Location = new Point(150, txt.Bottom);
            txt1.Visible= true;
            this.Controls.Add(txt1);
            txt2 = new TextBox();
            txt2.Height = 40;
            txt2.Width = 100;
            txt2.Location = new Point(150,txt1.Bottom);
            txt2.Visible= true;
            this.Controls.Add(txt2);
            pb = new PictureBox();
            //pb.Image = new Bitmap("../../../vordhaarne.png");
            pb.Location = new Point(kolmnurk.Width, txt2.Location.Y + txt2.Height + 5);
            pb.Size = new Size(200, 200);
            pb.Visible = true;
            this.Controls.Add(pb);



        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            double A, B, C;
            A = Convert.ToDouble(txt.Text);
            B = Convert.ToDouble(txt1.Text);
            C = Convert.ToDouble(txt2.Text);
            Triangle triangle = new Triangle(A, B, C);
            ListViewkolmnurkList.Items.Add("külg a");
            ListViewkolmnurkList.Items.Add("külg b");
            ListViewkolmnurkList.Items.Add("külg c");
            ListViewkolmnurkList.Items.Add("ümbermõõt");
            ListViewkolmnurkList.Items.Add("Pindala");
            ListViewkolmnurkList.Items.Add("on?");
            ListViewkolmnurkList.Items.Add("specificator");
            ListViewkolmnurkList.Items.Add("kõrgus");
            ListViewkolmnurkList.Items[0].SubItems.Add(triangle.outputa());
            ListViewkolmnurkList.Items[1].SubItems.Add(triangle.outputb());
            ListViewkolmnurkList.Items[2].SubItems.Add(triangle.outputc());
            ListViewkolmnurkList.Items[3].SubItems.Add(Convert.ToString(triangle.Perimeter()));
            ListViewkolmnurkList.Items[4].SubItems.Add(Convert.ToString(triangle.Surface()));
            ListViewkolmnurkList.Items[7].SubItems.Add(Convert.ToString(triangle.Getkorgus()));
            if (triangle.ExistTriangle) { ListViewkolmnurkList.Items[5].SubItems.Add("on"); }
            else ListViewkolmnurkList.Items[5].SubItems.Add("ei ole");
            if (A == B || B == C)
            {
                ListViewkolmnurkList.Items[6].SubItems.Add("võrdhaarne");
                pb.Image = new Bitmap("../../../vordhaarne.png");
                
            }
            else if (A == C)
            {
                ListViewkolmnurkList.Items[6].SubItems.Add("võrdkülgne");
                pb.Image = new Bitmap("../../../vordkulgne.png");
                
            }
            else
            {
                ListViewkolmnurkList.Items[6].SubItems.Add("erikulgne");
                pb.Image = new Bitmap("../../../erikulgne.png");
                
            }
            
        }
        private void Btn_Click1(object? sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }


    }
    
}
