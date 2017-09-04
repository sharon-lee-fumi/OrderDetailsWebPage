<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="A3XiaowenLi.ProductInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            color: #9900CC;
        }
        .auto-style4 {
            color: #CC33FF;
        }
        .auto-style5 {
            color: #CC00FF;
        }
        </style>
</head>
<body style="background-color: #CCCCFF">
    <form id="form1" runat="server">
        <div style="background-color: #CCCCFF; text-align: center;">
            <asp:ScriptManager ID="ScriptManagerAll" runat="server">
            </asp:ScriptManager>
            <em>
            <asp:Label ID="lblExceptions" runat="server" ForeColor="Red"></asp:Label>
            </em>
            <asp:UpdatePanel ID="UpdatePanelAll" runat="server">
                <ContentTemplate>
                        <h3 class="auto-style4"><em>Categories </em></h3>
                        <asp:ListBox ID="lboxCategories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lboxCategories_SelectedIndexChanged" style="margin-top: 0px; text-align: left;" Height="113px" Width="175px" BackColor="#FFCCFF" ForeColor="#660066"></asp:ListBox>
                        <br />
                        <br />
                        <h3 class="auto-style5"><em>Products</em></h3>
                        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" Height="35px" Width="232px" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" BackColor="#FFCCFF" ForeColor="#660066">
                        </asp:DropDownList>
                        &nbsp;
                        <br />
                        &nbsp;<asp:Label ID="lblMesage" runat="server" ForeColor="Red"></asp:Label>
                        <br />
                        <br />
                    
                    
                        <h3 class="auto-style3"><em>Order Details</em></h3>
                        <asp:GridView ID="gvOerderDetails" runat="server" BackColor="#FFCCFF" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" style="text-align: center; background-color: #999999;" ForeColor="#660066" HorizontalAlign="Center">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>                  
                    <br />
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
