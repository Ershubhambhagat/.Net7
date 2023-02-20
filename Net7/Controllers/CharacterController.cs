using Microsoft.AspNetCore.Mvc;
using Models;
using Net7.DTOs.Character;
using Net7.Models;
using Net7.Services.CharacterServices;


namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character Knight = new Character();
        private readonly ICharacterService _CharacterService;

        public CharacterController(ICharacterService CharacterService)
        {
            this._CharacterService = CharacterService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponce<GetCharacterDTO>>> get()
        {
            return Ok(await _CharacterService.GetAllCharacter());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponce<List<AddCharacterDTO>>>> AddCharacter(AddCharacterDTO addCharacterDTO)

        {
            return Ok(await _CharacterService.addCharacter(addCharacterDTO));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponce<List<AddCharacterDTO>>>> UpdateCharacterDTO(UpdateCharacterDTO updateCharacterDTO)
        {
            var responce = await _CharacterService.UpdateCharacter(updateCharacterDTO);
            if (responce is null)
                return NotFound("Data not Found ");
            return Ok(responce);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponce<GetCharacterDTO>>> getSingle(int id)
        {
            return Ok(await _CharacterService.GetCharacterById(id));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponce<GetCharacterDTO>>> DeleteCharacterById(int id)
        {
            var responce = await _CharacterService.DeleteCharacterById(id);
            if (responce is null)
                return NotFound($"Data not Found { responce}" );
            return Ok(responce);
        }

    }
}