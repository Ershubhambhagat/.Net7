global using AutoMapper;
using Net7.Data;
using Net7.DTOs.Character;
using Net7.Models;

namespace Net7.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {

        //static Character
        //private static List<Character> Character = new List<Character>
        //{
        //    new Character(),
        //    new Character{Id=1,Name="shubhM" }

        //};
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponce<List<GetCharacterDTO>>> GetAllCharacter()
        {
            var serviceResponce = new ServiceResponce<List<GetCharacterDTO>>();
            var DbCharacters=await _dataContext.Characters.ToArrayAsync();
            serviceResponce.Data = DbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponce;


        }

        public async Task<ServiceResponce<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponce = new ServiceResponce<GetCharacterDTO>();

            var DbCharacter= await _dataContext.Characters.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponce.Data = _mapper.Map<GetCharacterDTO>(DbCharacter);
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetCharacterDTO>>> addCharacter(AddCharacterDTO addCharacterDTO)
        {
            var serviceResponce = new ServiceResponce<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(addCharacterDTO);
            _dataContext.Characters.Add(character);
            await _dataContext.SaveChangesAsync();
            serviceResponce.Data =await _dataContext.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacterDTO)
        {
            var serviceResponce = new ServiceResponce<GetCharacterDTO>();
            try
            {
                var charecter =await _dataContext.Characters.FirstOrDefaultAsync(x => x.Id == updateCharacterDTO.Id);

                if (charecter is null)
                    throw new Exception($"Character with id '{updateCharacterDTO.Id}' is null");

                //_mapper.Map(charecter,updateCharacterDTO);
                charecter.Name = updateCharacterDTO.Name;
                charecter.Intelligent = updateCharacterDTO.Intelligent;
                charecter.Defence = updateCharacterDTO.Defence;
                charecter.Strength = updateCharacterDTO.Strength;
                charecter.HitPoint = updateCharacterDTO.HitPoint;
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = _mapper.Map<GetCharacterDTO>(charecter);

            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetCharacterDTO>>> DeleteCharacterById(int id)
        {

            var serviceResponce = new ServiceResponce<List<GetCharacterDTO>>();
            try
            {
                var charecter =await _dataContext.Characters.FirstOrDefaultAsync(x => x.Id == id);

                if (charecter is null)
                    throw new Exception($"Character with id '{id}' is null");

                //_mapper.Map(charecter,updateCharacterDTO);
                 _dataContext.Characters.Remove(charecter);
                _dataContext.SaveChangesAsync();

                serviceResponce.Data =await _dataContext.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();

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
