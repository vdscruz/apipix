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

    protected ErrorResponse(TratamentoErrosEnum erro)
    {
        Tipo = $"https://pix.bcb.gov.br/api/v2/error/{erro}";
        PreencherTituloDetalhe(erro);
    }

    private void PreencherTituloDetalhe(TratamentoErrosEnum erro)
    {
        switch (erro)
        {
            #region PayloadLocation
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