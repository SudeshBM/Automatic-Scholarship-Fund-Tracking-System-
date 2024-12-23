using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class DonorPayNGO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetNGO();
                ddlNGO.DataSource = tab;
                ddlNGO.DataTextField = "Name";
                ddlNGO.DataValueField = "NGOId";
                ddlNGO.DataBind();
                ddlNGO.Items.Insert(0, "--Select--");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.DonorPayNGO(int.Parse(Session["UserId"].ToString()),int.Parse(ddlNGO.SelectedItem.Value), int.Parse(txtAmount.Text));
            if (result == "1")
            {
                ddlNGO.SelectedIndex = 0;
                txtAmount.Text = "";
                lblMsg.Text = "Amount Added to Wallet Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}