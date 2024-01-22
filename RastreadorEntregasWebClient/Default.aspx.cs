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
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected async void btnBuscarViagem_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidarForm())
            {
                ViagemMilkrunResponse viagemMilkrunResponse = await new RastreadorClient().Post(int.Parse(txtViagem.Text));
                gvViagem.DataSource = viagemMilkrunResponse.SincronizarCutOffResult.Viagem;
                gvViagem.DataBind();
            }
        }
        catch (Exception)
        {
            throw;
        }   
    }

    /// <summary>
    /// Método para verificar se a caixa de texto contem um número de viagem válido.
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
}