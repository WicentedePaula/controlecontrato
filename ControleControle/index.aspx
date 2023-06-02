<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ControleControle.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="~/css/Site.css" />

<script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script  src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
    <title></title>

    <style type="text/css">
        .auto-style1 {
            margin-left: 39px;
        }
    </style>

</head>
<body>
    <div class="geral">
    <form id="form1" runat="server">

        <div style="height: 795px; font-size: 22px; font-weight: bold;">                                                                                                                                                             
            
            <div class="menu">
                <div class="logoTitle">

                    <asp:Image ID="Image1" ImageUrl="~/imagens/logo-arcomix_fundoBranco.png" runat="server" Height="63px" Width="126px" />     
                    <asp:Label ID="Label1" runat="server" Text="Controle de Contratos - ARCOMIX"></asp:Label>

                     <nav class="alinhamento">
                            <ul class="auto-style1">
                                <li><asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" OnClick="LinkButton5_Click">HOME</asp:LinkButton></li>
                                <li><asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Carregar" Font-Size="12pt" OnClick="LinkButton1_Click" Font-Underline="False" ForeColor="White">CARREGAR</asp:LinkButton></li>
                                <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="btn_lancamentobtn_Click" Font-Underline="False" ForeColor="White" Height="15pt">LANÇAMENTO</asp:LinkButton></li>
                                <li><asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Underline="False" ForeColor="White" OnClick="LinkButton3_Click">VOLTAR</asp:LinkButton></li>
                                <li> <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btn_sair_Click" Font-Underline="False" ForeColor="White">SAIR</asp:LinkButton></li>
                            </ul>
                    </nav>

                </div>

            </div>

            <div class="conteudo" style="font-family: Arial, Helvetica, sans-serif; font-size: x-large; font-weight: bold; font-style: inherit; font-variant: normal">

                    
            Informe o Período Carregar 
                
                    <br />
                &nbsp; &nbsp;&nbsp;
           
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:TextBox ID="Text_DtaInicial" runat="server" Font-Bold="True" Font-Size="15pt" TextMode="Date" required="true" ViewStateMode="Disabled" Height="25px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Text_dtaFinal" runat="server" OnTextChanged="TextBox1_TextChanged" Font-Bold="True" Font-Size="15pt" required="true" TextMode="Date" Height="25px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Button ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" Text="Pesquisar" CommandName="btnPesquisar" Height="56px" Width="158px" Font-Bold="True" BackColor="#080857" ForeColor="#F0F0F0" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chekSaldoZero" runat="server" Checked="True" OnCheckedChanged="chekSaldoZero_CheckedChanged" Text="Ocultar Contratos com Saldo Zero" AutoPostBack="True" Font-Bold="True" Font-Size="13pt" />
&nbsp;
                 
                    <br/>
                
                    
                    <br />
            
            <br />
            <hr />
    
            

            <asp:Panel ID="Panel1" runat="server" Height="602px" style="margin-left: 8px" Font-Bold="True" Font-Size="13pt" Font-Strikeout="False" ToolTip="Lançamento">
                <asp:GridView ID="GrdContratoIndex" runat="server" OnSelectedIndexChanged="GridCt_SelectedIndexChanged" OnRowCommand="GrdContratoIndex_RowCommand" CellPadding="4" Font-Bold="True" ForeColor="#333333" GridLines="None" ToolTip="Lançamento" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectText="Lanca"  ShowSelectButton="True" SelectImageUrl="~/icones/lanc.png" FooterText="Lançamento" >
                        <ItemStyle BorderStyle="None" Height="45px" VerticalAlign="Middle" />
                        </asp:CommandField>
                        <asp:ButtonField ButtonType="Image" CommandName="comando" Text="Detetalhes" FooterText="Alex" ImageUrl="~/icones/detalhes3.png" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                              

                <br />
                <br />
                VALOR TOTAL EM CONTRATOS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SALDO TOTAL EM CONTRATOS<br />
                <br />
                <br />
                <asp:TextBox ID="Text_valorContratoIndex" runat="server" Height="41px" Width="221px" BorderStyle="None" Font-Bold="True" Font-Size="18pt" ReadOnly="True" BackColor="#CCE6FF"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Text_SaldoContratoIndex" runat="server" Height="41px" Width="221px" BorderStyle="None" Font-Bold="True" Font-Size="18pt" ReadOnly="True" BackColor="#CCE6FF"></asp:TextBox>
            </asp:Panel>

       

            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
        </div>
        </div>

    </form>
      </div>
</body>
</html>
