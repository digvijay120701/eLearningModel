<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="eLearningModel.CourseList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course List</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Course List</h2>

            <!-- Master Course Dropdown -->
            <div>
                <label for="MasterCourse">Select Master Course:</label>
                <asp:DropDownList ID="MasterCourse" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="MasterCourse_SelectedIndexChanged">
                    <asp:ListItem Text="Select Master Course" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <br />

            <!-- Course Dropdown -->
            <div>
                <label for="CourseList1">Select Course:</label>
                <asp:DropDownList ID="CourseList1" runat="server">
                    <asp:ListItem Text="Select Course" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <br />

            <!-- Fetch Button -->
            <div>
                <asp:Button ID="btnFetch" runat="server" Text="Fetch Topics" OnClick="btnFetch_Click" />
            </div>

            <br />

            <!-- GridView to Display Data -->
            <asp:GridView ID="AllCoursesList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="MasterCourseName" HeaderText="Master Course Name" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="NoOfTopics" HeaderText="No. of Topics" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
