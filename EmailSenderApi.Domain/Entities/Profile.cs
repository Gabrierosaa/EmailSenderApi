namespace EmailSenderApi.Domain.Entities
{
    public class Profile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public Email EmailSenter { get; set; }

        public Profile(string? name, string description, string email)
        {
            Name = name;
            Description = description;
            Email = email;

            Validations(name, description, email);
        }

        private void Validations(string name, string description, string email)
        {
            if (Name == null || Name.Length > 14)
                throw new Exception(
                    "O Nome não pode estar vazio ou ser maior que 14 caracteres"
                );

            if (Description.Length > 150)
                throw new Exception(
                    "A Descrição não pode ser maior que 150 caracteres"
                );

            if (Email == null)
                throw new Exception("O Email não pode ser vazio");
        }
    }
}