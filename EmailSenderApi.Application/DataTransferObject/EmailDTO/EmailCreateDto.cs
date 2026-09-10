namespace EmailSenderApi.Application.DataTransferObject.EmailDTO
{
    public class EmailCreateDTO
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        DateTime Data { get; set; } = DateTime.Now;
    }
}
