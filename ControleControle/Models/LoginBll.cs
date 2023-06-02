using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ControleControle.Models
{
    public class LoginBll
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public string confirmarSenha { get; set; }

        DAL bdDal = new DAL();

        public Boolean capturaUsuario()
        {
           
            Boolean achou = false;

            string url = ("select * from tb_usuario where nomeUsuario =" + usuario + "senha =" + senha);


            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = url;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = reader["usuario"].ToString();
                        senha = reader["senha"].ToString();

                        achou = true;

                    }
                }

                return achou;

            }

        }


        public int cadastrarUsuario()
        {
            int cadastrado = 0;

            if (!existeUsu(usuario)) {

                string url = ("insert into usuContrato_teste.TB_USUARIO(TB_USUARIO.USUARIO, TB_USUARIO.SENHA)values('{0}','{1}')");
                url = string.Format(url,usuario,senha);
                bdDal.executarSql(url);
                cadastrado = 1;
            }

            return cadastrado;
        }

       
        public bool existeUsu(string user)
        {
            Boolean achou = false;
            string usu_banco;

            //string url1 = "select usuario from tb_usuario where usuario = '{0}'";
            string url = "select * from TB_USUARIO WHERE REGEXP_LIKE(usuario, '{0}','i')";
            url = string.Format(url, user);

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = url;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usu_banco = reader["usuario"].ToString();

                        if (usuario != null)
                        {
                            achou = CompararUsuario(user, usu_banco);
                        }
                                             

                    }
                }

                return achou;

            }
                                  

        }

        private Boolean CompararUsuario(string user, string usubanco)
        {
            Boolean achou = false;

            if (string.Equals(user, usubanco, StringComparison.OrdinalIgnoreCase))
            {
                return achou = true;
            }

            return achou;
        }
        
    }
}