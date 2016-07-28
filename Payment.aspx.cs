using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW2
{
    public partial class Payment : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string name = (string)Session["Name"] ?? "";
            Master.lblName = name;

            string movieName = null;
            int numOfTickets = 0;
            string seats = null;

            if (Request.Cookies["seatsData"] != null)
            {
                movieName = Request.Cookies["seatsData"].Values["movie"];
                numOfTickets = Convert.ToInt32(Request.Cookies["seatsData"].Values["numOftickets"]);
                seats = Request.Cookies["seatsData"].Values["seats"];
            }


            if (numOfTickets > 0)
            {
                OrderSummary.Text = "You have ordered a total of: <strong>" + numOfTickets + " Tickets</strong><br/>"
                    + "To: <strong>" + movieName + "</strong><br/>Seats: <strong>" + seats.Replace("R", "Row: ").Replace("S", "  Seat: ") +
                    "</strong><br/>Total Price: <strong>" + 10 * numOfTickets + "$<strong>";
            }
            else
            {
                OrderSummary.Text = "No seats have been selected!";
            }
        }



        protected void AddOrder(string title, string seats, string payment)
        {
            //  SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = Master.sqlConnection;
            SqlCommand sqlCommand = new SqlCommand("INSERT Orders Values(@title,@seats,@payment,@time)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@title", title);
            sqlCommand.Parameters.AddWithValue("@seats", seats);
            sqlCommand.Parameters.AddWithValue("@payment", payment);
            sqlCommand.Parameters.AddWithValue("@time", DateTime.Now);
            sqlCommand.Connection.Open();		//open the command connection
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();      //close the conenction

        }



        protected void btnOrderNow_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;


            if (Request.Cookies["seatsData"] != null)
            {
                if (Session["Seats"] == null)
                    Session["Seats"] = Request.Cookies["seatsData"].Values["seats"];
                else
                    Session["Seats"] = Session["Seats"] + "," + Request.Cookies["seatsData"].Values["seats"];

                Session["Phone"] = txtPhoneNumber.Text;

                Response.Cookies["seatsData"].Expires = DateTime.Now.AddSeconds(-10);

                string title = Request.Cookies["seatsData"].Values["movie"];
                string seats = Request.Cookies["seatsData"].Values["seats"];
                AddOrder(title, seats, ddlCreditList.SelectedItem.Text);
                Server.Transfer("MyOrders.aspx");
            }
        }
        
    }
}