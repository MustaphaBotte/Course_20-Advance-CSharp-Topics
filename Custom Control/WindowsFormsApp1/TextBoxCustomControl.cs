using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TextBoxCustomControl: TextBox
    {
        public TextBoxCustomControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
         base.OnPaint(pe);
        }
        public enum EnType { Text,Numeric,Email,Phone}
        public EnType Type
        {
           set;
           get;      
        } = EnType.Text;
        public bool Isrequired { set; get; } = false;

        public bool IsValid()
        {
            if(Isrequired)
            {
                return (this.Text.Trim().Length > 0);
            }
            else if(!Isrequired && (this.Text.Trim().Length == 0))
            {
                return true;
            }
            // if not required and the user provide it (email or phone) we must validate it
            if (this.Type == EnType.Numeric)
            {
               foreach(char c in Text)
                {
                    if (!char.IsDigit(c) && c != '.')
                        return false;
                }
                return true;
            }
            else if (this.Type == EnType.Email)
            {
                return Regex.IsMatch(Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            }
            else if (this.Type == EnType.Phone)
            {
                return Regex.IsMatch(Text, @"^(?:\+212)?\s?[5-7]\d{8}$");
            }
            return false;
        }

    }
}
