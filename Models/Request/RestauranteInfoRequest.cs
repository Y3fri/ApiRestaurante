namespace Restaurant.Models.Request
{
    public class RestauranteInfoRequest
    {

        public int InfId { get; set; }
        public int? InfMunicipio { get; set; }
        public string? IntNit { get; set; }
        public string? InfRazonSocial { get; set; }
        public string? InfEmailPrincipal { get; set; }
        public string? InfDireccionPrincipal { get; set; }
        public string? InfTelefonoPrincipal { get; set; }
        public string? InfLogo { get; set; }


    }
}
