<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/yspace.Master" AutoEventWireup="true" CodeFile="DefaultLogin.aspx.cs" Inherits="yspace.WebForm20" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style3
    {
        height: 148px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
<div align="center" class="post">
<table id="LoginForm" runat="server" border="0" cellpadding="0" cellspacing="3">
            <tr>
                <td class="style3">
                    <h5>
                    </h5>
                    <h5>
                        &nbsp;</h5>
                    <h5>
                        &nbsp;</h5>
                    <h5>
                        <b>&quot;Please login&quot;</b></h5>
                </td>
            </tr>
            <tr>
                <td>
                    Your Name :<br />
                    <asp:TextBox ID="txtName" runat="server" Height="20px" Width="200px"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Your Password :<br />
                    <asp:TextBox ID="txtPwd" runat="server" Height="20px" TextMode="Password" 
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLoginOK" runat="server" Text="OK" 
                        Width="60px" onclick="btnLoginOK_Click" />
                    <asp:Button ID="Cancle_btn" runat="server" Text="Cancle" Width="60px" />
                    <asp:Button ID="Button1" runat="server" Text="Register" 
                        Width="60px" onclick="Button1_Click" />
                    <br />
                </td>
            </tr>
        </table>
        <br /><br /><br /><br /><br />
</div>
</div>
</asp:Content>
