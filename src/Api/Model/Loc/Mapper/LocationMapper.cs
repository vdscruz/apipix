using Api.Enum;
using Api.Model.Loc.Responses;
using Application.Dto;

namespace Api.Model.Loc.Mapper;

public static class LocationMapper
{
    public static LocationResponse Map(this LocationDTO dto)
    {
        return new()
        {
            Id = dto.Id,
            Location = $"pix.example.com/qr/v2/{dto.Location}",
            TipoCob = System.Enum.GetName((TipoCob)dto.TipoCob),
            Criacao = dto.Criacao
        };
    }
}