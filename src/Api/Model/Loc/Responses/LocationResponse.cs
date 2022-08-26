using System.Text.Json.Serialization;
using api.Enum;

namespace Api.Model.Loc.Responses;

public class LocationResponse
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("location")] public string Location { get; set; }
    [JsonPropertyName("tipoCob")] public TipoCob TipoCob { get; set; }
    [JsonPropertyName("criacao")] public DateTime Criacao { get; set; }

    public LocationResponse(long id, string location, 
        TipoCob tipoCob, DateTime criacao)
    {
        Id = id;
        Location = location;
        TipoCob = tipoCob;
        Criacao = criacao;
    }

    public LocationResponse()
    {
        
    }
}