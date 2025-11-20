<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio_15_4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Laboratorio 15-4: Suma de Números</h1>
        
        <p>Número 1:</p>
        <asp:TextBox ID="TextBoxNum1" runat="server"></asp:TextBox>
        <br />
        
        <p>Número 2:</p>
        <asp:TextBox ID="TextBoxNum2" runat="server"></asp:TextBox>
        <br /><br />
        
        <asp:Button ID="ButtonSumar" runat="server" Text="Sumar" OnClick="ButtonSumar_Click" />
        <br /><br />
        
        <asp:Label ID="LabelResultado" runat="server" Text="El resultado aparecerá aquí."></asp:Label>
    </div>
</form>
</body>
</html>
