using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Net.Mail;

namespace Lib
{
    public static class Data
    {
        private static SqlConnection Connection;
        private static void Connect()
        {
             Connection = new SqlConnection("Data Source=DESKTOP-B7MPTPG\\SQLEXPRESS;Initial Catalog=LoginSystem;Integrated Security=True");
            Connection.Open();
        }
        private static void Close()
        {
            if (Connection.State==System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        public static bool Login(string email,string password)
        {
            //Girişte kullanıcı adı şifre kontrolü sağlanıyor
            Connect();
            SqlCommand Query = new SqlCommand("SELECT * FROM UserTable WHERE email=@email AND password=@password AND vertified=1", Connection);
            Query.Parameters.AddWithValue("@email", email);
            Query.Parameters.AddWithValue("@password", password);
            SqlDataReader dataReader = Query.ExecuteReader();
            if (dataReader.Read())
            {
                Close();
                setOnline(email, 1);
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }
        public static void setOnline(string email,int state)
        {
            Connect();
            SqlCommand Query = new SqlCommand("UPDATE UserTable SET isonline=" + state + " WHERE email='" + email + "'",Connection);
            Query.ExecuteNonQuery();
            Close();
        }
        public static void Register(string name,string surname,string email,string password,string secretquestion,string secretanswer,HttpResponse Response)
        {
            Connect();
            int vertif = new Random().Next(100000, 999999);
            SqlCommand Query = new SqlCommand("INSERT INTO UserTable VALUES(@email,@password,@name,@surname,@secretq,@secreta,0,GETDATE(),NULL,@vertif,'Standart',0)", Connection);
            Query.Parameters.AddWithValue("@email", email);
            Query.Parameters.AddWithValue("@password", password);
            Query.Parameters.AddWithValue("@name", name);
            Query.Parameters.AddWithValue("@surname", surname);
            Query.Parameters.AddWithValue("@secretq", secretquestion);
            Query.Parameters.AddWithValue("@secreta", secretanswer);
            Query.Parameters.AddWithValue("@vertif", vertif);
            Query.ExecuteNonQuery();
            Data.sendPassword("Vertification code: " + vertif.ToString(), email);
            Close();
            Response.Redirect(Data.Pages.Vertification.ToString() + ".aspx");
        }
        public static string getOnlineUserCount()
        {
            Connect();
            string ret = "0";
            SqlCommand Query = new SqlCommand("SELECT COUNT(*) FROM UserTable WHERE isonline=1",Connection);
            SqlDataReader dr = Query.ExecuteReader();
            if (dr.Read())
            {
                ret = dr[0].ToString();
            }
            Close();
            return ret;
        }
        public static int getRegisteredInOneDay()
        {
            Connect();
            int ret = 0;
            SqlCommand Query = new SqlCommand("SELECT DATEDIFF(DAY, registertime, verifytime) FROM UserTable WHERE vertified=1", Connection);
            SqlDataReader dr = Query.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == "0" || dr[0].ToString()=="1")
                {
                    ret++;
                }
            }
            Close();
            return ret;
        }
        public static void retrievePassword(string email,string question,string answer,Label warn)
        {
            Connect();
            SqlCommand Query = new SqlCommand("SELECT password FROM UserTable WHERE email=@email AND secretquestion=@secretq AND secretanswer=@secreta", Connection);
            Query.Parameters.AddWithValue("@email", email);
            Query.Parameters.AddWithValue("@secretq", question);
            Query.Parameters.AddWithValue("@secreta", answer);
            SqlDataReader dr = Query.ExecuteReader();
            warn.Visible = true;
            if (dr.Read())
            {
                Data.sendPassword( "Hesabınız Kurtarıldı, Şifreniz: " + dr[0].ToString(), email);
                warn.Text = "Şifreniz mail adresinize gönderildi.";
            }
            else warn.Text = "Girilen bilgiler hatalı.";
            Close();
        }
        public static int getNotVerifiedAfterOneDay()
        {
            Connect();
            int ret = 0;
            SqlCommand Query = new SqlCommand("SELECT COUNT(*) FROM UserTable WHERE vertified=0", Connection);
            SqlDataReader dr = Query.ExecuteReader();
            if (dr.Read())
            {
                ret = Convert.ToInt32(dr[0].ToString());
            }
            Close();
            return ret;
        }
        public static int getAverageRegistriation()
        {
            Connect();
            int ret = 0;
            int count = 0;
            SqlCommand Query = new SqlCommand("SELECT DATEDIFF(SECOND, registertime, verifytime) FROM UserTable WHERE vertified=1", Connection);
            SqlDataReader dr = Query.ExecuteReader();
            while (dr.Read())
            {
                ret += Convert.ToInt32(dr[0]);
                count++;
            }
            Close();
            try
            {
                return ret / count;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static void Vertify(string code,string email,HttpResponse Response,Label warn)
        {
            Connect();
            SqlCommand Query = new SqlCommand("SELECT * FROM UserTable WHERE email=@email AND vertificationcode=@vertificationcode", Connection);
            Query.Parameters.AddWithValue("@email", email);
            Query.Parameters.AddWithValue("@vertificationcode", code);
            SqlDataReader dataReader = Query.ExecuteReader();
            if (dataReader.Read())
            {
                Close();
                vertifyUser(email);
                Response.Redirect(Data.Pages.Login.ToString() + ".aspx");
            }
            else
            {
                warn.Text = "Invalid vertification code.";
                Close();
            }
        }
        public static void vertifyUser(string email)
        {
            Connect();
            SqlCommand Query = new SqlCommand("UPDATE UserTable SET vertified=1,verifytime=GETDATE() WHERE email='" + email + "'",Connection);
            Query.ExecuteNonQuery();
            Close();
        }
        public static User getUser(string email)
        {
            //Parametreden gelen kullanıcı adına göre User nesnesi döndürülüyor.
            Connect();
            User user = new User();
            SqlCommand Query = new SqlCommand("SELECT id,role,email FROM UserTable WHERE email=@email", Connection);
            Query.Parameters.AddWithValue("@email", email);
            SqlDataReader dataReader = Query.ExecuteReader();
            if (dataReader.Read())
            {
                user.Id = dataReader[0].ToString();
                user.Role = dataReader[1].ToString();
                user.Email = email;
            }
            return user;
        }
        public static void sendPassword(string mail,string adres)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            //Kendi mail bilgilerimizi gireceğimiz alan
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mail", "sifre");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("aliakpinar3435@gmail.com");
            msg.To.Add(new MailAddress(adres));

            msg.Subject = "Registery Vertification Code";
            msg.IsBodyHtml = true;
            msg.Body = string.Format(mail);
            client.Send(msg);
        }
        public enum Pages
        {
            Login,
            Standart,
            Admin,
            Vertification
        }
    }
}
