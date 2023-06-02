<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro_usuario.aspx.cs" Inherits="ControleControle.cadastro_usuario" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #txtUserName {
            width: 116px;
        }
        .auto-style1 {
            height: 26px;
        }
        #txtUserPass {
            width: 116px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">

          
         <div class="geral">

             <h1>
                <font face="Verdana">Cadastro de Usuário</font>
            </h1>

            <table>
                <tr>
                    <td>Nome:</td>
                    <td><input id="txtUserName" type="text" runat="server" maxlength="18" required="required" size="18"/></td>
                    <td><ASP:RequiredFieldValidator ControlToValidate="txtUserName" Display="Static" ErrorMessage="Campo obrigatório" runat="server" 
                        ID="vUserName" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">Senha:</td>
                    <td class="auto-style1"><input id="txtUserPass" type="password" runat="server" maxlength="8" required="required"/></td>
                    <td class="auto-style1"><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
                    Display="Static" ErrorMessage="Campo obrigatório" runat="server" ID="vUserPass" />
                    </td>
                </tr>

                 <tr>
                    <td class="auto-style1">Confirmar Senha:</td>
                    <td class="auto-style1"><input id="Password1" type="password" runat="server" maxlength="8" required="required"/></td>
                    <td class="auto-style1"><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
                    Display="Static" ErrorMessage="Campo obrigatório" runat="server" ID="RequiredFieldValidator1" />
                    </td>
                </tr>
   
            </table>
            <input type="submit" Value="Cadastrar" runat="server" ID="cadastroLogin"/><p></p>
            <asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />

          </div>

                </form>  
</body>
</html>
