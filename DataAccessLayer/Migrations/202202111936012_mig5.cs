namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "PhoneNumber", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "PhoneNumber", c => c.String(maxLength: 13));
        }
    }
}
