using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace AutomateScholarship
{
    public class MyConnection
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;

        public MyConnection()
        {
            con = new MySqlConnection("server=localhost;database=scholarship;user id=root;password=root;port=3307;");
            con.Open();
        }
        public int LoginVerify(string UserId, string Password, string UserType)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (UserType == "Application Manager")
            {
                sql = string.Format("Select count(*) from applicationmanager where AppId='{0}' and Password='{1}'", UserId, Password);
            }
            else if (UserType == "NGO")
            {
                sql = string.Format("Select count(*) from ngomaster where NGOId={0} and Password='{1}' and Status='Approve'", UserId, Password);
            }
            else if (UserType == "Donor")
            {
                sql = string.Format("Select count(*) from donormaster where DonorId={0} and Password='{1}'", UserId, Password);
            }
            else if (UserType == "Recipient")
            {
                sql = string.Format("Select count(*) from recipientmaster where RecipientId={0} and Password='{1}'", UserId, Password);
            }
            cmd.CommandText = sql;
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return result;
        }
        public string ChangePassword(string UserId, string Password, string UserType)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            if (UserType == "Application Manager")
            {
                sql = string.Format("Update applicationmanager set Password='{0}' where AppId='{1}'", Password, UserId);
            }
            else if (UserType == "NGO")
            {
                sql = string.Format("Update ngomaster set Password='{0}' where NGOId={1}", Password, UserId);
            }
            else if (UserType == "Donor")
            {
                sql = string.Format("Update donormaster set Password='{0}' where DonorId={1}", Password, UserId);
            }
            else if (UserType == "Recipient")
            {
                sql = string.Format("Update recipientmaster set Password='{0}' where RecipientId={1}", Password, UserId);
            }
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string NGORegister(int NGOId, string Name, string Password, string MobileNo, string EmailId, string Address)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from ngomaster where MobileNo='{0}'", MobileNo);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into ngomaster(NGOId,Name,Password,MobileNo,EmailId,Address,Status)values({0},'{1}','{2}','{3}','{4}','{5}','Pending')", NGOId, Name, Password, MobileNo, EmailId, Address);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }

        public DataTable GetNGO_Pending()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from ngomaster where status='Pending'");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetNGO()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from ngomaster where status='Approve'");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string ApproveNGORegister(int NGOId, string Status)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            sql = string.Format("Update ngomaster set Status='{0}' where NGOId={1}", Status, NGOId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string DonorRegister(int DonorId,string DonorType, string Name, string Password, string MobileNo, string EmailId, string Address)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from donormaster where MobileNo='{0}'", MobileNo);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into donormaster(DonorId,DonorType,Name,Password,MobileNo,EmailId,Address,Balance)values({0},'{1}','{2}','{3}','{4}','{5}','{6}',0)", DonorId, DonorType, Name, Password, MobileNo, EmailId, Address);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public string AddScholarshipAmount(int NGOId,string SType,string Description,int Amount)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlchk = string.Format("Select count(*) from scholarshipamount where SType='{0}' and NGOId={1}", SType,NGOId);
            cmd.CommandText = sqlchk;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            string result = "";
            if (cnt == 0)
            {
                string sql = string.Format("insert into scholarshipamount(NGOId,SType,Description,Amount)values({0},'{1}','{2}',{3})",NGOId, SType,Description, Amount);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public DataTable GetNGO_ScholarShip(int NGOId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from scholarshipamount where NGOId={0}", NGOId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable Get_ScholarShip(int SAId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from scholarshipamount where SAId={0}", SAId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string UpdateScholarship(int SAId,int Amount, string Description)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            sql = string.Format("Update scholarshipamount set Description='{0}',Amount={1} where SAId={2}", Description, Amount, SAId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public string AddDonorWallet(int DonorId, int Amount)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            string sqlw = string.Format("insert into donorwallet(DonorId,LogDate,Amount)values({0},'{1}',{2})", DonorId, DateTime.Now.ToString("dd/MM/yyyy"), Amount);
            cmd.CommandText = sqlw;
            result = cmd.ExecuteNonQuery().ToString();

            sql = string.Format("Update donormaster set Balance=Balance+{0} where DonorId={1}", Amount, DonorId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public DataTable GetDonorWallet(int DonorId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from donorwallet where DonorId={0}", DonorId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string RecipientRegister(int RecipientId, string Name, string Password, string MobileNo, string EmailId, string Address,string PhotoPath)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from recipientmaster where MobileNo='{0}'", MobileNo);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into recipientmaster(RecipientId,Name,Password,MobileNo,EmailId,Address,PhotoPath)values({0},'{1}','{2}','{3}','{4}','{5}','{6}')", RecipientId, Name, Password, MobileNo, EmailId, Address,PhotoPath);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public string UploadFile(int RecipientId, string FileName, string FilePath,string FKey1,string FKey2)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from uploadfile where FileName='{0}' and RId={1} and Status='Active'", FileName,RecipientId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into uploadfile(RId,FileName,FilePath,UploadDate,FKey1,FKey2,Status)values({0},'{1}','{2}','{3}','{4}','{5}','Active')", RecipientId, FileName, FilePath, DateTime.Now.ToString("dd/MM/yyyy"),FKey1,FKey2);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public DataTable GetUploadFile_RId(int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from uploadfile where RId={0} and Status='Active'", RId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string DeactiveUploadFile(int UFId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            sql = string.Format("Update uploadfile set Status='Deactive' where UFId={0}", UFId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string RecipientEducation(int RId, string IName, string Education, string YearPass, string Percentage)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into recipienteducation(RId,IName,Education,YearPass,Percentage)values({0},'{1}','{2}','{3}','{4}')", RId, IName, Education, YearPass, Percentage);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public DataTable GetNGOScholarship_NGO(int NGOId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from scholarshipamount where NGOId={0}", NGOId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string CreateScholarShip(int SAId, string SSD, string SCD)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string chksql = string.Format("Select count(*) from scholarshipmaster where SAId={0}", SAId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            if (res == "0")
            {
                string sql = string.Format("insert into scholarshipmaster(SAId,SSD,SCD,Status)values({0},'{1}','{2}','Pending')", SAId, SSD, SCD);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();

            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }

        public DataTable GetNGOScholarshipDetails_NGO(int NGOId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select SHId,SType,Description,Amount,SSD,SCD from scholarshipamount inner join scholarshipmaster on scholarshipamount.SAId=scholarshipmaster.SAId where scholarshipamount.NGOId={0}", NGOId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string ApplyScholarShip(int SHId, int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string chksql = string.Format("Select count(*) from applyscholarship where SHId={0} and RId={1}", SHId,RId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            if (res == "0")
            {
                string sql = string.Format("insert into applyscholarship(SHId,RId,ApplyDate,Status)values({0},{1},'{2}','Pending')", SHId, RId, DateTime.Now);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();

            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }

        public DataTable GetNGOScholarShip_SAId(int SAId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT scholarshipamount.SAId,scholarshipamount.SType,scholarshipamount.Description,scholarshipamount.Amount,scholarshipmaster.SHId,scholarshipmaster.SSD,scholarshipmaster.SCD
                                        FROM scholarshipamount INNER JOIN scholarshipmaster
                                        ON scholarshipamount.SAId=scholarshipmaster.SAId
                                        WHERE scholarshipmaster.Status='Pending' and scholarshipamount.SAId={0}", SAId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetRecipientApply(int SHId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT recipientmaster.RecipientId,recipientmaster.Name,
                                        recipientmaster.MobileNo,recipientmaster.Address,recipientmaster.PhotoPath
                                        FROM recipientmaster INNER JOIN applyscholarship ON
                                        recipientmaster.RecipientId=applyscholarship.RId
                                        WHERE applyscholarship.SHId={0} and applyscholarship.Status='Pending'", SHId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetRecipientEducation(int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from recipienteducation where RId={0}", RId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetUploadFileRId(int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from uploadfile where RId={0} and Status='Active'", RId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string AddGovtNGOPay(int NGOId, int Amount)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            string sqlw = string.Format("insert into govtfundngo(NGOId,PayDate,Amount)values({0},'{1}',{2})", NGOId, DateTime.Now.ToString("dd/MM/yyyy"), Amount);
            cmd.CommandText = sqlw;
            result = cmd.ExecuteNonQuery().ToString();

            sql = string.Format("Update ngomaster set Balance=Balance+{0} where NGOId={1}", Amount, NGOId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public string DonorPayNGO(int DonorId,int NGOId, int Amount)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            string sqlw = string.Format("insert into donorpayngo(DonorId,NGOId,PayDate,Amount)values({0},{1},'{2}',{3})",DonorId, NGOId, DateTime.Now.ToString("dd/MM/yyyy"), Amount);
            cmd.CommandText = sqlw;
            result = cmd.ExecuteNonQuery().ToString();

            sql = string.Format("Update ngomaster set Balance=Balance+{0} where NGOId={1}", Amount, NGOId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            string sqld = string.Format("Update donormaster set Balance=Balance-{0} where DonorId={1}", Amount, DonorId);
            cmd.CommandText = sqld;
            result = cmd.ExecuteNonQuery().ToString();

            con.Close();
            return result;
        }

        public DataTable GetNGO_DonorPay(int NGOId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select donormaster.Name,donormaster.MobileNo,donorpayngo.PayDate,donorpayngo.Amount from donormaster inner join donorpayngo on donormaster.DonorId=donorpayngo.DonorId where donorpayngo.NGOId={0}", NGOId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetNGO_GovtPay(int NGOId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from govtfundngo where NGOId={0}",NGOId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetNGOBalance(int NGOId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from ngomaster where NGOId={0}", NGOId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string ScholarshipReject(int SHId, int RId,string Reason)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string chksql = string.Format("Select count(*) from rejectlog where SHId={0} and RId={1}", SHId, RId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            if (res == "0")
            {
                string sql = string.Format("insert into rejectlog(SHId,RId,Reason,LogDate)values({0},{1},'{2}','{3}')", SHId, RId, Reason, DateTime.Now);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();

            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }

        public DataTable GetRId_MobileNo(int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from recipientmaster where RecipientId={0}", RId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string NGOApproveScholarship(int NGOId, int SHId,int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";

            sql = string.Format("select scholarshipamount.Amount from scholarshipamount inner join scholarshipmaster on scholarshipamount.SAId=scholarshipmaster.SAId where scholarshipmaster.SHId={0}", SHId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);


            string sqlw = string.Format("insert into recipientwallet(NGOId,RId,PayDate,Amount)values({0},{1},'{2}',{3})", NGOId, RId, DateTime.Now.ToString("dd/MM/yyyy"), int.Parse(tab.Rows[0]["Amount"].ToString()));
            cmd.CommandText = sqlw;
            result = cmd.ExecuteNonQuery().ToString();

            sql = string.Format("Update ngomaster set Balance=Balance-{0} where NGOId={1}", int.Parse(tab.Rows[0]["Amount"].ToString()), NGOId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            string sqld = string.Format("Update applyscholarship set Status='Approve' where SHId={0} and RId={1}", SHId, RId);
            cmd.CommandText = sqld;
            result = cmd.ExecuteNonQuery().ToString();

            con.Close();
            return result;
        }

        public DataTable GetRecipientWallet(int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select ngomaster.Name,recipientwallet.PayDate,recipientwallet.Amount from recipientwallet inner join ngomaster on ngomaster.NGOId=recipientwallet.NGOId where recipientwallet.RId={0}", RId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetRecipientScholarship(int RId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT ngomaster.Name,scholarshipamount.SType,
                                        scholarshipamount.Description,scholarshipamount.Amount,
                                        applyscholarship.ASId FROM applyscholarship INNER JOIN
                                        scholarshipmaster ON applyscholarship.SHId=
                                        scholarshipmaster.SHId INNER JOIN scholarshipamount ON
                                        scholarshipamount.SAId=scholarshipmaster.SAId
                                        INNER JOIN ngomaster ON ngomaster.NGOId=scholarshipamount.NGOId
                                        WHERE applyscholarship.RId={0} and applyscholarship.Status='Approve'", RId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string PostFeedback(int ASId, string Feedback)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string chksql = string.Format("Select count(*) from feedbacklog where ASId={0}", ASId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            if (res == "0")
            {
                string sqlw = string.Format("insert into feedbacklog(ASId,PostDate,FeedBack)values({0},'{1}','{2}')", ASId, DateTime.Now.ToString("dd/MM/yyyy"), Feedback);
                cmd.CommandText = sqlw;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }

        public DataTable GetScholarship_NGO(int NGOId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT ngomaster.Name,scholarshipamount.SType,
                                        scholarshipamount.Description,scholarshipamount.Amount,
                                        applyscholarship.ASId FROM applyscholarship INNER JOIN
                                        scholarshipmaster ON applyscholarship.SHId=
                                        scholarshipmaster.SHId INNER JOIN scholarshipamount ON
                                        scholarshipamount.SAId=scholarshipmaster.SAId
                                        INNER JOIN ngomaster ON ngomaster.NGOId=scholarshipamount.NGOId
                                        WHERE ngomaster.NGOId={0} and applyscholarship.Status='Approve'", NGOId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetFB(int ASId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT * from feedbacklog where ASId={0}", ASId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetScholarship_Recipient(int ASId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT recipientmaster.Name,recipientmaster.MobileNo,recipientmaster.address
                                from recipientmaster inner join applyscholarship on recipientmaster.RecipientId=applyscholarship.RId 
                                where applyscholarship.ASId={0} and applyscholarship.Status='Approve'", ASId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
    }
}