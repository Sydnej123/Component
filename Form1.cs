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
            comboBox1.Items.Add("password");
            comboBox1.Items.Add("text");
            comboBox1.Items.Add("combobox");
            comboBox1.Items.Add("checkbox");
            comboBox1.Items.Add("date");
            comboBox1.Items.Add("number");
            comboBox1.SelectedIndex = 0;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.addField(textBox5.Text, textBox1.Text, comboBox1.SelectedItem.ToString(), textBox2.Text, textBox3.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
