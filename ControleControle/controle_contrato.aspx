<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controle_contrato.aspx.cs" Inherits="ControleControle.ControleContrato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 

<link rel="stylesheet" type="text/css" href="~/css/Site.css" />
<script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script  src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
 <script src="Scripts/jquery-3.6.0.min.js"></script>
 <script src="https://igorescobar.github.io/jQuery-Mask-Plugin/js/jquery.mask.min.js"></script>           
 <!--<script src="Scripts/jquery.maskedinput.min.js"></script> -->
   
     <script type="text/javascript">
         jQuery(function ($) {

             $("#Text_ValorUsado").mask("#.##0,00", { reverse: true });

         });

     </script>   
    <title></title>
    <style type="text/css">
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            margin-top: 0px;
        }
    </style>
    </head>
<body style="height: 1615px; margin-bottom: 5px; ">
    <div class="geral">
        <form id="form1" runat="server">

            <div style="height: 967px; width: auto;">


                <div class="menu">
                <div class="logoTitle">

                    <asp:Image ID="Image1" ImageUrl="~/imagens/logo-arcomix_fundoBranco.png" runat="server" Height="63px" Width="126px" />     
                    <asp:Label ID="Label1" runat="server" Text="Controle de Contratos - ARCOMIX"></asp:Label>

                     <nav class="alinhamento">
                            
                            <ul class="auto-style1_controlecontrato">                                
                                <li><asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="False" ForeColor="White" OnClick="LinkButton1_Click1">HOME</asp:LinkButton></li>
                                <li><asp:HyperLink ID="HyperLink1" runat="server">CONFIGURAR</asp:HyperLink></li>
                                <li><asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="False" ForeColor="White" OnClick="LinkButton2_Click" Font-Bold="True">CARREGAR</asp:LinkButton></li>
                                <li><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click" Font-Underline="False" ForeColor="White" Font-Bold="True">VOLTAR</asp:LinkButton> </li>
                                <li> <asp:LinkButton ID="btn_sair_ln" runat="server" OnClick="btn_sair_ln_Click" Font-Underline="False" ForeColor="White" Font-Bold="True">SAIR</asp:LinkButton></li>
                            </ul>
                           
                    </nav>

                </div>

            </div>

                <div class="conteudo" style="font-family: Arial, Helvetica, sans-serif; font-size: x-large; font-weight: bold; font-style: inherit; font-variant: normal">
              
                    Numero do Contrato
                    <!-- <asp:LinkButton ID="LinkButton3_" runat="server" OnClick="LinkButton1_Click">VOLTAR</asp:LinkButton> -->
                    <!--<asp:LinkButton ID="btn_sair_ln1" runat="server" OnClick="btn_sair_ln_Click">SAIR</asp:LinkButton>  -->
                   
                 

                    <div class="div_pesquisa">
                    <asp:TextBox ID="Text_NroContrato" runat="server" OnTextChanged="Text_NroContrato_TextChanged" Font-Bold="True" required="true" onkeypress="return event.charCode >= 48 && event.charCode <= 57" Font-Size="14pt" MaxLength="9"></asp:TextBox>
                    
                    &nbsp;
                    
                    <asp:Button ID="btn_PesquisaContrato" runat="server" OnClick="btn_PesquisaContrato_Click" Text="Pesquisa" CommandName="btn_PesquisaName" BackColor="#000066" BorderStyle="Solid" CssClass="auto-style3" Font-Bold="True" ForeColor="White" Height="32px" Width="194px" />
                    </div>
                                      
                    <hr />
                  
                    <asp:GridView ID="grd_pesquisaContratos" runat="server" OnSelectedIndexChanged="grd_pesquisaContratos_SelectedIndexChanged" CellPadding="4" Font-Bold="True" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
                <div class="div_alinhamento">

                    <div class="alinhamento2">

                    <h3>Informações do Contrato </h3>
                    <hr />

                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                    <br />
                      
                    <div class="textfield">
                        
                    <label>Nome da Ação <br />
                    <asp:TextBox ID="Text_Acao" runat="server" Width="500px" Height="24px" Font-Bold="True" Font-Size="11pt" ReadOnly="True" MaxLength="48"></asp:TextBox>
                    </label>
                    
                    </div>
                                                                             
                        
                    <br />

                    <div class="textfield">
                    
                    <label>Nome do Fornecedor <br />
                    <asp:TextBox ID="Text_Fornecedor" runat="server" Width="500px" Height="24px" OnTextChanged="Text_Fornecedor_TextChanged" Font-Bold="True" Font-Size="11pt" ReadOnly="True" MaxLength="38"></asp:TextBox>
                    </label>

                    </div> 

                     <br />


                     <div class="textfield">
                        
                    <label>Nome do Gestor<br />
                        <asp:TextBox ID="Text_Gestor" runat="server" Width="500px" Height="24px" Font-Bold="True" Font-Size="11pt" Font-Strikeout="False" ReadOnly="True"></asp:TextBox>
                    </label>

                    </div> 
                   
                     <br />
                      
                    <div class="textfield_alin">  

                    <label>Data do Contrato <br />
                    <asp:TextBox ID="dta_contrato" runat="server" Width="210px" Height="24px" Font-Bold="True" Font-Size="11pt" ReadOnly="True"></asp:TextBox>
                    &nbsp;
                    </label>
                     
                     <br />  
                                        
                   
                    <label>Codigo do Gestor <br />
                    <asp:TextBox ID="TxtCodGestor" runat="server" Height="24px" Width="210px" Font-Bold="True" Font-Size="11pt" OnTextChanged="TxtCodGestor_TextChanged" ReadOnly="True"></asp:TextBox>
                    </label>

                   </div>


                     <div class="textfield_alin">

                    <label>Cod. Fornecedor <br />
                    <asp:TextBox ID="TextCodFornecedor" runat="server" Height="24px" Width="210px" Font-Bold="True" Font-Italic="False" Font-Size="11pt" OnTextChanged="TextCodFornecedor_TextChanged" ReadOnly="True" MaxLength="7"></asp:TextBox>
                    &nbsp;
                    </label>
                    <br />
                   

                    <label>Numero da Loja <br />
                    <asp:TextBox ID="TextNroLoja" runat="server" Height="24px" Width="210px" Font-Bold="True" Font-Size="11pt" ReadOnly="True"></asp:TextBox>
                    </label>

                     </div>
                     
                    <div class="textfield_alin">  
                        
                   
                        
                    <label>Valor do Contrato <br />
                    <asp:TextBox ID="Text_ValorContrato" runat="server" Height="24px" Width="209px" Font-Bold="True" Font-Size="11pt" OnTextChanged="Text_ValorContrato_TextChanged" ReadOnly="True"></asp:TextBox>
                    
                    &nbsp;
                    
                    </label>
                        <br />
                                        

                    <label>Saldo do Contrato <br />
                    <asp:TextBox ID="Text_SaldoContrato" runat="server" Height="24px" Width="210px" Font-Bold="True" Font-Size="11pt" ReadOnly="True"></asp:TextBox>
                    </label>

                 
                                     
                    </div>
                                           
                    </div>

                    <div class="alinhamento3">

                    <h3>Dados para o Lançamento:</h3> 
                          
                        
                         <div class="textfield_alin"> 
                   
                            <label>Cod. do Fornec. 
                            <asp:TextBox ID="Text_codFornecedor_acao" runat="server" Height="24px" Width="110px" OnTextChanged="codFornecedor_acao_TextChanged" AutoPostBack="True" Font-Bold="True" onkeypress="return event.charCode >= 48 && event.charCode <= 57" Font-Size="11pt" MaxLength="8" CssClass="auto-style2"></asp:TextBox>
                            </label>
                        
                             &nbsp;&nbsp;     &nbsp;   
                               
                            <asp:DropDownList ID="drpList_Lojas" runat="server" OnSelectedIndexChanged="drpList_Lojas_SelectedIndexChanged" Height="35px" Width="180px" AutoPostBack="True" DataTextField="Selecione a Loja" Font-Size="14pt">
                            <asp:ListItem Selected="True" Value="0">Selecione a Loja</asp:ListItem>
                            </asp:DropDownList>

                       </div>
                                         
                                              
                       
                         <div class="textfield">

                           <label>Nome do Fornecedor da Ação  <br />
                            <asp:TextBox ID="Text_nomeFornecedorAcao" runat="server" Height="22px" Width="500px" Font-Bold="True" Font-Size="11pt" MaxLength="48"></asp:TextBox>
                          </label>                                            
                          
                          </div>

                         <div class="textfield">

                        <label>Informe o Nome da Ação <br />
                        <asp:TextBox ID="Text_acaoEdicao" runat="server" Height="22px" Width="500px" Font-Bold="True"  Font-Size="11pt" AutoPostBack="True" MaxLength="48"></asp:TextBox>
                       </label>

                       </div>

                       <div class="textfield">

                       <label>Oberservação <br />
                       <asp:TextBox ID="Text_observacao" runat="server" Height="22px" Width="500px" OnTextChanged="Text_observacao_TextChanged" Font-Bold="True"  Font-Size="11pt" MaxLength="48"></asp:TextBox>
                    
                       </label> 

                      </div>
                       <!--
                        
                         <div class="textfield_alin"> 
                   
                            <label> Cod. do Forn. 
                            <asp:TextBox ID="Text_codFornecedor_acao1" runat="server" Height="24px" Width="110px" OnTextChanged="codFornecedor_acao_TextChanged" AutoPostBack="True" Font-Bold="True" onkeypress="return event.charCode >= 48 && event.charCode <= 57" Font-Size="11pt" MaxLength="8"></asp:TextBox>
                            </label>
                        
                             &nbsp;&nbsp;     &nbsp;   
                               
                            <asp:DropDownList ID="drpList_Lojas1" runat="server" OnSelectedIndexChanged="drpList_Lojas_SelectedIndexChanged" Height="35px" Width="180px" AutoPostBack="True" DataTextField="Selecione a Loja" Font-Size="14pt">
                            <asp:ListItem Selected="True" Value="0">Selecione a Loja</asp:ListItem>
                            </asp:DropDownList>

                       </div>
                        
                        -->
                         <div class="textfield_alin"> 
                                      
                        <label>Valor a ser Usado <br />
                        R$<asp:TextBox ID="Text_ValorUsado" runat="server" Width="178px" Height="23px" OnTextChanged="Text_ValorUsado_TextChanged" AutoPostBack="True" Font-Bold="True" Font-Size="11pt"  MaxLength="12"></asp:TextBox>
                    
                        </label>

                              &nbsp;&nbsp; &nbsp;&nbsp;  &nbsp;&nbsp;  
                       
                        <label>Nota Fiscal <br />
                        <asp:TextBox ID="TextNronf" runat="server" Height="23px" Width="160px" Font-Bold="True" Font-Italic="False" Font-Size="11pt" onkeypress="return event.charCode >= 48 && event.charCode <= 57" MaxLength="9"></asp:TextBox>
                        </label>

                        </div>

                        </div>


                     </div>
                    <br />
                                     
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     
                    <asp:Button ID="btn_Salvar" runat="server" Text="Salvar" OnClick="btn_executar_Click" BackColor="#000066" ForeColor="White" Height="44px" Width="195px" />
                    &nbsp;<br />
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
                    <br />
                    <br />
                    <br />
                    
                </div>
                </div>
        </form>
    </div> 
</body>
</html>
