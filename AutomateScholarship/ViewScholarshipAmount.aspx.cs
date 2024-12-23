using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class ViewScholarshipAmount : System.Web.UI.Page
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
                tab = obj.GetNGO_ScholarShip(int.Parse(Session["UserId"].ToString()));
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {

                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();


                    hc1.Text = "Sl No";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Academic";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Description";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Amount";
                    hr.Cells.Add(hc4);
                    hc5.Text = "";
                    hr.Cells.Add(hc5);



                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblSlNo = new Label();
                        lblSlNo.Text = (i + 1).ToString();
                        TableCell SlNo = new TableCell();
                        SlNo.Controls.Add(lblSlNo);

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



                        LinkButton Edit = new LinkButton();
                        Edit.Text = "Edit";
                        Edit.ID = "lnkEdit" + i.ToString();
                        Edit.CommandArgument = tab.Rows[i]["SAId"].ToString();
                        Edit.Click += new EventHandler(Edit_Click);

                        TableCell EditCell = new TableCell();
                        EditCell.Controls.Add(Edit);

                        
                        row.Controls.Add(SlNo);
                        row.Controls.Add(SType);
                        row.Controls.Add(Description);
                        row.Controls.Add(Amount);
                        row.Controls.Add(EditCell);
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

        void Edit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Response.Redirect("AddScholarshipAmount.aspx?SAId="+lnk.CommandArgument);
        }
    }
}