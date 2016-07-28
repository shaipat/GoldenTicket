using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW2
{
    public partial class _Default : Page
    {
        SqlCommand sqlCommand;//will be availabe for all function
        SqlConnection sqlConnection;//will be availabe for all function


        protected void Page_Load(object sender, EventArgs e)
        {
                string name = (string)Session["Name"] ?? "";
                Master.lblName = name;
        }



        protected void btnLetsGo_Click(object sender, EventArgs e)
        {
           
            HttpCookie myCookie = new HttpCookie("AuthCookie");

            if (CheckLogin(txtUserName.Text, txtPassword.Text)) //authenticated by DB
            {
                //todo: save unique id cookie
                string uid = UniqueId();
                Session["Name"] = txtUserName.Text;
                Session["UniqueId"] = uid; //save unique id to session

                Response.Cookies["AuthCookie"].Expires = DateTime.Now.AddSeconds(-10); //delete cookie

                myCookie.Expires = DateTime.Now.AddMinutes(10);
                myCookie.Values.Add("UniqueId", uid); //save unique id to cookies
                Response.Cookies.Add(myCookie);
                Response.Redirect("Tickets.aspx");
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"JavaScript\">alert(\"Incorrect Username or Password!\")</SCRIPT>");
            }     
        }


        //checks in SQL databse if the given username and password combination exists
        protected bool CheckLogin(string user, string pass)
        {
            //SQL
            SqlDataReader sqlDataReader;
            sqlConnection = Master.sqlConnection;

            sqlCommand = new SqlCommand("SELECT Username FROM Users WHERE Username = @par_user AND Password = @par_password", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@par_user", user);
            sqlCommand.Parameters.AddWithValue("@par_password", pass);

            sqlCommand.Connection.Open();				//open the command connection
            sqlDataReader = sqlCommand.ExecuteReader();	//the Reader gets the selected records
            return sqlDataReader.HasRows;
        }

        protected string UniqueId()
        {
            return Guid.NewGuid().ToString("N");           
        }
        
    }
}