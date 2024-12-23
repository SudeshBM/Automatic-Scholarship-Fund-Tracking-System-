using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AutomateScholarship
{
    public partial class ViewDonorWallet : System.Web.UI.Page
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
                tab = obj.GetDonorWallet(int.Parse(Session["UserId"].ToString()));
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
                    hc2.Text = "LogDate";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Amount";
                    hr.Cells.Add(hc3);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblSlNo = new Label();
                        lblSlNo.Text = (i + 1).ToString();
                        TableCell SlNo = new TableCell();
                        SlNo.Controls.Add(lblSlNo);

                        Label lblLogDate = new Label();
                        lblLogDate.Text = tab.Rows[i]["LogDate"].ToString();
                        TableCell LogDate = new TableCell();
                        LogDate.Controls.Add(lblLogDate);

                        Label lblAmount = new Label();
                        lblAmount.Text = tab.Rows[i]["Amount"].ToString();
                        TableCell Amount = new TableCell();
                        Amount.Controls.Add(lblAmount);


                        row.Controls.Add(SlNo);
                        row.Controls.Add(LogDate);
                        row.Controls.Add(Amount);
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
    }
}