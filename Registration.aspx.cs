using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace Registration
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                string constring = "Server=localhost;uid=root;pwd=Pass@123;database=Student";
                string Course = "";
                MySqlConnection con = new MySqlConnection();
                MySqlCommand cmd;
                con.ConnectionString = constring;
                con.Open();
                
                cmd = new MySqlCommand("Insert into Test" + "(Name,Email_Address,Phone_Number,Course_Name,Course_Start)" + "values(@Name,@Email_Address,@Phone_Number,@Course_Name,@Course_Start)", con);

                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Email_Address", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Phone_Number", TextBox3.Text);

                if (CheckBox1.Checked)
                {
                    Course = CheckBox1.Text + ",";

                }

                if (CheckBox2.Checked)
                {
                    Course = Course + CheckBox2.Text + ",";
                }

                if (CheckBox3.Checked)
                {
                    Course = Course + CheckBox3.Text + ",";
                }

                if (CheckBox4.Checked)
                {
                    Course = Course + CheckBox4.Text;
                }

                cmd.Parameters.AddWithValue("@Course_Name", Course);

                DateTime dt = DateTime.ParseExact(TextBox4.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@Course_Start",dt);

                

                try
                {


                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        
                        Response.Write("Registration was Successfully");
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";

                        if (CheckBox1.Checked)
                        {
                            CheckBox1.Checked = false;
                        }
                        if (CheckBox2.Checked)
                        {
                            CheckBox2.Checked = false;
                        }
                        if (CheckBox3.Checked)
                        {
                            CheckBox3.Checked = false;
                        }
                        if (CheckBox4.Checked)
                        {
                            CheckBox4 .Checked = false;
                        }

                    }
                }


                catch(Exception)
                {
                    Show.Text = "Registration was Failed";
                }
                finally
                {
                    con.Close();
                }
                
            }
        }
    }
}