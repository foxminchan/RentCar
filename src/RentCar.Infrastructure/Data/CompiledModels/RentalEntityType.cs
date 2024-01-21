﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using RentCar.Core.Entities;
using RentCar.Core.Enums;
using RentCar.Core.Identity;

#pragma warning disable 219, 612, 618
#nullable disable

namespace RentCar.Infrastructure.Data.CompiledModels
{
    internal partial class RentalEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "RentCar.Core.Entities.Rental",
                typeof(Rental),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(Guid),
                propertyInfo: typeof(EntityBase<Guid>).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(EntityBase<Guid>).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: new Guid("00000000-0000-0000-0000-000000000000"));
            id.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                keyComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            id.AddAnnotation("Relational:ColumnName", "id");

            var endDate = runtimeEntityType.AddProperty(
                "EndDate",
                typeof(DateTime?),
                propertyInfo: typeof(Rental).GetProperty("EndDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<EndDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            endDate.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                keyComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                providerValueComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)));
            endDate.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            endDate.AddAnnotation("Relational:ColumnName", "end_date");

            var paymentId = runtimeEntityType.AddProperty(
                "PaymentId",
                typeof(Guid?),
                propertyInfo: typeof(Rental).GetProperty("PaymentId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<PaymentId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            paymentId.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<Guid?>(
                    (Nullable<Guid> v1, Nullable<Guid> v2) => v1.HasValue && v2.HasValue && (Guid)v1 == (Guid)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<Guid> v) => v.HasValue ? ((Guid)v).GetHashCode() : 0,
                    (Nullable<Guid> v) => v.HasValue ? (Nullable<Guid>)(Guid)v : default(Nullable<Guid>)),
                keyComparer: new ValueComparer<Guid?>(
                    (Nullable<Guid> v1, Nullable<Guid> v2) => v1.HasValue && v2.HasValue && (Guid)v1 == (Guid)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<Guid> v) => v.HasValue ? ((Guid)v).GetHashCode() : 0,
                    (Nullable<Guid> v) => v.HasValue ? (Nullable<Guid>)(Guid)v : default(Nullable<Guid>)),
                providerValueComparer: new ValueComparer<Guid?>(
                    (Nullable<Guid> v1, Nullable<Guid> v2) => v1.HasValue && v2.HasValue && (Guid)v1 == (Guid)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<Guid> v) => v.HasValue ? ((Guid)v).GetHashCode() : 0,
                    (Nullable<Guid> v) => v.HasValue ? (Nullable<Guid>)(Guid)v : default(Nullable<Guid>)),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"));
            paymentId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            paymentId.AddAnnotation("Relational:ColumnName", "payment_id");

            var startDate = runtimeEntityType.AddProperty(
                "StartDate",
                typeof(DateTime?),
                propertyInfo: typeof(Rental).GetProperty("StartDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<StartDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            startDate.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                keyComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                providerValueComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)));
            startDate.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            startDate.AddAnnotation("Relational:ColumnName", "start_date");

            var status = runtimeEntityType.AddProperty(
                "Status",
                typeof(RentStatus?),
                propertyInfo: typeof(Rental).GetProperty("Status", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<Status>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            status.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<RentStatus?>(
                    (Nullable<RentStatus> v1, Nullable<RentStatus> v2) => v1.HasValue && v2.HasValue && object.Equals((object)(RentStatus)v1, (object)(RentStatus)v2) || !v1.HasValue && !v2.HasValue,
                    (Nullable<RentStatus> v) => v.HasValue ? ((RentStatus)v).GetHashCode() : 0,
                    (Nullable<RentStatus> v) => v.HasValue ? (Nullable<RentStatus>)(RentStatus)v : default(Nullable<RentStatus>)),
                keyComparer: new ValueComparer<RentStatus?>(
                    (Nullable<RentStatus> v1, Nullable<RentStatus> v2) => v1.HasValue && v2.HasValue && object.Equals((object)(RentStatus)v1, (object)(RentStatus)v2) || !v1.HasValue && !v2.HasValue,
                    (Nullable<RentStatus> v) => v.HasValue ? ((RentStatus)v).GetHashCode() : 0,
                    (Nullable<RentStatus> v) => v.HasValue ? (Nullable<RentStatus>)(RentStatus)v : default(Nullable<RentStatus>)),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "integer"),
                converter: new ValueConverter<RentStatus, int>(
                    (RentStatus value) => (int)value,
                    (int value) => (RentStatus)value),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<RentStatus, int>(
                    JsonInt32ReaderWriter.Instance,
                    new ValueConverter<RentStatus, int>(
                        (RentStatus value) => (int)value,
                        (int value) => (RentStatus)value)));
            status.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            status.AddAnnotation("Relational:ColumnName", "status");

            var totalPrice = runtimeEntityType.AddProperty(
                "TotalPrice",
                typeof(decimal?),
                propertyInfo: typeof(Rental).GetProperty("TotalPrice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<TotalPrice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            totalPrice.TypeMapping = NpgsqlDecimalTypeMapping.Default.Clone(
                comparer: new ValueComparer<decimal?>(
                    (Nullable<decimal> v1, Nullable<decimal> v2) => v1.HasValue && v2.HasValue && (decimal)v1 == (decimal)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<decimal> v) => v.HasValue ? ((decimal)v).GetHashCode() : 0,
                    (Nullable<decimal> v) => v.HasValue ? (Nullable<decimal>)(decimal)v : default(Nullable<decimal>)),
                keyComparer: new ValueComparer<decimal?>(
                    (Nullable<decimal> v1, Nullable<decimal> v2) => v1.HasValue && v2.HasValue && (decimal)v1 == (decimal)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<decimal> v) => v.HasValue ? ((decimal)v).GetHashCode() : 0,
                    (Nullable<decimal> v) => v.HasValue ? (Nullable<decimal>)(decimal)v : default(Nullable<decimal>)),
                providerValueComparer: new ValueComparer<decimal?>(
                    (Nullable<decimal> v1, Nullable<decimal> v2) => v1.HasValue && v2.HasValue && (decimal)v1 == (decimal)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<decimal> v) => v.HasValue ? ((decimal)v).GetHashCode() : 0,
                    (Nullable<decimal> v) => v.HasValue ? (Nullable<decimal>)(decimal)v : default(Nullable<decimal>)));
            totalPrice.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            totalPrice.AddAnnotation("Relational:ColumnName", "total_price");

            var userId = runtimeEntityType.AddProperty(
                "UserId",
                typeof(string),
                propertyInfo: typeof(Rental).GetProperty("UserId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<UserId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);
            userId.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "character varying(50)",
                    size: 50));
            userId.TypeMapping = ((NpgsqlStringTypeMapping)userId.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
        userId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        userId.AddAnnotation("Relational:ColumnName", "user_id");

        var vehicleId = runtimeEntityType.AddProperty(
            "VehicleId",
            typeof(Guid?),
            propertyInfo: typeof(Rental).GetProperty("VehicleId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Rental).GetField("<VehicleId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true);
        vehicleId.TypeMapping = GuidTypeMapping.Default.Clone(
            comparer: new ValueComparer<Guid?>(
                (Nullable<Guid> v1, Nullable<Guid> v2) => v1.HasValue && v2.HasValue && (Guid)v1 == (Guid)v2 || !v1.HasValue && !v2.HasValue,
                (Nullable<Guid> v) => v.HasValue ? ((Guid)v).GetHashCode() : 0,
                (Nullable<Guid> v) => v.HasValue ? (Nullable<Guid>)(Guid)v : default(Nullable<Guid>)),
            keyComparer: new ValueComparer<Guid?>(
                (Nullable<Guid> v1, Nullable<Guid> v2) => v1.HasValue && v2.HasValue && (Guid)v1 == (Guid)v2 || !v1.HasValue && !v2.HasValue,
                (Nullable<Guid> v) => v.HasValue ? ((Guid)v).GetHashCode() : 0,
                (Nullable<Guid> v) => v.HasValue ? (Nullable<Guid>)(Guid)v : default(Nullable<Guid>)),
            providerValueComparer: new ValueComparer<Guid?>(
                (Nullable<Guid> v1, Nullable<Guid> v2) => v1.HasValue && v2.HasValue && (Guid)v1 == (Guid)v2 || !v1.HasValue && !v2.HasValue,
                (Nullable<Guid> v) => v.HasValue ? ((Guid)v).GetHashCode() : 0,
                (Nullable<Guid> v) => v.HasValue ? (Nullable<Guid>)(Guid)v : default(Nullable<Guid>)),
            mappingInfo: new RelationalTypeMappingInfo(
                storeTypeName: "uuid"));
        vehicleId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        vehicleId.AddAnnotation("Relational:ColumnName", "vehicle_id");

        var key = runtimeEntityType.AddKey(
            new[] { id });
        runtimeEntityType.SetPrimaryKey(key);
        key.AddAnnotation("Relational:Name", "pk_rentals");

        var index = runtimeEntityType.AddIndex(
            new[] { paymentId });
        index.AddAnnotation("Relational:Name", "ix_rentals_payment_id");

        var index0 = runtimeEntityType.AddIndex(
            new[] { userId });
        index0.AddAnnotation("Relational:Name", "ix_rentals_user_id");

        var index1 = runtimeEntityType.AddIndex(
            new[] { vehicleId });
        index1.AddAnnotation("Relational:Name", "ix_rentals_vehicle_id");

        return runtimeEntityType;
    }

    public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
    {
        var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("PaymentId") },
            principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
            principalEntityType,
            deleteBehavior: DeleteBehavior.SetNull);

        var payment = declaringEntityType.AddNavigation("Payment",
            runtimeForeignKey,
            onDependent: true,
            typeof(Payment),
            propertyInfo: typeof(Rental).GetProperty("Payment", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Rental).GetField("<Payment>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        var rentals = principalEntityType.AddNavigation("Rentals",
            runtimeForeignKey,
            onDependent: false,
            typeof(ICollection<Rental>),
            propertyInfo: typeof(Payment).GetProperty("Rentals", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Payment).GetField("<Rentals>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        runtimeForeignKey.AddAnnotation("Relational:Name", "fk_rentals_payments_payment_id");
        return runtimeForeignKey;
    }

    public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
    {
        var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("UserId") },
            principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
            principalEntityType,
            deleteBehavior: DeleteBehavior.SetNull);

        var user = declaringEntityType.AddNavigation("User",
            runtimeForeignKey,
            onDependent: true,
            typeof(ApplicationUser),
            propertyInfo: typeof(Rental).GetProperty("User", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Rental).GetField("<User>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        var rentals = principalEntityType.AddNavigation("Rentals",
            runtimeForeignKey,
            onDependent: false,
            typeof(ICollection<Rental>),
            propertyInfo: typeof(ApplicationUser).GetProperty("Rentals", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(ApplicationUser).GetField("<Rentals>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        runtimeForeignKey.AddAnnotation("Relational:Name", "fk_rentals_users_user_id");
        return runtimeForeignKey;
    }

    public static RuntimeForeignKey CreateForeignKey3(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
    {
        var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("VehicleId") },
            principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
            principalEntityType,
            deleteBehavior: DeleteBehavior.SetNull);

        var vehicle = declaringEntityType.AddNavigation("Vehicle",
            runtimeForeignKey,
            onDependent: true,
            typeof(Vehicle),
            propertyInfo: typeof(Rental).GetProperty("Vehicle", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Rental).GetField("<Vehicle>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        var rentals = principalEntityType.AddNavigation("Rentals",
            runtimeForeignKey,
            onDependent: false,
            typeof(ICollection<Rental>),
            propertyInfo: typeof(Vehicle).GetProperty("Rentals", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Vehicle).GetField("<Rentals>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        runtimeForeignKey.AddAnnotation("Relational:Name", "fk_rentals_vehicles_vehicle_id");
        return runtimeForeignKey;
    }

    public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
    {
        runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
        runtimeEntityType.AddAnnotation("Relational:Schema", null);
        runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
        runtimeEntityType.AddAnnotation("Relational:TableName", "rentals");
        runtimeEntityType.AddAnnotation("Relational:ViewName", null);
        runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

        Customize(runtimeEntityType);
    }

    static partial void Customize(RuntimeEntityType runtimeEntityType);
}
}
