namespace ISB.CLWater.Service.Context;

public partial class CLWaterContext : DbContext
{
    public CLWaterContext(DbContextOptions<CLWaterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressNote> LK_ADDRESS_NOTE { get; set; }
   
    public virtual DbSet<Country> LK_COUNTRY { get; set; }

    public virtual DbSet<FollowUpReason> LK_FOLLOW_UP_REASON { get; set; }

    public virtual DbSet<HearAboutUs> LK_HEAR_ABOUT_US { get; set; }

    public virtual DbSet<InquiryType> LK_INQUIRY_TYPE { get; set; }

    public virtual DbSet<LookupCode> LookupCodes { get; set; }

    public virtual DbSet<NotificationType> LK_NOTIFICATION_TYPE { get; set; }

    public virtual DbSet<RegistrationType> LK_REGISTRATION_TYPE { get; set; }

    public virtual DbSet<State> LK_STATE { get; set; }

    public virtual DbSet<Suffix> LK_SUFFIX { get; set; }

    public virtual DbSet<Profile> Profile { get; set; }

    public virtual DbSet<RealTimeStateData> RealTimeStateData { get; set; }

    public virtual DbSet<Address> TBL_ADDRESS { get; set; }

    public virtual DbSet<AddressStaging> TBL_ADDRESS_STAGING { get; set; }

    public virtual DbSet<Comment> TBL_COMMENT { get; set; }

    public virtual DbSet<Error> TBL_ERROR { get; set; }

    public virtual DbSet<HitCounter> TBL_HitCounter { get; set; }

    public virtual DbSet<Inquiry> TBL_INQUIRY { get; set; }

    public virtual DbSet<NotificationTracking> TBL_NOTIFICATION_TRACKING { get; set; }

    public virtual DbSet<NotificationTrackingStaging> TBL_NOTIFICATION_TRACKING_Staging { get; set; }

    public virtual DbSet<Person> TBL_PERSON { get; set; }

    public virtual DbSet<PersonStaging> TBL_PERSON_STAGING { get; set; }

    public virtual DbSet<ProjectUpdate> TBL_ProjectUpdate { get; set; }

    public virtual DbSet<User> TBL_USER { get; set; }

    public virtual DbSet<ValidationHistory> TBL_VALIDATION_HISTORY { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.COUNTRY_ID).HasName("PK__LK_COUNTRY__1BFD2C07");
        });

        modelBuilder.Entity<FollowUpReason>(entity =>
        {
            entity.HasKey(e => e.FOLLOW_UP_REASON_ID).HasName("PK__LK_FOLLOW_UP_REA__239E4DCF");
        });

        modelBuilder.Entity<HearAboutUs>(entity =>
        {
            entity.HasKey(e => e.HEAR_ABOUT_US_ID).HasName("PK__LK_HEAR_ABOUT_US__1DE57479");
        });

        modelBuilder.Entity<InquiryType>(entity =>
        {
            entity.HasKey(e => e.INQUIRY_TYPE_ID).HasName("PK__LK_INQUIRY_TYPE__1FCDBCEB");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.HasKey(e => e.NOTIFICATION_TYPE_ID).HasName("PK__LK_NOTIFICATION___25869641");
        });

        modelBuilder.Entity<RegistrationType>(entity =>
        {
            entity.HasKey(e => e.REGISTRATION_TYPE_ID).HasName("XPKLK_REGISTRATION_TYPE");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.STATE_ID).HasName("PK__LK_STATE__1A14E395");
        });

        modelBuilder.Entity<Suffix>(entity =>
        {
            entity.HasKey(e => e.SUFFIX_ID).HasName("PK__LK_SUFFIX__182C9B23");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.RowNumber).HasName("PK__Profile__AAAC09D870DDC3D8");
        });

        modelBuilder.Entity<RealTimeStateData>(entity =>
        {
            entity.ToView("RealTimeStateData");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.ADDRESS_ID).HasName("PK__TBL_ADDRESS__1273C1CD");

            entity.HasOne(d => d.COUNTRY).WithMany(p => p.TBL_ADDRESS).HasConstraintName("R_13");

            entity.HasOne(d => d.PERSON).WithMany(p => p.TBL_ADDRESS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERSON_ADDRESS");

            entity.HasOne(d => d.STATE).WithMany(p => p.TBL_ADDRESS).HasConstraintName("R_12");
        });

        modelBuilder.Entity<AddressStaging>(entity =>
        {
            entity.Property(e => e.ADDRESS_ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Inquiry>(entity =>
        {
            entity.HasKey(e => e.INQUIRY_ID).HasName("PK__TBL_INQUIRY__21B6055D");
        });

        modelBuilder.Entity<NotificationTracking>(entity =>
        {
            entity.HasKey(e => e.NOTIFICATION_TRACKING_ID).HasName("PK__TBL_NOTIFICATION__276EDEB3");

            entity.HasOne(d => d.NOTIFICATION_TYPE).WithMany(p => p.TBL_NOTIFICATION_TRACKING)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_11");

            entity.HasOne(d => d.PERSON).WithMany(p => p.TBL_NOTIFICATION_TRACKING)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_5");
        });

        modelBuilder.Entity<NotificationTrackingStaging>(entity =>
        {
            entity.Property(e => e.NOTIFICATION_TRACKING_ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PERSON_ID).HasName("PK__TBLCLNR__108B795B");

            entity.ToTable(tb => tb.HasTrigger("trgInsertValidationHistory"));

            entity.Property(e => e.address_note_id).HasDefaultValue(1);

            entity.HasOne(d => d.HEAR_ABOUT_US).WithMany(p => p.TBL_PERSON).HasConstraintName("R_8");

            entity.HasOne(d => d.REGISTRATION_TYPE).WithMany(p => p.TBL_PERSON).HasConstraintName("R_10");

            entity.HasOne(d => d.SUFFIX).WithMany(p => p.TBL_PERSON).HasConstraintName("R_3");

            entity.HasOne(d => d.address_note).WithMany(p => p.TBL_PERSON)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_address_note_id");
        });

        modelBuilder.Entity<PersonStaging>(entity =>
        {
            entity.Property(e => e.PERSON_ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.USER_ID).HasName("XPKTBL_USER");
        });

        modelBuilder.Entity<ValidationHistory>(entity =>
        {
            entity.Property(e => e.VALIDATION_HISTORY_ID).ValueGeneratedOnAdd();
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}