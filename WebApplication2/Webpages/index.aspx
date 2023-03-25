<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication2.Webpages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INDEX PAGE</title>
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            TO INSERT A STUDENT DETAIL <br /><br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert Student" />
            <br /><br /><br />
            SERACH STUDENT BY ANY FIELD :<br /><br />
            ID:<textarea id="Id" runat="server" pattern="\d+"></textarea>
            First Name:<textarea id="FirstName" runat="server" ></textarea>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Student"/>
            <br /><br /> 
            <div>
                <p id="errorLabel" runat="server"></p>
            </div>
            <br /><br />
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>ID</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>DOB</th>
                                <th>Father Name</th>
                                <th>Mother Name</th>
                                <th>Address</th>
                                <th>Mobile</th>
                                <th>Marks</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Id") %></td>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("Dob") %></td>
                            <td><%# Eval("FatherName") %></td>
                            <td><%# Eval("MotherName") %></td>
                            <td><%# Eval("Address") %></td>
                            <td><%# Eval("Mobile") %></td>
                            <td><%# Eval("Marks") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
    </form>
</body>
</html>
