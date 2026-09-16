using EmailSenderApi.Domain.Entities.Enum;

namespace EmailSenderApi.Domain.Entities
{
    public class Email
    {
        public int Id { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public DateTime SentAt { get; private set; }
        public bool IsHtml { get; private set; }
        public Guid ProfileId { get; private set; }
        public StatusEnum Status { get; private set; }
        public string? ErrorMessage { get; private set; } 

        private Email() { }

        public Email(string from, string to, string subject, string body, Guid profileId, bool isHtml = true)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
            ProfileId = profileId;
            IsHtml = isHtml;

            SentAt = DateTime.UtcNow; 
            Status = StatusEnum.Pending;

            Validations();
        }
        public void MarkAsSent()
        {
            Status = StatusEnum.Sent;
            ErrorMessage = null;
        }

        public void MarkAsFailed(string errorMessage)
        {
            Status = StatusEnum.Failed;
            ErrorMessage = errorMessage;
        }

        private void Validations()
        {
            if (string.IsNullOrWhiteSpace(From))
                throw new ArgumentException("O remetente (From) não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(To))
                throw new ArgumentException("O destinatário (To) não pode ser vazio.");

            if (ProfileId == Guid.Empty)
                throw new ArgumentException("O e-mail deve estar vinculado a um ProfileId válido.");

            if (string.IsNullOrWhiteSpace(Subject))
                throw new ArgumentException("O assunto (Subject) não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(Body))
                throw new ArgumentException("O corpo (Body) não pode ser vazio.");
        }
    }
}
