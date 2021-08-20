<%@ Page Title="Log In" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="Sgo.WebApp.Account_Login" CodeBehind="Login.aspx.vb" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="accountInfo" style="margin: auto">

        <h2>
            <b>Ingresar </b>
        </h2>

        <p>
            Por favor, ingrese Usuario y Contraseña.               
        </p>

        <span class="failureNotification">
            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        </span>

        <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="LoginUserValidationGroup" />

        <fieldset class="login">
            <legend>Información Cuenta</legend>
            <p>
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">Usuario:</asp:Label>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="Se requiere Usuario."
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Contraseña:</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry"
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                    CssClass="failureNotification" ErrorMessage="Contraseña Requerida." ToolTip="Contraseña Requerida."
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar"
                ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click" />
        </p>
    </div>

    <asp:HiddenField ID="CurrentLoginCount"   Value="0" runat="server" />
</asp:Content>
