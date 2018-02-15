using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM2gui
{
    public partial class NumberBox : TextBox
    {
        public string Type { get; set; }

        public int? Digit { get; set; }

        public NumberBox(string type, int? digit)
        {
            InitializeComponent();
            this.Type = type;
            this.Digit = digit;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (IsIllegalChar(e.KeyChar))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
            else
            {
                // check for length
                if (this.Type == "INT" && this.Digit != null)
                {
                    
                }
            }
                base.OnKeyPress(e);
        }

        private bool IsIllegalChar(char c)
        {
            //bool isPlusORMinusInTheMiddle = this.SelectionStart != 0 && (c == '+' || c == '-');
            bool isDecimalPointAtTheStart = this.SelectionStart == 0 && (c == '.');
            bool isSecondDecimalPoint = this.SelectionStart != 0 && c == '.' && this.Text.Contains('.');

            switch (this.Type)
            {
                case "INT":
                    return !char.IsControl(c) && !char.IsDigit(c) ;
                    break;
                default:
                    return (!char.IsControl(c) && !char.IsDigit(c) && c != '.' && c != '+' && c != '-') || isDecimalPointAtTheStart || isSecondDecimalPoint;
                    break;
            }
        }
    }
}
