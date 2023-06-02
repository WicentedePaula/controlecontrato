<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acoes.aspx.cs" Inherits="ControleControle.acoes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 524px">
    <form id="form1" runat="server">
        <div style="height: 567px">
            <br />
            <br />
            <asp:GridView ID="grd_retornoContratoLocalizado" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            Informe o nome da Acão<br />
            <asp:TextBox ID="text_nomeAcao" runat="server" Height="26px" Width="386px"></asp:TextBox>
            <br />
            <br />
            Informe o Valor da Ação<br />
            <asp:TextBox ID="text_valorAcao" runat="server" Height="28px" Width="162px"></asp:TextBox>
            <br />
            <br />
            Informe o numero da nota fiscal<br />
            <asp:TextBox ID="Text_ValorUsado" runat="server" Width="167px" Height="28px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_executar" runat="server" Text="Executar" />
            <br />
        </div>
    </form>
</body>
</html>
