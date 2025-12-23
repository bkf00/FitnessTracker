using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Infrastructure.Models;

namespace FitnessTracker.Infrastructure.Context;

public partial class FitnessDbContext : DbContext
{
    public FitnessDbContext()
    {
    }

    public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<FoodLog> FoodLogs { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<GoalType> GoalTypes { get; set; }

    public virtual DbSet<MeasurementLog> MeasurementLogs { get; set; }

    public virtual DbSet<MuscleGroup> MuscleGroups { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }

   /* keeping this for future reasons -  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FitnessDB;Trusted_Connection=True;TrustServerCertificate=True");
   */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DifficultyLevel>(entity =>
        {
            entity.HasKey(e => e.Value).HasName("PK__Difficul__07D9BBC340417BD7");

            entity.ToTable("DifficultyLevel");

            entity.Property(e => e.Value)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToTable("Exercise", tb => tb.HasTrigger("trg_Exercise_PreventDelete"));

            entity.HasIndex(e => e.Name, "UQ_Exercise_Name").IsUnique();

            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MuscleGroup)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.DifficultyLevelNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.DifficultyLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exercise_DifficultyLevel");

            entity.HasOne(d => d.MuscleGroupNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.MuscleGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exercise_MuscleGroup");
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.ToTable("FoodItem");

            entity.HasIndex(e => e.Name, "UQ_FoodItem_Name").IsUnique();

            entity.Property(e => e.Carbs).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Fat).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Protein).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<FoodLog>(entity =>
        {
            entity.ToTable("FoodLog", tb => tb.HasTrigger("trg_FoodLog_RegistrationDate"));

            entity.Property(e => e.Quantity).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Servings).HasColumnType("decimal(7, 2)");

            entity.HasOne(d => d.FoodItem).WithMany(p => p.FoodLogs)
                .HasForeignKey(d => d.FoodItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodLog_FoodItem");

            entity.HasOne(d => d.User).WithMany(p => p.FoodLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodLog_User");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Value).HasName("PK__Gender__07D9BBC385853FE6");

            entity.ToTable("Gender");

            entity.Property(e => e.Value)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.ToTable("Goal", tb =>
                {
                    tb.HasTrigger("trg_Goal_NoOverlap");
                    tb.HasTrigger("trg_Goal_WeightLogic");
                });

            entity.Property(e => e.GoalType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TargetValue).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.GoalTypeNavigation).WithMany(p => p.Goals)
                .HasForeignKey(d => d.GoalType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goal_GoalType");

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goal_User");
        });

        modelBuilder.Entity<GoalType>(entity =>
        {
            entity.HasKey(e => e.Value).HasName("PK__GoalType__07D9BBC3D890AA50");

            entity.ToTable("GoalType");

            entity.Property(e => e.Value)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MeasurementLog>(entity =>
        {
            entity.ToTable("MeasurementLog", tb => tb.HasTrigger("trg_Measurement_WeightDelta"));

            entity.Property(e => e.ArmCircumference).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.BodyFatPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ChestCircumference).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.WaistCircumference).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Weight).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.MeasurementLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MeasurementLog_User");
        });

        modelBuilder.Entity<MuscleGroup>(entity =>
        {
            entity.HasKey(e => e.Value).HasName("PK__MuscleGr__07D9BBC3C42324DF");

            entity.ToTable("MuscleGroup");

            entity.Property(e => e.Value)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07456E3B43");

            entity.ToTable("User", tb => tb.HasTrigger("trg_User_Age_Min13"));

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534A800E915").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(CONVERT([date],getdate()))");
            entity.Property(e => e.Weight).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Gender");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.ToTable("Workout", tb => tb.HasTrigger("trg_Workout_RegistrationDate"));

            entity.HasIndex(e => new { e.UserId, e.StartAt }, "UX_Workout_User_StartAt").IsUnique();

            entity.Property(e => e.StartAt).HasPrecision(0);
            entity.Property(e => e.StartAtMinute)
                .HasComputedColumnSql("(dateadd(minute,datediff(minute,'20000101',[StartAt]),'20000101'))", false)
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Workout_User");
        });

        modelBuilder.Entity<WorkoutExercise>(entity =>
        {
            entity.ToTable("WorkoutExercise");

            entity.Property(e => e.WeightUsed).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Exercise).WithMany(p => p.WorkoutExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutExercise_Exercise");

            entity.HasOne(d => d.Workout).WithMany(p => p.WorkoutExercises)
                .HasForeignKey(d => d.WorkoutId)
                .HasConstraintName("FK_WorkoutExercise_Workout");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
