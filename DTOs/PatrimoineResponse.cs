namespace PatrimoineAPI.DTOs
{
    public class PatrimoineResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public decimal TotalPatrimoine { get; set; }
    }
}
