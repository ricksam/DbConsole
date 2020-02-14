<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarregaArquivo.aspx.cs" Inherits="WebConsole.CarregaArquivo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <div>
      <asp:Label ID="lblDadosConn" runat="server">Configurações : </asp:Label>
      <br />

      <asp:TextBox ID="txtLinkDownload" runat="server"></asp:TextBox>

      <asp:Button ID="btnExecutarArquivo" runat="server" Text="Executar Arquivo" 
                onclick="btnExecutarArquivo_Click" />
      <br />
      <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
