using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class AddScholarshipAmount : System.Web.UI.Page
    {
        static int SAId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SAId"] != null)
                {
                    SAId = int.Parse(Request.QueryString["SAId"]);
                    LoadData();
                }
            }
        }
        public void LoadData()
        {
            try
            {
                btnSubmit.Text = "Update";
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.Get_ScholarShip(SAId);
                ddlAcademic.Items.FindByText(tab.Rows[0]["SType"].ToString()).Selected = true;
                txtDescription.Text = tab.Rows[0]["Description"].ToString();
                txtAmount.Text = tab.Rows[0]["Amount"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            if (btnSubmit.Text == "Update")
            {
                string result = obj.UpdateScholarship(SAId, int.Parse(txtAmount.Text), txtDescription.Text);
                if (result == "1")
                {

                    ddlAcademic.SelectedIndex = 0;
                    txtAmount.Text = txtDescription.Text = "";
                    lblMsg.Text = "Scholarship Amount Updated Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    btnSubmit.Text="Submit";
                }
            }
            else
            {
                string result = obj.AddScholarshipAmount(int.Parse(Session["UserId"].ToString()), ddlAcademic.SelectedItem.Text, txtDescription.Text, int.Parse(txtAmount.Text));
                if (result == "1")
                {

                    ddlAcademic.SelectedIndex = 0;
                    txtAmount.Text = txtDescription.Text = "";
                    lblMsg.Text = "Scholarship Amount Added Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else if (result == "2")
                {
                    ddlAcademic.SelectedIndex = 0;
                    txtAmount.Text = txtDescription.Text = "";
                    lblMsg.Text = "Scholarship Amount Added Already";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else if (result == "0")
                {
                    ddlAcademic.SelectedIndex = 0;
                    txtAmount.Text = txtDescription.Text = "";
                    lblMsg.Text = "Scholarship Amount Creation Error";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}