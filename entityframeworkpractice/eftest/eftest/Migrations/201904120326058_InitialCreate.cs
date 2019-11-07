namespace eftest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.student1", "Age", c => c.String());

        }

        public override void Down()
        {
            DropColumn("dbo.student1", "Age");

        }
    }
}
