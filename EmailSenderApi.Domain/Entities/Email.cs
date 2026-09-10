namespace EmailSenderApi.Domain.Entities
{
    public class Email
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        DateTime Data { get; set; } = DateTime.Now;

        public Email(string from, string to, string subject, string body, DateTime data)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
            Data = data;

            Validations();
        }

        private void Validations()
        {
            if (From == null)
                throw new Exception("From nao pode ser vazio");

            if (To == null)
                throw new Exception("To nao pode ser vazio");

            if (Subject == null)
                throw new Exception("Subject nao pode ser vazio");

            if (Body == null)
                throw new Exception("Body nao pode ser vazio");

            if (Data == null)
                throw new Exception("Data nao pode ser vazio");
        }
    }
}
