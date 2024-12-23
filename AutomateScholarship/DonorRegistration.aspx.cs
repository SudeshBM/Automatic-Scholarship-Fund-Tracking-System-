using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SMS_LIB;

namespace AutomateScholarship
{
    public partial class DonorRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SMS _smsClassObj = null;
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            Random rnd = new Random();
            int DonorId = (rnd.Next(100000, 999999) + DateTime.Now.Second);
            string Password = (rnd.Next(1000, 9999) + DateTime.Now.Second).ToString();
            string result = obj.DonorRegister(DonorId,ddlDonorType.SelectedItem.Text, txtName.Text, Password, txtMobileNo.Text, txtEmailId.Text, txtAddress.Text);
            if (result == "1")
            {
                _smsClassObj = new SMS_LIB.SMS(ConfigurationManager.AppSettings["SmartCardPort"].ToString());
                _smsClassObj.OpenPort();
                string Message = "Login Credentials Donor Id:" + DonorId + " & Password:" + Password;
                _smsClassObj.SendSMS(txtMobileNo.Text, Message);
                _smsClassObj.ClosePort();
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Donor Register Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Donor MobileNo Already Registered";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == "0")
            {


                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Donor Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}