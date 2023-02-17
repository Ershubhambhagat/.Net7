using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Character
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