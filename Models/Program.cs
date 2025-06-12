using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var db = new ItasksContext())
            {
                db.Database.CreateIfNotExists();

                if (!db.Utilizadores.Any())
                {
                    var utilizadores = new List<Utilizador>
                    {
                        new Utilizador { Username = "gestor", Password = "12345", Tipo = TipoUtilizador.Gestor },
                        new Utilizador { Username = "programador", Password = "1234", Tipo = TipoUtilizador.Programador }
                    };
                    db.Utilizadores.AddRange(utilizadores);
                    db.SaveChanges();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}