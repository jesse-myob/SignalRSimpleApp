namespace SignalRDev.DataAccess.Dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.CoopbaseUserLogDatas",
                c => new
                    {
                        UserNumericId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        LogDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserNumericId);
            
        }
        
        public override void Down()
        {
            DropTable("public.CoopbaseUserLogDatas");
        }
    }
}
