using System.Text.Json.Serialization;
using api.Enum;
using FluentValidation.Results;
using ErrorResponse = api.Model.ErrorResponse;

namespace Api.Validation;

public class ValidationFailureResponse: ErrorResponse
{
    [JsonPropertyName("validations"), JsonPropertyOrder(1)]
    public IEnumerable<Validacoes> Validacoes { get; set; }

    public ValidationFailureResponse(TratamentoErrosEnum erro): base(erro)
    {
        Validacoes = new List<Validacoes>();
    }
}

public class Validacoes
{
    public Validacoes(string campo, string mensagem)
    {
        Mensagem = mensagem;
        Campo = campo;
    }

    [JsonPropertyName("message")]
    public string Mensagem { get; }
    
    [JsonPropertyName("property")]
    public string Campo { get; }
}