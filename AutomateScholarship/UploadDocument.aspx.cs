using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;
using System.Data;
using Amazon.Runtime;
using Amazon.S3.Transfer;

namespace AutomateScholarship
{
    public partial class UploadDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Tuple<byte[], byte[]> T = null;
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string Pfilename = Session["UserId"].ToString() + "_" + rnd.Next(1000, 9999) + Path.GetExtension(PhotoFile.FileName);
            string filepath = "~/StudentFile/" + Pfilename;
            PhotoFile.SaveAs(Server.MapPath(filepath));

            string Securekey = "KEY" + rnd.Next(9999);
            T = SymmetricCryptoClass.GenerateSymmetricKeys(Securekey);

            SymmetricCryptoClass.Encryption(Server.MapPath(filepath), T.Item1.ToString());
            string key2 = System.Text.ASCIIEncoding.ASCII.GetString(T.Item2);

            ////Amazon AWS 
            BasicAWSCredentials credentials = new BasicAWSCredentials("AKIA2PAQROQSYOJ52K4Z", "DlyNZC62y0RQx1HSm+65xS7Dwfosd4xD1VDo6Mn3");

            // Create a new Amazon S3 client
            AmazonS3Client s3Client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1);
            TransferUtility fileTransferUtility = new TransferUtility(s3Client);
            fileTransferUtility.Upload(Server.MapPath(filepath), "scholarship2024", Pfilename);
            MyConnection obj = new MyConnection();
            string amzpath = "scholarship2024" + "/" + Pfilename;
            string res = obj.UploadFile(int.Parse(Session["UserId"].ToString()),txtFileName.Text, amzpath, T.Item1.ToString(), T.Item2.ToString());
            if (res == "1")
            {

                txtFileName.Text = "";
                lblMsg.Text = "File Encrypted & Uploaded to AWS Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == "2")
            {
                txtFileName.Text = "";
                lblMsg.Text = "Document Already Uploaded";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                txtFileName.Text = "";
                lblMsg.Text = "File Encrypted & Upload Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}