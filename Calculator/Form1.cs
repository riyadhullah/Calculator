using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double result = 0;

        //
        //num_btn_Click
        //
        private void num_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblEquil.Text = "";
            
            if (btn.Text == "."&& txtBox.Text.Contains("."))
                return;
            if(txtBox.Text == "0")
                txtBox.Text = "";
            txtBox.Text += btn.Text;
        }

        //
        //fun_btn_Click
        //
        private void fun_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblEquil.Text = "";

            try
            {
                if (lblOP.Text == "")
                {
                 result = double.Parse(txtBox.Text);
                 lblFN1.Text = result + "";
                 lblOP.Text = btn.Text;
                 txtBox.Text = "0";
                }
                else if (lblOP.Text != "")
                {
                    if (lblOP.Text == "+")
                    {
                        result += double.Parse(txtBox.Text);
                        lblFN1.Text = result + "";
                        lblOP.Text = btn.Text;
                        txtBox.Text = "0";
                    }
                    else if (lblOP.Text == "-")
                    {
                        result -= double.Parse(txtBox.Text);
                        lblFN1.Text = result + "";
                        lblOP.Text = btn.Text;
                        txtBox.Text = "0";
                    }
                    else if (lblOP.Text == "/")
                    {
                        if (txtBox.Text == "0")
                        {
                            lblOP.Text = btn.Text;
                            return;
                        }
                        result /= double.Parse(txtBox.Text);
                        result = Math.Round(result, 3);
                        lblFN1.Text = result + "";
                        lblOP.Text = btn.Text;
                        txtBox.Text = "0";
                    }
                    else if (lblOP.Text == "*")
                    {
                        if (txtBox.Text == "0")
                        {
                            lblOP.Text = btn.Text;
                            return;
                        }
                        result *= double.Parse(txtBox.Text);
                        result = Math.Round(result, 3);
                        lblFN1.Text = result + "";
                        lblOP.Text = btn.Text;
                        txtBox.Text = "0";
                    }
                    
                }
            }
            catch { }
            /*finally
            {
                 //lblOP.Text = btn.Text;
            }*/
        }
        //
        //btnDEL_Click
        //
        private void btnDEL_Click(object sender, EventArgs e)
        {
            try
            {
                lblEquil.Text = "";
                if (txtBox.Text != "0")
                {
                    txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 1);
                    if(txtBox.Text.Length == 0)
                        txtBox.Text = "0";
                }
                else
                    txtBox.Text = "0";
            }
            catch { }
            
        }
        //
        //btnClear_Click
        //
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBox.Text = "0";
            lblFN1.Text = "";
            lblFN2.Text = "";
            lblOP.Text = "";
            lblEquil.Text = "";
        }
        //
        //btnEquil_Click
        //
        private void btnEquil_Click(object sender, EventArgs e)
        {
            try 
            {
                if (lblOP.Text == "+")
                {
                    result = double.Parse(lblFN1.Text) + double.Parse(txtBox.Text);
                    result = Math.Round(result, 3);
                    lblEquil.Text = lblFN1.Text + "  " + lblOP.Text + "  " + txtBox.Text + "  =  " + result;
                }
                else if (lblOP.Text == "-")
                {
                    result = double.Parse(lblFN1.Text) - double.Parse(txtBox.Text);
                    result = Math.Round(result, 3);
                    lblEquil.Text = lblFN1.Text + "  " + lblOP.Text + "  " + txtBox.Text + "  =  " + result;
                }
                else if (lblOP.Text == "*")
                {
                    result = double.Parse(lblFN1.Text) * double.Parse(txtBox.Text);
                    result = Math.Round(result, 3);
                    lblEquil.Text = lblFN1.Text + "  " + lblOP.Text + "  " + txtBox.Text + "  =  " + result;
                }
                else if (lblOP.Text == "/")
                {
                    if(txtBox.Text == "0")
                    {
                        MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    result = double.Parse(lblFN1.Text) / double.Parse(txtBox.Text);
                    result = Math.Round(result, 3);
                    lblEquil.Text = lblFN1.Text +"  "+ lblOP.Text + "  " + txtBox.Text + "  =  " + result;
                }
            }
            catch { }

            txtBox.Text = "0";
            lblFN1.Text = "";
            lblFN2.Text = "";
            lblOP.Text = "";
        }
    }
}
