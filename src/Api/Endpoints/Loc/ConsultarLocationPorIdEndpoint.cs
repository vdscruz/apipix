using Application.Enum;
using Application.Model.Loc.Responses;

namespace Api.Endpoints.Loc;

public class ConsultarLocationPorIdEndpoint: EndpointWithoutRequest<LocationResponse>
{
    
    public override void Configure()
    {
        Get("loc/{idLocation}");
        Tags("PayloadLocation");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var idLocation = Route<string>("idLocation");
        
        var response = new LocationResponse()
        {
            Id = 7716,
            Location = "pix.example.com/qr/v2/2353c790eefb11eaadc10242ac120002",
            TipoCob = Enum.Parse<TipoCob>("cob"),
            Criacao = DateTime.Now,
        };

        await SendOkAsync(response);
    }
}