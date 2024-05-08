namespace ISB.CLWater.Data.Entities
{
    [Table("LookupCode")]
    public partial class LookupCode
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public required string CODE_TYPE { get; set; }

        [StringLength(255)]
        public required string DESCRIPTION { get; set; }

        [StringLength(255)]
        public string? DESCRIPTION_LONG { get; set; }

        public bool? IS_ACTIVE { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }

        [InverseProperty("SUFFIX")]
        public virtual ICollection<Person> Person_Suffix { get; set; } = new List<Person>();

        [InverseProperty("HEAR_ABOUT_US")]
        public virtual ICollection<Person> Person_HearAboutUs { get; set; } = new List<Person>();

        [InverseProperty("REGISTRATION_TYPE")]
        public virtual ICollection<Person> Person_RegistrationType { get; set; } = new List<Person>();

        [InverseProperty("address_note")]
        public virtual ICollection<Person> Person_AddressNote { get; set; } = new List<Person>();

        //[InverseProperty("SUFFIX")]
        //public virtual ICollection<PersonStaging> Person_Staging_Suffix { get; set; } = new List<PersonStaging>();

        //[InverseProperty("HEAR_ABOUT_US")]
        //public virtual ICollection<PersonStaging> Person_Staging_HearAboutUs { get; set; } = new List<PersonStaging>();

        //[InverseProperty("REGISTRATION_TYPE")]
        //public virtual ICollection<PersonStaging> Person_Staging_RegistrationType { get; set; } = new List<PersonStaging>();

        [InverseProperty("STATE")]
        public virtual ICollection<Address> Address_State { get; set; } = new List<Address>();

        [InverseProperty("COUNTRY")]
        public virtual ICollection<Address> Address_Country { get; set; } = new List<Address>();

        //[InverseProperty("STATE")]
        //public virtual ICollection<AddressStaging> Address_Staging_State { get; set; } = new List<AddressStaging>();

        //[InverseProperty("COUNTRY")]
        //public virtual ICollection<AddressStaging> Address_Staging_Country { get; set; } = new List<AddressStaging>();

        [InverseProperty("INQUIRY_TYPE")]
        public virtual ICollection<Inquiry> Inquiry_Type { get; set; } = new List<Inquiry>();

        [InverseProperty("NOTIFICATION_TYPE")]
        public virtual ICollection<NotificationTracking> Notification_Type { get; set; } = new List<NotificationTracking>();

        //[InverseProperty("NOTIFICATION_STAGING_TYPE")]
        //public virtual ICollection<NotificationTrackingStaging> Notification_Staging_Type { get; set; } = new List<NotificationTrackingStaging>();
    }
}