<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chave.aspx.cs" Inherits="chave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 363px;
            width: 546px;
        }
        .auto-style2 {
            width: 100%;
            height: 347px;
        }
        .auto-style3 {
            width: 40px;
        }
        .auto-style4 {
            width: 434px;
        }
        .auto-style5 {
            width: 40px;
            height: 138px;
        }
        .auto-style6 {
            width: 434px;
            height: 138px;
        }
        .auto-style7 {
            height: 138px;
        }
        .auto-style8 {
            width: 40px;
            height: 195px;
        }
        .auto-style9 {
            width: 434px;
            height: 195px;
        }
        .auto-style10 {
            height: 195px;
        }
    </style>
</head>
<body style="width: 548px; height: 357px">
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#D9ECFF" Height="359px" Width="549px">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6" style="background-color: #FFC6B3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Image ID="Image1" runat="server" Height="99px" Width="120px" ImageUrl="~/imagens/1031eing.gif" />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Atualização de licença.</td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style9" style="background-color: #FFFFCC">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Senha do usuário :&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="296px"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Height="38px" Text="OK" Width="117px" OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
