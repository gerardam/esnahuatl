<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DicEspNahuatl.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
            <div class="row">
                <div class="col m6">
                    <div class="card center">
                        <h4>¡Bienvenido!</h4>
                        <div class="card-image">
                            <img src="../img/books.png" alt="libros" class="imgIniIzq">
                        </div>
                        <div class="card-content align-justify">
                            <p>
                                Conoce las herramientas disponibles que te ayudaran a conocer una de las lenguas más importantes de México, resuelve tus dudas de una manera sencilla y fácil. Adéntrate a la página, y por su puesto aprende en el camino.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col m6">
                    <div class="col m12">
                        <div class="card">
                            <div class="card-image waves-effect waves-block waves-light center">
                                <img class="activator" src="../img/buscar.png">
                            </div>
                            <div class="card-content">
                                <span class="card-title activator grey-text text-darken-4">Buscador<i class="material-icons right">more_vert</i></span>
                                <p><a href="../buscador">Acceder...</a></p>
                            </div>
                            <div class="card-reveal">
                                <span class="card-title grey-text text-darken-4">Buscador<i class="material-icons right">close</i></span>
                                <p>Buscador de palabras de forma rápida, con información e imagen de referencia para la mejor comprensión.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col m12">
                        <div class="card">
                            <div class="card-image waves-effect waves-block waves-light center">
                                <img class="activator" src="../img/cubos.png">
                            </div>
                            <div class="card-content">
                                <span class="card-title activator grey-text text-darken-4">Conjugacion de verbos<i class="material-icons right">more_vert</i></span>
                                <p><a href="#mdlProcess" class="modal-trigger">Acceder...</a></p>
                            </div>
                            <div class="card-reveal">
                                <span class="card-title grey-text text-darken-4">Conjugacion de verbos<i class="material-icons right">close</i></span>
                                <p>Busque el verbo que desee visualizar su conjugación en pasado, presente y futuro, de acuerdo con los pronombres personales.</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="mdlProcess" class="modal">
                    <div class="modal-content">
                        <h4><i class="small material-icons">info</i> Información</h4>
                        <p>Esta sección está en desarrollo, por favor ten paciencia.</p>
                        <p>Gracias</p>
                    </div>
                    <div class="modal-footer">
                        <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>