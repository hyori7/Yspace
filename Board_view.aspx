<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Board_view.aspx.cs" Inherits="yspace.board.Board_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 75px;
        }
        .style5
        {
            width: 68px;
        }
        .style6
        {
            width: 66px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
 <%--<uc1:LoginCheck_WebUserControl ID="LoginCheck_WebUserControl1" runat="server" />--%>
        <table id="Table1" border="3" bordercolor="#dedce2" cellpadding="0" 
            cellspacing="0" style="border-style: inherit; border-color: #C0C0C0; BORDER-COLLAPSE: collapse; HEIGHT: 56px; color: #FFFFFF; font-weight: bold;" 
            width="620" align="center" bgcolor="#003366">
            <tr>
                <td style="WIDTH: 58px; HEIGHT: 26px" width="58" align="center" valign="middle">
                   <asp:Label ID="Label2" runat="server" Text="NAME"></asp:Label>
                   <%-- <asp:Image ID="Image6" runat="server" ImageUrl="images/board_view_03.gif" />--%>
                </td>
                <td align="center" valign="middle">
                    <font face="굴림"><asp:Label ID="lblName" runat="server" Font-Size="medium"></asp:Label>
                    </font>
                </td>
                <td align="right" style="HEIGHT: 26px" width="450">
                    <asp:Label ID="lblview" runat="server" Font-Size="Smaller" Visible="False"></asp:Label>
                    <asp:Label ID="lblDate" runat="server" Font-Size="Smaller" Width="214px"></asp:Label>
                    / Hit count:&nbsp;
                    <asp:Label ID="lblHit" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="WIDTH: 58px" valign="middle" width="58" align="center">
                    <%--<asp:Image ID="Image2" runat="server" ImageUrl="images/board_view_07.gif" />--%>
                    <asp:Label ID="Label1" runat="server" Text="SUBJECT"></asp:Label>
                </td>
                <td colspan="2" width="450">
                    <font face="굴림">&nbsp;&nbsp;&nbsp;</font>
                    <asp:Label ID="lblTitle" runat="server" Font-Size="Smaller"></asp:Label>
                </td>
            </tr>
        </table>
        <table id="AutoNumber2" cellpadding="0" 
            cellspacing="0" style="border-color: #C0C0C0; BORDER-COLLAPSE: collapse; HEIGHT: 254px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid;" 
            width="620" align="center">
            <tr>
                <td style="HEIGHT: 221px" valign="top" width="535">
                    <br />
                    &nbsp;
                    <asp:Label ID="lblMemo" runat="server" Font-Size="Smaller"></asp:Label>
                </td>
            </tr>
           <%-- <tr>
                <td width="535">
                    <asp:Image ID="Image5" runat="server" ImageUrl="images/free_board_12.gif" />
                </td>
            </tr>--%>
        </table>
        <table id="Table2" bgcolor="white" border="0" bordercolor="#dedce2" 
            cellpadding="0" cellspacing="0" 
            style="WIDTH: 600px; BORDER-COLLAPSE: collapse; HEIGHT: 34px" 
        width="600px" align="center">
            <tr>
                <td class="style4">
                    <a href="Board_write.aspx?mode=edit&amp;seq=<%=seq%>">
                    <%--<img bgcolor="white" border="0" 
                        src="images/board_view_23.giff" />--%>Modify</a>
                </td>
                <td class="style5">
                    <a href="Board_list.aspx">
                   List</a>
                </td>
                <td class="style6">
                    <a href="Board_write.aspx?mode=reply&amp;seq=<%=seq%>">
                    Reply</a>
                </td>
                <td align="right" width="285">
                    <a href="board_delete.aspx?seq=<%=seq%>">
                    Delete</a><a 
                        href="board_write.aspx"></a></td>
            </tr>
        </table>
    

</div>

</asp:Content>