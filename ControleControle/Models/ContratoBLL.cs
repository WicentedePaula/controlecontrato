using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ControleControle.Models
{
    public class ContratoBLL
    {
        public int NRO_CONTRATO { get; set; } //0
        public int COD_FORNECEDOR { get; set; } //1
        public int NROEMPRESA { get; set; } //2
        public int COD_GESTOR { get; set; } //3
        public decimal VALOR_CONTRATO { get; set; }//4
        public string NRO_NF { get; set; }//5
        public decimal SALDO { get; set; }//6
        public int ID_ACAO { get; set; }//7
        public string DTA_CONTRATO { get; set; }
        public string total_contrato { get; set; }//7
        public string total_saldo { get; set; }//7
        public bool saldoZerado { get; set; }


        BD_ConsincoDALL bd_dalConsinco = new BD_ConsincoDALL();
        DAL bdDal = new DAL();

        public DataTable bllRetornaLojas()
        {
          //  string sql = "select empresa from CONSINCO.dim_empresa where nroempresa ";
            string sql = "select nroempresa, empresa from CONSINCO.dim_empresa";
            
            return bd_dalConsinco.retDataTable(sql);
        }

        /*
         *  Método  bllRetListaContratosBancoConsinco()
         * Recebe um numero de contrato da tela controle_contrato retorna dos dados do contrato se o mesmo existir
         * */
        public DataTable bllRetListaContratosBancoConsinco()
        {
          //  string sql = "SELECT nac.NROACORDO, A.SEQFORNECEDOR, B.SEQPESSOA, nac.nroempresa, B.NOMERAZAO, c.seqcomprador,c.comprador, nac.descacordo , nac.vlracordo, nac.codtipoacordo, TO_CHAR(nac.dtainclusao,'dd/mm/yyyy') as DATA_CONTRATO FROM CONSINCO.msu_acordopromoc nac, MAF_FORNECEDOR A, GE_PESSOA B, max_comprador C WHERE nac.nroacordo =" + NRO_CONTRATO+ "and A.SEQFORNECEDOR = B.SEQPESSOA and nac.seqfornecedor = a.seqfornecedor AND nac.seqcomprador = c.seqcomprador AND codtipoacordo in (3,4,6) order by nac.nroempresa";
            string sql = "SELECT nac.NROACORDO, A.SEQFORNECEDOR, B.SEQPESSOA, nac.nroempresa, B.NOMERAZAO, c.seqcomprador,c.comprador, nac.descacordo ,TO_CHAR(nac.vlracordo,'L99G999D99') as VALOR_ACORDO, nac.codtipoacordo, TO_CHAR(nac.dtainclusao,'dd/mm/yyyy') as DATA_CONTRATO FROM CONSINCO.msu_acordopromoc nac, MAF_FORNECEDOR A, GE_PESSOA B, max_comprador C WHERE nac.nroacordo =" + NRO_CONTRATO+ "and A.SEQFORNECEDOR = B.SEQPESSOA and nac.seqfornecedor = a.seqfornecedor AND nac.seqcomprador = c.seqcomprador AND codtipoacordo in (3,4,6) order by nac.nroempresa";
            sql = string.Format(sql);

            return bd_dalConsinco.retDataTable(sql);
        }

        // QUERY ALTERADA
        public DataTable bllRetListaBancoBd_Contratos()
        {
            string sql = "SELECT * from   WHERE nac.nroacordo =" +NRO_CONTRATO+ "and nroempresa ="+NROEMPRESA;
            sql = string.Format(sql);

            return bd_dalConsinco.retDataTable(sql); //bd_dalConsinco
        }


        public DataTable bllRetListaContratos()
        {
            string sql = "select contrato.nro_contrato, gestor.nome_gestor, fornecedor.nome_fornecedor, contrato.valor_contrato, contrato.saldo FROM contrato, gestor, fornecedor, acao where contrato.nro_contrato = acao.nro_contrato and contrato.cod_fornecedor = fornecedor.id_fornecedor and contrato.cod_gestor = gestor.cod_gestor AND codtipoacordo in (3,4,6)";

            return bd_dalConsinco.retDataTable(sql);
        }

        //######################
        public void inserirContrato()
        {               
            string url = ("insert into usuContrato_teste.CONTRATO(contrato.nro_contrato, contrato.seqfornecedor, contrato.nroempresa, contrato.seqgestor, contrato.valor_contrato, contrato.NRO_NF, contrato.saldo_contrato, contrato.id_acao, contrato.DTA_CONTRATO)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')");
            url = string.Format(url, NRO_CONTRATO, COD_FORNECEDOR, NROEMPRESA, COD_GESTOR, VALOR_CONTRATO, NRO_NF, SALDO, ID_ACAO, DTA_CONTRATO);
            bdDal.executarSql(url);
           
        }

                     
        
       
        public void updateTbContrato()
        {
            string url = "update CONTRATO set CONTRATO.saldo_contrato =" + SALDO+ " where CONTRATO.nro_contrato =" + NRO_CONTRATO + " and CONTRATO.nroempresa =" + NROEMPRESA + " and CONTRATO.seqgestor =" + COD_GESTOR;
            url = string.Format(url, SALDO, NRO_CONTRATO, NROEMPRESA, COD_GESTOR);
            bdDal.executarSql(url.Replace(",", "."));


        }


        public bool existeContrato()
        {
            string url = ("select * from contrato where nro_contrato =" + NRO_CONTRATO+" and NROEMPRESA = "+NROEMPRESA+" and seqgestor =" +COD_GESTOR);
            bool id_acao_text_contrato = false;

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = url;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //   id_acao_text_contrato = reader["ID_ACAO"].ToString();
                        id_acao_text_contrato = true;

                    }
                }

                return id_acao_text_contrato;

            }

        }


        /*Método chamado pelo método cadastrar Açoes, retorna o contrato cadastrado para receber as açoes
       * 
       */
        public DataTable retornaContratoParaEdicao()
        {
            string sql = "select * from contrato where nro_contrato =" + NRO_CONTRATO+" and nroempresa ="+NROEMPRESA+"and seqgestor ="+COD_GESTOR+"and seqfornecedor ="+ COD_FORNECEDOR;
            sql = string.Format(sql);

            return bdDal.retDataTable(sql);

        }

        public DataTable retornaContratoSemIdAcao()
        {
            string sql = "select NRO_CONTRATO, SEQFORNECEDOR, NROEMPRESA, SEQGESTOR, VALOR_CONTRATO, NRO_NF, SALDO_CONTRATO from contrato where nro_contrato =" + NRO_CONTRATO + " and nroempresa =" + NROEMPRESA + "and seqgestor =" + COD_GESTOR + "and seqfornecedor =" + COD_FORNECEDOR;
            sql = string.Format(sql);

            return bdDal.retDataTable(sql);

        }


        public string retornaSaldoContrado()
        {
            string url = ("select * from contrato where nro_contrato =" + NRO_CONTRATO + " and NROEMPRESA = " + NROEMPRESA + " and seqgestor =" + COD_GESTOR);
            string saldoContrato = null ;

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = url;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        saldoContrato = reader["saldo_contrato"].ToString(); 

                    }
                }

                return saldoContrato;

            }

        }

        public DataTable retornaContratoIndex()
        {
            //  string sql1 = "SELECT c.NRO_CONTRATO, c.nroempresa,d.empresa,g.nomerazao,c.seqgestor, f.comprador, c.VALOR_CONTRATO, c.SALDO_CONTRATO, TO_CHAR(c.dta_contrato,'dd/mm/yyyy') as DATA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.nro_contrato = a.nro_contrato and c.nroempresa = a.nroempresa and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa order by c.dta_contrato";
            //  string sql2 = "SELECT c.NRO_CONTRATO, c.nroempresa,d.empresa,g.nomerazao,c.seqgestor, f.comprador, c.VALOR_CONTRATO, c.SALDO_CONTRATO, TO_CHAR(c.dta_contrato,'dd/mm/yyyy') as DATA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.nro_contrato = a.nro_contrato and c.nroempresa = a.nroempresa and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa and c.SALDO_CONTRATO > 0 order by c.dta_contrato";
                        
            string sql1 = "SELECT c.NRO_CONTRATO, c.nroempresa,d.empresa,g.nomerazao,c.seqgestor, f.comprador, TO_CHAR(c.VALOR_CONTRATO,'L99G999D99') as VALOR_CONTRATO, TO_CHAR(c.SALDO_CONTRATO,'L99G999D99') as SALDO_CONTRATO, TO_CHAR(c.dta_contrato,'dd/mm/yyyy') as DATA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.nro_contrato = a.nro_contrato and c.nroempresa = a.nroempresa and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa order by c.dta_contrato";
            string sql2 = "SELECT c.NRO_CONTRATO, c.nroempresa,d.empresa,g.nomerazao,c.seqgestor, f.comprador, TO_CHAR(c.VALOR_CONTRATO,'L99G999D99') as VALOR_CONTRATO, TO_CHAR(c.SALDO_CONTRATO,'L99G999D99') as SALDO_CONTRATO, TO_CHAR(c.dta_contrato,'dd/mm/yyyy') as DATA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.nro_contrato = a.nro_contrato and c.nroempresa = a.nroempresa and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa and c.SALDO_CONTRATO > 0 order by c.dta_contrato";


            if (saldoZerado)
            {
                return bd_dalConsinco.retDataTable(sql2);
            }
            else
            {
                return bd_dalConsinco.retDataTable(sql1);
            }
           
        }


        public void retornaValorTotalContrato()
        {
            string sql = "SELECT sum(VALOR_CONTRATO)AS valor_contrato, sum(SALDO_CONTRATO)AS saldo_contrato FROM   CONTRATO";

          
            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = sql;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        total_contrato = reader["valor_contrato"].ToString();
                        total_saldo = reader["saldo_contrato"].ToString();

                    }
                }

          
            }

                      
        }

        public DataTable retornaContratoIndexPorData(string dataInicial, string dataFinal )
        {
            string sql1 = "SELECT c.NRO_CONTRATO, c.nroempresa,d.empresa,g.nomerazao, c.seqgestor,f.comprador,TO_CHAR(c.VALOR_CONTRATO,'L99G999D99') as VALOR_CONTRATO, TO_CHAR(c.SALDO_CONTRATO,'L99G999D99') as SALDO_CONTRATO, c.DTA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.DTA_CONTRATO between to_date('" + dataInicial + "','dd/mm/yyyy') AND to_date('" + dataFinal + "','dd/mm/yyyy') and c.nro_contrato = a.nro_contrato and c.nroempresa = a.nroempresa and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa order by c.DTA_CONTRATO";
            string sql2 = "SELECT c.NRO_CONTRATO, c.nroempresa,d.empresa,g.nomerazao, c.seqgestor,f.comprador,TO_CHAR(c.VALOR_CONTRATO,'L99G999D99') as VALOR_CONTRATO, TO_CHAR(c.SALDO_CONTRATO,'L99G999D99') as SALDO_CONTRATO, c.DTA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.DTA_CONTRATO between to_date('" + dataInicial + "','dd/mm/yyyy') AND to_date('" + dataFinal + "','dd/mm/yyyy') and c.nro_contrato = a.nro_contrato and c.nroempresa = a.nroempresa and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa and c.SALDO_CONTRATO > 0 order by c.DTA_CONTRATO";


            if (saldoZerado)
            {
                return bd_dalConsinco.retDataTable(sql2);
            }
            else
            {
                return bd_dalConsinco.retDataTable(sql1);
            }
            
        }

        public void carregarContratoPorId(String id)
        {

            
        }


        //Método vai ser chamado pela tela inicial da tela index, mas carregada na 
        //Pagina de controle_contrato no momento nao esta em uso
        public DataTable carregaContratoSemId_Index(int nrocont, int nroempr, decimal saldo)
        {
            string sql = "SELECT c.NRO_CONTRATO, c.seqfornecedor, g.seqpessoa, c.nroempresa, g.nomerazao, c.seqgestor,f.comprador,a.nome_acao,c.VALOR_CONTRATO, c.SALDO_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.nro_contrato =" + nrocont+"  and c.nroempresa =" +nroempr+ " and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa";

          //  string sql = "select NRO_CONTRATO, SEQFORNECEDOR, NROEMPRESA, SEQGESTOR, VALOR_CONTRATO, NRO_NF, SALDO_CONTRATO from contrato where nro_contrato =" + nrcontrato + " and nroempresa =" + nrempresa + "and seqgestor =" + cogGestor + "and valor_contrato =" + vlcontrato + "and saldo_contrato ="+ saldocontr;
            sql = string.Format(sql);

            return bdDal.retDataTable(sql);

        }


        public DataTable carregaTelaContratoPag_load()
        {
        //    string sql = "SELECT c.NRO_CONTRATO, c.seqfornecedor, g.seqpessoa, c.nroempresa, g.nomerazao, c.seqgestor,f.comprador,a.nome_acao,c.VALOR_CONTRATO, c.SALDO_CONTRATO, TO_CHAR(c.dta_contrato,'dd/mm/yyyy') as DATA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.nro_contrato =" + NRO_CONTRATO + "  and c.nroempresa =" + NROEMPRESA + " and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa";
            string sql = "SELECT c.NRO_CONTRATO, c.seqfornecedor, g.seqpessoa, c.nroempresa, g.nomerazao, c.seqgestor,f.comprador,a.nome_acao, TO_CHAR(c.VALOR_CONTRATO,'L99G999D99') as VALOR_CONTRATO, TO_CHAR(c.SALDO_CONTRATO,'L99G999D99') as SALDO_CONTRATO, TO_CHAR(c.dta_contrato,'dd/mm/yyyy') as DATA_CONTRATO FROM usuContrato_teste.contrato C, usuContrato_teste.acao a, CONSINCO.GE_PESSOA G, CONSINCO.max_comprador F, CONSINCODW.DIM_EMPRESA D where c.nro_contrato =" + NRO_CONTRATO + "  and c.nroempresa =" + NROEMPRESA + " and c.id_acao = a.id_acao and c.seqfornecedor = g.seqpessoa AND c.seqgestor = f.seqcomprador and c.nroempresa = d.nroempresa";

            sql = string.Format(sql);

            return bdDal.retDataTable(sql);

        }



        public void inserirTbTempContrato()
        {
            string url = ("insert into usuContrato_teste.tb_temp_contrato(tb_temp_contrato.nro_contrato, tb_temp_contrato.nroempresa, tb_temp_contrato.seqgestor, tb_temp_contrato.valor_contrato, tb_temp_contrato.saldo)values('{0}','{1}','{2}','{3}','{4}')");
            url = string.Format(url, NRO_CONTRATO,NROEMPRESA, COD_GESTOR, VALOR_CONTRATO, SALDO);
            bdDal.executarSql(url);

        }


        public bool retornaValoresTbTempContrato()
        {
            string sql = "SELECT * from  tb_temp_contrato";
            bool contron = false;

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = sql;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        NRO_CONTRATO = convertInt(reader["nro_contrato"].ToString());
                        NROEMPRESA = convertInt(reader["nroempresa"].ToString());
                        COD_GESTOR  = convertInt(reader["seqgestor"].ToString());
                        VALOR_CONTRATO = convertDecimal(reader["valor_contrato"].ToString());
                        SALDO = convertDecimal(reader["saldo"].ToString());
                        contron = true;
                    }
                }
                deletarDadosTbTemp();

            }

            return contron;
        }

        public void deletarDadosTbTemp()
        {
            string url = ("DELETE FROM tb_temp_contrato WHERE tb_temp_contrato.nro_contrato =" + NRO_CONTRATO);
            url = string.Format(url, NRO_CONTRATO);
            bdDal.executarSql(url);
        }

        private int convertInt(string valor)
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

        public string retornaNomeFornecedor()
        {
            string sql = "select * from consinco.ge_PESSOA WHERE seqpessoa ="+ COD_FORNECEDOR;
            string nomeFornecedor= null;

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = sql;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        nomeFornecedor = reader["NOMERAZAO"].ToString();
                        
                    }
                }
            }
            
            return nomeFornecedor;
        }


        public string retornaNomeEmpresa(int nroEmpresa)
        {
            string sql = "select empresa from CONSINCO.dim_empresa where nroempresa =" + nroEmpresa;
            string nomeEmpresa = null;

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = sql;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nomeEmpresa = reader["EMPRESA"].ToString();

                    }
                }
            }

            return nomeEmpresa;
        }


    }
}