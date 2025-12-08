using StepTune.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepTune.Domain.Users.Events
{
    public sealed record UserRegisteredEvent(Guid UserId):DomainEvent;
    
}
