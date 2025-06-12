using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    class Programador : Utilizador
    {
        public NivelExperiencia Experiencia { get; set; } // Propriedade específica do Programador
        public override string ToString() => Nome;
    }
}
