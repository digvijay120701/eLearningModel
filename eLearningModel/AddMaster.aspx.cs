using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearningModel
{
    public partial class AddMaster : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void AddMasterCourse_Click(object sender, EventArgs e)
        {
            string masterName = MasterCourseName.Text;
            string email = "Admin"; //use session here

            if (string.IsNullOrEmpty(masterName))
            {
                Message.Text = "Master Course Name cannot be empty.";
                return;
            }
            if (MasterPic.HasFile)
            {
                string folderPath = Server.MapPath("~/Pictures/");
                string fileName = Path.GetFileName(MasterPic.PostedFile.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                MasterPic.SaveAs(filePath);

                string query = $"EXEC AddMasterCourse '{masterName}', '{filePath}', '{email}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                Message.Text = "Master Course added successfully.";
            }
            else
            {
                Message.Text = "Please Select Picture.";
            }
        }
    }
}