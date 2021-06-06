using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Extensions
{
    internal static class EntityTypeBuilderExtensions
    {
        public static void EnumProperty<TEntity, TEnum>(this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TEnum>> func)
            where TEntity : class
            where TEnum : struct, Enum
        {
            var property = func.GetPropertyAccess();

            builder
                .Property(func)
                .HasConversion<long>()
                .HasColumnName($"{property.PropertyType.Name}Id");

            builder.HasOne(FindEnumEntityType<TEnum>())
                .WithMany()
                .HasForeignKey(property.Name)
                .IsRequired();
        }
        
        public static void EnumProperty<TEntity, TEnum>(this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TEnum?>> func)
            where TEntity : class
            where TEnum : struct, Enum
        {
            var property = func.GetPropertyAccess();

            builder
                .Property(func)
                .HasConversion<long?>()
                .HasColumnName($"{property.PropertyType.GenericTypeArguments[0].Name}Id");

            builder.HasOne(FindEnumEntityType<TEnum>())
                .WithMany()
                .HasForeignKey(property.Name);
        }
        
        private static Type FindEnumEntityType<TEnum>() where TEnum : struct, Enum =>
            Assembly.GetAssembly(typeof(TEnum))
                ?.GetExportedTypes()
                .Single(type => typeof(EnumEntity<TEnum>).IsAssignableFrom(type));
        
    }
}