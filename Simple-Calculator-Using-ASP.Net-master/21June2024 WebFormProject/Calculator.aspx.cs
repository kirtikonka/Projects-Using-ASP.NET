using System;

namespace _21June2024_WebFormProject
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValidInputs())
            {
                double number1 = Convert.ToDouble(txtNumber1.Text);
                double number2 = Convert.ToDouble(txtNumber2.Text);
                string operation = ddlOperation.SelectedValue;

                double result = 0;

                switch (operation)
                {
                    case "add":
                        result = number1 + number2;
                        break;
                    case "subtract":
                        result = number1 - number2;
                        break;
                    case "multiply":
                        result = number1 * number2;
                        break;
                    case "divide":
                        if (number2 != 0)
                        {
                            result = number1 / number2;
                        }
                        else
                        {
                            lblResult.Text = "Cannot divide by zero";
                            return;
                        }
                        break;
                    default:
                        lblResult.Text = "Invalid operation";
                        return;
                }

                lblResult.Text = $"Result: {result}";
            }
            else
            {
                lblResult.Text = "Please enter valid numbers";
            }
        }

        private bool IsValidInputs()
        {
            double number1, number2;
            if (double.TryParse(txtNumber1.Text, out number1) && double.TryParse(txtNumber2.Text, out number2))
            {
                return true;
            }
            return false;
        }
    }
}