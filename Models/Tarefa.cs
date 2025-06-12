using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    public enum EstadoAtual { ToDo, Doing, Done }

    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataPrevistaInicio { get; set; }
        public DateTime? DataPrevistaFim { get; set; }
        public DateTime? DataRealInicio { get; set; }
        public DateTime? DataRealFim { get; set; }

        public EstadoAtual EstadoAtual { get; set; } = EstadoAtual.ToDo;
        public int Ordem { get; set; }
        public int StoryPoints { get; set; }

        public int TipoTarefaId { get; set; }
        public TipoTarefa TipoTarefa { get; set; }

        public int? GestorId { get; set; }
        public Utilizador Gestor { get; set; }

        public int ProgramadorId { get; set; }
        public Utilizador Programador { get; set; }

        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }

}
