using Microsoft.AspNetCore.Mvc;
using VideoGameCharacter.Api.Dtos;
using VideoGameCharacter.Api.Models;
using VideoGameCharacter.Api.Services;

namespace VideoGameCharacter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController(IPersonagemService perso) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetPersonagemDto>>> GetAllPersonagens()
        {
            var personagens = await perso.GetAllPersonagemAsync();
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPersonagemDto>> GetPersonagensById(int id)
        {
            var personagem = await perso.GetPersonagemByIdAsync(id);
            if (personagem == null)
            {
                return BadRequest($"Personagem do Id {id} não localizado");
            }
            return Ok(personagem);
        }

        [HttpPost]
        public async Task<ActionResult<Personagem>> AddPersonagem(CriarPersonagemDto personagemDto)
        {
            var result = await perso.AddPersonagemAsync(personagemDto);
            return CreatedAtAction(nameof(GetAllPersonagens), new { id = result.Id }, result);
            //return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Personagem>> PutPersonagem(int id, AtualizarPersonagemDto personagem)
        {
            var result = await perso.UpdatePersonagemAsync(id, personagem);
            if (result == null) return NotFound("Erro ao atualizar personagem");
            return Ok(result);
            //return result ? NoContent() : NotFound("Erro ao atualizar personagem");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Personagem>> DeletePersonagem(int id)
        {
            var result = await perso.DeletePersonagemAsync(id);

            return result ? NoContent() : NotFound("Erro ao deletar personagem");
            //return Ok(result);
        }
    }
}