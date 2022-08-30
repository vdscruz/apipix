namespace Application.Dto;

public class LocationDTO
{
    public long Id { get; }
    public string Location { get; }
    public int TipoCob { get; }
    public DateTime Criacao { get; }

    public LocationDTO(int id, int tipoCob)
    {
        Id = id;
        Location = Guid.NewGuid().ToString().Replace("-", string.Empty);
        TipoCob = tipoCob;
        Criacao = DateTime.Now;
    }
}