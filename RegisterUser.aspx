<%@ Page Language="C#" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="RegisterUser.aspx.cs" Inherits="RegisterUser" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
    <h1>Register Page</h1>
    <p>Please fill this form</p>
     <div align="center">
     <table>
     <tr><td>Username:<br />
         <asp:TextBox ID="userId" runat="server"></asp:TextBox><br />
         <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your Name" ControlToValidate="userId" ></asp:RequiredFieldValidator></td></tr>
     <tr><td>
         <asp:Button ID="checkName" runat="server" Text="Check ID" 
             onclick="checkName_Click" /></td></tr>
     <tr><td>Password:<br /></td></tr>
     <tr><td><input type="password" id="password" runat="server" /><br /></td></tr>
     <tr><td> Email:<br /></td></tr>
     <tr><td> <input type="text" id="email" runat="server" /><br />
     <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a proper Email Address" ControlToValidate="email" ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)"></asp:RegularExpressionValidator><br /></td></tr>
     <tr><td> Supporter:<input type="checkbox" id="supporter" runat="server" onselect="1"/><br /></td></tr>
     <tr><td> </td></tr>
     <tr><td> <asp:Button ID="Button1" runat="server" Text="Register" OnClick="submit"/><br /></td></tr>
        
      
        
        
       
        </table>
         <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
        
</div>

    </div>
</asp:Content>
