using Models;
using Net7.Models;

namespace Net7.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<Character>>> GetAllCharacter();
        //Task<ServiceResponce<Character>> GetCharacterById(int id);
        Task<ServiceResponce<List<Character>>> addCharacter(Character NewCharacter);


    }
}
