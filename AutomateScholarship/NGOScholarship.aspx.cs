using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class NGOScholarship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetNGOScholarship_NGO(int.Parse(Session["UserId"].ToString()));
                ddlAcademic.DataSource = tab;
                ddlAcademic.DataTextField = "SType";
                ddlAcademic.DataValueField = "SAId";
                ddlAcademic.DataBind();
                ddlAcademic.Items.Insert(0, "--Select--");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.CreateScholarShip(int.Parse(ddlAcademic.SelectedItem.Value),  txtSD.Text, txtED.Text);
            if (result == "1")
            {
                ddlAcademic.SelectedIndex = 0;
                txtSD.Text = txtED.Text = "";
                lblMsg.Text = "Scholarship Created Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                ddlAcademic.SelectedIndex = 0;
                txtSD.Text = txtED.Text = "";
                lblMsg.Text = "Scholarship Created Already,Select Academic!!!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == "0")
            {

                ddlAcademic.SelectedIndex = 0;
                txtSD.Text = txtED.Text = "";
                lblMsg.Text = "Scholarship Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}