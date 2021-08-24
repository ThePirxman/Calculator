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
            txtDisplay.Clear();
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (prevOperation == Operation.None)
                prevOperation = Operation.Div;
            else
                PerformCalculation(prevOperation);
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            if (prevOperation == Operation.None)
                prevOperation = Operation.Mul;
            else
                PerformCalculation(prevOperation);
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (prevOperation == Operation.None)
                prevOperation = Operation.Sub;
            else
                PerformCalculation(prevOperation);
            txtDisplay.Text += (sender as Button).Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (prevOperation == Operation.None)
                prevOperation = Operation.Add;
            else
                PerformCalculation(prevOperation);
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
                    lstNums = txtDisplay.Text.Split('*').Select(double.Parse).ToList();
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
