using Net7.DTOs.Character;
using Net7.Models;

namespace Net7.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<GetCharacterDTO>>> GetAllCharacter();
        Task<ServiceResponce<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponce<List<GetCharacterDTO>>> DeleteCharacterById(int id);

        Task<ServiceResponce<List<GetCharacterDTO>>> addCharacter(AddCharacterDTO addCharacterDTO);
        Task<ServiceResponce<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO  updateCharacterDTO);


    }
}
