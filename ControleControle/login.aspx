<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ControleControle.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="~/css/login.css" />

    <title></title>
    <style type="text/css">
        #txtUserName {
            width: 450px;
        }
        #txtUserPass {
            width: 450px;
        }
        .auto-style2 {
            width: 220px;
        }
        .auto-style3 {
            width: 279px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
         <div class="tela-login">
             <asp:Image ID="Image1" ImageUrl="~/imagens/logo-arcomix_fundoBranco.png" runat="server" Height="196px" Width="227px" /> 
             <div class="card">

                    <h1>
                        Bem Vindo
                    </h1>
                    
                        <fieldset>

                            <div>
                               <h3> Nome:</h3>
                                <input id="txtUserName" type="text" runat="server"   maxlength="18" required="required" size="20"  placeholder="Nome"/>
                                <ASP:RequiredFieldValidator ControlToValidate="txtUserName" Display="Static" placeholder="Nome" ErrorMessage="Campo obrigatório" runat="server" 
                                 ID="vUserName" />
                           </div>

                            <div>
                                   <h3>Senha:</h3>
                                    <input id="txtUserPass" type="password" runat="server" placeholder="Senha" maxlength="8" required="required" />
                                    <ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
                                    Display="Static" ErrorMessage="Campo obrigatório" runat="server" ID="vUserPass" />
                            </div>

                            
                            <div>
                                <h4>Gravar Cookie:
                                <ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" />
                                </h4>
                            </div>


                            <div>
                                
                                <input type="submit" Value="Entrar" runat="server" ID="cmdLogin"/>
                                <asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />


                            </div>

                        </fieldset>
                    
                    
            </div>

        </div>
    </form>
</body>
</html>
