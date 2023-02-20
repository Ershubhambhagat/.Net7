using Models;

using Net7.DTOs.Character;

namespace Net7
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<Character, UpdateCharacterDTO>();

        }
    }
}
