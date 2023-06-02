<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lancamento.aspx.cs" Inherits="ControleControle.lancamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <div class="geral">
        <form id="form1" runat="server">

           
                <div>
                    Lançamento de Contrato<br />
                    <hr />
                    <br />
                    Informe o nome da ação&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Informe o formenedor da ação&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nro NF&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                    <asp:TextBox ID="Text_nomeAcao" runat="server" Height="25px" Width="282px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Text_nomeFornecedor" runat="server" Height="25px" Width="260px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Text_nroNF" runat="server" Height="25px" Width="134px"></asp:TextBox>
                    <br />
                    <br />
                    Valor a ser usado<br />
                    <br />
        &nbsp;<asp:TextBox ID="Text_valorUsado" runat="server" Height="28px" Width="172px"></asp:TextBox>
                    <br />
                    <br />
                    <hr />
                    <br />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    <br />
                    <hr />
                    <br />
                    <asp:Button ID="btn_Salvar" runat="server" Text="Salvar" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            
        </form>
    </div>
</body>
</html>
