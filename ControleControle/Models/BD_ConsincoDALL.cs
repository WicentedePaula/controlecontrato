using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ControleControle.Models
{
    public class BD_ConsincoDALL
    {
        

        string servidor = "10.102.227.2";
        string porta = "1521";
        string servico = "arcomix.subnetarcomixda.vcnrootskyoneda.oraclevcn.com";
        string usuario = "consinco";
        string senha = "consinco";
        public string url = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.102.227.2)(PORT=1521))) (CONNECT_DATA=(SERVICE_NAME=arcomix.subnetarcomixda.vcnrootskyoneda.oraclevcn.com))); User Id=consinco; Password=consinco";

        OracleConnection connection;

        public BD_ConsincoDALL()
        {                          
            connection = new OracleConnection(url);
            connection.Open();
        }


        public void executarSql(string sql)
        {
            OracleCommand commmand = new OracleCommand(sql, connection);
            commmand.ExecuteNonQuery();

        }

        public DataTable retDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            OracleCommand commmand = new OracleCommand(sql, connection);
            OracleDataAdapter dataAdapter = new OracleDataAdapter(commmand);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

    }
}