<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reading.aspx.cs" Inherits="OratorjuMSSPService.reading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OratorjuMSSPDB %>"
            SelectCommand="SELECT [r_date],[r_friendlyDate],[r_qari1],[r_salm],[r_qari2],[r_vangelu] FROM [reading] ORDER BY [r_date]"
            UpdateCommand="SELECT 1" DeleteCommand="SELECT 1">
        </asp:SqlDataSource>

        <div class="form-group">
        <asp:Label id="lblReadingDate" runat="server" Text="Data tal-Qari"></asp:Label>
        <asp:TextBox ID="txtReadingDate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label id="lblReadingFriendlyDate" runat="server" Text="Data sħiħa tal-Qari"></asp:Label>
        <asp:TextBox ID="txtFriendlyDate" runat="server" CssClass="form-control" placeholder="eż. 1 ta' Novembru"></asp:TextBox>

        <asp:Label id="lblReadingQari1" runat="server" Text="Qari I"></asp:Label>
        <asp:TextBox ID="txtQari1" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label id="lblReadingSalm" runat="server" Text="Salm"></asp:Label>
        <asp:TextBox ID="txtSalm" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label id="lblReadingQari2" runat="server" Text="Qari II"></asp:Label>
        <asp:TextBox ID="txtQari2" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label id="lblReadingVangelu" runat="server" Text="Vangelu"></asp:Label>
        <asp:TextBox ID="txtVangelu" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
        
        </div>
        <asp:Button ID="btnAddReading" runat="server" Text="Żid il-Qari" OnClick="btnAddReading_click"  cssclass="btn btn-default"/>
        <br /><hr /><br />
         <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True" DataKeyNames="r_date"
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowUpdating="gridView_RowUpdating"
            OnRowEditing="gridView_RowEditing" 
            OnRowCancelingEdit="gridView_RowCancelingEdit" 
            OnRowDeleting="gridView_RowDeleting"
            CssClass="table table-hover table-condensed"
             UseAccessibleHeader="true">
            <Columns>
                <asp:BoundField ReadOnly="true" DataField="r_date" HeaderText="Data" SortExpression="r_date" />
                <asp:BoundField DataField="r_friendlyDate" HeaderText="Data bil-Malti" SortExpression="r_friendlyDate"  />
                <asp:BoundField DataField="r_qari1" HeaderText="Qari I" SortExpression="r_qari1" HtmlEncode="false"/>
                <asp:BoundField DataField="r_salm" HeaderText="Salm" SortExpression="r_salm" HtmlEncode="false"/>
                <asp:BoundField DataField="r_qari2" HeaderText="Qari II" SortExpression="r_qari2" HtmlEncode="false"/>
                <asp:BoundField DataField="r_vangelu" HeaderText="Vangelu" SortExpression="r_vangelu" HtmlEncode="false"/>
                <asp:CommandField ShowEditButton="true" />
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
