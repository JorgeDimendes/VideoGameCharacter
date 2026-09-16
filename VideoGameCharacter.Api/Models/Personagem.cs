namespace VideoGameCharacter.Api.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Jogo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}