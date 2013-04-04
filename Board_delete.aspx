<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="Board_delete.aspx.cs"
    Inherits="yspace.board.Board_Delete" %>
<%@ Register src="LoginCheck_WebUserControl.ascx" tagname="LoginCheck_WebUserControl" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
    <div class="post">
        <table id="Table2" runat="server" align="center" border="0" cellpadding="1" cellspacing="1"
            width="350">
            <tr valign="top">
                <td>
                    <uc1:logincheck_webusercontrol id="LoginCheck_WebUserControl1" runat="server" />
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <p align="center">
                        <font color="#535454" size="4">Do you want to delete?</font></p>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Height="24px" Width="48px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <p align="center">
                        <asp:Button ID="Button2" runat="server" Height="24px" OnClick="Button2_Click" Text="Delete"
                            Width="72px" />
                        <font face="굴림">&nbsp;&nbsp; </font>
                        <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" Text="Cancel"
                            Width="63px" />
                    </p>
                </td>
            </tr>
        </table>
        </div>
    </div>
</asp:Content>
