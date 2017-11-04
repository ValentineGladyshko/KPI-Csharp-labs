using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        Complex a;
        Complex b;
        Context context;

        private Complex A { get => a; set => a = value; }
        private Complex B { get => b; set => b = value; }
        private Context Context { get => context; set => context = value; }

        public Form1()
        {
            InitializeComponent();
            A = new Complex();
            B = new Complex();
            Context = new Context();
        }

        private string CheckComplexNumbers()
        {
            string result = "";
            try
            {
                Convert.ToDouble(Complex1X.Text);
                Convert.ToDouble(Complex1Y.Text);
            }
            catch (FormatException)
            {
                result += "Некоректне комплексне число 1\n";
            }

            try
            {
                Convert.ToDouble(Complex2X.Text);
                Convert.ToDouble(Complex2Y.Text);
            }
            catch (FormatException)
            {
                result += "Некоректне комплексне число 2\n";
            }
            return result;
        }

        private void CheckComplex1()
        {
            try
            {
                A.X = Convert.ToDouble(Complex1X.Text);
                A.Y = Convert.ToDouble(Complex1Y.Text);

                Complex1.Text = A.ToString();
            }
            catch (FormatException) { };
        }

        private void CheckComplex2()
        {
            try
            {
                B.X = Convert.ToDouble(Complex2X.Text);
                B.Y = Convert.ToDouble(Complex2Y.Text);

                Complex2.Text = B.ToString();
            }
            catch (System.FormatException) { };
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string result = "";
            result = CheckComplexNumbers();

            if (result == "")
            {
                Context.SetStrategy(new OperationAdd());
                ResultBox.Text = Context.Execute(A, B).ToString();
                MessageBox.Text += "Виконано додавання: " + ResultBox.Text + "\n";
            }

            else
            {
                MessageBox.Text += "Неможливо виконати додавання:\n" + result;
            }
        }

        private void ButtonSubtract_Click(object sender, EventArgs e)
        {
            string result = "";
            result = CheckComplexNumbers();

            if (result == "")
            {
                Context.SetStrategy(new OperationSubtract());
                ResultBox.Text = Context.Execute(A, B).ToString();
                MessageBox.Text += "Виконано віднімання: " + ResultBox.Text + "\n";
            }

            else
            {
                MessageBox.Text += "Неможливо виконати віднімання:\n" + result;
            }
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            string result = "";
            result = CheckComplexNumbers();

            if (result == "")
            {
                Context.SetStrategy(new OperationMultiply());
                ResultBox.Text = Context.Execute(A, B).ToString();
                MessageBox.Text += "Виконано множення: " + ResultBox.Text + "\n";
            }

            else
            {
                MessageBox.Text += "Неможливо виконати множення:\n" + result;
            }
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            string result = "";
            result = CheckComplexNumbers();

            if (result == "")
            {
                Context.SetStrategy(new OperationDivide());
                ResultBox.Text = Context.Execute(A, B).ToString();
                MessageBox.Text += "Виконано ділення: " + ResultBox.Text + "\n";
            }

            else
            {
                MessageBox.Text += "Неможливо виконати ділення:\n" + result;
            }
        }

        private void Complex1X_TextChanged(object sender, EventArgs e)
        {
            CheckComplex1();
        }

        private void Complex1X_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(Complex1X.Text);
            }
            catch (FormatException)
            {
                MessageBox.Text += "Некоректне введення числа 1\n";
            };
        }

        private void Complex1Y_TextChanged(object sender, EventArgs e)
        {
            CheckComplex1();
        }

        private void Complex1Y_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(Complex1Y.Text);
            }
            catch (FormatException)
            {
                MessageBox.Text += "Некоректне введення числа 1\n";
            };
        }

        private void Complex2X_TextChanged(object sender, EventArgs e)
        {
            CheckComplex2();
        }

        private void Complex2X_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(Complex2X.Text);
            }
            catch (FormatException)
            {
                MessageBox.Text += "Некоректне введення числа 2\n";
            };
        }

        private void Complex2Y_TextChanged(object sender, EventArgs e)
        {
            CheckComplex2();
        }        

        private void Complex2Y_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(Complex2Y.Text);
            }
            catch (FormatException)
            {
                MessageBox.Text += "Некоректне введення числа 2\n";
            };
        }

        private void ClearMessageBox_Click(object sender, EventArgs e)
        {
            MessageBox.Text = "";
        }
    }
}
