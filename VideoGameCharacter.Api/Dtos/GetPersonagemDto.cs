namespace VideoGameCharacter.Api.Dtos
{
    public class GetPersonagemDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Jogo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}