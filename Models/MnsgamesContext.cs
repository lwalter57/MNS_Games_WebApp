using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MNS_Games_WebApplication.Models;

public partial class MnsgamesContext : DbContext
{
    public MnsgamesContext()
    {
    }

    public MnsgamesContext(DbContextOptions<MnsgamesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Obtain> Obtains { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Registrate> Registrates { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-64ED8DR\\SQLEXPRESS;Initial Catalog=MNSGames;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Answer__3214EC274EDA4E8A");

            entity.ToTable("Answer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LabelAnswer).HasMaxLength(200);
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Answer__Question__2F10007B");
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.ToTable("AppUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoginNickname).HasMaxLength(50);
            entity.Property(e => e.LoginPassword).HasMaxLength(200);
            entity.Property(e => e.StreetName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StreetNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Badge__3214EC27B10A80A0");

            entity.ToTable("Badge");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descript)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ObtainingConditions)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC276C371C70");

            entity.ToTable("Game");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppUserId).HasColumnName("AppUserID");
            entity.Property(e => e.QuizId).HasColumnName("QuizID");

            entity.HasOne(d => d.AppUser).WithMany(p => p.Games)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Game__AppUserID__34C8D9D1");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Games)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Game__QuizID__33D4B598");
        });

        modelBuilder.Entity<Obtain>(entity =>
        {
            entity.HasKey(e => new { e.QuestionId, e.AnswerId, e.GameId }).HasName("PK__Obtain__8CA2F219009F5AE0");

            entity.ToTable("Obtain");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.AnswerId).HasColumnName("AnswerID");
            entity.Property(e => e.GameId).HasColumnName("GameID");

            entity.HasOne(d => d.Answer).WithMany(p => p.Obtains)
                .HasForeignKey(d => d.AnswerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Obtain__AnswerID__440B1D61");

            entity.HasOne(d => d.Game).WithMany(p => p.Obtains)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Obtain__GameID__44FF419A");

            entity.HasOne(d => d.Question).WithMany(p => p.Obtains)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Obtain__Question__4316F928");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC2752C8BFCF");

            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LabelQuestion).HasMaxLength(200);
            entity.Property(e => e.QuizId).HasColumnName("QuizID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__QuizID__2C3393D0");

            entity.HasMany(d => d.AnswersNavigation).WithMany(p => p.Questions)
                .UsingEntity<Dictionary<string, object>>(
                    "Correspond",
                    r => r.HasOne<Answer>().WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Correspon__Answe__3C69FB99"),
                    l => l.HasOne<Question>().WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Correspon__Quest__3B75D760"),
                    j =>
                    {
                        j.HasKey("QuestionId", "AnswerId").HasName("PK__Correspo__50884A8E92036163");
                        j.ToTable("Correspond");
                        j.IndexerProperty<int>("QuestionId").HasColumnName("QuestionID");
                        j.IndexerProperty<int>("AnswerId").HasColumnName("AnswerID");
                    });
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quiz__3214EC277A62C4B3");

            entity.ToTable("Quiz");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppUserId).HasColumnName("AppUserID");
            entity.Property(e => e.QuizName).HasMaxLength(100);
            entity.Property(e => e.ThemeId).HasColumnName("ThemeID");

            entity.HasOne(d => d.AppUser).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quiz__AppUserID__29572725");

            entity.HasOne(d => d.Theme).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.ThemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quiz__ThemeID__286302EC");

            entity.HasMany(d => d.Badges).WithMany(p => p.Quizzes)
                .UsingEntity<Dictionary<string, object>>(
                    "Attribute",
                    r => r.HasOne<Badge>().WithMany()
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Attribute__Badge__38996AB5"),
                    l => l.HasOne<Quiz>().WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Attribute__QuizI__37A5467C"),
                    j =>
                    {
                        j.HasKey("QuizId", "BadgeId").HasName("PK__Attribut__5AD32C59BE32BA99");
                        j.ToTable("Attribute");
                        j.IndexerProperty<int>("QuizId").HasColumnName("QuizID");
                        j.IndexerProperty<int>("BadgeId").HasColumnName("BadgeID");
                    });
        });

        modelBuilder.Entity<Registrate>(entity =>
        {
            entity.HasKey(e => new { e.QuizId, e.AppUserId }).HasName("PK__Registra__9484F21BEF881535");

            entity.ToTable("Registrate");

            entity.Property(e => e.QuizId).HasColumnName("QuizID");
            entity.Property(e => e.AppUserId).HasColumnName("AppUserID");

            entity.HasOne(d => d.AppUser).WithMany(p => p.Registrates)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registrat__AppUs__403A8C7D");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Registrates)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registrat__QuizI__3F466844");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Theme__3214EC2726B0733C");

            entity.ToTable("Theme");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
