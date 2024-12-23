using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutomateScholarship
{
    public partial class AddDonorWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.AddDonorWallet(int.Parse(Session["UserId"].ToString()), int.Parse(txtAmount.Text));
            if (result == "1")
            {
                txtAmount.Text = "";
                lblMsg.Text = "Amount Added to Wallet Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}