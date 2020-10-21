namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12345 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Categories_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categories_Id)
                .Index(t => t.Categories_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Categories_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
