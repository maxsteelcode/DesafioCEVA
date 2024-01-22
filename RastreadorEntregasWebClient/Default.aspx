<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Async="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <h3 class="fw-bold text-center mt-4">Rastreador de viagens</h3>
        <p class="fs-4 text-center mb-4">Busque as informações de viagens dos transportadores.</p>
    </div>

    <div class="p-4 mb-4 bg-body-tertiary rounded-3 jumbotron">
        <div class="container-fluid py-4">
        </div>
    </div>

    <form id="formBusca" runat="server" class="needs-validation" novalidate>
        <div class="container">
            <div class="row mt-2">
                <div>
                    <asp:TextBox ID="txtViagem" MaxLength="10" type="number" runat="server" class="form-control form-control-lg" oninput="validarNumero(this)"
                        placeholder="Digite o número da viagem" required></asp:TextBox>
                    <div class="invalid-feedback" id="divInvalidFeedback" runat="server">
                        Por favor, informe o número da viagem.
                    </div>
                </div>
            </div>
            <div class="row mt-4">
                <div>
                    <div class="d-grid gap-2">
                        <asp:Button ID="btnBuscarViagem" runat="server" Text="Buscar Viagem" CssClass="btn btn-lg btn-dark" OnClick="btnBuscarViagem_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="mt-4 border rounded">
                <asp:GridView ID="gvViagem" runat="server" AutoGenerateColumns="false" CssClass="table table-borderless" BorderStyle="None">
                    <Columns>
                        <asp:BoundField DataField="Code_5C" HeaderText="Code_5C" SortExpression="Code_5C" />
                        <asp:BoundField DataField="Code_5P" HeaderText="Code_5P" SortExpression="Code_5P" />
                        <asp:TemplateField HeaderText="Codes">
                            <ItemTemplate>
                                <asp:Literal runat="server" Text='<%# string.Join(", ", ((RastreadorEntregasEntities.Viagem)Container.DataItem).Codes) %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor" SortExpression="Fornecedor" />
                        <asp:TemplateField HeaderText="Pedidos">
                            <ItemTemplate>
                                <asp:Literal runat="server" Text='<%# string.Join(", ", ((RastreadorEntregasEntities.Viagem)Container.DataItem).Pedidos) %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="container">
            <div class="alert alert-danger" role="alert" id="divAlertError" runat="server">
                <h4 class="alert-heading">Ops!</h4>
                <p>
                    <asp:Label ID="lblMensagemErro" runat="server"></asp:Label>
                </p>
                <hr>
                <p class="mb-0">Caso o erra persita, favor informar ao suporte de T.I. </p>
            </div>

            <div class="alert alert-warning d-flex align-items-center" role="alert" id="divAlertAviso" runat="server">
                <svg class="bi flex-shrink-0 me-2" role="img" aria-label="Warning:">
                    <use xlink:href="#exclamation-triangle-fill" />
                </svg>
                <div>
                    <asp:Label ID="lblMensagemAlerta" runat="server"></asp:Label>
                </div>
            </div>
        </div>

    </form>

</asp:Content>

