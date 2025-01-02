<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourses.aspx.cs" Inherits="eLearningModel.AddCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add Course</h2>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>

            <br />

            <div>
                <label for="MasterCourse">Select Master Course:</label>
                <asp:DropDownList ID="MasterCourse" runat="server" DataTextField="MasterCourse" DataValueField="MasterCourseId" AppendDataBoundItems="true" DataSourceID="SqlDataSource1">
                    <asp:ListItem Text="Select Master Course" Value="0"></asp:ListItem>
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:dbconn %>"
                    SelectCommand="SELECT MasterCourseId, MasterCourse FROM MasterCourse">
                </asp:SqlDataSource>
            </div>

            <br />

            <div>
                <label for="CourseName">Course Name:</label>
                <asp:TextBox ID="CourseName" runat="server"></asp:TextBox>
            </div>

            <br />

            <div>
                <label for="Price">Course Price:</label>
                <asp:TextBox ID="Price" runat="server"></asp:TextBox>
            </div>

            <br />

            <div>
                <label for="CoursePic">Upload Course Picture:</label>
                <asp:FileUpload ID="CoursePic" runat="server" />
            </div>

            <br />

            <div>
                <asp:Button ID="addCourse" runat="server" Text="Add Course" CssClass="btn btn-primary" OnClick="addCourse_Click" />
            </div>
        </div>
    </form>
</body>
</html>
