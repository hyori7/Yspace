<%@ Page Language="C#"  MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Control.aspx.cs" Inherits="Control" Title="Untitled Page" %>
<%--

<script runat="server">
protected void DataList2_EditCommand(object source, 
    DataListCommandEventArgs e)
{
    DataList2.EditItemIndex = e.Item.ItemIndex;
    DataList2.DataBind();
}



protected void DataList2_UpdateCommand(object source, 
    DataListCommandEventArgs e)
{
   
    String imageId = DataList2.DataKeys[e.Item.ItemIndex].ToString();
    String approval = ((DropDownList)e.Item.FindControl("DropDownList1")).Text;
   
    SqlDataSource1.UpdateParameters["ori_id"].DefaultValue = imageId;
    SqlDataSource1.UpdateParameters["approval"].DefaultValue= approval;
    SqlDataSource1.Update();

    DataList2.EditItemIndex = -1;
    DataList2.DataBind();
}

</script>--%>

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
<div class="post">
   
   <div id="dolphinnav">
            <ul>
                <li><a href="../MainControl.aspx"><span>Main Control</span></a></li>
                <li><a href="../Control.aspx"><span>Image Control</span></a></li>
                <li><a href="../Article.aspx"><span>Article</span></a></li>
		  
            </ul>
            </div>
            
<br />  
<br />
<h1>Photo Approval</h1>
<div id="gallery">
<asp:DataList ID="DataList1" runat="server" CellPadding="2" RepeatColumns="5">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            <br />
            <a href='<%# "Control.aspx?id=" + Eval("id") %>'  title='<%# Eval("description") %>'>
                <img src='<%# "Control.aspx?id=" + Eval("id")%>'   width="120" height="80" alt="" />
            </a>
           
            <br />
            
            <asp:Button ID="update" runat="server" Text="Update" 
                PostBackUrl='<%# "approval.aspx?photoID="+DataBinder.Eval(Container, "DataItem.id") %>'/>
            <br />

        </ItemTemplate>
        </asp:DataList>
<br />
</div>

<div>
</div>

</div>

         
</div>
    
</asp:Content>