using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class ApplyScholarship : System.Web.UI.Page
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
            LoadData();
        }

        protected void ddlNGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {

            }
        }
        private void LoadData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetNGOScholarshipDetails_NGO(int.Parse(ddlNGO.SelectedItem.Value));
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

                    hc1.Text = "Academic Name";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Description";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Scholarship Amount";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Apply Start Date";
                    hr.Cells.Add(hc4);
                    hc5.Text = "Apply Close Date";
                    hr.Cells.Add(hc5);
                    hc6.Text = "";
                    hr.Cells.Add(hc6);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblName = new Label();
                        lblName.Text = tab.Rows[i]["SType"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);


                        Label lblDescription = new Label();
                        lblDescription.Text = tab.Rows[i]["Description"].ToString();
                        TableCell Description = new TableCell();
                        Description.Controls.Add(lblDescription);

                        Label lblAmount = new Label();
                        lblAmount.Text = tab.Rows[i]["Amount"].ToString();
                        TableCell Amount = new TableCell();
                        Amount.Controls.Add(lblAmount);

                        Label lblSSD = new Label();
                        lblSSD.Text = tab.Rows[i]["SSD"].ToString();
                        TableCell SSD = new TableCell();
                        SSD.Controls.Add(lblSSD);

                        Label lblSCD = new Label();
                        lblSCD.Text = tab.Rows[i]["SCD"].ToString();
                        TableCell SCD = new TableCell();
                        SCD.Controls.Add(lblSCD);

                        LinkButton Apply = new LinkButton();
                        Apply.Text = "Apply";
                        Apply.ID = "lnkApply" + i.ToString();
                        Apply.CommandArgument = tab.Rows[i]["SHId"].ToString() + "," + tab.Rows[i]["SSD"].ToString() + "," + tab.Rows[i]["SCD"].ToString();
                        Apply.Click += new EventHandler(Apply_Click);

                        TableCell ApplyCell = new TableCell();
                        ApplyCell.Controls.Add(Apply);



                        row.Controls.Add(Name);
                        row.Controls.Add(Description);
                        row.Controls.Add(Amount);
                        row.Controls.Add(SSD);
                        row.Controls.Add(SCD);
                        row.Controls.Add(ApplyCell);
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

        void Apply_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string SSD = lnk.CommandArgument.Split(',')[1];
            string SCD = lnk.CommandArgument.Split(',')[2];

            if (DateTime.Now < Convert.ToDateTime(SSD) || DateTime.Now > Convert.ToDateTime(SCD))
            {
                lblMsg.Text = "Check Scholarship Start Date/Close Date";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                MyConnection obj = new MyConnection();
                string res = obj.ApplyScholarShip(int.Parse(lnk.CommandArgument.Split(',')[0]), int.Parse(Session["UserId"].ToString()));
                if (res == "1")
                {
                    lblMsg.Text = "Scholarship Apply Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else if (res == "2")
                {
                    lblMsg.Text = "Scholarship Apply Already";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            
        }
    }
}