using RastreadorEntregasEntities;
using RastreadorEntregasServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    #region Eventos    

    protected void Page_Load(object sender, EventArgs e)
    {
        OcultarMensagemDeErro();
        OcultarAlerta();
        LimparGridViewResultadoBusca();
    }

    protected async void btnBuscarViagem_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidarForm())
            {
                ViagemMilkrunResponse viagemMilkrunResponse = await new RastreadorClient().Post(int.Parse(txtViagem.Text));

                if (viagemMilkrunResponse == null || viagemMilkrunResponse.SincronizarCutOffResult.ExecutouOK == false)
                {
                    throw new Exception("Erro ao executar a api SincronizarCutOff: " + viagemMilkrunResponse.SincronizarCutOffResult.Erro);
                }

                if (viagemMilkrunResponse.SincronizarCutOffResult.Viagem.Count != 0)
                {
                    gvViagem.DataSource = viagemMilkrunResponse.SincronizarCutOffResult.Viagem;
                    gvViagem.DataBind();
                }
                else
                {
                    ExibirAlerta("Não foi possível encontrar a viagem de número: " + txtViagem.Text);
                }
            }
        }
        catch (Exception ex)
        {
            ExibirMensagemDeErro("Ocorreu um erro inesperado ao realizar esta operação. Por favor, tente novamente em alguns instantes.");
            // Log(exception)
        }
    }

    #endregion

    #region Métodos    

    /// <summary>
    /// Método para verificar se a caixa de texto de pesquisa de viagem contem um número válido.
    /// </summary>
    /// <returns>true se o número for válido</returns>
    private bool ValidarForm()
    {
        if (!string.IsNullOrEmpty(txtViagem.Text))
        {
            int viagem;

            if (int.TryParse(txtViagem.Text, out viagem))
            {
                return true;
            }

            // nesse caso, o usuário digitou algo diferente de um número
            txtViagem.Text = String.Empty;
            divInvalidFeedback.InnerText = "Favor informar um número de viagem válido.";
            divInvalidFeedback.Visible = true;
        }
        // usuário recebe feedback de que precisa digitar o número da viagem ou que o valor informado é inválido
        formBusca.Attributes["class"] = formBusca.Attributes["class"] + " was-validated";
        return false;
    }

    /// <summary>
    /// Exibe uma mensagem de erro para o usuário
    /// </summary>
    private void ExibirMensagemDeErro(string mensagem)
    {
        divAlertError.Visible = true;
        lblMensagemErro.Text = mensagem;
    }

    /// <summary>
    /// Oculta a mensagem de erro
    /// </summary>
    private void OcultarMensagemDeErro()
    {
        divAlertError.Visible = false;
        lblMensagemErro.Text = string.Empty;
    }

    /// <summary>
    /// Exibe uma mensagem de alerta para o usuário
    /// </summary>
    private void ExibirAlerta(string mensagem)
    {
        divAlertAviso.Visible = true;
        lblMensagemAlerta.Text = mensagem;
    }

    /// <summary>
    /// Oculta a mensagem de alerta
    /// </summary>
    private void OcultarAlerta()
    {
        divAlertAviso.Visible = false;
        lblMensagemAlerta.Text = string.Empty;
    }

    /// <summary>
    /// Atribui null ao grid view de pesquisa limpar buscas anteriores antes de realizar uma nova.
    /// </summary>
    private void LimparGridViewResultadoBusca()
    {
        gvViagem.DataSource = null;
        gvViagem.DataBind();
    }

    #endregion

}