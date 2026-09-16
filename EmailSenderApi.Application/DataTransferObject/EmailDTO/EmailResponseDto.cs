namespace EmailSenderApi.Application.DataTransferObject.EmailDTO
{
    public class EmailResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int TotalProcessed { get; set; }
        public List<Guid> ProcessedProfileIds { get; set; } = new();
        public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
    }
}
