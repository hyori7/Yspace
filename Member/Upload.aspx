<%@ Page Language="C#" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Member_Upload" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #descriptionBox
        {
            height: 65px;
            width: 364px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

    

<h2>Upload Photo</h2>
<div id="upload" align="center">
<table>
<td>
 Enter Title: 
</td>
<tr><td>
<input type="text" id="txtImgName" runat="server" maxlength="20" /> 
<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtImgName"></asp:RequiredFieldValidator>
</td>
</tr>
<tr><td>
Select Photo To Upload: 
</td></tr>
<tr><td>
<input id="UploadFile" type="file" runat="server" />
</td></tr>
<tr><td>
 Select Category:
</td></tr>
<tr><td>
<asp:DropDownList ID="categoryDrop" runat="server">
                <asp:ListItem>Policing And Security</asp:ListItem>
                <asp:ListItem>Homeless</asp:ListItem>
                <asp:ListItem>Speaking Out</asp:ListItem>
                <asp:ListItem>Green and Wild Spaces</asp:ListItem>
                <asp:ListItem>Hansing Out</asp:ListItem>
                <asp:ListItem>Public Art</asp:ListItem>
                <asp:ListItem>Signs</asp:ListItem>
                <asp:ListItem>Community Access Places</asp:ListItem>
                <asp:ListItem>City Spaces</asp:ListItem>
                <asp:ListItem>Being Active</asp:ListItem>
                <asp:ListItem>Favourite Spaces</asp:ListItem>
                <asp:ListItem>Unfavourite Spaces</asp:ListItem>
            </asp:DropDownList>
</td></tr>
<tr><td>
Enter a short description:
</td></tr>
<tr><td>
<asp:TextBox ID="descriptionBox" runat="server" TextMode="MultiLine" Width="200px" Height="65px"></asp:TextBox> 
</td></tr>
<tr><td>
<asp:button id="UploadBtn" Text="Upload" OnClick="UploadBtn_Click" runat="server" BackColor="#3399FF" ForeColor="White"></asp:button>
</td></tr>
<tr><td>Note: Uploaded images will be displayed on admin approval</td></tr>
</table>

             
    


     
    </div>
  


</div>
</asp:Content>