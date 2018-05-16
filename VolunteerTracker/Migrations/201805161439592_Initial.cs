namespace VolunteerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(),
                        Time = c.DateTime(),
                        EndTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        VolunteersNeeded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Cause = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        HomePhone = c.String(),
                        CellPhone = c.String(),
                        Email = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationEvents",
                c => new
                    {
                        Organization_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_Id, t.Event_Id })
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Organization_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.VolunteerEvents",
                c => new
                    {
                        Volunteer_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Volunteer_Id, t.Event_Id })
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Volunteer_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.VolunteerOrganizations",
                c => new
                    {
                        Volunteer_Id = c.Int(nullable: false),
                        Organization_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Volunteer_Id, t.Organization_Id })
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .Index(t => t.Volunteer_Id)
                .Index(t => t.Organization_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VolunteerOrganizations", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.VolunteerOrganizations", "Volunteer_Id", "dbo.Volunteers");
            DropForeignKey("dbo.VolunteerEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.VolunteerEvents", "Volunteer_Id", "dbo.Volunteers");
            DropForeignKey("dbo.OrganizationEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.OrganizationEvents", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.VolunteerOrganizations", new[] { "Organization_Id" });
            DropIndex("dbo.VolunteerOrganizations", new[] { "Volunteer_Id" });
            DropIndex("dbo.VolunteerEvents", new[] { "Event_Id" });
            DropIndex("dbo.VolunteerEvents", new[] { "Volunteer_Id" });
            DropIndex("dbo.OrganizationEvents", new[] { "Event_Id" });
            DropIndex("dbo.OrganizationEvents", new[] { "Organization_Id" });
            DropTable("dbo.VolunteerOrganizations");
            DropTable("dbo.VolunteerEvents");
            DropTable("dbo.OrganizationEvents");
            DropTable("dbo.Volunteers");
            DropTable("dbo.Organizations");
            DropTable("dbo.Events");
        }
    }
}
