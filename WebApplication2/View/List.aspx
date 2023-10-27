<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebApplication2.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>List Page<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save" />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Clear" />
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Delete" />
            </h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="Show All" OnClick="Button1_Click" style="margin-bottom: 0px" />
            
        </div>
    </form>
</body>
</html>
