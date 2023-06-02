using ControleControle.Models;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControleControle
{
    public partial class ControleContrato : System.Web.UI.Page
    {
        ContratoBLL contratoBll = new ContratoBLL();
        AcaoBLL acaoBll = new AcaoBLL();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            bool contron = contratoBll.retornaValoresTbTempContrato();
            //bllRetornaLojas();
            if (contron) 
            {
              
                carregaDadosPagina();

            }
        }
    

        private void bllRetornaLojas()
        {   
            drpList_Lojas.DataSource = contratoBll.bllRetornaLojas();
            drpList_Lojas.DataValueField = "NROEMPRESA";
            drpList_Lojas.DataTextField = "EMPRESA";
            drpList_Lojas.DataBind();

        }

        protected void btn_PesquisaContrato_Click(object sender, EventArgs e)
        {  // busca no banco da consinco
       //     if (Text_codFornecedor_acao.Text.Equals(""))
        //    {
                retornaPesquisaContrato();
               
            //
           // }

        }

        /*
         * Método chamado quando o botao pesquisa é: Faz a busca no banco da consinco
         * acionado
         */
        public void retornaPesquisaContrato()
        {
            contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            grd_pesquisaContratos.DataSource = contratoBll.bllRetListaContratosBancoConsinco();
            grd_pesquisaContratos.DataBind();

        }

        public void retornaPesquisaContratoLoad()
        {
            contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            grd_pesquisaContratos.DataSource = contratoBll.carregaTelaContratoPag_load();
            grd_pesquisaContratos.DataBind();
                        
           
        }


        protected void grd_pesquisaContratos_SelectedIndexChanged(object sender, EventArgs e)
        {
            capturaCampos();
                                
            contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            contratoBll.COD_FORNECEDOR = convertInt(TextCodFornecedor.Text);
            contratoBll.NROEMPRESA = convertInt(TextNroLoja.Text);
            contratoBll.COD_GESTOR = convertInt(TxtCodGestor.Text);
            contratoBll.VALOR_CONTRATO = convertDecimal(Text_ValorContrato.Text);
            contratoBll.DTA_CONTRATO = dta_contrato.Text;


            if (!contratoBll.existeContrato())
            {

               Text_SaldoContrato.Text = Text_ValorContrato.Text;
            }
            else
            {
                Text_SaldoContrato.Text = contratoBll.retornaSaldoContrado().ToString();
                
            }
            // EM TESTE
            //retornaPesquisaContrato();
            retornaPesquisaContratoLoad();
            bllRetornaLojas();

        }

       
        private void capturaCampos()
        {
       //     grd_pesquisaContratos.RowCommand
            Text_NroContrato.Text = grd_pesquisaContratos.SelectedRow.Cells[1].Text;
            TextCodFornecedor.Text = grd_pesquisaContratos.SelectedRow.Cells[2].Text;
            TextNroLoja.Text = grd_pesquisaContratos.SelectedRow.Cells[4].Text;
            Text_Fornecedor.Text = grd_pesquisaContratos.SelectedRow.Cells[5].Text;
            TxtCodGestor.Text = grd_pesquisaContratos.SelectedRow.Cells[6].Text;
            Text_Gestor.Text = grd_pesquisaContratos.SelectedRow.Cells[7].Text;
          //Text_Acao.Text = grd_pesquisaContratos.SelectedRow.Cells[8].Text;
            Text_Acao.Text = Server.HtmlDecode(grd_pesquisaContratos.SelectedRow.Cells[8].Text);
            Text_ValorContrato.Text = grd_pesquisaContratos.SelectedRow.Cells[9].Text;
            dta_contrato.Text = grd_pesquisaContratos.SelectedRow.Cells[11].Text;
          //Text_SaldoContrato.Text = grd_pesquisaContratos.SelectedRow.Cells[10].Text;
                     
        }

        
        private void inserirTabelaAcoes()
        {
            acaoBll.NOME_ACAO = Text_acaoEdicao.Text;
            acaoBll.DTA_ACAO = capturaDataSistema();
            acaoBll.VALOR_ACAO = convertDecimal(Text_ValorUsado.Text);
            acaoBll.NROEMPRESA = convertInt(TextNroLoja.Text);
            acaoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            acaoBll.nomeFornecedorAcao = Text_nomeFornecedorAcao.Text;
            acaoBll.observacao = Text_observacao.Text;
            acaoBll.nomeDaLoja = drpList_Lojas.SelectedItem.Text;
 
           
            acaoBll.cadastrarAcoes();

        }

        protected void btn_executar_Click(object sender, EventArgs e)
        {   
            contratoBll.NRO_CONTRATO =   convertInt(Text_NroContrato.Text);
            contratoBll.COD_FORNECEDOR = convertInt(TextCodFornecedor.Text);
            contratoBll.NROEMPRESA =     convertInt(TextNroLoja.Text);
            contratoBll.COD_GESTOR =     convertInt(TxtCodGestor.Text);

            string vlrcontrato = Text_ValorContrato.Text.Trim();
            vlrcontrato = vlrcontrato.Substring(2); // Esta linha retira o cifrão (R$) da frente do valor

            contratoBll.VALOR_CONTRATO = convertDecimal(vlrcontrato);
            contratoBll.DTA_CONTRATO = dta_contrato.Text;
            contratoBll.NRO_NF = TextNronf.Text;
           
                                     
            if (!contratoBll.existeContrato())
            {
                                                       
                
                contratoBll.VALOR_CONTRATO = convertDecimal(vlrcontrato);
                acaoBll.VALOR_ACAO = convertDecimal(Text_ValorUsado.Text);

                if (acaoBll.VALOR_ACAO <= contratoBll.VALOR_CONTRATO && acaoBll.VALOR_ACAO >= 0) // Nesto momento o saldo na tabela e zero daí pegar o valor do contrato
                {   
                    //inserir os dados na tabela ações
                    inserirTabelaAcoes();

                    //aqui vou capturar o id_acao gerado com o metodo abaixo e lançar na variavel id_acao atabela contrato
                    contratoBll.ID_ACAO = convertInt(acaoBll.returnIdAcaoes());

                 //   contratoBll.VALOR_CONTRATO = convertDecimal(contratoBll.VALOR_CONTRATO.ToString("N2"));
                 //   acaoBll.VALOR_ACAO = convertDecimal(acaoBll.VALOR_ACAO.ToString("N2"));
                                                         
                    contratoBll.SALDO = (contratoBll.VALOR_CONTRATO - acaoBll.VALOR_ACAO);
                    contratoBll.inserirContrato();
                 
                    retornaPesquisaContratoSemColunaIdAcao();
                   
                    Text_SaldoContrato.Text = contratoBll.retornaSaldoContrado();

                }
                else
                {   
                    contratoBll.SALDO = convertDecimal(Text_SaldoContrato.Text);
                            
                    retornaPesquisaContrato();
                   //INSERIR AQUI COMANDO PARA APAGAR OS DADOS DO FORMULARIO
                }

            }
            else
            {

                inserirTabelaAcoes();
                contratoBll.ID_ACAO = convertInt(acaoBll.returnIdAcaoes());

                contratoBll.SALDO = calculaSaldo();
                contratoBll.updateTbContrato();
                // carregaContratoPosEdicao();
                retornaPesquisaContratoSemColunaIdAcao();
                Text_SaldoContrato.Text = contratoBll.retornaSaldoContrado();

            }
          
           
        }

        private decimal calculaSaldo()
        {
            decimal resultadoSaldo = 0;
         
            contratoBll.SALDO = convertDecimal(contratoBll.retornaSaldoContrado());
            acaoBll.VALOR_ACAO = convertDecimal(Text_ValorUsado.Text);

            if (acaoBll.VALOR_ACAO >= 0 && acaoBll.VALOR_ACAO <= contratoBll.SALDO)
            {   
                //contratoBll.SALDO = convertDecimal(contratoBll.retornaSaldoContrado());
                //acaoBll.VALOR_ACAO = convertDecimal(Text_ValorUsado.Text); JA ESTA SENDO FEITO FORA
                resultadoSaldo = (contratoBll.SALDO - acaoBll.VALOR_ACAO);
            }
            else
            {
                resultadoSaldo = convertDecimal(Text_SaldoContrato.Text);
                retornaPesquisaContrato();
                //INSERIR AQUI COMANDO PARA APAGAR OS DADOS DO FORMULARIO
            }
            
            return resultadoSaldo;
        }


        public void retornaPesquisaContratoSemColunaIdAcao()
        {
            contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            contratoBll.COD_FORNECEDOR = convertInt(TextCodFornecedor.Text);
            contratoBll.NROEMPRESA = convertInt(TextNroLoja.Text);
            contratoBll.COD_GESTOR = convertInt(TxtCodGestor.Text);

             // EM TESTE
          //  grd_pesquisaContratos.DataSource = contratoBll.retornaContratoSemIdAcao();
            grd_pesquisaContratos.DataSource = contratoBll.carregaTelaContratoPag_load(); 
            grd_pesquisaContratos.DataBind();
        }


        //Pega os contratos da tebela Contrato do bando bd_contratos
        private void carregaContratoPosEdicao()
        {
            contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            contratoBll.COD_FORNECEDOR = convertInt(TextCodFornecedor.Text);
            contratoBll.NROEMPRESA = convertInt(TextNroLoja.Text);
            contratoBll.COD_GESTOR = convertInt(TxtCodGestor.Text);
            
            grd_pesquisaContratos.DataSource = contratoBll.retornaContratoParaEdicao();
            grd_pesquisaContratos.DataBind();
                      
        }

        
        private int convertInt(string valor )
        {
            int valorConvertido;
            int.TryParse(valor, out valorConvertido); ;
            return valorConvertido;
        }

        private decimal convertDecimal(string valor)
        {           
            decimal valorConvertido;
           
            decimal.TryParse(valor, out valorConvertido);

            return valorConvertido;
        }

       // Fora de uso por enquando
        public void carregaDadosPagina()
        {
            grd_pesquisaContratos.DataSource = contratoBll.carregaTelaContratoPag_load();
            grd_pesquisaContratos.DataBind();

            // contratoBll.inserirTbTempContrato();
            /*
            string nroCon = Request.QueryString["nroC"];
           
            string nroEmp = Request.QueryString["nroEmp"];
            string coGest = Request.QueryString["coGest"];
            string saldo = Request.QueryString["saldo"];

            grd_pesquisaContratos.DataSource = contratoBll.carregaContratoSemId_Index(convertInt(nroCon), convertInt(nroEmp), convertDecimal(saldo));
            grd_pesquisaContratos.DataBind();
            */
        }

        private void limparTela()
        {


        }

          

        private String capturaDataSistema()
        {
            string data = DateTime.Now.ToString("dd-MM-yyyy");

            return data;
        }

        protected void Text_ValorUsado_TextChanged(object sender, EventArgs e)
        {
            if (Text_ValorUsado.Text != "")
            {
           //     Text_ValorUsado.Text = Convert.ToDecimal(Text_ValorUsado.Text).ToString("C");
            }
            

            
        }
        

        protected void drpList_Lojas_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaDadosPagina();
        }

       
        //#############################################################################

        //SEM FUNÇÃO
        /*Retorna um grid da tabela contrato do banco BD_Contrato
         * 
         */
        public void retornaPesquisaContratoBancoBD_contratosPosEdicao()
        {
            contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            contratoBll.NRO_CONTRATO = convertInt(TextNroLoja.Text);
            grd_pesquisaContratos.DataSource = contratoBll.bllRetListaBancoBd_Contratos();
            grd_pesquisaContratos.DataBind();
        }

        //SEM FUNCAO
        private void capturaCamposTabelaContratoBD_consinco()
        {
           DataTable data = contratoBll.bllRetListaBancoBd_Contratos();
            Text_NroContrato.Text = data.Rows[0]["NRO_CONTRATO"].ToString();
            TextCodFornecedor.Text = data.Rows[0]["SEQFORNECEDOR"].ToString();
            TextNroLoja.Text = data.Rows[0]["NROEMPRESA"].ToString();
            TxtCodGestor.Text = data.Rows[0]["SEQGESTO"].ToString();
            Text_ValorContrato.Text = data.Rows[0]["VALOR_CONTRATO"].ToString();
            TextNronf.Text = data.Rows[0]["NRO_NF"].ToString();
            Text_SaldoContrato.Text = data.Rows[0]["SALDO_CONTRATO"].ToString();
            
            /*
            Text_NroContrato.Text = grd_pesquisaContratos.SelectedRow.Cells[1].Text;
            TextCodFornecedor.Text = grd_pesquisaContratos.SelectedRow.Cells[2].Text;
            TextNroLoja.Text = grd_pesquisaContratos.SelectedRow.Cells[3].Text;
            TextNronf.Text = grd_pesquisaContratos.SelectedRow.Cells[6].Text;
            TxtCodGestor.Text = grd_pesquisaContratos.SelectedRow.Cells[4].Text;
            Text_Acao.Text = grd_pesquisaContratos.SelectedRow.Cells[8].Text;
            Text_ValorContrato.Text = grd_pesquisaContratos.SelectedRow.Cells[5].Text;
            Text_SaldoContrato.Text = grd_pesquisaContratos.SelectedRow.Cells[7].Text;
           */

        }

        protected void Text_Fornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Text_NroContrato_TextChanged(object sender, EventArgs e)
        {

        }

        protected void codFornecedor_acao_TextChanged(object sender, EventArgs e)
        {
            
            contratoBll.COD_FORNECEDOR = convertInt(Text_codFornecedor_acao.Text);
         //   Text_nomeFornecedorAcao.Text = contratoBll.retornaNomeFornecedor();
            //  Text_nomeLoja.Text = contratoBll.retornaNomeEmpresa(convertInt(Text_codLoja1.Text));
            /*
              contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
              contratoBll.NROEMPRESA = convertInt(TextNroLoja.Text);
              contratoBll.carregaTelaContratoPag_load();
              */

            Text_nomeFornecedorAcao.Text = Server.HtmlEncode(contratoBll.retornaNomeFornecedor());

            contratoBll.NRO_CONTRATO = convertInt(Text_NroContrato.Text);
            contratoBll.COD_FORNECEDOR = convertInt(TextCodFornecedor.Text);
            contratoBll.NROEMPRESA = convertInt(TextNroLoja.Text);
            contratoBll.COD_GESTOR = convertInt(TxtCodGestor.Text);
                       

            grd_pesquisaContratos.DataSource = contratoBll.carregaTelaContratoPag_load();
            grd_pesquisaContratos.DataBind();


        }

        protected void Text_observacao_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Text_ValorContrato_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextCodFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtCodGestor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btn_sair_ln_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
        }

        protected void btn_sair_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("controle_contrato.aspx");
        }
    }


}