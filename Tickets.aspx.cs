using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW2
{
    public partial class Tickets : System.Web.UI.Page
    {
        HttpCookie myCookie = new HttpCookie("seatsData");     
        protected void Page_Load(object sender, EventArgs e)
        {
                string name = (string)Session["Name"] ?? "";
                Master.lblName = name;

                LoadSeats();
                LoadMovies();

                Response.Cookies["seatsData"].Expires = DateTime.Now.AddDays(-1); 
               
        }


        protected void LoadSeats()
        {
            SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = Master.sqlConnection;
            SqlCommand sqlCommand = new SqlCommand("SELECT Seats FROM Orders", sqlConnection);
            sqlCommand.Connection.Open();				//open the command connection
            sqlDataReader = sqlCommand.ExecuteReader();	//the Reader gets the selected records

            while (sqlDataReader.Read())
            {
                string seats = sqlDataReader["Seats"].ToString();
                foreach (ListItem s in Seats.Items)
                {
                    if (seats.Contains(s.Value))
                    {
                        s.Enabled = false;
                        s.Selected = false;
                    }
                }
            }

            sqlCommand.Connection.Close();
            sqlDataReader.Close();
        }

        protected void LoadMovies()
        {
            SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = Master.sqlConnection;
            SqlCommand sqlCommand = new SqlCommand("SELECT Title FROM Films", sqlConnection);
            sqlCommand.Connection.Open();				//opens the command connection
            sqlDataReader = sqlCommand.ExecuteReader();	//the Reader gets the selected records

            while (sqlDataReader.Read())
            {
                MoviesList.Items.Add(sqlDataReader["Title"].ToString());
            }
            sqlCommand.Connection.Close();
            sqlDataReader.Close();
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string result = "";
            int Ticketcounter = 0;
            foreach (ListItem seat in Seats.Items)
            {
                if (seat.Selected)
                {
                    result += seat.Value + ", ";
                    Ticketcounter++;
                }
            }

            int length = result.Length;
            if (length > 0)
                result = result.Remove(length - 2);
            else
                return;

           
            myCookie.Values.Add("movie", MoviesList.SelectedItem.Text);
            myCookie.Values.Add("numOftickets", Convert.ToString(Ticketcounter));
            myCookie.Values.Add("seats", result);


            myCookie.Expires = DateTime.Now.AddSeconds(60); //saves selected seats for 1 minute
            Response.Cookies.Add(myCookie);

            Response.Redirect("Payment.aspx");
        }

       
    }
}