using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MvcStockv2.Models.Entity;

public partial class Logiconnectv2Context : DbContext
{
    public Logiconnectv2Context()
    {
    }

    public Logiconnectv2Context(DbContextOptions<Logiconnectv2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AirFreighter> AirFreighters { get; set; }

    public virtual DbSet<CustomerService> CustomerServices { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Kullanıcı> Kullanıcıs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Receiver> Receivers { get; set; }

    public virtual DbSet<ReceiverFirmTelno> ReceiverFirmTelnos { get; set; }

    public virtual DbSet<SalesMarketing> SalesMarketings { get; set; }

    public virtual DbSet<Sender> Senders { get; set; }

    public virtual DbSet<SenderTelno> SenderTelnos { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<StorageLocation> StorageLocations { get; set; }

    public virtual DbSet<SupplyChain> SupplyChains { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<TransportOperation> TransportOperations { get; set; }

    public virtual DbSet<Truck> Trucks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-V8M003LS\\SQLEXPRESS;Initial Catalog=logiconnectv2;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AirFreighter>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Air_Frei__A17E32779ADAAA29");

            entity.ToTable("Air_Freighter");

            entity.Property(e => e.TransportId)
                .ValueGeneratedNever()
                .HasColumnName("transport_id");
            entity.Property(e => e.AirFreighterCapacity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("air_freighter_capacity");
            entity.Property(e => e.AirlineFee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("airline_fee");
            entity.Property(e => e.PilotName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pilot_name");
        });

        modelBuilder.Entity<CustomerService>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Customer__C52E0BA8999A4D70");

            entity.ToTable("Customer_Service");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.ReceiverFirmId).HasColumnName("receiver_firm_id");
            entity.Property(e => e.Salary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salary");
            entity.Property(e => e.ServiceSatisfactionRate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("service_satisfaction_rate");

            entity.HasOne(d => d.ReceiverFirm).WithMany(p => p.CustomerServices)
                .HasForeignKey(d => d.ReceiverFirmId)
                .HasConstraintName("FK__Customer___recei__3F115E1A");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => new { e.TransportId, e.ReceiverFirmId }).HasName("PK__Delivery__00057EC29E15E4BB");

            entity.ToTable("Delivery");

            entity.Property(e => e.TransportId).HasColumnName("transport_id");
            entity.Property(e => e.ReceiverFirmId).HasColumnName("receiver_firm_id");
            entity.Property(e => e.DeliveryDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("delivery_date");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Driver__A411C5BD47803C81");

            entity.ToTable("Driver");

            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("driver_name");
            entity.Property(e => e.DriverSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("driver_surname");
        });

        modelBuilder.Entity<Kullanıcı>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Kullanıc__B9BE370F37B1FADC");

            entity.ToTable("Kullanıcı");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF5E7AEAEC9");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductSensivity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_sensivity");
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_type");
            entity.Property(e => e.ProductUnit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_unit");
        });

        modelBuilder.Entity<Receiver>(entity =>
        {
            entity.HasKey(e => e.ReceiverFirmId).HasName("PK__Receiver__17B4CB5B76E35E18");

            entity.ToTable("Receiver");

            entity.Property(e => e.ReceiverFirmId).HasColumnName("receiver_firm_id");
            entity.Property(e => e.ReceiverFirmEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("receiver_firm_email");
            entity.Property(e => e.ReceiverFirmLocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("receiver_firm_location");
            entity.Property(e => e.ReceiverFirmName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("receiver_firm_name");
        });

        modelBuilder.Entity<ReceiverFirmTelno>(entity =>
        {
            entity.HasKey(e => new { e.ReceiverfirmTelno1, e.ReceiverFirmId }).HasName("PK__receiver__24AE38C9B649B7C8");

            entity.ToTable("receiver_firm_telno");

            entity.Property(e => e.ReceiverfirmTelno1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("receiverfirm_telno");
            entity.Property(e => e.ReceiverFirmId).HasColumnName("receiver_firm_id");
        });

        modelBuilder.Entity<SalesMarketing>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Sales_Ma__C52E0BA853F0C7B8");

            entity.ToTable("Sales_Marketing");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.ReceiverFirmId).HasColumnName("receiver_firm_id");
            entity.Property(e => e.Salary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salary");

            entity.HasOne(d => d.ReceiverFirm).WithMany(p => p.SalesMarketings)
                .HasForeignKey(d => d.ReceiverFirmId)
                .HasConstraintName("FK__Sales_Mar__recei__208CD6FA");
        });

        modelBuilder.Entity<Sender>(entity =>
        {
            entity.HasKey(e => e.SenderFirmId).HasName("PK__Sender__BD94933035059F9C");

            entity.ToTable("Sender");

            entity.Property(e => e.SenderFirmId).HasColumnName("sender_firm_id");
            entity.Property(e => e.SenderFirmEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_firm_email");
            entity.Property(e => e.SenderFirmLocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_firm_location");
            entity.Property(e => e.SenderFirmName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_firm_name");
        });

        modelBuilder.Entity<SenderTelno>(entity =>
        {
            entity.HasKey(e => e.SenderTelNo1).HasName("PK__Sender_t__9F72DE70B3D1DA31");

            entity.ToTable("Sender_telno");

            entity.Property(e => e.SenderTelNo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_tel_no");
            entity.Property(e => e.SenderFirmId).HasColumnName("sender_firm_id");

            entity.HasOne(d => d.SenderFirm).WithMany(p => p.SenderTelnos)
                .HasForeignKey(d => d.SenderFirmId)
                .HasConstraintName("FK__Sender_te__sende__72C60C4A");
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Ship__A17E3277CDA50509");

            entity.ToTable("Ship");

            entity.Property(e => e.TransportId)
                .ValueGeneratedNever()
                .HasColumnName("transport_id");
            entity.Property(e => e.CaptainName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("captain_name");
            entity.Property(e => e.ShipCapacity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ship_capacity");
            entity.Property(e => e.ShipFee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ship_fee");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.StorageId).HasName("PK__Storage__AB53044A6BD46B03");

            entity.ToTable("Storage");

            entity.Property(e => e.StorageId).HasColumnName("storage_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.StorageCapacity).HasColumnName("storage_capacity");
            entity.Property(e => e.StorageName)
                .HasMaxLength(50)
                .HasColumnName("storage_name");

            entity.HasOne(d => d.Product).WithMany(p => p.Storages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Storage__product__787EE5A0");
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.HasKey(e => e.StorageLocation1).HasName("PK__Storage___48A916E970F41CA9");

            entity.ToTable("Storage_Location");

            entity.Property(e => e.StorageLocation1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("storage_location");
            entity.Property(e => e.StorageId).HasColumnName("storage_id");

            entity.HasOne(d => d.Storage).WithMany(p => p.StorageLocations)
                .HasForeignKey(d => d.StorageId)
                .HasConstraintName("FK__Storage_L__stora__7E37BEF6");
        });

        modelBuilder.Entity<SupplyChain>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Supply_C__C52E0BA8B4957D96");

            entity.ToTable("Supply_Chain");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.Salary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salary");
            entity.Property(e => e.StorageId).HasColumnName("storage_id");

            entity.HasOne(d => d.Storage).WithMany(p => p.SupplyChains)
                .HasForeignKey(d => d.StorageId)
                .HasConstraintName("FK__Supply_Ch__stora__17F790F9");
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.ToTable("Transfer");

            entity.Property(e => e.TransferId).HasColumnName("transfer_id");
            entity.Property(e => e.LoadingDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("loading_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ReceiverFirmId).HasColumnName("receiver_firm_id");
            entity.Property(e => e.SenderFirmId).HasColumnName("sender_firm_id");
            entity.Property(e => e.StorageId).HasColumnName("storage_id");
            entity.Property(e => e.TransferPayment).HasColumnName("transfer_payment");
            entity.Property(e => e.TransportId).HasColumnName("transport_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Transfer__produc__67DE6983");

            entity.HasOne(d => d.ReceiverFirm).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.ReceiverFirmId)
                .HasConstraintName("FK__Transfer__receiv__6ABAD62E");

            entity.HasOne(d => d.SenderFirm).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.SenderFirmId)
                .HasConstraintName("FK__Transfer__sender__68D28DBC");

            entity.HasOne(d => d.Storage).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.StorageId)
                .HasConstraintName("FK__Transfer__storag__69C6B1F5");

            entity.HasOne(d => d.Transport).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.TransportId)
                .HasConstraintName("FK__Transfer__transp__66EA454A");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Transpor__A17E32772905D1C6");

            entity.ToTable("Transport");

            entity.Property(e => e.TransportId).HasColumnName("transport_id");
            entity.Property(e => e.TransportType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transport_type");
        });

        modelBuilder.Entity<TransportOperation>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Transpor__C52E0BA8B25F30E0");

            entity.ToTable("Transport_Operation");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.Salary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salary");
            entity.Property(e => e.TransportId).HasColumnName("transport_id");

            entity.HasOne(d => d.Transport).WithMany(p => p.TransportOperations)
                .HasForeignKey(d => d.TransportId)
                .HasConstraintName("FK__Transport__trans__2645B050");
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Truck__A17E327744E2AC2D");

            entity.ToTable("Truck");

            entity.Property(e => e.TransportId).HasColumnName("transport_id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.HighwayFee).HasColumnName("highway_fee");
            entity.Property(e => e.TruckCapacity).HasColumnName("truck_capacity");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trucks)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Truck__driver_id__531856C7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
