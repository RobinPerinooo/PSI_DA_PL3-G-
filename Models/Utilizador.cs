using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    public enum TipoUtilizador { Programador = 0, Gestor = 1 }
    public enum NivelExperiencia { Junior, Senior }
    public enum Departamento { IT, Marketing, Administração }
    public class Utilizador
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Nome { get; set; }
        public TipoUtilizador Tipo { get; set; }
        public NivelExperiencia Nivel { get; set; }
        public Departamento Departamento { get; set; }

        public int? GestorId { get; set; }
        public Utilizador Gestor { get; set; }
    }
}
