<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Formulario de Registro</title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <div>
            <telerik:RadTextBox ID="RadTextBoxNombre" runat="server" Label="Nombre:" Width="200px"></telerik:RadTextBox><br />
            <telerik:RadTextBox ID="RadTextBoxApellido" runat="server" Label="Apellido:" Width="200px"></telerik:RadTextBox><br />
            <telerik:RadTextBox ID="RadTextBoxCorreo" runat="server" Label="Correo:" Width="200px"></telerik:RadTextBox><br />
            <telerik:RadButton ID="RadButtonEnviar" runat="server" Text="Enviar" OnClick="RadButtonEnviar_Click"></telerik:RadButton>
        </div>
    </form>
</body>
</html>
