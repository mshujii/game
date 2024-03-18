using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Game
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Maegan Cervantes\OneDrive\Documents\loginreg.mdf"";Integrated Security=True;Connect Timeout=30");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];


            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('All fields are required to be filled.');", true);
            }
            else
            {
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectData = "SELECT * FROM users WHERE email = @email AND password = @pass";

                        using(SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@pass", password);

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login Successfully!');", true);

                                Session["email"] = email;

                                Response.Redirect("/index.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Incorret Email/Password');", true);
                            }
                        }
                    }
                    catch(Exception ex) 
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Connection Failed');", true);
                    }
                    finally
                    {
                        connect.Close();
                    }

                }
            }
        }
    }
}