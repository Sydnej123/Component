using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FormComponent
{
    
    public partial class Form : UserControl
    {
        private Dictionary<string, Control> componentMap;
        private Dictionary<string, Control> errorLabels;
        private Dictionary<string, string> errorMap;
        private Dictionary<string, string> regexMap;
        private Button submitButton;
        Control destination;
        public Form()
        {
            InitializeComponent();
            componentMap = new Dictionary<string, Control>();
            errorLabels = new Dictionary<string, Control>();
            errorMap = new Dictionary<string, string>();
            regexMap = new Dictionary<string, string>();
            tableLayoutPanel2.Height = 30;
            tableLayoutPanel2.Width = 150;
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.ColumnCount = 1;
            submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Click += new EventHandler(button1_Click);
            tableLayoutPanel2.Controls.Add(submitButton, 0, 0);

        }

        public void addField(String labelName, String name, String type, String regex, String errorMessage)
        {   
           

            tableLayoutPanel2.Height += 75;
            tableLayoutPanel2.RowCount += 3;

            tableLayoutPanel2.SetRow(submitButton, tableLayoutPanel2.RowCount);

            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            addError(name, errorMessage);
            addRegex(name, regex);
            Label nameLabel = new Label();
            nameLabel.Text = labelName;
            nameLabel.TextAlign = ContentAlignment.BottomLeft;
            Label errorLabel = new Label();
            errorLabel.Text = "blad";
            errorLabel.AutoSize = false;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            errorLabel.Dock = DockStyle.None;
            errorLabel.ForeColor = this.BackColor;
           
            errorLabels.Add(name, errorLabel);
            tableLayoutPanel2.Controls.Add(nameLabel ,1, tableLayoutPanel2.RowCount-3);


            switch (type.ToUpper())
            {
                case "TEXT":
                    componentMap.Add(name, new TextBox());
                    break;
                case "PASSWORD":
                    TextBox passwordFied = new TextBox();
                    passwordFied.PasswordChar = '*';
                    componentMap.Add(name, passwordFied);
                    break;
                case "COMBOBOX":
                    ComboBox comboBox = new ComboBox();
                    // add options
                    componentMap.Add(name, comboBox);
                    break;
                case "CHECKBOX":
                    CheckBox radio= new CheckBox();
                    componentMap.Add(name, radio);
                    break;
                case "DATE":
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    componentMap.Add(name, dateTimePicker);
                    break;
                case "NUMBER":
                    NumericUpDown numberField = new NumericUpDown();
                    componentMap.Add(name, numberField);
                    break;

            }
            





            componentMap.TryGetValue(name, out Control textfield);
            tableLayoutPanel2.Controls.Add(textfield, 1, tableLayoutPanel2.RowCount-2);
            tableLayoutPanel2.Controls.Add(errorLabel,1, tableLayoutPanel2.RowCount-1);
            
            
        }

        public void addError(String fieldName, String errorContent)
        {
            errorMap.Add(fieldName, errorContent);
        }

        public void addRegex(String fieldName, String regex)
        {
            regexMap.Add(fieldName, regex);
        }


        private bool validateField(String fieldName)
        {
            componentMap.TryGetValue(fieldName, out Control control);
            regexMap.TryGetValue(fieldName, out String regex);
            errorLabels.TryGetValue(fieldName, out Control errorLabel);
            errorMap.TryGetValue(fieldName, out String errorMessage);
            if (regex.Length > 0) {
                Regex r = new Regex(regex);
                Match matcher = r.Match(control.Text);
                if (!matcher.Success)
                {
                    errorLabel.Text = errorMessage;
                   
                    errorLabel.ForeColor = Color.Black;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
              

        }

        public String getData()
        {
            bool isFormValid = true;
            bool isFirst = true;
            String json = "{";
            foreach(KeyValuePair<string, Control> entry in componentMap)
            {
                if (!isFirst)
                {
                    json += ",";
                }
                else
                {
                    isFirst = false;
                }

                if (!validateField(entry.Key)) {
                    isFormValid = false;
                }
                if(entry.Value.GetType() == typeof(CheckBox))
                {
                    json += entry.Key.ToString() + ":" + "\"" + ((CheckBox) entry.Value).Checked + "\"";
                }
                else if (entry.Value.GetType() == typeof(ComboBox))
                {
                    json += entry.Key.ToString() + ":" + "\"" + ((ComboBox) entry.Value).SelectedItem.ToString() + "\"";
                }
                else
                {
                    json += entry.Key.ToString() + ":" + "\"" + entry.Value.Text + "\"";
                }
               
              
            }
       
            json += "}";
            if (isFormValid)
            {
                clearFields();
                return json;
            }else
            {
                return "Error";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            destination.Text = getData();
        }

        public void setControl(Control control)
        {
            destination = control;
        }

        private void clearFields()
        {
            foreach (KeyValuePair<string, Control> entry in componentMap)
            {
                entry.Value.Text = "";
            }
        }

        private void numericField(object sender, EventArgs e)
        {
             // validation
        }
    }
}
