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
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Maegan Cervantes\OneDrive\Documents\loginreg.mdf"";Integrated Security=True;Connect Timeout=30");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void singupBtn_Click(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string cPassword = Request.Form["cPassword"];

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cPassword))
            {
                //message box
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('All fields are required to be filled');", true);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        //checks if email already exist to the database
                        string selectEmail = "SELECT * FROM users WHERE email = @email";

                        using (SqlCommand cmd = new SqlCommand(selectEmail, connect))
                        {
                            cmd.Parameters.AddWithValue("@email", email);

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email you've entered has been taken already.');", true);
                            }
                            else if (password != cPassword) //checks if password and confirm password does not match
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password does not match.');", true);
                            }
                            else if (password.Length < 8) //mo check if pass is atleast 8 chractrs 
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid password, at least 8 characters are needed.');", true);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO users (email, password, date) VALUES(@email, @pass, @date)";

                                using (SqlCommand insertD = new SqlCommand(insertData, connect))
                                {
                                    insertD.Parameters.AddWithValue("@email", email);
                                    insertD.Parameters.AddWithValue("@pass", password);
                                    insertD.Parameters.AddWithValue("@date", today);

                                    insertD.ExecuteNonQuery();

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registered Succesfully!');", true);
                                    Response.Redirect("/LoginForm.aspx");

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed Connection.');", true);
                    }
                    finally
                    {
                        connect.Close();
                    }

                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {

        }
    }
}