<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio_15_3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboratorio 15-3</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Introduzca un Texto</h1>
            
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br /><br />
            
            <asp:Button ID="Button1" runat="server" Text="Mostrar Mensaje" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
