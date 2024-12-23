using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class ApproveNGORegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetNGO_Pending();
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {

                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();
                    TableHeaderCell hc6 = new TableHeaderCell();
                    TableHeaderCell hc7 = new TableHeaderCell();


                    hc1.Text = "Sl No";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Name";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Mobile No";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Address";
                    hr.Cells.Add(hc4);
                    hc5.Text = "";
                    hr.Cells.Add(hc5);
                    hc6.Text = "";
                    hr.Cells.Add(hc6);



                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblSlNo = new Label();
                        lblSlNo.Text = (i + 1).ToString();
                        TableCell SlNo = new TableCell();
                        SlNo.Controls.Add(lblSlNo);

                        Label lblName = new Label();
                        lblName.Text = tab.Rows[i]["Name"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);

                        Label lblMobileNo = new Label();
                        lblMobileNo.Text = tab.Rows[i]["MobileNo"].ToString();
                        TableCell MobileNo = new TableCell();
                        MobileNo.Controls.Add(lblMobileNo);

                        Label lblAddress = new Label();
                        lblAddress.Text = tab.Rows[i]["Address"].ToString();
                        TableCell Address = new TableCell();
                        Address.Controls.Add(lblAddress);



                        LinkButton Approve = new LinkButton();
                        Approve.Text = "Approve";
                        Approve.ID = "lnkApprove" + i.ToString();
                        Approve.CommandArgument = tab.Rows[i]["NGOId"].ToString();
                        Approve.Click += new EventHandler(Approve_Click);

                        TableCell ApproveCell = new TableCell();
                        ApproveCell.Controls.Add(Approve);

                        LinkButton Reject = new LinkButton();
                        Reject.Text = "Reject";
                        Reject.ID = "lnkReject" + i.ToString();
                        Reject.CommandArgument = tab.Rows[i]["NGOId"].ToString();
                        Reject.Click += new EventHandler(Reject_Click);

                        TableCell RejectCell = new TableCell();
                        RejectCell.Controls.Add(Reject);



                        row.Controls.Add(SlNo);
                        row.Controls.Add(Name);
                        row.Controls.Add(MobileNo);
                        row.Controls.Add(Address);
                        row.Controls.Add(ApproveCell);
                        row.Controls.Add(RejectCell);
                        Table1.Controls.Add(row);

                    }
                }
                else
                {
                    //lblMsg.Text = "No Record Found";
                }
            }
            catch
            {

            }
        }

        void Reject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int NGOId = int.Parse(lnk.CommandArgument);
            MyConnection obj = new MyConnection();
            string result = obj.ApproveNGORegister(NGOId, "Reject");
            if (result == "1")
            {
                LoadData();
            }
        }

        void Approve_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int NGOId = int.Parse(lnk.CommandArgument);
            MyConnection obj = new MyConnection();
            string result = obj.ApproveNGORegister(NGOId, "Approve");
            if (result == "1")
            {
                LoadData();
            }
        }
    }
}