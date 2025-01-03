using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace eLearningModel
{
    public partial class showassignment : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Retrieve the logged-in user's email
            string email = "user1@example.com";
            if (string.IsNullOrEmpty(email))
            {
                Response.Write("<script>alert('Please log in first.');</script>");
                return;
            }

            string query = @"
                SELECT A.AssignmentId, A.Title, A.Description, A.DueDate
                FROM VideoTracker VT
                JOIN TopicList TL ON VT.TopicID = TL.TopicId
                JOIN Assignment A ON TL.CourseId = A.CourseId
                WHERE VT.Email = @Email";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@Email", email);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
                Response.Write("<script>alert('No assignments found for the current video.');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Response.Write("<script>alert('Please select a file to upload.');</script>");
                return;
            }

            // Retrieve the logged-in user's email
            string email = "user1@example.com";
            if (string.IsNullOrEmpty(email))
            {
                Response.Write("<script>alert('Please log in first.');</script>");
                return;
            }

            // Save the uploaded file
            string fileName = FileUpload1.FileName;
            string filePath = Server.MapPath("~/Pictures/" + fileName);
            FileUpload1.SaveAs(filePath);

            // Insert the submission into the database
            string query = @"
                INSERT INTO Submission (AssignmentId, Email, FilePath, SubmissionDate)
                VALUES (@AssignmentId, @Email, @FilePath, GETDATE())";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AssignmentId", GridView1.SelectedRow.Cells[0].Text);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@FilePath", filePath);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                Response.Write("<script>alert('File uploaded successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('File upload failed.');</script>");
            }
        }
    }
}
