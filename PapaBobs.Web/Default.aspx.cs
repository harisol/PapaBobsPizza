using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // clear the error message if user modify the pizza
                validationLabel.Text = "";
                validationLabel.Visible = false;
            }
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (!textBoxDataIsValid())
            {
                return;
            }

            var orderDTO = buildOrder();
            Domain.OrderManager.CreateOrder(orderDTO);

            //validationLabel.Text = "Order Created!";
            //validationLabel.Visible = true;

            Response.Redirect("Success.aspx");
        }

        protected void recalculateTotalCost(object sender, EventArgs e)
        {
            if (sizeDropDown.SelectedValue == "")
                return;
            if (crustDropDown.SelectedValue == "")
                return;

            var order = buildOrder();
            var cost = Domain.PizzaPriceManager.CalculateCost(order);
            resultLabel.Text = string.Format("<h3>{0:C}</h3>", cost);
        }

        private DTO.OrderDTO buildOrder()
        {
            DTO.OrderDTO orderDTO = new DTO.OrderDTO();

            orderDTO.Size = determineSize();
            orderDTO.Crust = determineCrust();
            orderDTO.Pepperoni = pepperoniCheckBox.Checked;
            orderDTO.Sausage = sausageCheckBox.Checked;
            orderDTO.GreenPeppers = greenPepperCheckBox.Checked;
            orderDTO.Onions = onionCheckBox.Checked;
            orderDTO.Name = nameTextBox.Text;
            orderDTO.Address = addressTextBox.Text;
            orderDTO.ZipCode = zipCodeTextBox.Text;
            orderDTO.Phone = phoneTextBox.Text;
            orderDTO.PaymentType = determinePayment();

            return orderDTO;
        }

        private DTO.Enums.SizeType determineSize()
        {
            DTO.Enums.SizeType size;

            if (!Enum.TryParse(sizeDropDown.SelectedValue, out size))
            {
                throw new Exception("Could not determine Pizza size");
            }

            return size;
        }

        private DTO.Enums.CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;

            if (!Enum.TryParse(crustDropDown.SelectedValue, out crust))
            {
                throw new Exception("Could not determine Pizza crust");
            }

            return crust;
        }

        private DTO.Enums.PaymentType determinePayment()
        {
            DTO.Enums.PaymentType payment;

            if (cashRadio.Checked)
                payment = DTO.Enums.PaymentType.Cash;
            else
                payment = DTO.Enums.PaymentType.Credit;

            return payment;
        }

        private bool textBoxDataIsValid()
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("name");
                return false;
            }
            else if (addressTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("address");
                return false;
            }
            else if (zipCodeTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("zip code");
                return false;
            }
            else if (phoneTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("phone number");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void textBoxValidationError(string errorType)
        {
            string errorMessage = "";
            errorMessage += String.Format("<strong>Please enter a {0}.<strong>", errorType);
            validationLabel.Text = errorMessage;
            validationLabel.Visible = true;
        }

    }
}