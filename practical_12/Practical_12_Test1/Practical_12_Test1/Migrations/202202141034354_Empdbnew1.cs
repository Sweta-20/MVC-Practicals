namespace Practical_12_Test1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empdbnew1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DateOfJoing", c => c.DateTime());
            DropColumn("dbo.Employees", "DOB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DOB", c => c.DateTime());
            DropColumn("dbo.Employees", "DateOfJoing");
        }
    }
}
