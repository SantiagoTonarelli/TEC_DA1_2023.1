namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EstudianteId);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Departamento_DepartamentoId = c.Int(),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Departamentoes", t => t.Departamento_DepartamentoId)
                .Index(t => t.Departamento_DepartamentoId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        DireccionId = c.Int(nullable: false),
                        Calle = c.String(),
                        Ciudad = c.String(),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Personas", t => t.DireccionId)
                .Index(t => t.DireccionId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.EstudianteCursoes",
                c => new
                    {
                        Estudiante_EstudianteId = c.Int(nullable: false),
                        Curso_CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Estudiante_EstudianteId, t.Curso_CursoId })
                .ForeignKey("dbo.Estudiantes", t => t.Estudiante_EstudianteId, cascadeDelete: true)
                .ForeignKey("dbo.Cursoes", t => t.Curso_CursoId, cascadeDelete: true)
                .Index(t => t.Estudiante_EstudianteId)
                .Index(t => t.Curso_CursoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccions", "DireccionId", "dbo.Personas");
            DropForeignKey("dbo.Empleadoes", "Departamento_DepartamentoId", "dbo.Departamentoes");
            DropForeignKey("dbo.EstudianteCursoes", "Curso_CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.EstudianteCursoes", "Estudiante_EstudianteId", "dbo.Estudiantes");
            DropIndex("dbo.EstudianteCursoes", new[] { "Curso_CursoId" });
            DropIndex("dbo.EstudianteCursoes", new[] { "Estudiante_EstudianteId" });
            DropIndex("dbo.Direccions", new[] { "DireccionId" });
            DropIndex("dbo.Empleadoes", new[] { "Departamento_DepartamentoId" });
            DropTable("dbo.EstudianteCursoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Personas");
            DropTable("dbo.Direccions");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Cursoes");
        }
    }
}
