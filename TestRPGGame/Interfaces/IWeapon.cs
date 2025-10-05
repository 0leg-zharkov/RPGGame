using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TestRPGGame.Interfaces
{
    internal interface IWeapon
    {
        public int Damage { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
