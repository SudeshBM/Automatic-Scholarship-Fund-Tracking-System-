using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using Amazon.Runtime;
using Amazon.S3.Transfer;
using System.Xml;
using Amazon.S3.IO;
using System.Text;
using System.Configuration;
using SMS_LIB;


namespace AutomateScholarship
{
    public partial class ApproveScholarship : System.Web.UI.Page
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

                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
                lblMsg.Text = "";

                SHId = 0;
                RId = 0;
            }
            LoadData();
            LoadRData();
            LoadREData();
            LoadDFData();
        }

        protected void ddlAcademic_SelectedIndexChanged(object sender, EventArgs e)
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
                tab = obj.GetNGOScholarShip_SAId(int.Parse(ddlAcademic.SelectedItem.Value));
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

                        LinkButton ViewRecipient = new LinkButton();
                        ViewRecipient.Text = "View Recipient";
                        ViewRecipient.ID = "lnkViewRecipient" + i.ToString();
                        ViewRecipient.CommandArgument = tab.Rows[i]["SHId"].ToString();
                        ViewRecipient.Click += new EventHandler(ViewRecipient_Click);

                        TableCell ViewRecipientCell = new TableCell();
                        ViewRecipientCell.Controls.Add(ViewRecipient);



                        row.Controls.Add(Name);
                        row.Controls.Add(Description);
                        row.Controls.Add(Amount);
                        row.Controls.Add(SSD);
                        row.Controls.Add(SCD);
                        row.Controls.Add(ViewRecipientCell);
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

        static int SHId = 0;
        void ViewRecipient_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            SHId =int.Parse(lnk.CommandArgument);
            LoadRData();
        }

        private void LoadRData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetRecipientApply(SHId);
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
                    TableHeaderCell hc7 = new TableHeaderCell();
                    TableHeaderCell hc8 = new TableHeaderCell();

                    hc1.Text = "Recipient Name";
                    hr.Cells.Add(hc1);
                    hc2.Text = "MobileNo";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Address";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Photo";
                    hr.Cells.Add(hc4);
                    hc5.Text = "";
                    hr.Cells.Add(hc5);
                    hc6.Text = "";
                    hr.Cells.Add(hc6);
                    hc7.Text = "";
                    hr.Cells.Add(hc7);
                    hc8.Text = "";
                    hr.Cells.Add(hc8);

                    Table2.Rows.Add(hr);
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

                        Image img = new Image();
                        img.ImageUrl = tab.Rows[i]["PhotoPath"].ToString();
                        TableCell imgcell = new TableCell();
                        imgcell.Controls.Add(img);

                        

                        LinkButton ViewEduction = new LinkButton();
                        ViewEduction.Text = "View Education";
                        ViewEduction.ID = "lnkViewEduction" + i.ToString();
                        ViewEduction.CommandArgument = tab.Rows[i]["RecipientId"].ToString();
                        ViewEduction.Click += new EventHandler(ViewEduction_Click);

                        TableCell ViewEductionCell = new TableCell();
                        ViewEductionCell.Controls.Add(ViewEduction);

                        LinkButton ViewFile = new LinkButton();
                        ViewFile.Text = "View Files";
                        ViewFile.ID = "lnkViewFiles" + i.ToString();
                        ViewFile.CommandArgument = tab.Rows[i]["RecipientId"].ToString();
                        ViewFile.Click += new EventHandler(ViewFile_Click);

                        TableCell FilesCell = new TableCell();
                        FilesCell.Controls.Add(ViewFile);

                        LinkButton Approve = new LinkButton();
                        Approve.Text = "Approve";
                        Approve.ID = "lnkApprove" + i.ToString();
                        Approve.CommandArgument = tab.Rows[i]["RecipientId"].ToString() + "," + SHId;
                        Approve.Click += new EventHandler(Approve_Click);

                        TableCell ApproveCell = new TableCell();
                        ApproveCell.Controls.Add(Approve);

                        LinkButton Reject = new LinkButton();
                        Reject.Text = "Reject";
                        Reject.ID = "lnkReject" + i.ToString();
                        Reject.CommandArgument = tab.Rows[i]["RecipientId"].ToString() + "," + SHId;
                        Reject.Click += new EventHandler(Reject_Click);

                        TableCell RejectCell = new TableCell();
                        RejectCell.Controls.Add(Reject);

                        row.Controls.Add(Name);
                        row.Controls.Add(MobileNo);
                        row.Controls.Add(Address);
                        row.Controls.Add(imgcell);
                        row.Controls.Add(ViewEductionCell);
                        row.Controls.Add(FilesCell);
                        row.Controls.Add(ApproveCell);
                        row.Controls.Add(RejectCell);
                        Table2.Controls.Add(row);

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
        SMS _smsClassObj = null;
        
        void Reject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RId = int.Parse(lnk.CommandArgument.Split(',')[0]);
            SHId = int.Parse(lnk.CommandArgument.Split(',')[1]);
            Panel5.Visible = true;
        }

        void Approve_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton lnk = (LinkButton)sender;
            RId = int.Parse(lnk.CommandArgument.Split(',')[0]);
            SHId = int.Parse(lnk.CommandArgument.Split(',')[1]);
            MyConnection obj = new MyConnection();
            string result = obj.NGOApproveScholarship(int.Parse(Session["UserId"].ToString()),SHId, RId);
            if (result == "1")
            {
                obj = new MyConnection();
                DataTable tabmp = new DataTable();
                tabmp = obj.GetRId_MobileNo(RId);
                _smsClassObj = new SMS_LIB.SMS(ConfigurationManager.AppSettings["SmartCardPort"].ToString());
                _smsClassObj.OpenPort();

                string Message = "Apply Scholarship Approved Successfully";
                _smsClassObj.SendSMS(tabmp.Rows[0]["MobileNo"].ToString(), Message);
                _smsClassObj.ClosePort();
                RId = 0;
                SHId = 0;
                Response.Redirect("ApproveScholarship.aspx");
            }
            else
            {
                lblMsg.Text = "Scholarship Reject Log Already!!!";
            }
        }

        
        void ViewEduction_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton lnk = (LinkButton)sender;
            RId = int.Parse(lnk.CommandArgument);
            LoadREData();
        }

        static int RId = 0;
        private void LoadREData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetRecipientEducation(RId);
                Table3.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    Panel3.Visible = true;
                    lblMsg.Text = "";
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();

                    hc1.Text = "School/College Name";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Education";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Year Pass";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Percentage";
                    hr.Cells.Add(hc4);

                    Table3.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblName = new Label();
                        lblName.Text = tab.Rows[i]["IName"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);


                        Label lblEducation = new Label();
                        lblEducation.Text = tab.Rows[i]["Education"].ToString();
                        TableCell Education = new TableCell();
                        Education.Controls.Add(lblEducation);

                        Label lblYearPass = new Label();
                        lblYearPass.Text = tab.Rows[i]["YearPass"].ToString();
                        TableCell YearPass = new TableCell();
                        YearPass.Controls.Add(lblYearPass);

                        Label lblPercentage = new Label();
                        lblPercentage.Text = tab.Rows[i]["Percentage"].ToString();
                        TableCell Percentage = new TableCell();
                        Percentage.Controls.Add(lblPercentage);


                        row.Controls.Add(Name);
                        row.Controls.Add(Education);
                        row.Controls.Add(YearPass);
                        row.Controls.Add(Percentage);
                        Table3.Controls.Add(row);

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

        void ViewFile_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RId = int.Parse(lnk.CommandArgument);
            LoadDFData();
        }
        private void LoadDFData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetUploadFileRId(RId);
                Table4.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    Panel4.Visible = true;
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();


                    hc1.Text = "Sl No";
                    hr.Cells.Add(hc1);
                    hc2.Text = "File Name";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Upload Date";
                    hr.Cells.Add(hc3);
                    hc4.Text = "";
                    hr.Cells.Add(hc4);


                    Table4.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblSlNo = new Label();
                        lblSlNo.Text = (i + 1).ToString();
                        TableCell SlNo = new TableCell();
                        SlNo.Controls.Add(lblSlNo);

                        Label lblName = new Label();
                        lblName.Text = tab.Rows[i]["FileName"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);

                        Label lblTDate = new Label();
                        lblTDate.Text = tab.Rows[i]["UploadDate"].ToString();
                        TableCell TDate = new TableCell();
                        TDate.Controls.Add(lblTDate);

                        LinkButton Download = new LinkButton();
                        Download.Text = "Download File";
                        Download.ID = "lnkDownload" + i.ToString();
                        Download.CommandArgument = tab.Rows[i]["FilePath"].ToString() + "," + tab.Rows[i]["FKey2"].ToString();
                        Download.Click += new EventHandler(Download_Click);

                        TableCell DownloadCell = new TableCell();
                        DownloadCell.Controls.Add(Download);


                        row.Controls.Add(SlNo);
                        row.Controls.Add(Name);
                        row.Controls.Add(TDate);
                        row.Controls.Add(DownloadCell);
                        Table4.Controls.Add(row);

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
        AmazonS3Client _s3ClientObj = null;
        void Download_Click(object sender, EventArgs e)
        {
            _s3ClientObj = new AmazonS3Client("AKIA2PAQROQSYOJ52K4Z", "DlyNZC62y0RQx1HSm+65xS7Dwfosd4xD1VDo6Mn3", Amazon.RegionEndpoint.USEast1);
            LinkButton lnk = (LinkButton)sender;
            string fpath = "~/blockchainfile/" + lnk.CommandArgument.ToString().Split(',')[0].Split('/')[1];
            GetObjectResponse _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = lnk.CommandArgument.ToString().Split(',')[0].Split('/')[0], Key = lnk.CommandArgument.ToString().Split(',')[0].Split('/')[1] });
            _responseObj.WriteResponseStreamToFile(Server.MapPath(fpath));

            byte[] key = ASCIIEncoding.ASCII.GetBytes(lnk.CommandArgument.ToString().Split(',')[1]);
            SymmetricCryptoClass.Decryption(Server.MapPath(fpath), key.ToString());
            System.Diagnostics.Process.Start(Server.MapPath(fpath));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.ScholarshipReject(SHId, RId, txtReason.Text);
            if (result == "1")
            {
                obj = new MyConnection();
                DataTable tabmp = new DataTable();
                tabmp = obj.GetRId_MobileNo(RId);
                _smsClassObj = new SMS_LIB.SMS(ConfigurationManager.AppSettings["SmartCardPort"].ToString());
                _smsClassObj.OpenPort();

                string Message = "Apply Scholarship Rejected & Reason:" + txtReason.Text;
                _smsClassObj.SendSMS(tabmp.Rows[0]["MobileNo"].ToString(), Message);
                _smsClassObj.ClosePort();
                Panel5.Visible = false;
            }
            else
            {
                lblMsg.Text = "Scholarship Reject Log Already!!!";
            }
        }
    }
}