using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Net7.Models;
using Net7.Services.CharacterServices;
using System.Net.NetworkInformation;


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
        [HttpGet("{all}")]
        public async Task<ActionResult<ServiceResponce<Character>>> get() {
            return Ok( await _CharacterService.GetAllCharacter());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponce<List<Character>>>> AddCharacter(Character newCharacter)
        {
            return Ok(await _CharacterService.addCharacter(newCharacter));
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ServiceResponce<Character>>> getSingle( int id)
        //{
        //    return Ok(await _CharacterService.GetCharacterById(id));
        //}

    }
}