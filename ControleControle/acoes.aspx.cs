using ControleControle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleControle
{
    public partial class acoes : System.Web.UI.Page
    {
        ContratoBLL ctbll = new ContratoBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            grd_retornoContratoLocalizado.DataSource = ctbll.retornaContratoParaEdicao();
            grd_retornoContratoLocalizado.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
    }
}