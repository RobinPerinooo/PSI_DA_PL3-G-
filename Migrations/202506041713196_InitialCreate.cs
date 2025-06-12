namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projetoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataPrevistaInicio = c.DateTime(),
                        DataPrevistaFim = c.DateTime(),
                        DataRealInicio = c.DateTime(),
                        DataRealFim = c.DateTime(),
                        EstadoAtual = c.Int(nullable: false),
                        Ordem = c.Int(nullable: false),
                        StoryPoints = c.Int(nullable: false),
                        TipoTarefaId = c.Int(nullable: false),
                        GestorId = c.Int(),
                        ProgramadorId = c.Int(nullable: false),
                        ProjetoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.GestorId)
                .ForeignKey("dbo.Utilizadors", t => t.ProgramadorId)
                .ForeignKey("dbo.Projetoes", t => t.ProjetoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoTarefas", t => t.TipoTarefaId, cascadeDelete: true)
                .Index(t => t.TipoTarefaId)
                .Index(t => t.GestorId)
                .Index(t => t.ProgramadorId)
                .Index(t => t.ProjetoId);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Tipo = c.Int(nullable: false),
                        Nivel = c.Int(nullable: false),
                        Departamento = c.Int(nullable: false),
                        GestorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.GestorId)
                .Index(t => t.GestorId);
            
            CreateTable(
                "dbo.TipoTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "TipoTarefaId", "dbo.TipoTarefas");
            DropForeignKey("dbo.Tarefas", "ProjetoId", "dbo.Projetoes");
            DropForeignKey("dbo.Tarefas", "ProgramadorId", "dbo.Utilizadors");
            DropForeignKey("dbo.Tarefas", "GestorId", "dbo.Utilizadors");
            DropForeignKey("dbo.Utilizadors", "GestorId", "dbo.Utilizadors");
            DropIndex("dbo.Utilizadors", new[] { "GestorId" });
            DropIndex("dbo.Tarefas", new[] { "ProjetoId" });
            DropIndex("dbo.Tarefas", new[] { "ProgramadorId" });
            DropIndex("dbo.Tarefas", new[] { "GestorId" });
            DropIndex("dbo.Tarefas", new[] { "TipoTarefaId" });
            DropTable("dbo.TipoTarefas");
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Projetoes");
        }
    }
}
