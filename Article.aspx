<%@ Page Language="C#"  MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Article" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #title
        {
            width: 189px;
        }
    </style>
    
    <script type="text/javascript">
        function dosub(){
            editor = top.document.getElementById(editorId);
            editor.value = richeditor.toHtmlString();
            
        }     
    </script>
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
<h1>Article</h1>
<br />
<h4>Title:</h4>
<asp:TextBox ID="titleTxt" runat="server" TextMode ="MultiLine" Width="500px" Height="50px"></asp:TextBox><br /><br />

<h4>Select an article category:</h4>
    <asp:DropDownList ID="categoryDrop" runat="server" AutoPostBack="true">
    </asp:DropDownList>
<h4>Content:</h4>

    
    <asp:TextBox ID="contentTxt" runat="server" TextMode="MultiLine" width="500px" Height="100px" validateRequest="false"></asp:TextBox><br /><br />
    <h4>Author &amp; Date:</h4>
    <asp:TextBox ID="authorTxt" runat="server" TextMode="MultiLine" Width="500px" Height="60px"></asp:TextBox><br /><br />
    <h4>Upload Image</h4>
    <input id="UploadFile" type="file" runat="server" /> 
    <br /><br /><br />
    
    
    <asp:Button ID="submit" runat="server" Text="Submit" onclick="submit_Click" BackColor="#3399FF" ForeColor="White"/>

<br />
<br \>





</div>
</div>
</asp:Content>