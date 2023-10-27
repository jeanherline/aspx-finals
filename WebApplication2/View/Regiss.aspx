<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regiss.aspx.cs" Inherits="WebApplication2.Regiss" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hr />
            <h2>Users<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" /> 
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Clear" /> 
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" /> 
            </h2>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            </asp:GridView>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="Button4" runat="server" Text="Show All" OnClick="Button4_Click" style="margin-bottom: 0px" />
    </form>
</body>
</html>
