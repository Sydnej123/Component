using System;
using System.Windows.Forms;

namespace FormComponent
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Form form;
        public Form1()
        {
            InitializeComponent();
            form = new Form();
            form.Width = 500;
            form.Height = 800;
            form.setControl(textBox4);
            this.Controls.Add(form);
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.addField(textBox1.Text, "aa", textBox2.Text, textBox3.Text);
        }     
    }
}
