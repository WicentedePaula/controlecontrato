using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;

using System.Linq;
using System.Web;
using ControleControle.Models;

namespace ControleControle.Models
{
    public class AcaoBLL
    {

        public string NOME_ACAO { get; set; }
        public string DTA_ACAO { get; set; }
        public decimal VALOR_ACAO { get; set; }
        public int NRO_CONTRATO { get; set; }
        public int ID_ACAO { get; set; }
        public int NROEMPRESA { get; set; }
        public string nomeFornecedorAcao { get; set; }
        public string observacao { get; set; }
        public string nomeDaLoja { get; set; }


      
        DAL bdDal = new DAL();

        public void cadastrarAcoes()
        {
            string url = ("insert into ACAO(NOME_ACAO, DTA_ACAO, VALOR_ACAO, NRO_CONTRATO, NROEMPRESA, FORNECEDOR_ACAO, OBSERVACAO, NOME_LOJA)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')");
            url = string.Format( url, NOME_ACAO, DTA_ACAO, VALOR_ACAO, NRO_CONTRATO, NROEMPRESA, nomeFornecedorAcao, observacao, nomeDaLoja);
            bdDal.executarSql(url);
        }


        public string returnIdAcaoes()
        {
           // decimal valordaAcao = convertDecimal(VALOR_ACAO.ToString());

            string url = ("select ID_ACAO from ACAO WHERE NRO_CONTRATO = " + NRO_CONTRATO + " AND NROEMPRESA = " + NROEMPRESA + " AND VALOR_ACAO = " + VALOR_ACAO);
            string id_acao_text = null;


            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = url.Replace(",",".");

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id_acao_text = reader["ID_ACAO"].ToString();

                    }
                }
             
                return id_acao_text;

            }

        }

        private decimal convertDecimal(string valor)
        {
            decimal valorConvertido;
            decimal.TryParse(valor, out valorConvertido);

            return valorConvertido;
        }


        public DataTable carregaTelaDetalhesContrato()
        {
         //   string sql = "SELECT id_acao, nro_contrato,nome_loja,nome_acao,fornecedor_acao,observacao,valor_acao, TO_CHAR(dta_acao,'dd/mm/yyyy') as DATA_AÇÃO FROM acao WHERE nro_contrato =" + NRO_CONTRATO;
            string sql = "SELECT id_acao, nro_contrato,nome_loja,nome_acao,fornecedor_acao,observacao, TO_CHAR(valor_acao,'L99G999D99') as VALOR_AÇÃO, TO_CHAR(dta_acao,'dd/mm/yyyy') as DATA_AÇÃO FROM acao WHERE nro_contrato =" + NRO_CONTRATO;

            sql = string.Format(sql);
            
            return bdDal.retDataTable(sql);

        }



    }
       

}



