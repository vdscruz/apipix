using System.Text.Json.Serialization;

namespace Application.Model.Loc.Requests;

public class CriarLocationRequest
{
    [JsonPropertyName("tipoCob")] 
    public string TipoCob { get; set; }
    
}