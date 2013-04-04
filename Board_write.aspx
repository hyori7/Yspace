<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Board_write.aspx.cs" Inherits="yspace.board.Board_Write" %>
<%@ Register src="LoginCheck_WebUserControl.ascx" tagname="LoginCheck_WebUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="visibility:visible"><uc1:LoginCheck_WebUserControl ID="LoginCheck_WebUserControl1" runat="server" /></div>
<div id="content">
<div align="center" class="post">

        
        
        <table id="WriteTable" runat="server" border="0" width="600px">
            <tr>
                <td width="23%">
                    　TiTle:</td>
                <td align="left" width="75%">
                    <asp:TextBox ID="txtSubject" runat="server" Width="450px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    　<asp:TextBox ID="memo_txt" runat="server" Height="313px" TextMode="MultiLine" 
                        Width="600px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table id="AutoNumber2" bgcolor="white" border="0" bordercolor="#111111" 
            cellpadding="0" cellspacing="0" 
            style="BORDER-COLLAPSE: collapse; width: 614px;">
            <tr>
                <td width="420">
                    <font face="굴림">
                    <asp:Label ID="Label1" runat="server" BorderColor="White" Font-Size="Smaller" 
                        ForeColor="#403F40" Width="296px"></asp:Label>
                    </font>
                </td>
                <td width="60">
                    <asp:ImageButton ID="ImageButton1" runat="server"
                        ImageUrl="images/b_confirm.png" onclick="ImageButton1_Click1" 
                        Width="40px" />
                </td>
                <td width="60">
                    <asp:ImageButton ID="ImageButton2" runat="server"
                        ImageUrl="images/b_cancel.png" onclick="ImageButton2_Click" 
                        Width="40px" />
                </td>
            </tr>
        </table>
</div>
</div>

</asp:Content>