using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PM2gui
{
    public partial class NumberBox : TextBox
    {
        public string Type { get; set; }

        public double? Max { get; set; }
        public double? Min { get; set; }


        public NumberBox(string type, double? max, double? min)
        {
            InitializeComponent();

            this.Type = type;
            this.Max = max;
            this.Min = min;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text.Length == 0)
            {
                this.Text = "0";
                this.SelectionStart = 1;
                base.OnTextChanged(e);
                return;
            }
            else
            {
                base.OnTextChanged(e);
            }

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
                string preview = this.Text.Insert(this.SelectionStart, e.KeyChar.ToString());
                if (!char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    double number = double.Parse(preview);
                    if ((this.Max != null && number > this.Max) || (this.Min != null && number < this.Min))
                    {
                        MessageBox.Show("Number out of range");
                        e.Handled = true;
                        return;
                    }
                }

                base.OnKeyPress(e);

            }

        }

        private bool IsIllegalChar(char c)
        {
            //bool isPlusORMinusInTheMiddle = this.SelectionStart != 0 && (c == '+' || c == '-');
            bool isDecimalPointAtTheStart = this.SelectionStart == 0 && (c == '.');
            bool isSecondDecimalPoint = this.SelectionStart != 0 && c == '.' && this.Text.Contains('.');

            switch (this.Type)
            {
                case "INT":
                    return !char.IsControl(c) && !char.IsDigit(c);
                    break;
                default:
                    return (!char.IsControl(c) && !char.IsDigit(c) && c != '.') || isDecimalPointAtTheStart || isSecondDecimalPoint;
                    break;
            }
        }
    }
}
