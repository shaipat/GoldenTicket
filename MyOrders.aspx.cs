using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW2
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            string name = (string)Session["Name"] ?? "";
            Master.lblName = name;

            if (Session["Phone"] != null)
                txtPhoneNumber.Text = "Your Phone Number: " + Session["Phone"].ToString();


            LoadOrders(); 
        }


        //Loads recently saved orders details from datebase into table
        protected void LoadOrders()
        {
            SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = Master.sqlConnection;
            SqlCommand sqlCommand = new SqlCommand("SELECT Title,Seats,Payment,DateNTime FROM Orders", sqlConnection);
            sqlCommand.Connection.Open(); //open the command connection
            sqlDataReader = sqlCommand.ExecuteReader(); //the Reader gets the selected records

            while (sqlDataReader.Read())
            {
                string title = sqlDataReader["Title"].ToString();
                string seats = sqlDataReader["Seats"].ToString();
                string Payment = sqlDataReader["Payment"].ToString();
                string DateNTime = sqlDataReader["DateNTime"].ToString();

                TableRow tRow = new TableRow();

                TableCell tCell = new TableCell();
                tCell.Text = title;

                TableCell tCell2 = new TableCell();
                tCell2.Text = Convert.ToString(seats.Split('S').Length - 1);

                TableCell tCell3 = new TableCell();
                tCell3.Text = Payment;

                TableCell tCell4 = new TableCell();
                tCell4.Text = DateNTime;

                tRow.Cells.Add(tCell);
                tRow.Cells.Add(tCell2);
                tRow.Cells.Add(tCell3);
                tRow.Cells.Add(tCell4);

                TblOrders.Rows.Add(tRow);
            }

            sqlCommand.Connection.Close(); // close existing sql connection
            sqlDataReader.Close();

        }
    }
}