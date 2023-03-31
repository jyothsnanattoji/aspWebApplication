<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertStudent.aspx.cs" Inherits="WebApplication2.Webpages.InsertStudent1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INSERT STUDENTS</title>
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link rel="stylesheet" href="StyleSheet1.css"/>
    <script src="script.js"></script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return required()" >
       <div>
           <p>  INSERT STUDENT DETAILS:</p><br />
           <asp:Table runat="server">
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"><asp:Label class="labelgap" runat="server">ID</asp:Label>  </asp:TableCell>
                   <asp:TableCell runat="server"><asp:TextBox ID="Id" TextMode="Number" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"> <asp:Label class="labelgap" runat="server">First Name</asp:Label>   </asp:TableCell>
                   <asp:TableCell runat="server">    <asp:TextBox ID="FirstName" TextMode="SingleLine" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"> <asp:Label  class="labelgap" runat="server">Last Name</asp:Label>   </asp:TableCell>
                   <asp:TableCell runat="server"> <asp:TextBox ID="LastName" TextMode="SingleLine" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"><asp:Label  class="labelgap" runat="server">Date of Birth</asp:Label>  </asp:TableCell>
                   <asp:TableCell runat="server"> <asp:TextBox ID="Dob" TextMode="Date" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"> <asp:Label   class="labelgap" runat="server">Father's Name</asp:Label> </asp:TableCell>
                   <asp:TableCell runat="server"><asp:TextBox ID="FatherName" TextMode="SingleLine" runat="server" ></asp:TextBox> </asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"><asp:Label  class="labelgap" runat="server">Mother's Name</asp:Label>    </asp:TableCell>
                   <asp:TableCell runat="server"><asp:TextBox ID="MotherName" TextMode="SingleLine" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"><asp:Label  class="labelgap" runat="server">Address</asp:Label></asp:TableCell>
                   <asp:TableCell runat="server"> <asp:TextBox ID="Address" TextMode="MultiLine" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"><asp:Label  class="labelgap" runat="server">Phone Number</asp:Label> </asp:TableCell>
                   <asp:TableCell runat="server"><asp:TextBox ID="Mobile" TextMode="Number" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server">
                   <asp:TableCell runat="server"><asp:Label  class="labelgap" runat="server">Marks</asp:Label> </asp:TableCell>
                   <asp:TableCell runat="server"><asp:TextBox ID="Marks" TextMode="Number" runat="server" ></asp:TextBox></asp:TableCell>
               </asp:TableRow>
           </asp:Table>       
         <br />
           <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Submit_Clicked" />
            <div>
                <p id="errorLabel" runat="server"></p>
            </div>
        </div>

    </form>
</body>

</html>
