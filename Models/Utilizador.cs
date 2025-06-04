using System;
using System.Collections.Generic;


using System.Data.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{

    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; } // tipo de utilizador Programador ou Gestor

        public override string ToString() => Nome; // Opcional: define como aparece na ListBox
    }

  public static class SessaoAtual
{
    public static Utilizador UtilizadorLogado { get; set; }
    public static List<Utilizador> TodosUtilizadores { get; set; } = new List<Utilizador>();
}

}

