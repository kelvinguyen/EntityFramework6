namespace NameSearch.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddressTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Zipcode", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "State", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "State", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "Zipcode");
        }
    }
}
