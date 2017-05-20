namespace Ratings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Indices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UOM = c.Int(nullable: false),
                        ParentId = c.Guid(),
                        GroupId = c.Guid(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Indices", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.IndexValues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IndexId = c.Guid(nullable: false),
                        FacultyId = c.Guid(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .ForeignKey("dbo.Indices", t => t.IndexId, cascadeDelete: true)
                .Index(t => t.IndexId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.ListLines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FacultyId = c.Guid(),
                        Line = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .Index(t => t.FacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListLines", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.IndexValues", "IndexId", "dbo.Indices");
            DropForeignKey("dbo.IndexValues", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Indices", "ParentId", "dbo.Indices");
            DropForeignKey("dbo.Indices", "GroupId", "dbo.Groups");
            DropIndex("dbo.ListLines", new[] { "FacultyId" });
            DropIndex("dbo.IndexValues", new[] { "FacultyId" });
            DropIndex("dbo.IndexValues", new[] { "IndexId" });
            DropIndex("dbo.Indices", new[] { "GroupId" });
            DropIndex("dbo.Indices", new[] { "ParentId" });
            DropTable("dbo.ListLines");
            DropTable("dbo.IndexValues");
            DropTable("dbo.Indices");
            DropTable("dbo.Groups");
            DropTable("dbo.Faculties");
        }
    }
}
