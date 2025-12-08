using StepTune.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepTune.Domain.Users.ValueObjects
{
    public sealed class UserProfile : IEquatable<UserProfile>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime? BirthDate { get; }
        public string? Gender { get; }
        public double? WeightKg { get; }
        public double? HeightCm { get; }
        private UserProfile(
            string firstName,
            string lastName,
            DateTime? birthDate,
            string? gender,
            double? weightKg,
            double? heightCm
            ) 
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            WeightKg = weightKg;
            HeightCm = heightCm;
        }

        public static Result<UserProfile> Create(
            string firstName,
            string lastName,
            DateTime? birthDate =null,
            string? gender = null,
            double? weightKg = null,
            double? heightCm = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<UserProfile>("First name is required");
            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Failure<UserProfile>("Last name is required");
            var profile = new UserProfile(firstName,lastName,birthDate,gender,weightKg,heightCm);
            return Result.Success<UserProfile>(profile);
        }

        public override bool Equals(object? obj)
        {
            return obj is UserProfile other && Equals(other);
        }
        public bool Equals(UserProfile? other)
        {
            if(other is null) return false;
            return FirstName == other.FirstName &&
                LastName == other.LastName &&
                BirthDate == other.BirthDate &&
                Gender == other.Gender &&
                WeightKg == other.WeightKg;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName,LastName,BirthDate,Gender,WeightKg,HeightCm);
        }

    }
}
