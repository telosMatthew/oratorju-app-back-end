<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thought.aspx.cs" Inherits="OratorjuMSSPService.thought" %>

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
                SelectCommand="SELECT [t_date],[t_friendlyDate],[t_content],[t_image] FROM [thought] ORDER BY [t_date]"
                UpdateCommand="SELECT 1" DeleteCommand="SELECT 1"></asp:SqlDataSource>

            <div class="form-group">
                <asp:Label ID="lblthoughtDate" runat="server" Text="Data tal-Hsieb"></asp:Label>
                <asp:TextBox ID="txtthoughtDate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblthoughtFriendlyDate" runat="server" Text="Data sħiħa tal-Hsieb"></asp:Label>
                <asp:TextBox ID="txtFriendlyDate" runat="server" CssClass="form-control" placeholder="eż. 1 ta' Novembru"></asp:TextBox>

                <asp:Label ID="lblthoughtContent" runat="server" Text="Il-Hsieb"></asp:Label>
                <asp:TextBox ID="txtContent" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblthoughtImage" runat="server" Text="Image"></asp:Label>
                <asp:FileUpload ID="fuImage" runat="server"></asp:FileUpload>


            </div>
            <asp:Button ID="btnAddthought" runat="server" Text="Żid il-Hsieb" OnClick="btnAddThought_click" CssClass="btn btn-default" />
            <br />
            <hr />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True" DataKeyNames="t_date"
                AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowUpdating="gridView_RowUpdating"
                OnRowEditing="gridView_RowEditing"
                OnRowCancelingEdit="gridView_RowCancelingEdit"
                OnRowDeleting="gridView_RowDeleting"
                CssClass="table table-hover table-condensed"
                UseAccessibleHeader="true">
                <Columns>
                    <asp:BoundField ReadOnly="true" DataField="t_date" HeaderText="Data" SortExpression="t_date" />
                    <asp:BoundField DataField="t_friendlyDate" HeaderText="Data bil-Malti" SortExpression="t_friendlyDate" />
                    <asp:BoundField DataField="t_content" HeaderText="Hsieb" SortExpression="t_content" HtmlEncode="false" />
                    <asp:ImageField DataImageUrlField="t_image" />
                   <%-- <asp:TemplateField HeaderText="Image" HeaderStyle-CssClass="arialfontgvtitle">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("Value") %>' runat="server" />
                            <!--<asp:Image ID="imgStatus" runat="server" ImageUrl='<%# "ThoughtHandler.ashx?id_Image="+  Eval("t_date") %>' Height="128" Width="128" />
                       -->
                                 </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:CommandField ShowEditButton="true" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
