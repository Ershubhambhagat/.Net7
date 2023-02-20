global using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Models;
using Net7.DTOs.Character;
using Net7.Models;

namespace Net7.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> Character = new List<Character>
        {
            new Character(),
            new Character{Id=1,Name="shubhM" }

        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponce<List<GetCharacterDTO>>> GetAllCharacter()
        {
            var serviceResponce = new ServiceResponce<List<GetCharacterDTO>>();

            serviceResponce.Data = Character.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponce;


        }

        public async Task<ServiceResponce<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponce = new ServiceResponce<GetCharacterDTO>();

            var chhharactor = Character.FirstOrDefault(x => x.Id == id);
            serviceResponce.Data = _mapper.Map<GetCharacterDTO>(chhharactor);
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetCharacterDTO>>> addCharacter(AddCharacterDTO addCharacterDTO)
        {
            var serviceResponce = new ServiceResponce<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(addCharacterDTO);

            character.Id = Character.Max(c => c.Id) + 1;
            Character.Add(character);
            serviceResponce.Data = Character.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDTO>>UpdateCharacter(UpdateCharacterDTO updateCharacterDTO)
        {
            var serviceResponce = new ServiceResponce<GetCharacterDTO>();
            try
            {
                var charecter =  Character.FirstOrDefault(x => x.Id == updateCharacterDTO.Id);
                
                if(charecter is null)
                    throw new Exception ($"Character with id '{updateCharacterDTO.Id}' is null");

                //_mapper.Map(charecter,updateCharacterDTO);
                charecter.Name = updateCharacterDTO.Name;
                charecter.Intelligent = updateCharacterDTO.Intelligent;
                charecter.Defence = updateCharacterDTO.Defence;
                charecter.Strength = updateCharacterDTO.Strength;
                charecter.HitPoint = updateCharacterDTO.HitPoint;

                serviceResponce.Data = _mapper.Map<GetCharacterDTO>(charecter);
                
            }
            catch(Exception ex)
            {
                serviceResponce.Success=false;
                serviceResponce.Message= ex.Message;
            }
            
             return serviceResponce;
            
        }

        public async Task<ServiceResponce<List<GetCharacterDTO>>> DeleteCharacterById(int id)
        {

            var serviceResponce = new ServiceResponce<List<GetCharacterDTO>>();
            try
            {
                var charecter = Character.FirstOrDefault(x => x.Id == id);

                if (charecter is null)
                    throw new Exception($"Character with id '{id}' is null");

                //_mapper.Map(charecter,updateCharacterDTO);
                Character.Remove(charecter);

                serviceResponce.Data = Character.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

             return serviceResponce;
            

        }
    }


}
