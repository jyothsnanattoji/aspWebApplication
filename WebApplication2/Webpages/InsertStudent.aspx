<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertStudent.aspx.cs" Inherits="WebApplication2.Webpages.InsertStudent1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INSERT STUDENTS</title>
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
</head>
<body>
    <form id="form1" runat="server">
       <div>
            INSERT STUDENT DETAILS:
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>Id :</asp:TableCell>
                    <asp:TableCell><textarea id="Id" runat="server" pattern="\d+"></textarea></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>First Name :</asp:TableCell>
                    <asp:TableCell><textarea id="FirstName"  runat="server"></textarea> </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Last Name :</asp:TableCell>
                    <asp:TableCell><textarea id="LastName"  runat="server"></textarea></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Dob :</asp:TableCell>
                    <asp:TableCell> <textarea id="Dob"  runat="server"></textarea></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Father's Name :</asp:TableCell>
                    <asp:TableCell><textarea id="FatherNme"  runat="server"></textarea></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Mother's Name :</asp:TableCell>
                    <asp:TableCell><textarea id="MotherName"  runat="server"></textarea></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Address :</asp:TableCell>
                    <asp:TableCell><textarea id="Address"  runat="server"></textarea></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell> Mobile:</asp:TableCell>
                    <asp:TableCell><textarea id="Mobile"  runat="server"></textarea></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell> Marks :</asp:TableCell>
                    <asp:TableCell><textarea id="Marks"  runat="server" pattern="\d+"></textarea> </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button Text="Submit" value="Submit" runat="server" OnClick="Submit_Click" />
            <div>
                <p id="errorLabel" runat="server"></p>
            </div>
        </div>

    </form>
</body>
</html>
