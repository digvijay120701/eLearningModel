using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearningModel
{
    public partial class CreateTopic : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }
        protected void addTopic_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(DropDownList1.SelectedValue);
            string topicName = TopicName.Text;
            string url = YoutubeUrl.Text;
            //string email = "Admin"; // Use session here

            if (string.IsNullOrEmpty(url))
            {
                Message.Text = "Please enter a YouTube URL.";
                return;
            }

            string query = $"EXEC sp_AddTopic {courseId}, '{topicName}', '{url}', '{DateTime.Now}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Message.Text = "Topic added successfully.";
        }
    }
}