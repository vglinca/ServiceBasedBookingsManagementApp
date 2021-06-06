using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Domain.ValueObjects;
using OnlineBookingAggregatorApp.Persistence.Helpers;

namespace OnlineBookingAggregatorApp.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private const int MaxLengthOfNamesGeneral = 128;
        private const string AuthSchema = "Auth";
        
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ServiceEmployee> ServiceEmployees { get; set; }
        public virtual DbSet<CompanyTypeEntity> CompanyTypes { get; set; }
        public virtual DbSet<BusinessTypeEntity> ServiceTypes { get; set; }
        public virtual DbSet<BusinessAreaEntity> BusinessAreas { get; set; }
        public virtual DbSet<CompanyBusinessArea> CompanyBusinessAreas { get; set; }
        public virtual DbSet<GenderEntity> Genders { get; set; }
        public virtual DbSet<ClientCategoryEntity> ClientCategories { get; set; }
        public virtual DbSet<EmployeesSizeEntity> SizeOfEmployees { get; set; }
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }
        public virtual DbSet<PolicyEntity> Policies { get; set; }
        public virtual DbSet<SystemRoleEntity> SystemRoles { get; set; }
        public virtual DbSet<PolicyRole> PolicyRoles { get; set; }
        public virtual DbSet<ServiceTargetGroupEntity> TargetGroups { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<EmployeeStatusEntity> EmployeeStatuses { get; set; }
        public virtual DbSet<WeekDayEntity> DaysOfWeek { get; set; }
        public virtual DbSet<WeekDayWorkSchedule> WeekDayWorkSchedules { get; set; }
        public virtual DbSet<ColourEntity> Colours { get; set; }
        public virtual DbSet<BookingStateEntity> BookingStates { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        private static readonly ILoggerFactory SqlQueriesLoggerFactory = LoggerFactory.Create(builder => builder
                .AddFilter((category, lvl) => category == DbLoggerCategory.Database.Command.Name && 
                                              (lvl == LogLevel.Information || lvl == LogLevel.Warning))
                .AddProvider(new LoggerProvider()));
        
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLoggerFactory(SqlQueriesLoggerFactory);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<User>();
            builder.Ignore<Address>();
            
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            SetEnumEntityBaseProperties<CompanyType, CompanyTypeEntity>(builder);
            SetEnumEntityBaseProperties<BusinessType, BusinessTypeEntity>(builder);
            SetEnumEntityBaseProperties<BusinessArea, BusinessAreaEntity>(builder);
            SetEnumEntityBaseProperties<Gender, GenderEntity>(builder);
            SetEnumEntityBaseProperties<ClientCategory, ClientCategoryEntity>(builder);
            SetEnumEntityBaseProperties<EmployeesSize, EmployeesSizeEntity>(builder);
            SetEnumEntityBaseProperties<Policy, PolicyEntity>(builder);
            SetEnumEntityBaseProperties<SystemRole, SystemRoleEntity>(builder);
            SetEnumEntityBaseProperties<ServiceTargetGroup, ServiceTargetGroupEntity>(builder);
            SetEnumEntityBaseProperties<EmployeeStatus, EmployeeStatusEntity>(builder);
            SetEnumEntityBaseProperties<WeekDay, WeekDayEntity>(builder);
            SetEnumEntityBaseProperties<Colour, ColourEntity>(builder);
            SetEnumEntityBaseProperties<BookingState, BookingStateEntity>(builder);

            SetEntityLookupProperty<Company, CompanyType, CompanyTypeEntity>(builder, c => c.CompanyType);
            SetEntityLookupProperty<Company, BusinessType, BusinessTypeEntity>(builder, x => x.BusinessType);
            SetEntityLookupProperty<Company, EmployeesSize, EmployeesSizeEntity>(builder, x => x.EmployeesSize);
            SetEntityLookupProperty<CompanyBusinessArea, BusinessArea, BusinessAreaEntity>(builder, x => x.BusinessArea);
            SetEntityLookupProperty<Client, ClientCategory, ClientCategoryEntity>(builder, x => x.ClientCategory);
            SetEntityNullableLookupProperty<Client, Gender, GenderEntity>(builder, x => x.Gender);
            SetEntityLookupProperty<WeekDayWorkSchedule, WeekDay, WeekDayEntity>(builder, x => x.DayOfWeek);
            SetIdentityEntityNullableLookupProperty<User, Gender, GenderEntity>(builder, x => x.Gender);
            SetIdentityEntityLookupProperty<User, SystemRole, SystemRoleEntity>(builder, x => x.SystemRole);
            SetEntityLookupProperty<PolicyRole, Policy, PolicyEntity>(builder, x => x.Policy);
            SetEntityLookupProperty<PolicyRole, SystemRole, SystemRoleEntity>(builder, x => x.Role);
            SetEntityLookupProperty<Category, BusinessArea, BusinessAreaEntity>(builder, x => x.BusinessArea);
            SetEntityLookupProperty<Category, ServiceTargetGroup, ServiceTargetGroupEntity>(builder, x => x.ServiceTargetGroup);
            SetIdentityEntityLookupProperty<User, EmployeeStatus, EmployeeStatusEntity>(builder, x => x.EmployeeStatus);
            SetEntityNullableLookupProperty<Booking, Colour, ColourEntity>(builder, x => x.Colour);
            SetEntityLookupProperty<Booking, BookingState, BookingStateEntity>(builder, x => x.State);
            
            EnsureEnumEntitiesHaveData(builder);
            SetSchemaForIdentityTables(builder);
        }

        private static void SetEntityLookupProperty<TEntity, TEnum, TEnumEntity>(
            ModelBuilder builder, 
            Expression<Func<TEntity, TEnum>> propertyExpression, 
            bool usePropertyName = false)
            where TEntity : Entity
            where TEnum : struct, Enum
            where TEnumEntity : EnumEntity<TEnum>
        {
            var property = propertyExpression.GetPropertyAccess();
            var columnName = (usePropertyName ? property.Name : property.PropertyType.Name) + nameof(Entity.Id);

            builder.Entity<TEntity>().Property(propertyExpression)
                .HasConversion<long>()
                .HasColumnName(columnName)
                .IsRequired();

            builder.Entity<TEntity>().HasOne(typeof(TEnumEntity))
                .WithMany()
                .HasForeignKey(property.Name)
                .IsRequired();
        }
        
        private static void SetEntityNullableLookupProperty<TEntity, TEnum, TEnumEntity>(
            ModelBuilder builder, 
            Expression<Func<TEntity, TEnum?>> propertyExpression)
            where TEntity : Entity
            where TEnum : struct, Enum
            where TEnumEntity : EnumEntity<TEnum>
        {
            var property = propertyExpression.GetPropertyAccess();

            builder.Entity<TEntity>().Property(propertyExpression)
                .HasConversion<long?>()
                .HasColumnName(property.PropertyType.GenericTypeArguments[0].Name + nameof(Entity.Id));

            builder.Entity<TEntity>().HasOne(typeof(TEnumEntity))
                .WithMany()
                .HasForeignKey(property.Name);
        }
        
        private static void SetIdentityEntityNullableLookupProperty<TEntity, TEnum, TEnumEntity>(
            ModelBuilder builder, 
            Expression<Func<TEntity, TEnum?>> propertyExpression)
            where TEntity : User
            where TEnum : struct, Enum
            where TEnumEntity : EnumEntity<TEnum>
        {
            var property = propertyExpression.GetPropertyAccess();

            builder.Entity<TEntity>().Property(propertyExpression)
                .HasConversion<long?>()
                .HasColumnName(property.PropertyType.GenericTypeArguments[0].Name + nameof(User.Id));

            builder.Entity<TEntity>().HasOne(typeof(TEnumEntity))
                .WithMany()
                .HasForeignKey(property.Name);
        }

        private static void SetIdentityEntityLookupProperty<TEntity, TEnum, TEnumEntity>(
            ModelBuilder builder,
            Expression<Func<TEntity, TEnum>> propertyExpression,
            bool usePropertyName = false)
            where TEntity : User
            where TEnum : struct, Enum
            where TEnumEntity : EnumEntity<TEnum>
        {
            var property = propertyExpression.GetPropertyAccess();
            var columnName = (usePropertyName ? property.Name : property.PropertyType.Name) + nameof(User.Id);

            builder.Entity<TEntity>().Property(propertyExpression)
                .HasConversion<long>()
                .HasColumnName(columnName)
                .IsRequired();

            builder.Entity<TEntity>().HasOne(typeof(TEnumEntity))
                .WithMany()
                .HasForeignKey(property.Name)
                .IsRequired();
        }

        private static void SetEnumEntityBaseProperties<TEnum, TEnumEntity>(ModelBuilder builder)
            where TEnum : struct, Enum
            where TEnumEntity : EnumEntity<TEnum>
        {
            builder.Entity<TEnumEntity>().Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion<long>()
                .HasColumnName($"{typeof(TEnum).Name}{nameof(Entity.Id)}");

            builder.Entity<TEnumEntity>().HasKey(entity => entity.Id);
            builder.Entity<TEnumEntity>().Property(entity => entity.Name).IsRequired().HasMaxLength(MaxLengthOfNamesGeneral);
        }
        
        static void SetDefaultDeleteBehavior(ModelBuilder builder, DeleteBehavior deleteBehavior)
        {
            var foreignKeys = builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())
                .Where(k => !k.IsOwnership);

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = deleteBehavior;
            }
        }

        private static void EnsureEnumEntitiesHaveData(ModelBuilder builder)
        {
            var types = Assembly.GetAssembly(typeof(Entity))!.ExportedTypes;
            var enumEntityFactoryTypes = types.Where(type =>
                !type.IsAbstract && type.BaseType!.IsConstructedGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(EnumEntityFactory<,>));

            foreach (var enumEntityFactoryType in enumEntityFactoryTypes)
            {
                var enumType = enumEntityFactoryType.BaseType!.GenericTypeArguments.Single(p => p.BaseType == typeof(Enum));
                var enumEntityFactory = enumEntityFactoryType.GetProperty("Instance")!.GetValue(null, null);

                if (enumEntityFactoryType.GetProperty("Entities")!.GetValue(enumEntityFactory) is IEnumerable<object> entities)
                {
                    var entityType = enumEntityFactoryType.BaseType.GenericTypeArguments
                        .Single(p => p.BaseType == typeof(EnumEntity<>).MakeGenericType(enumType));
                    builder.Entity(entityType).HasData(entities.ToArray());
                }
            }
        }
        
        private static void SetSchemaForIdentityTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Roles", AuthSchema);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", AuthSchema);
            modelBuilder.Entity<User>().ToTable("Users", AuthSchema);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", AuthSchema);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", AuthSchema);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", AuthSchema);
            modelBuilder.Entity<UserToken>().ToTable("UserTokens", AuthSchema);
        }
    }
}