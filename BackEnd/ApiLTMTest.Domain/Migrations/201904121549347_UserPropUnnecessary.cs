namespace ApiLTMTest.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPropUnnecessary : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Gender");
            DropColumn("dbo.User", "Birthday");
            DropColumn("dbo.User", "FacebookID");
            DropColumn("dbo.User", "FacebookToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "FacebookToken", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.User", "FacebookID", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.User", "Birthday", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.User", "Gender", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
