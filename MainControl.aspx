<%@ Page Language="C#"  MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="MainControl.aspx.cs" Inherits="MainControl" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #title
        {
            width: 189px;
        }
        #contentTxt
        {
            width: 484px;
            height: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
   <div class="post">
 <div id="dolphinnav">
            <ul>
                <li><a href="../MainControl.aspx"><span>Main Control</span></a></li>
                <li><a href="../Control.aspx"><span>Image Control</span></a></li>
                <li><a href="../Article.aspx"><span>Article</span></a></li>
		  
            </ul>
            </div>
<br />  
   
<h1>Homepage Content</h1>


<h2>Update Notice &amp; Archive</h2>
<h4>Title:</h4>
<asp:TextBox ID="titleTxt" runat="server" Width="300px" MaxLength="40"></asp:TextBox><br /><br />
       
<h4>Select a news category:</h4>
    <asp:DropDownList ID="newsDrop" runat="server">
        <asp:ListItem Value="0">Notices</asp:ListItem>
        <asp:ListItem Value="2">News Archives</asp:ListItem>
    </asp:DropDownList>
<h4>Content:</h4>
   <asp:TextBox ID="contentTxt" runat="server" TextMode="MultiLine"  Height="98px" Width="506px"></asp:TextBox><br /><br /><br />
       
    <asp:Button ID="submit" runat="server" Text="Submit" onclick="submit_Click" BackColor="#3399FF" ForeColor="White"/>

<br />
<br />


</div>
<div class="post">
<h2>Add Latest News</h2>
<h4>Title:</h4>
<asp:TextBox ID="Text1" runat="server" Width="300px" MaxLength="40"></asp:TextBox><br /><br />

<h4>Content:</h4>
    <asp:TextBox ID="TextBox1" runat="server" Height="117px" Width="479px" 
        TextMode="MultiLine"></asp:TextBox><br /><br /><br /><br />
    
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="submit_Click1" 
        BackColor="#3399FF" ForeColor="White" style="height: 26px"/>

<br />
</div>
</div>

</asp:Content>