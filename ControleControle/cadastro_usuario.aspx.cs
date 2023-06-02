using ControleControle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleControle
{
    public partial class cadastro_usuario : System.Web.UI.Page
    {
        LoginBll login = new LoginBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cadastroLogin.ServerClick += new System.EventHandler(this.cadastroLogin_ServerClick);
        }

        public void cadastroLogin_ServerClick(object sender, System.EventArgs e)
        {
            cadastroUsuario();
        }

        public void cadastroUsuario()
        {
            login.usuario = txtUserName.Value;
            login.senha = txtUserPass.Value;
            login.confirmarSenha = Password1.Value;

            if (login.senha.Equals(login.confirmarSenha))
            {
               int resultado = login.cadastrarUsuario();
                if (resultado == 1)
                {
                    //cadastro realizado
                    Response.Write("Cadastro Realizado com sucesso !!!");
                   
                }
                else
                {
                    //já existe um usuário com esse nome.
                    Response.Write("Já existe um usuário com esse nome !!!");
                }
            }
            else
            {
                    Response.Write("Senhas não coincidem !!!");

            }

        }

    }
}