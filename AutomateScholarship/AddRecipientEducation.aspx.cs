using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutomateScholarship
{
    public partial class AddRecipientEducation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.RecipientEducation(int.Parse(Session["UserId"].ToString()), txtIName.Text, txtEducation.Text, txtYearPass.Text, txtPercentage.Text);
            if (result == "1")
            {
                txtIName.Text = txtEducation.Text = txtYearPass.Text = txtPercentage.Text = "";
                lblMsg.Text = "Education Details Added Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtIName.Text = txtEducation.Text = txtYearPass.Text = txtPercentage.Text = "";
                lblMsg.Text = "Education Details Added Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}