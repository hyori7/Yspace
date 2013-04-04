<%@ Page Language="C#" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Display.aspx.cs" Inherits="Display" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<script type="text/javascript" src="../member/js/jquery.js"></script>
<script type="text/javascript" src="../member/js/jquery.lightbox-0.5.js"></script>
<script type="text/javascript" src="../member/js/jquery.lightbox-0.5.min.js"></script>
<script type="text/javascript" src="../member/js/jquery.lightbox-0.5.pack.js"></script>
<link rel="stylesheet" type="text/css" href="../jquery.lightbox-0.5.css" media="screen" />

<script type="text/javascript">
$(function() {
	// Use this example, or...
	$('a[@rel*=lightbox]').lightBox(); // Select all links that contains lightbox in the attribute rel
	// This, or...
	$('#gallery a').lightBox(); // Select all links in object with gallery ID
	// This, or...
	$('a.lightbox').lightBox(); // Select all links with lightbox class
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
<h1>Yspace Photo</h1>

<br \>
<div class="post" style="border: thin solid #C0C0C0">
<div id="gallery">
<div class="inpost" style="width:300px; float:left">
<h2 class="title">Policing And Security</h2>
<div id="police">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button1" runat="server" Text="more" 
            onclick="police_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>


<div class="inpost" style="width:300px; float:right">
<h2 class="title">Homeless</h2>
<div id="homeless">
    <asp:DataList ID="DataList2" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
         <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button2" runat="server" Text="more" 
            onclick="homeless_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>

<div class="inpost" style="width:300px; float:left">

<h2 class="title">Speaking Out</h2>
<div id="speak">
    <asp:DataList ID="DataList3" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
         <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button3" runat="server" Text="more" 
            onclick="speak_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>

<div class="inpost" style="width:300px; float:right">
<h2 class="title">Green and Wild Spaces</h2>
<div id="green">
    <asp:DataList ID="DataList4" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button4" runat="server" Text="more" 
            onclick="green_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>

<div class="inpost" style="width:300px; float:left">
<h2 class="title">Hansing Out</h2>
<div id="hansing">
    <asp:DataList ID="DataList5" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
         <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button5" runat="server" Text="more" 
            onclick="hansing_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>

<div class="inpost" style="width:300px; float:right">
<h2 class="title">Public Art</h2>
<div id="art">
    <asp:DataList ID="DataList6" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button6" runat="server" Text="more" 
            onclick="art_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>
        
<div class="inpost" style="width:300px; float:left">
<h2 class="title">Signs</h2>
<div id="sign">
    <asp:DataList ID="DataList7" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
         <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button7" runat="server" Text="more" 
            onclick="sign_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>

<div class="inpost" style="width:300px; float:right">
<h2 class="title">Community Access Places</h2>
<div id="community">
    <asp:DataList ID="DataList8" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button8" runat="server" Text="more" 
            onclick="community_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>

<div class="inpost" style="width:300px; float:left">
<h2 class="title">City Spaces</h2>
<div id="city">
    <asp:DataList ID="DataList9" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
         <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button9" runat="server" Text="more" 
            onclick="city_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>
        
<div class="inpost" style="width:300px; float:right">
<h2 class="title">Being Active</h2>
<div id="active">
    <asp:DataList ID="DataList10" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button10" runat="server" Text="more" 
            onclick="active_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>   

<div class="inpost" style="width:300px; float:left">
<h2 class="title">Favourite Spaces</h2>
<div id="favourite">
    <asp:DataList ID="DataList11" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
         <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button11" runat="server" Text="more" 
            onclick="favourite_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div>  

<div class="inpost" style="width:300px; float:right">
<h2 class="title">Unfavourite Spaces</h2>
<div id="unfavourite">
    <asp:DataList ID="DataList12" runat="server" RepeatColumns="3" CellPadding="2"
        RepeatDirection="Horizontal">
         <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Display.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' width="96px" height="60px" alt=""/>
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
      <div id="moreBtn"><asp:Button ID="Button12" runat="server" Text="more" 
            onclick="unfavourite_Click" BackColor="White" ForeColor="Blue"/></div>
   

</div>
</div> 
        </div> 
            <div id="moreBtn"><asp:Button ID="Button13" runat="server" Text="Upload" 
            onclick="upload_Click" BackColor="White" ForeColor="Blue"/></div>
     </div>
    
    </div>
    
   

</asp:Content>