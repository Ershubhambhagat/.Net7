using Models;

namespace Net7.DTOs.Character
{
    public class GetCharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Shubham";
        public int HitPoint { get; set; } = 10;
        public int Strength { get; set; } = 100;
        public int Defence { get; set; } = 10;
        public int Intelligent { get; set; } = 10;

        public RpgClass Class { get; set; } = RpgClass.knight;
    }
}
