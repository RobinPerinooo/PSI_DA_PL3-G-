using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace iTasks
{

    class ItasksContext : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TipoTarefa> TiposTarefa { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Relação ProgramadorId
            modelBuilder.Entity<Tarefa>()
                .HasRequired(t => t.Programador)
                .WithMany()
                .HasForeignKey(t => t.ProgramadorId)
                .WillCascadeOnDelete(false); // <- Impede o cascade delete

            // Relação GestorId
            modelBuilder.Entity<Tarefa>()
                .HasOptional(t => t.Gestor)
                .WithMany()
                .HasForeignKey(t => t.GestorId)
                .WillCascadeOnDelete(false); // <- Impede o cascade delete

            base.OnModelCreating(modelBuilder);
        }


    }

}
