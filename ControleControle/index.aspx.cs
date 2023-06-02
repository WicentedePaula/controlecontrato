using ControleControle.Models;
using System;
using System.Web.UI.WebControls;

using System.Globalization;

namespace ControleControle
{
    public partial class index : System.Web.UI.Page
    {
        ContratoBLL contratoBll = new ContratoBLL();
        Serializacao sr = new Serializacao();

        protected void Page_Load(object sender, EventArgs e)
        {
                  
            if (GrdContratoIndex.Rows.Count == 0)
            {                
                carregarGridView();
                
            }
        //    this.linkbtn_voltar.Visible = false;
            carregaCampos();
        }

        public void carregaCampos()
        {
            contratoBll.retornaValorTotalContrato();

            decimal saltoTotal = convertDecimal(contratoBll.total_saldo);
            decimal contratototal = convertDecimal(contratoBll.total_contrato);
            
            Text_SaldoContratoIndex.Text = saltoTotal.ToString("C", CultureInfo.CurrentCulture);
            Text_valorContratoIndex.Text = contratototal.ToString("C", CultureInfo.CurrentCulture);

        }


        private void carregarGridView()
        {            
           mostrarSaldoZero();
           GrdContratoIndex.DataSource = contratoBll.retornaContratoIndex();
                 
           GrdContratoIndex.DataBind();
           
        }

        private void mostrarSaldoZero()
        {
            bool saldoZ;
           
            if (chekSaldoZero.Checked)
            {
                saldoZ = true;
            }
            else
            {
                saldoZ = false;
            }
                     
            contratoBll.saldoZerado = saldoZ;

        }
       
              
        protected void GridCt_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            capturaCampos();
        
        }
        
        private void capturaCampos()
        {   /*
            string n = GrdContratoIndex.SelectedRow.Cells[2].Text;
            string e = GrdContratoIndex.SelectedRow.Cells[3].Text;
            string g = GrdContratoIndex.SelectedRow.Cells[6].Text;
            string v = GrdContratoIndex.SelectedRow.Cells[8].Text;
            string s = GrdContratoIndex.SelectedRow.Cells[9].Text;
             */

            contratoBll.NRO_CONTRATO = convertInt(GrdContratoIndex.SelectedRow.Cells[2].Text);
            contratoBll.NROEMPRESA = convertInt(GrdContratoIndex.SelectedRow.Cells[3].Text);
            contratoBll.COD_GESTOR = convertInt(GrdContratoIndex.SelectedRow.Cells[6].Text);
            contratoBll.VALOR_CONTRATO = convertDecimal(GrdContratoIndex.SelectedRow.Cells[8].Text);
            contratoBll.SALDO = convertDecimal(GrdContratoIndex.SelectedRow.Cells[9].Text);
            contratoBll.inserirTbTempContrato();

         //Response.Redirect("controle_contrato.aspx?nroC="+ GrdContratoIndex.SelectedRow.Cells[2].Text + "&nroEmp=" + GrdContratoIndex.SelectedRow.Cells[3].Text + "&coGest=" + GrdContratoIndex.SelectedRow.Cells[6].Text + "&vacontr=" + GrdContratoIndex.SelectedRow.Cells[8].Text + "&saldo="+ GrdContratoIndex.SelectedRow.Cells[9].Text + "&contron=" + 1);
           Response.Redirect("controle_contrato.aspx");

        }

        

        private decimal convertDecimal(string valor)
        {
            decimal valorConvertido;

            decimal.TryParse(valor, out valorConvertido);

            return valorConvertido;
        }

        private int convertInt(string valor)
        {
            int valorConvertido;
            int.TryParse(valor, out valorConvertido); 
            return valorConvertido;
        }


        protected void btnPesquisar_Click(object sender, EventArgs e)
        {  
            mostrarSaldoZero();
            PesquisarContratosPorData();

        }

        private void PesquisarContratosPorData()
        {
           string dt1 =  formataData(Text_DtaInicial.Text);
           string dt2 =  formataData(Text_dtaFinal.Text);
           GrdContratoIndex.DataSource =contratoBll.retornaContratoIndexPorData(dt1,dt2);
           GrdContratoIndex.DataBind();

        }

        private string formataData(string data)
        {            
            var parsedDate = DateTime.Parse(Text_dtaFinal.Text);
            var DateFormatFrom = parsedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            return DateFormatFrom;
        }

       


        protected void GrdContratoIndex_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "comando")
            {   
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gridIndex = GrdContratoIndex.Rows[index];
                TableCell nrocontrato = gridIndex.Cells[2];

                AcaoBLL acaoBLL = new AcaoBLL();
                acaoBLL.NRO_CONTRATO = convertInt(nrocontrato.Text);
                GrdContratoIndex.DataSource = acaoBLL.carregaTelaDetalhesContrato();
                                
                this.GrdContratoIndex.Columns[0].Visible = false;
                this.GrdContratoIndex.Columns[1].Visible = false;
                this.LinkButton1.Visible = false;
           //     this.linkbtn_voltar.Visible = true;
                GrdContratoIndex.DataBind();

                // string contact = nrocontrato.Text;
            }

            else
            {
               

            }

        }



        //#########################################################################################################


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void chekSaldoZero_CheckedChanged(object sender, EventArgs e)
        {  /*
            if (chekSaldoZero.Checked)
            {
                MessageBox.Show("You are in the CheckBox.CheckedChanged event.");

            }
            */
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {               
            carregarGridView();
        }
        /*s
        protected void linkbtn_voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
      */
        
        protected void btn_sair_Click(object sender, EventArgs e)
        {

            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();


        }

        protected void btn_lancamentobtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("controle_contrato.aspx");
        }
        
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }


}