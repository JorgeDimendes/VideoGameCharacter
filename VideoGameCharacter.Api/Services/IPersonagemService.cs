using VideoGameCharacter.Api.Dtos;
using VideoGameCharacter.Api.Models;

namespace VideoGameCharacter.Api.Services
{
    public interface IPersonagemService
    {
        Task<List<GetPersonagemDto>> GetAllPersonagemAsync();
        Task<GetPersonagemDto> GetPersonagemByIdAsync(int id);
        Task<GetPersonagemDto> AddPersonagemAsync(CriarPersonagemDto personagemDto);
        Task<bool> UpdatePersonagemAsync(int id, AtualizarPersonagemDto personagemDto);
        Task<bool> DeletePersonagemAsync(int id);
    }
}