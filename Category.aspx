<%@ Page Language="C#" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<html>
<script type="text/javascript" src="../member/js/jquery.js"></script>
<script type="text/javascript" src="../member/js/jquery.lightbox-0.5.js"></script>
<script type="text/javascript" src="../member/js/jquery.lightbox-0.5.min.js"></script>
<script type="text/javascript" src="../member/js/jquery.lightbox-0.5.pack.js"></script>
<link rel="stylesheet" type="text/css" href="../jquery.lightbox-0.5.css" media="screen" />


<script type="text/javascript">
$(function() {
	// Use this example, or...
	//$('a[@rel*=lightbox]').lightBox(); // Select all links that contains lightbox in the attribute rel
	// This, or...
	$('#gallery a').lightBox(); // Select all links in object with gallery ID
	// This, or...
	//$('a.lightbox').lightBox(); // Select all links with lightbox class
	// This, or...
	//$('a').lightBox(); // Select all links in the page
	// ... The possibility are many. Use your creative or choose one in the examples above
});
</script>

<script type="text/javascript">
$(function() {
   $('a[@rel*=lightbox]').lightBox({
	overlayBgColor: '#FFF',
	overlayOpacity: 0.6,
	imageLoading: '/images/lightbox-ico-loading.gif',
	imageBtnClose: '/images/lightbox-btn.close.gif',
	imageBtnPrev: '/images/lightbox-btn.prev.gif',
	imageBtnNext: '/images/lightbox-btn.next.gif',
	containerResizeSpeed: 350,
	txtImage: 'Imagem',
	txtOf: 'de'
   });
});
</script>
<div id="content">

<div id="gallery">
<div class="inpost" style="width:626px; float:left">
<h2 class="title">
    <asp:Label ID="categoryTxt" runat="server"></asp:Label></h2>
<div id="police">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" CellPadding="2"
        RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="120px" height="80px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button1" runat="server" Text="Back" 
            onclick="back_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>

    
    
</div>
</div>
</asp:Content>