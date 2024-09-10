namespace CycleTracker.Application.Dto.V1.Cycle;

public class CycleDto
{
    public DateOnly DataInicio { get; set; }
    public int DuracaoCiclo { get; set; }
    public int DuracaoMenstrual { get; set; }
    public DateOnly DataInicioUltimoCiclo { get; set; }
    public int UsuarioId { get; set; }
}