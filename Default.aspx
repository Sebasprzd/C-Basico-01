<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>arroz</title> <!-- comentario en HTML, aquí va el título -->

    <!-- default.aspx es como el index, la página que presenta los botones y demás, la lógica de las acciones de los botones se hace en Default.aspx.cs -->

    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link rel="stylesheet" type="text/css" href="styles/style.css" /> <!-- carpeta CSS -->
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>

        <script type="text/javascript">
            // Put your JavaScript code here.   //comentario en js
        </script>

        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>

        <div>
            <!-- Imagen -->
            <img src="images/camaron.jpg" alt="Logo" class="img-top-right" />

            <!-- Formulario -->
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Registrar" OnClick="btnSubmit_Click" />
            <br /><br />

            <!-- Carga de archivo PDF -->
            <asp:FileUpload ID="fileUploadPdf" runat="server" />
            <asp:Button ID="btnUploadPdf" runat="server" Text="Subir PDF" OnClick="btnUploadPdf_Click" />
            <br /><br />

            <!-- Botón para cargar datos -->
            <asp:Button ID="btnLoadData" runat="server" Text="Cargar Datos" OnClick="btnLoadData_Click" />
            <br /><br />

            <!-- GridView para mostrar los datos -->
            <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDatos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" />
                    <asp:TemplateField HeaderText="Ver PDF">
                        <ItemTemplate>
                            <asp:Button ID="btnViewPdf" runat="server" Text="Ver PDF" CommandName="ViewPdf" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br /><br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
