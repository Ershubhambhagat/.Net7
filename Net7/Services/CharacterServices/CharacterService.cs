using Models;
using Net7.Models;
using System.Xml.Linq;

namespace Net7.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> Character = new List<Character>
        {
            new Character(),
            new Character{Id=1,Name="shubhM" }

        };


        public async Task<ServiceResponce<List<Character>>> GetAllCharacter()
        {
            var serviceResponce = new ServiceResponce<List<Character>>();
            serviceResponce.Data = Character;
            return serviceResponce;

            
        }

        //public async Task<ServiceResponce<Character>> GetCharacterById(int id)
        //{
        //    var serviceResponce = new ServiceResponce<Character>();

        //    var chhharactor =await Character.FirstOrDefault (x => x.Id == id);
        //    serviceResponce.Data = chhharactor;
        //    return serviceResponce;

        //}

        public async Task<ServiceResponce<List<Character>>> addCharacter(Character NewCharacter)
        {
            var serviceResponce = new ServiceResponce<List<Character>>();
            Character.Add(NewCharacter);
            serviceResponce.Data = Character;
            return serviceResponce;
        }
    }

}
