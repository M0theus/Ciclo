namespace CycleTracker.Application.Dto.V1.User;

public class AlterarUsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Apelido { get; set; }
}