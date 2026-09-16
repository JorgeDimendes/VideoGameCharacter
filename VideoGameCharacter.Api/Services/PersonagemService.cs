using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Api.Data;
using VideoGameCharacter.Api.Dtos;
using VideoGameCharacter.Api.Models;

namespace VideoGameCharacter.Api.Services
{
    public class PersonagemService : IPersonagemService
    {
        private readonly AppDbContext _Context;
        public PersonagemService(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<List<GetPersonagemDto>> GetAllPersonagemAsync()
        {
            var personagens = await _Context.Personagens.ToListAsync();
            var resultado = personagens.Select(p => new GetPersonagemDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Jogo = p.Jogo,
                Role = p.Role
            }).ToList();

            return resultado;
        }

        public async Task<GetPersonagemDto> GetPersonagemByIdAsync(int id)
        {
            var resultado = await _Context.Personagens
                .Where(p => p.Id == id)
                .Select(p => new GetPersonagemDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Jogo = p.Jogo,
                    Role = p.Role
                })
                .FirstOrDefaultAsync();

            if (resultado == null) return null;

            /*
            var resultado = new GetPersonagemDto
            {
                Nome = novoPersonagem.Nome,
                Jogo = novoPersonagem.Jogo,
                Role = novoPersonagem.Role
            };
            return resultado;
            */

            return resultado;
        }

        public async Task<GetPersonagemDto> AddPersonagemAsync(CriarPersonagemDto personagemDto)
        {
            var novoPersonagem = new Personagem
            {
                Nome = personagemDto.Nome,
                Jogo = personagemDto.Jogo,
                Role = personagemDto.Role
            };
            await _Context.Personagens.AddAsync(novoPersonagem);
            await _Context.SaveChangesAsync();
            //return personagemDto;

            return new GetPersonagemDto
            {
                Id = novoPersonagem.Id,
                Nome = novoPersonagem.Nome,
                Jogo = novoPersonagem.Jogo,
                Role = novoPersonagem.Role
            };
        }

        public async Task<bool> UpdatePersonagemAsync(int id, AtualizarPersonagemDto personagem)
        {
            var result = await _Context.Personagens.FindAsync(id);

            if(result == null) return false;

            result.Nome = personagem.Nome;
            result.Jogo = personagem.Jogo;
            result.Role = personagem.Role;

            await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePersonagemAsync(int id)
        {
            var result = await _Context.Personagens.FindAsync(id);
            if (result == null) return false;
            
            _Context.Personagens.Remove(result);
            await _Context.SaveChangesAsync();

            return true;
        }
    }
}