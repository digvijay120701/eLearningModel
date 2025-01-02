using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearningModel
{
    public partial class CourseList : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadMasterCourses();
            }
        }

        private void LoadMasterCourses()
        {
            // Fetch Master Courses
            
            
                string query = "SELECT MasterCourse FROM MasterCourse";
                SqlCommand cmd = new SqlCommand(query, conn);

               
                SqlDataReader rdr = cmd.ExecuteReader();

                MasterCourse.DataSource = rdr;
                MasterCourse.DataTextField = "MasterCourse";
                MasterCourse.DataValueField = "MasterCourse";
                MasterCourse.DataBind();
                MasterCourse.Items.Insert(0, new ListItem("Select Master Course", "0"));
            
        }

        protected void MasterCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            CourseList1.Items.Clear();
            string selectedMasterCourse = MasterCourse.SelectedValue;

            
               
                    string query = "SELECT CourseId, CourseName FROM Course WHERE MasterCourse = @MasterCourse";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MasterCourse", selectedMasterCourse);

                   
                    SqlDataReader rdr = cmd.ExecuteReader();

                    CourseList1.DataSource = rdr;
                    CourseList1.DataTextField = "CourseName";
                    CourseList1.DataValueField = "CourseId";
                    CourseList1.DataBind();
                
                CourseList1.Items.Insert(0, new ListItem("Select Course", "0"));
            
        }

        protected void btnFetch_Click(object sender, EventArgs e)
        {
            string masterName = MasterCourse.SelectedValue;
            string courseName = CourseList1.SelectedItem.Text;

            string query = "EXEC sp_GetTopicsForCourse @MasterCourseName, @CourseName";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MasterCourseName", masterName);
            cmd.Parameters.AddWithValue("@CourseName", courseName);

            SqlDataReader rdr = cmd.ExecuteReader();
            AllCoursesList.DataSource = rdr;
            AllCoursesList.DataBind();
        }

    }
}
