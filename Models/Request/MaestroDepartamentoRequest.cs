namespace Restaurant.Models.Request
{
    public class MaestroDepartamentoRequest
    {
        public int DepId { get; set; }
        public int DepPais { get; set; }
        public string? DepCodigoDane { get; set; }
        public string? DepNombre { get; set; }

    }
}
