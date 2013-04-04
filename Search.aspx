<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="yspace.WebForm16" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
<p>Search results ></p>
  <asp:DataList ID="DataList10" runat="server" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Vertical">
      <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
      <AlternatingItemStyle BackColor="#DCDCDC" />
      <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
      <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
      <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />      
    <ItemTemplate>
    <table style="width:100%">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>' ForeColor="#0066CC" Font-Size="Medium" Font-Bold="True"></asp:Label>
        </td>
        <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text='<%# Eval("authoranddate") %>'></asp:Label>
        </td>
        </tr>
            
    </tr> 
    <tr>
        <td colspan="2">
            <asp:Label ID="Label2" runat="server" Text='<%# Eval("content") %>'></asp:Label>
        </td>
    </tr>
    </table>
        </ItemTemplate> 
    </asp:DataList>


</div>
</asp:Content>
