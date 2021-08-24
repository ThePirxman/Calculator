using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            prevOperation = Operation.None;
            txtDisplay.Clear();
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {
                double d;
                if(!double.TryParse(txtDisplay.Text[txtDisplay.Text.Length - 1].ToString(), out d))
                {
                    prevOperation = Operation.None;
                }
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (prevOperation != Operation.None)
                PerformCalculation(prevOperation);
            prevOperation = Operation.Div;          
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            if (prevOperation != Operation.None)
                PerformCalculation(prevOperation);
            prevOperation = Operation.Mul;
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (prevOperation != Operation.None)
                PerformCalculation(prevOperation);
            prevOperation = Operation.Sub;     
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (prevOperation != Operation.None)
                PerformCalculation(prevOperation);
            prevOperation = Operation.Add;
            txtDisplay.Text += (sender as Button).Text;
        }

        List<double> lstNums = new List<double>();
        private void PerformCalculation(Operation prevOperation)
        {
            switch (prevOperation)
            {
                case Operation.Add:
                    lstNums = txtDisplay.Text.Split('+').Select(double.Parse).ToList();
                    txtDisplay.Text = (lstNums[0] + lstNums[1]).ToString();
                    break;
                case Operation.Div:
                    try
                    {
                        lstNums = txtDisplay.Text.Split('/').Select(double.Parse).ToList();
                        txtDisplay.Text = (lstNums[0] / lstNums[1]).ToString();
                    }
                    catch (DivideByZeroException)
                    {

                        txtDisplay.Text = "Error";
                    }
                    break;
                case Operation.Mul:
                    lstNums = txtDisplay.Text.Split('x').Select(double.Parse).ToList();
                    txtDisplay.Text = (lstNums[0] * lstNums[1]).ToString();
                    break;
                case Operation.Sub:
                    lstNums = txtDisplay.Text.Split('-').Select(double.Parse).ToList();
                    txtDisplay.Text = (lstNums[0] - lstNums[1]).ToString();
                    break;
                case Operation.None:
                    break;
                default:
                    break;
            }
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            if (prevOperation == Operation.None)
                return;
            else
            {
                PerformCalculation(prevOperation);
                prevOperation = Operation.None;
            }
               
        }

        enum Operation
        {
            Add,
            Sub,
            Mul,
            Div,
            None
        }
        static Operation prevOperation = Operation.None;
    }
}
