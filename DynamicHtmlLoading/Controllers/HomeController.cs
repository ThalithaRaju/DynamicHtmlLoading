using DynamicHtmlLoading.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicHtmlLoading.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult UserGet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserGet( User user)
        {
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS;Database=ManagementDB;Trusted_connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Gethtml", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", user.Name);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            user.PageContent = dr["PageContent"].ToString();

            return View("View",user);
        }
        public ActionResult Login(User user)
        {
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS;Database=ManagementDB;Trusted_connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("GetHtmlLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
          
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            user.PageContent = dr["PageContent"].ToString();

            return View(user);
        }
        public ActionResult Registration(User user)
        {
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS;Database=ManagementDB;Trusted_connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("GetHtmlRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            user.PageContent = dr["PageContent"].ToString();

            return View(user);
        }

    }
}