using System.Text.Json.Serialization;
using Api.Enum;

namespace Api.Model;

public class ErrorResponse
{
    [JsonPropertyName("type")]
    public String Tipo { get; set; }
    
    [JsonPropertyName("title")]
    public String Titulo { get; set; }
    
    [JsonPropertyName("status")]
    public int Codigo { get; set; }
    
    [JsonPropertyName("detail")]
    public String Detalhe { get; set; }

    public ErrorResponse(TratamentoErrosEnum erro)
    {
        Tipo = $"https://pix.bcb.gov.br/api/v2/error/{erro}";
        PreencherTituloDetalhe(erro);
    }

    private void PreencherTituloDetalhe(TratamentoErrosEnum erro)
    {
        switch (erro)
        {
            #region # Gerais

            case TratamentoErrosEnum.NaoEncontrado:
            {
                Titulo = "Entidade não encontrada.";
                Detalhe = string.Empty;
                Codigo = 404;
                break;
            }
            case TratamentoErrosEnum.ErroInternoDoServidor:
            {
                Titulo = "Condição inesperada ao processar requisição.";
                Detalhe = string.Empty;
                Codigo = 500;
                break;
            }
            #endregion
            
            #region # PayloadLocation
            case TratamentoErrosEnum.PayloadLocationNaoEncontrado:
            {
                Titulo = "PayloadLocation não encontrado.";
                Detalhe = "Location não encontrada para o \"id\" informado";
                Codigo = 400;
                break;
            }
            case TratamentoErrosEnum.PayloadLocationOperacaoInvalida:
            {
                Titulo = "PayloadLocation inválido.";
                Detalhe = "A presente requisição busca criar uma location sem respeitar o _schema_ estabelecido.";
                Codigo = 400;
                break;
            }
            case TratamentoErrosEnum.PayloadLocationConsultaInvalida:
            {
                Titulo = "PayloadLocation consulta inválida.";
                Detalhe = "Algum dos parâmetros informados para a consulta não respeitam o schema.";
                Codigo = 400;
                break;
            }
            #endregion

            case TratamentoErrosEnum.CobOperacaoInvalida:
            case TratamentoErrosEnum.CobVOperacaoInvalida:
            case TratamentoErrosEnum.LoteCobVOperacaoInvalida:
            case TratamentoErrosEnum.PixDevolucaoInvalida:
            case TratamentoErrosEnum.WebhookOperacaoInvalida:
            default:
            {
                Titulo = "";
                Detalhe = "";
                Codigo = 500;
                break;
            }
        }
    }
}