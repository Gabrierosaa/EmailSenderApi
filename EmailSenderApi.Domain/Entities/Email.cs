namespace EmailSenderApi.Domain.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Data { get; set; }

        private Email() { } 

        public Email(string from, string to, string subject, string body)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
            Data = DateTime.Now;

            Validations();
        }

        private void Validations()
        {
            if (string.IsNullOrWhiteSpace(From))
                throw new ArgumentException("From nao pode ser vazio");

            if (string.IsNullOrWhiteSpace(To))
                throw new ArgumentException("To nao pode ser vazio");

            if (string.IsNullOrWhiteSpace(Subject))
                throw new ArgumentException("Subject nao pode ser vazio");

            if (string.IsNullOrWhiteSpace(Body))
                throw new ArgumentException("Body nao pode ser vazio");
        }
    }
}