namespace Practical_12_Test1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empdbnew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
