﻿namespace iTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarModelo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadors", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadors", "Nome");
        }
    }
}
