<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestLogin.aspx.cs" Inherits="Login.TestLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <table>
        <tr>
            <td>
                <label>Username</label>
            </td>
            <td>
             <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                <label>Password</label>
            </td>
            <td>
             <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Button" 
                    onclick="btnLogin_Click" />
            </td>
        </tr>
    </table>
       
       
    </div>
    </form>
</body>
</html>
