using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormComponent
{
    
    public partial class Form : UserControl
    {
        private Dictionary<string, Control> componentMap;
        private Dictionary<string, string> errorMap;
        private Dictionary<string, string> regexMap;
        
        public Form()
        {
            InitializeComponent();
            componentMap = new Dictionary<string, Control>();
            errorMap = new Dictionary<string, string>();
            regexMap = new Dictionary<string, string>();
            tableLayoutPanel2.Height = 0;
            tableLayoutPanel2.RowCount = 0;
            tableLayoutPanel2.ColumnCount = 1;

        }

        public void addField(String name, String type, String regex, String errorMessage)
        {
            tableLayoutPanel2.Height += 75;
            tableLayoutPanel2.RowCount += 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            addError(name, errorMessage);
            addRegex(name, regex);
            Label t = new Label();
            t.Text = "aaaa";
            t.TextAlign = ContentAlignment.BottomLeft;
            Label b = new Label();
           
            b.Text = "blad";
            b.AutoSize = false;
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.Dock = DockStyle.None;
            tableLayoutPanel2.Controls.Add(t ,1, tableLayoutPanel2.RowCount-3);
            tableLayoutPanel2.Controls.Add(new TextBox(),1, tableLayoutPanel2.RowCount-2);
            tableLayoutPanel2.Controls.Add(b,1, tableLayoutPanel2.RowCount-1);
            
            
        }

        public void addError(String fieldName, String errorContent)
        {
            errorMap.Add(fieldName, errorContent);
        }

        public void addRegex(String fieldName, String regex)
        {
            regexMap.Add(fieldName, regex);
        }
    }
}
