<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMaster.aspx.cs" Inherits="eLearningModel.AddMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add Master Course</h2>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>

            <br />

            <div>
                <label for="MasterCourseName">Master Course Name:</label>
                <asp:TextBox ID="MasterCourseName" runat="server"></asp:TextBox>
            </div>

            <br />

            <div>
                <label for="MasterPic">Upload Master Course Picture:</label>
                <asp:FileUpload ID="MasterPic" runat="server" />
            </div>

            <br />

            <div>
                <asp:Button ID="AddMasterCourse" runat="server" Text="Add Master Course" CssClass="btn btn-primary" OnClick="AddMasterCourse_Click" />
            </div>
        </div>
    </form>
</body>
</html>
