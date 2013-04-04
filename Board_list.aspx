<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Board_list.aspx.cs" Inherits="yspace.WebForm18" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style3
    {
        font-size: x-small;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" style="vertical-align:middle;">  
        <div class="post">
       <%-- <uc1:logincheck_webusercontrol ID="LoginCheck_WebUserControl1" runat="server" />--%>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" 
            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" 
            Width="630px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <Columns>
                <asp:TemplateField  HeaderText="no" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Font-Size="9pt" style="text-align:center"
                            Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="9pt" 
                            NavigateUrl='<%# "Board_view.aspx?seq="+DataBinder.Eval(Container, "DataItem.Seq") %>' 
                            Text='<%# title(DataBinder.Eval(Container, "DataItem.subject").ToString(), DataBinder.Eval(Container, "DataItem.depth").ToString()) %>'></asp:HyperLink>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="name" HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="date">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Font-Size="9pt" 
                            Text='<%# DataBinder.Eval(Container, "DataItem.reg_date","{0:dd/MM}")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
        </asp:GridView><br />
    <table id="Table1" style="BORDER-COLLAPSE: collapse; background-color: #003366; color: #FFFFFF;" 
            borderColor="black" cellSpacing="0"
												cellPadding="0" width="630" border="0">
		<tr>
			<td width="58">&nbsp;&nbsp;&nbsp;<a href="Board_write.aspx" 
                    style="color: #FFFFFF; font-weight: bold;" ><span class="style3">New topic</span></A></td>
			<td align="right" width="442">&nbsp;
				<asp:checkbox id="chkName" runat="server" ForeColor="White" Text="NAME" 
                    Font-Bold="True"></asp:checkbox><asp:checkbox id="chkSubject" 
                    runat="server" ForeColor="White" Text="TITLE" Font-Bold="True"></asp:checkbox>
                <asp:checkbox id="chkMemo" runat="server" ForeColor="White" Text="CONTENT" 
                    Font-Bold="True">
                    </asp:checkbox><asp:textbox id="txtSearch" runat="server" ForeColor="DimGray" BorderStyle="Inset"></asp:textbox>
            </td>
			<td width="36">
			   <asp:imagebutton id="ImageButton1" runat="server" ImageUrl="images/b_search.gif"
                    onclick="ImageButton1_Click" style="height:24px;width:50px;float:right;"></asp:imagebutton>
                
                    </td>
            
            </tr>
	</table>
</div>
    </div>

</asp:Content>
