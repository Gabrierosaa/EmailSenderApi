namespace EmailSenderApi.Domain.Entities
{
    public class Profile
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
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
            if (Id == null)
                throw new Exception("O Id não pode esta vazio");

            if (Name == null || Name.Length > 14)
                throw new Exception("O Nome nao pode estar vazio ou maior que 14 caracteres");

            if (Name.Length > 150)
                throw new Exception("A Descricao nao pode ser maior que 150 caracteres");

            if (Email == null)
                throw new Exception("O Email não pode ser vazio");

            
        }

    }
}
