using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearningModel
{
    public partial class AddCourses : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void addCourse_Click(object sender, EventArgs e)
        {
            string masterCourse = MasterCourse.SelectedItem.Text;
            string courseName = CourseName.Text;
            decimal price = Convert.ToDecimal(Price.Text);
            string email = "Admin"; // Use session here

            if (CoursePic.HasFile)
            {
                string folderPath = Server.MapPath("~/Pictures/");
                string fileName = Path.GetFileName(CoursePic.PostedFile.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                CoursePic.SaveAs(filePath);

                string query = $"EXEC AddCourseSp {masterCourse}, '{courseName}', {price}, '{filePath}', '{DateTime.Now}', '{email}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                Message.Text = "Course added successfully.";
            }
            else
            {
                Message.Text = "Please Select Picture.";
            }
        }
    }
}