using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    class Programador : Utilizador
    {
        public int NivelExperiencia = 0;
        public override string ToString() => Nome; // Opcional: define como aparece na ListBox
    }
}
