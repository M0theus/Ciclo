namespace CycleTracker.Application.Dto.V1.User;

public class CadastrarUsuarioDto
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string? Apelido { get; set; }
}