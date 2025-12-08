using StepTune.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepTune.Domain.Users.Services
{
    public sealed class ProfileCompletionService
    {
        public int CacluateCompletion(UserProfile profile)
        {
            int score = 0;
            int total = 6;

            if (!string.IsNullOrEmpty(profile.FirstName)) score++;
            if (!string.IsNullOrEmpty(profile.LastName)) score++;
            if(profile.BirthDate != null) score++;
            if (profile.Gender != null) score++;
            if(profile.WeightKg != null) score++;
            if(profile.HeightCm != null) score++;

            return (int) Math.Round((double) score / total * 100);
                
        }

        
    }
}
