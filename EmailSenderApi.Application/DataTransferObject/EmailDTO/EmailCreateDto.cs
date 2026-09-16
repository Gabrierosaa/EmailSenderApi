namespace EmailSenderApi.Application.DataTransferObject.EmailDTO
{
    public class EmailCreateDTO
    {
        public List<Guid> ProfileIds { get; set; } = new();
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
