<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebConsole._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Console</title>
    <style type="text/css">
      body
      {
        background-color:#aaa;
        font-size:10pt;
        font-family:Arial;
      }          
      form
      {
        background-color:#fff;
        padding:10px;  
        border:1px solid #555;
        position:absolute;
        width:960px;
      }  
      .connection table 
      {
        position:absolute;
        top:90px;
        left:35px;        
        background-color:#f5f5f5;
        border:1px solid #aaa;
        float:left;
      }      
      .clear{clear:both}
      .borda{border:solid 1px #aaa}
      .default_zise{ width:950px }   
      .tables
      {
        width:930px;
        margin-top:5px;
        padding:10px;
        background-color:#f5f5f5;
      }
      .tables .item
      {
        width:300px; 
        float:left;
      }   
      .sql
      { height:150px; }
      .progress
      {
        position:absolute;
        left:10px;
        top:10px;
        background-color:#333;
        color:#fff;
      }
      .result
      {
        margin-top:5px;        
        overflow: auto; 
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="smDb" runat="server" EnableHistory="true" OnNavigate="smDb_Navigate" />

      <asp:UpdateProgress runat="server" id="PageUpdateProgress">
        <ProgressTemplate>
          <div id="dvProgress" class="progress" runat="server">Aguarde...</div>
        </ProgressTemplate>
      </asp:UpdateProgress>

      <asp:UpdatePanel ID="upCnn" runat="server">
        <ContentTemplate>
          <h2>Web Console</h2>
          <div id="dvConnect" class="borda default_zise" runat="server">
            <asp:Button ID="btnExpRec" runat="server" Text="+" onclick="btnExpRec_Click" />
            <asp:Label ID="lblDadosConn" runat="server">Configurações : </asp:Label>
          </div>

          <div id="dvCfgConnection"  class="connection" runat="server">
            <table>
              <tr>
                <td><label>Tipo do Banco</label></td>
                <td><asp:Textbox ID="txtDbType" runat="server"></asp:Textbox></td>
              </tr>
              <tr>
                <td><label>Servidor</label></td>
                <td><asp:Textbox ID="txtServer" runat="server"></asp:Textbox></td>
              </tr>
              <tr>
                <td>Autenticação pelo Windows </td>
                <td><asp:CheckBox ID="chkWindowsAut" runat="server" /> </td>
              </tr>
              <tr>
                <td><label>Banco de dados</label></td>
                <td><asp:Textbox ID="txtDatabase" runat="server"></asp:Textbox></td>
              </tr>
              <tr>
                <td><label>Usuário</label></td>
                <td><asp:Textbox ID="txtUser" runat="server"></asp:Textbox></td>
              </tr>
              <tr>
                <td><label>Senha</label></td>
                <td><asp:Textbox ID="txtPassword" TextMode="Password" runat="server"></asp:Textbox></td>
              </tr>
              <tr>
                <td colspan="2"><asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                    onclick="btnSalvar_Click" /></td>
              </tr>
            </table>
          </div>

          <br class="clear" />

          <div id="dvAtuTable" class="borda default_zise" runat="server">
            <asp:Button ID="btnExpTable" runat="server" Text="+" onclick="btnExpTable_Click" />
            <label>Tabelas</label>
            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" 
              onclick="btnAtualizar_Click" />
          </div>

          <div id="dvTable"  class="tables borda" runat="server">
            <asp:Label ID="lblTables" runat="server"></asp:Label>
            <br class="clear" />
          </div>
          
          <br class="clear" />
          <div id="dvCommand"  class="command" runat="server">
            <label>Sql</label>
            <asp:Button ID="btnExecutar" runat="server" Text="Executar" 
              onclick="btnExecutar_Click" />
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" 
              onclick="btnConsultar_Click" />
              <a href="CarregaArquivo.aspx">Carrega Arquivo</a>
              <asp:Label ID="lblConsultas" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtSql" class="sql default_zise" TextMode="MultiLine" runat="server"></asp:TextBox><br />
            <div class="result borda default_zise">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            </div>
          </div>
          
        </ContentTemplate>
      </asp:UpdatePanel>
    </form>
</body>
</html>
