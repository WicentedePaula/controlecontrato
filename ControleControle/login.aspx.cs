using ControleControle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleControle
{
    public partial class login : System.Web.UI.Page
    {
        DAL bdDal = new DAL();
        LoginBll log = new LoginBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
        }




        private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (ValidateUser(txtUserName.Value, txtUserPass.Value))
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, chkPersistCookie.Checked);
                Response.Redirect("index.aspx", true);
            }
            else
            {
                Response.Redirect("login.aspx", true);
            }


        }


        public Boolean ValidateUser(string userName, string passWord)
        {

            string url = ("SELECT * FROM TB_USUARIO WHERE USUARIO='{0}' and senha='{1}'");
            url = String.Format(url, userName, passWord);

            bool achou = false;

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = url;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        log.usuario = reader["USUARIO"].ToString();
                        log.senha = reader["SENHA"].ToString();
                        achou = true;
                        break;
                    }
                }

                return achou;

            }


        }


        public Boolean ValidateUser_1(string userName, string passWord)
        {

            string url = ("select usuario from tb_usuario where senha =" + passWord);

            bool achou = false;

            using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
            {
                comm.Connection = bdDal.connection();

                comm.CommandText = url;

                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        log.usuario = reader["USUARIO"].ToString();
                        achou = true;
                        break;
                    }
                }

                return achou;

            }


        }

    }
}