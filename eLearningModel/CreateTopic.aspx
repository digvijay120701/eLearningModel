<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTopic.aspx.cs" Inherits="eLearningModel.CreateTopic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add Topic</h2>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>

            <br />

            <div>
                <label for="Course">Select Course:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="CourseName" DataValueField="CourseId" DataSourceID="SqlDataSource1">
                    <asp:ListItem Text="Select Course" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource
                    ID="SqlDataSource1"
                    runat="server"
                    ConnectionString="<%$ ConnectionStrings:dbconn %>"
                    SelectCommand="SELECT CourseId, CourseName FROM Course">
                </asp:SqlDataSource>
            </div>

            <br />

            <div>
                <label for="TopicName">Topic Name:</label>
                <asp:TextBox ID="TopicName" runat="server"></asp:TextBox>
            </div>

            <br />

            <div>
                <label for="YoutubeUrl">YouTube URL:</label>
                <asp:TextBox ID="YoutubeUrl" runat="server"></asp:TextBox>
            </div>

            <br />

            <div>
                <asp:Button ID="addTopic" runat="server" Text="Add-Topic" CssClass="btn btn-primary" OnClick="addTopic_Click" />
            </div>
        </div>
    </form>
</body>
</html>
