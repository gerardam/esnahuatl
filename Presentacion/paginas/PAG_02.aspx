<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PAG_02.aspx.cs" Inherits="DicEspNahuatl.PAG_02" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManagerProxy ID="smp" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/js/PAG_02.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <script type="text/javascript">
        $(document).ready(function () {
            $('select').material_select();
            $('.dropdown-button').dropdown();
            $('.button-collapse').sideNav();
            $('.modal-trigger').leanModal();
        });
    </script>
    <asp:UpdatePanel runat="server" ID="udpContenido">
        <ContentTemplate>
            <div class="row inicioWeb">
                <div class="col s12">
                    <div class="card-panel">
                        <div class="input-field">
                            <i class="material-icons prefix">search</i>
                            <asp:TextBox runat="server" class="txtBuscar validate" name="txtBuscar" ID="txtBuscar"></asp:TextBox>
                            <label for="txtBuscar">
                                <asp:Label runat="server" for="Buscar">Buscar</asp:Label></label>
                            <asp:Button ID="btnBuscar" runat="server" data-target="modal1" class="btn modal-trigger" Style="display: none" />
                            <asp:HiddenField ID="hdComerId" runat="server" OnValueChanged="hdComerId_ValueChanged" />
                        </div>
                    </div>
                </div>
                <div class="col m4">
                    <div class="card-panel center panelInfo">
                        <div class="card-image">
                            <asp:Image ID="imgPalabra" runat="server" CssClass="logoC" ImageUrl="~/img/picture.png" />
                        </div>
                    </div>
                </div>
                <div class="col m8">
                    <div class="card-panel panelInfo">
                        <h2>
                            <asp:Label runat="server" ID="lblNahuatl"></asp:Label></h2>
                        <h4>
                            <asp:Label runat="server" ID="lblEspaniol">¡Información!</asp:Label></h4>
                        <p>
                            <asp:Label runat="server" ID="lblComentarios">Busque las palabras en español en el cuadro superior, solo puede buscar la traducción de palabras y no de oraciones completas.</asp:Label>
                        </p>
                    </div>
                </div>

                <div id="modal1" class="modal">
                    <div class="modal-content">
                        <h4><i class="small material-icons">info</i> Información</h4>
                        <p>Seleccione uno de los elementos de la lista de sugerencia para visualizar la traducción de su búsqueda. Si la palabra que busca no aparece, lo sentimos; estamos trabajando en aumentar el catálogo de palabras.</p>
                    </div>
                    <div class="modal-footer">
                        <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>