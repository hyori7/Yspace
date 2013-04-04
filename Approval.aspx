<%@ Page Language="C#" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Approval.aspx.cs"
    Inherits="Approval" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="post">
            <bold>Image ID: </bold><asp:Label ID="imageID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
           <h4>Approval:</h4>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1">Approved</asp:ListItem>
                <asp:ListItem Value="9">Disapproved</asp:ListItem>
            </asp:DropDownList><br />
            <h4>Category</h4>
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
            <h4>Name:</h4>
              <asp:TextBox ID="nameTxt" runat="server" Width="400px" MaxLength="20"></asp:TextBox>
              <h4>Description:</h4>
        <asp:TextBox ID="descriptionTxt" runat="server" TextMode="MultiLine" Width="200px" Height="65px" ></asp:TextBox><br /><br />
        
            <asp:Button ID="update" runat="server" Text="Update" onclick="update_Click" />
            <asp:Button ID="back" runat="server" Text="Back" style="float:right" 
                onclick="back_Click"/>
        </div>
      
    </div>

</asp:Content>
