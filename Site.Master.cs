using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW2
{
    
    public partial class SiteMaster : MasterPage
    {
        public SqlCommand sqlCommand;//will be availabe for all function

        /*** SET THE MATCHING CONNECTION STRING ***/
        static string conString = @"Data Source=shaipat-pc\sqlexpress;Initial Catalog=GoldenTicket;Integrated Security=True";

        public SqlConnection sqlConnection = new SqlConnection(conString);//will be availabe for all function

        public string lblName
        {
            get { return this.lblNameMaster.Text; }
            set { this.lblNameMaster.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogout.Visible = false;
            CheckUserAuth();
        }

        protected void CheckUserAuth()
        {

            if (Request.Cookies["AuthCookie"] == null)
            {
                
                if (Request.FilePath != "/Default.aspx")
                {
                    Page.Visible = false;
                    Response.Redirect("Default.aspx");              
                }
                btnTickets.Visible = false;
                btnOrders.Visible = false;
                btnPayment.Visible = false;
                return;
             }

            string uidCookies = Request.Cookies["AuthCookie"].Values["UniqueId"];
            string uidSession = null;
            if (Session["UniqueId"] != null)
                uidSession = Session["UniqueId"].ToString();

            if (uidCookies != uidSession)
            {

                string currentUrl = Request.Url.LocalPath;
                btnTickets.Visible = false;
                btnOrders.Visible = false;
                btnPayment.Visible = false;
                if (currentUrl != "/Default.aspx")
                {
                    Page.Visible = false;
                    Response.Redirect("Default.aspx");

                }

            }
            else //user is logged in and matches unique id
            {
                btnLogout.Visible = true;
                btnTickets.Visible = true;
                btnOrders.Visible = true;
                btnPayment.Visible = true;
            }
        }

        protected void TopMenu_Nav(object sender, EventArgs e)
        {
            string caller = ((LinkButton)sender).Text;

            if (caller == "Pay")
            {
                Response.Redirect("Payment.aspx");
            }
            else if (caller == "Buy a Ticket")
            {
                Response.Redirect("Tickets.aspx");
            }
            else if (caller == "Home")
            {
                Response.Redirect("Default.aspx");
            }
            else if (caller == "My Orders")
            {
                Response.Redirect("MyOrders.aspx");
            }
        }

        protected void Logout_User(object sender, EventArgs e)
        {
            Response.Cookies["AuthCookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("Default.aspx");
        }
       
    }

}