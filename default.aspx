<%@ Page Language="C#" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Homepage" Title="Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
		<div class="post" style="border: thin solid #C0C0C0">	
		<div class="inpost"style="width:300px; float:left">			
            <embed src="movie3.swf" width="297" hidden=false ShowControls=0 ShowStatusbar=0 volume=100 autostart=true></embed>
            </div>
            <div class="inpost" style="width:300px; float:right">   
                <h2 class="title"><a href="#">NOTICES</a></h2>
		            <p class="byline">
                       Posted On:&nbsp; <asp:Label ID="Day" runat="server"></asp:Label></p>
                <div class="container">
                    <h3>
                        <span style="font-weight: bold;">
                            <asp:Label ID="noticeTitle" runat="server"></asp:Label></span></h3>
                    <p>
                        <asp:TextBox ID="noticeContent" runat="server" TextMode="MultiLine" ReadOnly="true"
                            Style="width: 300px; height: 130px; border: none; color: #2A536F; font-family: Tahoma,Arial,Helvetica,sans-serif;
                            font-size: 11px; text-align: justify;"></asp:TextBox></p>
                </div>
            </div>
            <div style="clear: both; visibility: hidden; height: 0px">
                &nbsp;</div>
        </div>
        <div class="post">
            <!-- left inside of contents -->
            <div class="post" style="width: 300px; float: left">
                <h2 class="title">
                    <a href="#">NEWS</a></h2>
                <p class="byline">
                    Posted on
                    <asp:Label ID="Day2" runat="server"></asp:Label></p>
                <div class="entry">
                    <h3>
                        <span style="font-weight: bold;">
                            <asp:Label ID="newsTitle" runat="server"></asp:Label></span></h3>
                    <p>
                        <asp:TextBox ID="newsContent" runat="server" TextMode="MultiLine" ReadOnly="true"
                            Style="width: 300px; height: 200px; border: none; color: #2A536F; font-family: Tahoma,Arial,Helvetica,sans-serif;
                            font-size: 11px; text-align: justify;"></asp:TextBox>
                    </p>
                    <p class="links">
                        <a href="#">More</a></p>
                    <br />
                    <br />
                </div>
		       
	
		       
		       <p style="border-color: #CCCCCC; border-style: dotted none none none; border-width: thin;"></p>
<!-- second in-content -->
                <h2 class="title"><a href="#">NEWS ARCHIVES</a></h2>
                <p class="byline">
                    Posted on
                    <asp:Label ID="Day3" runat="server"></asp:Label></p>
                <div class="entry">
                    <h3>
                        <span style="font-weight: bold;">
                            <asp:Label ID="archiveTitle" runat="server"></asp:Label></span></h3>
                    <p>
            
                            <asp:TextBox ID="archiveContent" runat="server" TextMode="MultiLine" ReadOnly="true"
                                Style="width: 300px; height: 200px; border: none; color: #2A536F; font-family: Tahoma,Arial,Helvetica,sans-serif;
                                font-size: 11px; text-align: justify;"></asp:TextBox>
                    </p>
                    <p class="links">
                        <a href="news.aspx">More</a></p>
                    <br />
                </div>

		    </div>			        
<!-- right inside of contents -->
		    <div class="post" style="width:300px; float:right">
		        <h2 class="title"><a href="#">NEW PHOTOS</a></h2>
		        <p class="byline">Posted by you and us</p>
		        <div class="entry">
		 <p>
		        <div id="homeImage">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
        CellSpacing="1">
        <ItemTemplate>
            <a>
                <img src='<%# "Display.aspx?id=" + Eval("id") %>' title='<%# Eval("description") %>' width="95" height="65" alt="" />
            </a>
            <br />
        </ItemTemplate>
    </asp:DataList>
                   </div>
                   </p>
                                 
				<p class="links"><a href="display.aspx">More</a></p><br /><br />				
		        </div>	
		        
		         <p style="border-color: #CCCCCC; border-style: dotted none none none; border-width: thin;"></p>


<!-- second inside of contents -->	
            	<h2 class="title"><a href="#">SHARE VIDEOS</a></h2>
			<p class="byline">Posted on October 1st, 2010</p>
			<div class="entry">
				<h3><span style="font-weight: bold;"></span></h3>            
                  <embed src="http://www.youtube.com/v/HvHOCqbA6rE"
                  type="application/x-shockwave-flash" wmode="transparent"
                  width="300">
                  </embed>  					
			</div>

	        
		    </div>		    
		    <div style="clear: both; visibility:hidden;height:0px">&nbsp;</div>
		</div>
	</div>
		<!-- end content -->
		
</asp:Content>
