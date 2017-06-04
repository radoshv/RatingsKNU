namespace Ratings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RatingIndexes",
                c => new
                    {
                        Rating_Id = c.Guid(nullable: false),
                        Index_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rating_Id, t.Index_Id })
                .ForeignKey("dbo.Ratings", t => t.Rating_Id, cascadeDelete: true)
                .ForeignKey("dbo.Indices", t => t.Index_Id, cascadeDelete: true)
                .Index(t => t.Rating_Id)
                .Index(t => t.Index_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingIndexes", "Index_Id", "dbo.Indices");
            DropForeignKey("dbo.RatingIndexes", "Rating_Id", "dbo.Ratings");
            DropIndex("dbo.RatingIndexes", new[] { "Index_Id" });
            DropIndex("dbo.RatingIndexes", new[] { "Rating_Id" });
            DropTable("dbo.RatingIndexes");
            DropTable("dbo.Ratings");
        }
    }
}
