using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace formid
{
    public partial class TreeForm: Form
    {
        TreeView tree;
        Button btn, btn2, btn3;
        Label lbl;
        TextBox txt;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb;
        ListBox lb;
        
        public TreeForm()
        {
            this.Height = 600;
            this.Width= 800;
            this.Text = "Vorm põhielementidega";
            tree=new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle= BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            
            TreeNode treeNode= new TreeNode("Elemendid");
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height= 40;
            btn.Width= 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;
            btn.MouseHover += button2_MouseHover;
            btn.Visible = false;
            tree.MouseDoubleClick += button_MouseDOubleClick;
            treeNode.Nodes.Add(new TreeNode("kolmnurk"));
            //new KolmnurkForm().Show();



            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(this.Width,btn.Location.Y);
            lbl.BackColor= Color.LightGray;
            lbl.BorderStyle= BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            lbl.Visible = false;
            treeNode.Nodes.Add(new TreeNode("tekstik"));
            this.Controls.Add(tree);
            txt = new TextBox();
            txt.BorderStyle = BorderStyle.Fixed3D;
            txt.Height = 50;
            txt.Width = 100;
            txt.Text = "...";
            txt.Visible = false;
            txt.Location = new Point(tree.Width, btn.Top + btn.Height + 5);
            txt.KeyDown += new KeyEventHandler(Text_Box_KeyDown);
            this.Controls.Add(txt);
            txt.Visible = false;
            treeNode.Nodes.Add(new TreeNode("Radionupp"));
            r1 = new RadioButton();
            r1.Text = "VAlik";
            r1.Visible = false;
            r1.Location = new Point(tree.Width, txt.Location.Y + txt.Height);
            r2 = new RadioButton();
            r2.Text = "valik2";
            r2.Visible = false;
            r2.Location = new Point(r1.Location.X + r1.Width, txt.Location.Y + txt.Height);
            r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
            r2.CheckedChanged += new EventHandler(RadioButtons_Changed);
            this.Controls.Add(r1);
            this.Controls.Add(r2);
            treeNode.Nodes.Add(new TreeNode("CheckBox"));
            c1 = new CheckBox();
            c1.Visible= true;
            c1.Text = "Valik 1.1";
            c1.Location = new Point(tree.Width, r1.Top + r1.Height + 5);
            c1.CheckedChanged += new EventHandler(CheckBoxes_Changed);
            c2 = new CheckBox();
            c2.Visible= true;
            c2.Text = "Valik 2.2";
            c2.Location = new Point(c1.Location.X + c1.Width, r1.Top + r1.Height + 5);
            c1.CheckedChanged += new EventHandler(CheckBoxes_Changed);
            pb=new PictureBox();
            pb.Location = new Point(tree.Width, c2.Location.Y + c2.Height + 5);
            pb.Image = new Bitmap("../../../msg1021801730-104019.jpg");
            pb.Size = new Size(100, 100);
            pb.SizeMode= PictureBoxSizeMode.Zoom;
            pb.BorderStyle= BorderStyle.Fixed3D;
            this.Controls.Add(pb);
            lb = new ListBox();
            lb.Items.Add("Roheline");
            lb.Items.Add("Sinine");
            lb.Items.Add("Hall");
            lb.Items.Add("Kollane");
            lb.Location = new Point(tree.Width, pb.Location.Y + pb.Height);
            this.Controls.Add(lb);
            lb.Visible = true;
            btn2 = new Button();
            btn2.Height = 50;
            btn2.Width= 100;
            btn2.Location = new Point(lb.Left, lb.Bottom);
            btn2.Visible = true;
            btn2.Click += btn2_Click;
            //btn3= new Button();
            //btn3.Height = 50;
            //btn3.Width= 100;
            //btn3.Text = "kustuta";
            //btn3.Location = new Point(150, btn2.Bottom);
            //btn3.Visible = true;
            //btn3.Click += btn3_Click;
            lb.KeyDown += Lb_KeyDown;


            treeNode.Nodes.Add(new TreeNode("DataGridView"));
            DataSet ds = new DataSet("XML fail. Menüü");
            DataGridView dataGrid = new DataGridView();
            ds.ReadXml(@"..\..\..\Uus tekstidokument.xml");
            dataGrid.Location = new Point(tree.Width + pb.Width, pb.Location.Y);
            dataGrid.Height = 200;
            dataGrid.Width= 300;
            dataGrid.DataSource= ds;
            dataGrid.AutoGenerateColumns= true;
            dataGrid.DataMember = "Food";
            this.Controls.Add(dataGrid);
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;




            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            this.Controls.Add(c1);
            this.Controls.Add(c2);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);

        }
        //private void btn3_Click(object? sender, EventArgs e)
        //{

        //    if (lb.SelectedItems != null)
        //    {
        //        lb.Items.Remove(lb.SelectedItems);
        //        lb.Height -= 20;
        //        lb.Height += 20;
        //        //btn2.Location = new Point(lb.Left, lb.Bottom);
        //        //btn3.Location = new Point(lb.Left, btn2.Bottom);

        //    }

        //}
        private void Lb_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lb.SelectedItem != null)
                {
                    lb.Items.Remove(lb.SelectedItem);
                    if (lb.Items.Count < 7)
                    {
                        lb.Height -= 20;
                        lb.Height += 20;
                        btn2.Location = new Point(lb.Left, lb.Bottom);
                    }
                }
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            string tekst = Interaction.InputBox("lsia uus väli", "Pealkiri muutmine", "väli");
            if(tekst.Length>0 && !lb.Items.Contains(tekst))
            {
                lb.Items.Add(tekst);
            }
        }
        private void CheckBoxes_Changed(object? sender, EventArgs e)
        {
            bool isChecked1 = c1.Checked;
            bool isChecked2 = c2.Checked;
            if (isChecked1 && !isChecked2)
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                btn.ForeColor = Color.Black;
                lbl.ForeColor = Color.Black;
            }
            else if (isChecked2 && !isChecked1)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                btn.ForeColor = Color.White;
                lbl.ForeColor = Color.Black;
            }
            else if (isChecked1 && isChecked2)
            {
                this.BackColor = Color.Gray;
                this.ForeColor = Color.Blue;
                btn.ForeColor = Color.Blue;
                lbl.ForeColor = Color.Blue;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                btn.ForeColor = SystemColors.ControlText;
                lbl.ForeColor = SystemColors.ControlText;
            }
        }

        private void Text_Box_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    txt.Enabled = false;
                    this.Text = txt.Text; }
                else
                {
                    string tekst = Interaction.InputBox("Sissesta pealkiri", "Pealkiri muutmine", "Uus pealkiri");
                    this.Text = tekst;
                }
            }

        }

        private void RadioButtons_Changed(object? sender, EventArgs e)
        {
            if(r1.Checked) { this.BackColor = Color.Purple; }
            else if(r2.Checked) { this.BackColor = Color.Red;}
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {


            //throw new NotImplementedException();
            if (e.Node.Text == "Nupp-Button" )
            {
                if (btn.Visible)
                {
                    btn.Visible = false;
                }
                else { btn.Visible = true; }
                
            }
            else if (e.Node.Text == "Silt-Label")
            {
                if (lbl.Visible)
                {
                    lbl.Visible = false;
                }
                else { lbl.Visible = true; }
            }
            else if (e.Node.Text == "tekstik")
            {
                if (txt.Visible)
                {
                    txt.Visible = false;
                }
                else { txt.Visible = true; }
            }
            else if (e.Node.Text== "Radionupp")
            {
                if (r1.Visible == true)
                {
                    r1.Visible = false;
                    r2.Visible = false;
                }
                else if (r2.Visible == false)
                {
                    r1.Visible = true;
                    r2.Visible = true;
                }
                
            }
            else if (e.Node.Text== "CheckBox")
            {
                if (c1.Visible == false)
                {
                    c1.Visible = true;
                    c2.Visible= true;
                }
                else if (c2.Visible == false)
                {
                    c1.Visible = true;
                    c2.Visible = true;
                }
            }
            else if (e.Node.Text== "kolmnurk")
            {
                new KolmnurkForm().Show();
            }
           
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor= Color.Chocolate;
            }
            else { btn.BackColor = Color.Blue; }
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            btn.Text = "your Mouse cursosr on button";
        }
        private void button_MouseDOubleClick(object sender, EventArgs e)
        {
            if (btn.Visible)
            {
                btn.Visible = false;
            }
            else { btn.Visible = true; }

            if (lbl.Visible)
            {
                lbl.Visible = false;
            }
            else { lbl.Visible = true; }


            if (txt.Visible)
            {
                txt.Visible = false;
            }
            else { txt.Visible = true; }

            if (r1.Visible == true)
            {
                r1.Visible = false;
                r2.Visible = false;
            }
            else if(r2.Visible == false)
            {
                r1.Visible = true;
                r2.Visible = true;
            }
            if (c1.Visible) { c1.Visible = false; }
            else { c1.Visible = true; }
            if (c2.Visible) { c2.Visible = false; }
            
        }
        
       
    }
}
