namespace Es.Pue.Intranet.Model.PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginId = c.Guid(),
                        DBInsertedDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.CandidateDatas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DBInsertedDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Candidate_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .Index(t => t.Candidate_Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DBInsertedDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Candidate_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .Index(t => t.Candidate_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginUser = c.String(),
                        Password = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        DBInsertedDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recruiters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        LoginId = c.Guid(),
                        DBInsertedDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.Candidate_Recruiters",
                c => new
                    {
                        Candidate_Id = c.Guid(nullable: false),
                        Recruiter_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Candidate_Id, t.Recruiter_Id })
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recruiters", t => t.Recruiter_Id, cascadeDelete: true)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Recruiter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidate_Recruiters", "Recruiter_Id", "dbo.Recruiters");
            DropForeignKey("dbo.Candidate_Recruiters", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Recruiters", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Candidates", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Exams", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.CandidateDatas", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.Candidate_Recruiters", new[] { "Recruiter_Id" });
            DropIndex("dbo.Candidate_Recruiters", new[] { "Candidate_Id" });
            DropIndex("dbo.Recruiters", new[] { "LoginId" });
            DropIndex("dbo.Exams", new[] { "Candidate_Id" });
            DropIndex("dbo.CandidateDatas", new[] { "Candidate_Id" });
            DropIndex("dbo.Candidates", new[] { "LoginId" });
            DropTable("dbo.Candidate_Recruiters");
            DropTable("dbo.Recruiters");
            DropTable("dbo.Logins");
            DropTable("dbo.Exams");
            DropTable("dbo.CandidateDatas");
            DropTable("dbo.Candidates");
        }
    }
}
