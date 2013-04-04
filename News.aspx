<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" Title="News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="post">
            <h2 class="title">NEWS</h2>
            <p class="byline">
            </p>
            <div class="post">
            <div class="entry">
               <asp:DataList ID="DataList1" runat="server" Width="615">
               <ItemTemplate>
                <h2 class="title"><a><asp:Label ID="title" runat="server" Text='<%# Eval("title") %>'></asp:Label></a></h2>
                    <p class="byline">
                       Posted On:&nbsp; <asp:Label ID="date" runat="server" Text='<%# Eval("date") %>'></asp:Label></p>
                  <br />
                   <p><asp:Label ID="content" runat="server" Text='<%# Eval("content") %>'></asp:Label></p>
               </ItemTemplate>
            </asp:DataList>
            </div>
            </div>
            
    </div>
                
</div>
</asp:Content>
