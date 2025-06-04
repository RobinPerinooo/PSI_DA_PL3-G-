using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    class Gestor : Utilizador
    {

       public string departamento { get; set; } // Propriedade específica do Gestor
        public override string ToString() => Nome; // Opcional: define como aparece na ListBox
    }
}
