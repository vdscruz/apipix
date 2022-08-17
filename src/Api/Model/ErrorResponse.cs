using System.Text.Json.Serialization;
using api.Enum;

namespace api.Model;

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
            case TratamentoErrosEnum.PayloadLocationOperacaoInvalida:
            {
                Titulo = "PayloadLocation inválido.";
                Detalhe = "A presente requisição busca criar uma location sem respeitar o _schema_ estabelecido.";
                Codigo = 400;
                break;
            }
            default:
            {
                Titulo = "";
                Detalhe = "";
                Codigo = 400;
                break;
            }
        }
    }
}