using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;
using System.Web;

namespace ControleControle.Models
{
    public class Serializacao
    {

        public void Serializar(Boolean dados)
        {       
           JavaScriptSerializer serializador = new JavaScriptSerializer();
           string arquivoSerializado = serializador.Serialize(dados);

            StreamWriter sw = new StreamWriter(@"C:\Users\Desenvolvimento\source\repos\ControleControle\ControleControle\Serialiacao\saldoZero.json");
            sw.WriteLine(arquivoSerializado);
            sw.Close();
            
        }


        public Boolean Deserializar()
        {
            StreamReader stream = new StreamReader(@"C:\Users\Desenvolvimento\source\repos\ControleControle\ControleControle\Serialiacao\saldoZero.json");
            string linhaArquivo = stream.ReadToEnd();
            JavaScriptSerializer serializador = new JavaScriptSerializer();
            Boolean dado = (Boolean) serializador.Deserialize(linhaArquivo ,typeof(Boolean));
            stream.Close();

            return dado;
        }

    }
}