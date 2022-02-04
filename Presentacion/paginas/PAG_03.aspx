<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PAG_03.aspx.cs" Inherits="DicEspNahuatl.PAG_03" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManagerProxy ID="smp" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/js/PAG_03.min.js" />
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
                    <div class="card-panel amber darken-1">
                        <h5 class="white-text">Agregar palabras</h5>
                    </div>
                </div>

                <div class="col s12 right-align lnkAccion">
                    <div class="card-panel">
                        <div class="input-field">
                            <asp:LinkButton ID="lnkAgregar" class="btn-floating  btn-large waves-effect waves-light amber darken-4" runat="server" OnClick="lnkAgregar_Click"><i class="material-icons md-48">add</i></asp:LinkButton>
                            <asp:LinkButton ID="lnkEditar" class="btn-floating  btn-large waves-effect waves-light amber darken-4" runat="server" OnClick="lnkEditar_Click"><i class="material-icons md-48">mode_edit</i></asp:LinkButton>
                            <asp:LinkButton ID="lnkAceptar" class="btn-floating  btn-large waves-effect waves-light light-green accent-4" runat="server" OnClick="lnkAceptar_Click" Visible="false"><i class="material-icons md-48">done</i></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancelar" class="btn-floating  btn-large waves-effect waves-light amber darken-4" runat="server" OnClick="lnkCancelar_Click" Visible="false"><i class="material-icons md-48">delete</i></asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="col m12 validationGroup">
                    <div class="card-panel">
                        <asp:MultiView runat="server" ID="MultiVista">
                            <asp:View ID="VistaInicial" runat="server">
                                <h3>No. de palabras:
                                    <asp:Label runat="server" ID="NoPalabras"></asp:Label></h3>
                                <p>Seleccione una opcion para la administracion del contenido del diccionario.</p>
                            </asp:View>

                            <asp:View ID="AgregarEditar" runat="server">
                                <div class="input-field" runat="server" id="divBuscador">
                                    <i class="material-icons prefix">search</i>
                                    <asp:TextBox runat="server" class="txtBusca validate" name="txtBusca" ID="txtBusca"></asp:TextBox>
                                    <label for="txtBusca">
                                        <asp:Label runat="server" for="Buscar">Buscar</asp:Label></label>
                                    <asp:Button ID="btnBuscar" runat="server" data-target="modal1" class="btn modal-trigger" Style="display: none" />
                                    <asp:HiddenField ID="hdComerId" runat="server" OnValueChanged="hdComerId_ValueChanged" />
                                </div>

                                <div class="input-field">
                                    <i class="material-icons prefix">perm_identity</i>
                                    <asp:TextBox runat="server" class="txtEspaniol validate" name="txtEspaniol" ID="txtEspaniol"></asp:TextBox>
                                    <label for="txtEspaniol">
                                        <asp:Label runat="server" for="Espaniol">Palabra en español*</asp:Label></label>
                                </div>
                                <div class="input-field">
                                    <i class="material-icons prefix">perm_identity</i>
                                    <asp:TextBox runat="server" class="txtNahuatl validate" name="txtNahuatl" ID="txtNahuatl"></asp:TextBox>
                                    <label for="txtNahuatl">
                                        <asp:Label runat="server" for="Nahuatl">Palabra en nahuatl*</asp:Label></label>
                                </div>
                                <div class="input-field">
                                    <i class="material-icons prefix">perm_identity</i>
                                    <asp:TextBox runat="server" class="txtTipo validate" name="txtTipo" ID="txtTipo"></asp:TextBox>
                                    <label for="txtTipo">
                                        <asp:Label runat="server" for="Tipo">Tipo de palabra*</asp:Label></label>
                                </div>

                                <div class="file-field input-field">
                                    <div class="btn">
                                        <span>Imagen</span>
                                        <asp:FileUpload runat="server" ID="fuArchivo" />
                                    </div>
                                    <div class="file-path-wrapper">
                                        <asp:TextBox runat="server" class="file-path validate" name="txtArchivo" ID="txtArchivo"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="input-field">
                                    <i class="material-icons prefix">perm_identity</i>
                                    <asp:TextBox runat="server" class="txtURL validate" name="txtURL" ID="txtURL"></asp:TextBox>
                                    <label for="txtURL">
                                        <asp:Label runat="server" for="URL">Url</asp:Label></label>
                                </div>
                                <div class="input-field">
                                    <i class="material-icons prefix">perm_identity</i>
                                    <asp:TextBox runat="server" class="txtDescripcion validate" name="txtDescripcion" ID="txtDescripcion"></asp:TextBox>
                                    <label for="txtDescripcion">
                                        <asp:Label runat="server" for="Descripcion">Descripcion</asp:Label></label>
                                </div>

                                <div class="card-image" runat="server" id="divImg">
                                    <asp:Image ID="imgPalabra" runat="server" CssClass="logoC" ImageUrl="~/img/ninos.png" />
                                </div>
                                <asp:Label runat="server" CssClass="rojo" ID="lblError">Campos obligatorios*</asp:Label>
                            </asp:View>
                        </asp:MultiView>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkAceptar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>