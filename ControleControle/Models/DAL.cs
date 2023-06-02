using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace ControleControle.Models
{
    public class DAL
    {
        /*
        string servidor = "10.102.227.2";
        string porta = "1521";
        string servico = "arcomix.subnetarcomixda.vcnrootskyoneda.oraclevcn.com";
        string usuario = "usuContrato_teste";
        string senha = "contrato_teste";
        */
        OracleConnection conn;


        public OracleConnection connection()
        {            
            string url = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.102.227.2)(PORT=1521))) (CONNECT_DATA=(SERVICE_NAME=arcomix.subnetarcomixda.vcnrootskyoneda.oraclevcn.com))); User Id=usuContrato_teste; Password= contrato_teste;";
            
            conn = new OracleConnection(url);
            conn.Open();

            return conn;

        }


        public void executarSql(string sql)
        {
            conn = connection();
            OracleCommand commmand = new OracleCommand(sql, conn);
            commmand.ExecuteNonQuery();
            
     //       conn.Close(); // VERIFICAR O COMPORTAMENTE
        }

                

        public DataTable retDataTable(string sql)
        {
            conn = connection();

            DataTable dataTable = new DataTable();
            OracleCommand commmand = new OracleCommand(sql, conn);
            OracleDataAdapter dataAdapter = new OracleDataAdapter(commmand);
            dataAdapter.Fill(dataTable);

        //    conn.Close(); // VERIFICAR O COMPORTAMENTE

            return dataTable;
        }
              

    }
}