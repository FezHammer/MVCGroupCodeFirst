namespace MVCGroupE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Students", "Email", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
        }
    }
}
