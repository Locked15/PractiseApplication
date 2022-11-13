using Microsoft.EntityFrameworkCore;

namespace PractiseApplication.Models.Entities;

public partial class BaseContext : DbContext
{
    /// <summary>
    /// This is signleron-property, that allows you to access to data in db.
    /// </summary>
    public static BaseContext Instance { get; set; } = new BaseContext();

    private BaseContext()
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestChat> RequestChats { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<RequestType> RequestTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserReview> UserReviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5430; Database=Other_PractiseApplicationData; User Id=postgres; Password=DayRadiation_Pass03;").UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("location_pkey");

            entity.ToTable("location");

            entity.HasIndex(e => new { e.Municipality, e.Floor, e.Cabinet, e.Table }, "unique_location").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cabinet).HasColumnName("cabinet");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.Municipality).HasColumnName("municipality");
            entity.Property(e => e.Table).HasColumnName("table");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_pkey");

            entity.ToTable("request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeginDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("begin_date");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.ExecutionerId).HasColumnName("executioner_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.RequestStatusId).HasColumnName("request_status_id");
            entity.Property(e => e.RequestTypeId).HasColumnName("request_type_id");
            entity.Property(e => e.RequesterId).HasColumnName("requester_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Executioner).WithMany(p => p.RequestExecutioners)
                .HasForeignKey(d => d.ExecutionerId)
                .HasConstraintName("request_executioner_id_fkey");

            entity.HasOne(d => d.Location).WithMany(p => p.Requests)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("request_location_id_fkey");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestStatusId)
                .HasConstraintName("request_request_status_id_fkey");

            entity.HasOne(d => d.RequestType).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestTypeId)
                .HasConstraintName("request_request_type_id_fkey");

            entity.HasOne(d => d.Requester).WithMany(p => p.RequestRequesters)
                .HasForeignKey(d => d.RequesterId)
                .HasConstraintName("request_requester_id_fkey");
        });

        modelBuilder.Entity<RequestChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_messages_pkey");

            entity.ToTable("request_chat");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('request_messages_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.SentDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sent_date");

            entity.HasOne(d => d.Author).WithMany(p => p.RequestChats)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("request_messages_author_id_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestChats)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("request_messages_request_id_fkey");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_status_pkey");

            entity.ToTable("request_status");

            entity.HasIndex(e => e.Status, "request_status_status_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<RequestType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_type_pkey");

            entity.ToTable("request_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_role_id_fkey");
        });

        modelBuilder.Entity<UserReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_review_pkey");

            entity.ToTable("user_review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Rate)
                .HasPrecision(4, 2)
                .HasColumnName("rate");
            entity.Property(e => e.ReviewTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("review_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_review_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
