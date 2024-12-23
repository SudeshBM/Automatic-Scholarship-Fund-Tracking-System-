using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class NGOViewRScholarship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
            LoadData();
            LoadFBData();
        }
        private void LoadData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetScholarship_NGO(int.Parse(Session["UserId"].ToString()));
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    Panel1.Visible = true;
                    lblMsg.Text = "";
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();
                    TableHeaderCell hc6 = new TableHeaderCell();

                    hc1.Text = "NGO Name";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Academic Name";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Description";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Scholarship Amount";
                    hr.Cells.Add(hc4);
                    hc5.Text = "";
                    hr.Cells.Add(hc5);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblName = new Label();
                        lblName.Text = tab.Rows[i]["Name"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);

                        Label lblSType = new Label();
                        lblSType.Text = tab.Rows[i]["SType"].ToString();
                        TableCell SType = new TableCell();
                        SType.Controls.Add(lblSType);


                        Label lblDescription = new Label();
                        lblDescription.Text = tab.Rows[i]["Description"].ToString();
                        TableCell Description = new TableCell();
                        Description.Controls.Add(lblDescription);

                        Label lblAmount = new Label();
                        lblAmount.Text = tab.Rows[i]["Amount"].ToString();
                        TableCell Amount = new TableCell();
                        Amount.Controls.Add(lblAmount);



                        LinkButton ViewFeedBack = new LinkButton();
                        ViewFeedBack.Text = "View FeedBack";
                        ViewFeedBack.ID = "lnkViewFeedBack" + i.ToString();
                        ViewFeedBack.CommandArgument = tab.Rows[i]["ASId"].ToString();
                        ViewFeedBack.Click += new EventHandler(ViewFeedBack_Click);

                        TableCell ViewFeedBackCell = new TableCell();
                        ViewFeedBackCell.Controls.Add(ViewFeedBack);



                        row.Controls.Add(Name);
                        row.Controls.Add(SType);
                        row.Controls.Add(Description);
                        row.Controls.Add(Amount);
                        row.Controls.Add(ViewFeedBackCell);
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

        static int ASId = 0;
        void ViewFeedBack_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton lnk = (LinkButton)sender;
            ASId = int.Parse(lnk.CommandArgument);
            LoadFBData();
        }

        private void LoadFBData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetFB(ASId);
                Table2.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    Panel2.Visible = true;
                    lblMsg.Text = "";
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();
                    TableHeaderCell hc6 = new TableHeaderCell();

                    hc1.Text = "Post Date";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Feed Back";
                    hr.Cells.Add(hc2);
                    hc3.Text = "";
                    hr.Cells.Add(hc3);

                    Table2.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblPostDate = new Label();
                        lblPostDate.Text = tab.Rows[i]["PostDate"].ToString();
                        TableCell PostDate = new TableCell();
                        PostDate.Controls.Add(lblPostDate);

                        Label lblFeedBack = new Label();
                        lblFeedBack.Text = tab.Rows[i]["FeedBack"].ToString();
                        TableCell FeedBack = new TableCell();
                        FeedBack.Controls.Add(lblFeedBack);



                        LinkButton ViewRecipient = new LinkButton();
                        ViewRecipient.Text = "View Recipient";
                        ViewRecipient.ID = "lnkViewRecipient" + i.ToString();
                        ViewRecipient.CommandArgument = tab.Rows[i]["ASId"].ToString();
                        ViewRecipient.Click += new EventHandler(ViewRecipient_Click);

                        TableCell ViewRecipientCell = new TableCell();
                        ViewRecipientCell.Controls.Add(ViewRecipient);



                        row.Controls.Add(PostDate);
                        row.Controls.Add(FeedBack);
                        row.Controls.Add(ViewRecipientCell);
                        Table2.Controls.Add(row);

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

        void ViewRecipient_Click(object sender, EventArgs e)
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                LinkButton lnk = (LinkButton)sender;
                tab = obj.GetScholarship_Recipient(int.Parse(lnk.CommandArgument));
                Table3.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    Panel3.Visible = true;
                    lblMsg.Text = "";
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();


                    hc1.Text = "Recipient Name";
                    hr.Cells.Add(hc1);
                    hc2.Text = "MobileNo";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Address";
                    hr.Cells.Add(hc3);

                    Table3.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

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

                        row.Controls.Add(Name);
                        row.Controls.Add(MobileNo);
                        row.Controls.Add(Address);
                        Table3.Controls.Add(row);

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
    }
}