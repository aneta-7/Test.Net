namespace LibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Authors", "BookID");
            DropColumn("dbo.Books", "AuthorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AuthorName", c => c.String(nullable: false));
            AddColumn("dbo.Authors", "BookID", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Books", "AuthorId");
        }
    }
}
