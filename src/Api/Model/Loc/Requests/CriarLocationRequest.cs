using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Model.Loc.Requests;

public class CriarLocationRequest
{
    [JsonPropertyName("tipoCob")] 
    public string TipoCob { get; set; }

}