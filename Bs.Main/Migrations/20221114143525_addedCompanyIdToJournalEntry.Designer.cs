// <auto-generated />
using System;
using Bs.Main.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bs.Main.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20221114143525_addedCompanyIdToJournalEntry")]
    partial class addedCompanyIdToJournalEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Bs.Main.Modules.MasterlistModule.ValueObjects.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Acronym")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Tin")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Bs.Main.Modules.MasterlistModule.ValueObjects.CompanyAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("VARCHAR(25)");

                    b.Property<string>("BankName")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("Code")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("CompanyId")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("CompanyAccounts");
                });

            modelBuilder.Entity("Bs.Main.Modules.MasterlistModule.ValueObjects.JournalAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<double>("Rate")
                        .HasColumnType("DOUBLE(6,2)");

                    b.HasKey("Id");

                    b.ToTable("JournalAccounts");
                });

            modelBuilder.Entity("Bs.Main.Modules.MasterlistModule.ValueObjects.Payee", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("OwnerName")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("PayeeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<string>("Tin")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Payees");
                });

            modelBuilder.Entity("Bs.Main.Modules.MasterlistModule.ValueObjects.PayeeAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("VARCHAR(25)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("DefaultParticulars")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PayeeId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.ToTable("PayeeAccounts");
                });

            modelBuilder.Entity("Bs.Main.Modules.VoucherModule.Entities.Voucher", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("CompanyAccountCode")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("CompanyId")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("DATE");

                    b.Property<int>("PayeeAccountId")
                        .HasColumnType("INT");

                    b.Property<byte[]>("PayeeId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Remarks")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("UseOwnerName")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("VoucherNumber")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PayeeAccountId");

                    b.HasIndex("PayeeId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Bs.Main.Modules.VoucherModule.ValueObjects.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("DOUBLE(10,2)");

                    b.Property<string>("CompanyId")
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("JournalAccountName")
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("Particulars")
                        .HasColumnType("TEXT");

                    b.Property<string>("VoucherId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<double>("WithholdingTaxRate")
                        .HasColumnType("DOUBLE(4,2)");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("Bs.Main.Modules.VoucherModule.Entities.Voucher", b =>
                {
                    b.HasOne("Bs.Main.Modules.MasterlistModule.ValueObjects.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Bs.Main.Modules.MasterlistModule.ValueObjects.PayeeAccount", "PayeeAccount")
                        .WithMany()
                        .HasForeignKey("PayeeAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bs.Main.Modules.MasterlistModule.ValueObjects.Payee", "Payee")
                        .WithMany()
                        .HasForeignKey("PayeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Payee");

                    b.Navigation("PayeeAccount");
                });

            modelBuilder.Entity("Bs.Main.Modules.VoucherModule.ValueObjects.JournalEntry", b =>
                {
                    b.HasOne("Bs.Main.Modules.VoucherModule.Entities.Voucher", null)
                        .WithMany("JournalEntries")
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bs.Main.Modules.VoucherModule.Entities.Voucher", b =>
                {
                    b.Navigation("JournalEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
