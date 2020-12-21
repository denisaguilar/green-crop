using GreenCrop.Application.Common.Interfaces;
using System;

namespace GreenCrop.Infrastructure.Services {
    public class DateTimeService : IDateTime {
        public DateTime Now => DateTime.UtcNow;
    }
}
