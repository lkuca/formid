using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formid
{
    public partial class TreeForm: Form
    {
        TreeView tree;
        Button btn;
        Label lbl;

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
            tree.MouseDoubleClick += button_MouseDOubleClick;


            tree.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(this.Width,btn.Location.Y);
            lbl.BackColor= Color.LightGray;
            lbl.BorderStyle= BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);




            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                this.Controls.Add(lbl);
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
        }
    }
}
