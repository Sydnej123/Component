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
        private Dictionary<string, Component> componentMap;
        private Dictionary<string, string> errorMap;
        private Dictionary<string, string> regexMap;
        
        public Form()
        {
            InitializeComponent();
            componentMap = new Dictionary<string, Component>();
            errorMap = new Dictionary<string, string>();
            regexMap = new Dictionary<string, string>();

        }

        public void addField(String name)
        {

        }

        public void addError(String fieldName, String errorContent)
        {

        }

        public void addRegex(String fieldName, String regex)
        {

        }


    }
}
