using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class RecipientPostFeedBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel2.Visible = false;
            }
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetRecipientScholarship(int.Parse(Session["UserId"].ToString()));
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

                        

                        LinkButton PostFeedBack = new LinkButton();
                        PostFeedBack.Text = "Post FeedBack";
                        PostFeedBack.ID = "lnkPostFeedBack" + i.ToString();
                        PostFeedBack.CommandArgument = tab.Rows[i]["ASId"].ToString();
                        PostFeedBack.Click += new EventHandler(PostFeedBack_Click);

                        TableCell PostFeedBackCell = new TableCell();
                        PostFeedBackCell.Controls.Add(PostFeedBack);



                        row.Controls.Add(Name);
                        row.Controls.Add(SType);
                        row.Controls.Add(Description);
                        row.Controls.Add(Amount);
                        row.Controls.Add(PostFeedBackCell);
                        Table1.Controls.Add(row);

                    }
                }
                else
                {
                    lblMsg.Text = "No Record Found";
                }
            }
            catch
            {

            }
        }

        static int ASId = 0;
        void PostFeedBack_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Panel2.Visible = true;
            LinkButton lnk = (LinkButton)sender;
            ASId = int.Parse(lnk.CommandArgument);
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.PostFeedback(ASId, txtFeedback.Text);
            if (result == "1")
            {
                txtFeedback.Text = "";
                Panel2.Visible = false;
                ASId = 0;
                lblMsg.Text = "Feedback Posted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                txtFeedback.Text = "";
                Panel2.Visible = false;
                ASId = 0;
                lblMsg.Text = "Feedback Posted Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}