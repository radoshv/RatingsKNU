namespace Ratings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Indices", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Indices", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
