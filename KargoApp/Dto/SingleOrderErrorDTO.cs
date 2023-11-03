namespace KargoApp.Dto
{
    public class SingleOrderErrorDTO
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
    }
}
