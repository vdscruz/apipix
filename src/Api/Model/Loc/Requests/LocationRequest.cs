using System.Text.Json.Serialization;

namespace Api.Model.Loc.Requests;

public abstract class LocationRequest
{
    [JsonPropertyName("tipoCob")] 
    public string TipoCob { get; set; }
}