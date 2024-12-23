using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

namespace AutomateScholarship
{
    public partial class RecipientViewUploadFile : System.Web.UI.Page
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
                tab = obj.GetUploadFile_RId(int.Parse(Session["UserId"].ToString()));
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
                    hc2.Text = "File Name";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Upload Date";
                    hr.Cells.Add(hc3);
                    hc4.Text = "";
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

                        Label lblFileName = new Label();
                        lblFileName.Text = tab.Rows[i]["FileName"].ToString();
                        TableCell FileName = new TableCell();
                        FileName.Controls.Add(lblFileName);

                        Label lblUploadDate = new Label();
                        lblUploadDate.Text = tab.Rows[i]["UploadDate"].ToString();
                        TableCell UploadDate = new TableCell();
                        UploadDate.Controls.Add(lblUploadDate);

                        LinkButton Download = new LinkButton();
                        Download.Text = "Download File";
                        Download.ID = "lnkDownload" + i.ToString();
                        Download.CommandArgument = tab.Rows[i]["FilePath"].ToString() + "," + tab.Rows[i]["FKey2"].ToString();
                        Download.Click += new EventHandler(Download_Click);

                        TableCell DownloadCell = new TableCell();
                        DownloadCell.Controls.Add(Download);



                        LinkButton Deactive = new LinkButton();
                        Deactive.Text = "Deactive";
                        Deactive.ID = "lnkDeactive" + i.ToString();
                        Deactive.CommandArgument = tab.Rows[i]["UFId"].ToString();
                        Deactive.Click += new EventHandler(Deactive_Click);

                        TableCell DeactiveCell = new TableCell();
                        DeactiveCell.Controls.Add(Deactive);


                        row.Controls.Add(SlNo);
                        row.Controls.Add(FileName);
                        row.Controls.Add(UploadDate);
                        row.Controls.Add(DownloadCell);
                        row.Controls.Add(DeactiveCell);
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

        void Deactive_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            MyConnection obj = new MyConnection();
            string result = obj.DeactiveUploadFile(int.Parse(lnk.CommandArgument));
            if (result == "1")
            {
                LoadData();
            }
        }
        Tuple<byte[], byte[]> T = null;
        AmazonS3Client _s3ClientObj = null;
        void Download_Click(object sender, EventArgs e)
        {
            _s3ClientObj = new AmazonS3Client("AKIA2PAQROQSYOJ52K4Z", "DlyNZC62y0RQx1HSm+65xS7Dwfosd4xD1VDo6Mn3", Amazon.RegionEndpoint.USEast1);
            LinkButton lnk = (LinkButton)sender;
            string fpath = "~/StudentFile/" + lnk.CommandArgument.ToString().Split(',')[0].Split('/')[1];
            GetObjectResponse _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = lnk.CommandArgument.ToString().Split(',')[0].Split('/')[0], Key = lnk.CommandArgument.ToString().Split(',')[0].Split('/')[1] });
            _responseObj.WriteResponseStreamToFile(Server.MapPath(fpath));

            byte[] key = ASCIIEncoding.ASCII.GetBytes(lnk.CommandArgument.ToString().Split(',')[1]);
            SymmetricCryptoClass.Decryption(Server.MapPath(fpath), key.ToString());
            System.Diagnostics.Process.Start(Server.MapPath(fpath));
        }
    }
}