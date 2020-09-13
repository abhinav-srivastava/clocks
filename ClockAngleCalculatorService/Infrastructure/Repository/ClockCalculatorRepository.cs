using Microsoft.Extensions.Logging;
using SampleService.Infrastructure.Exceptions;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace SampleService.Infrastructure.Repository
{
    public class ClockCalculatorRepository : IClockCalculatorRepository
    {
        private readonly ILogger<ClockCalculatorRepository> _logger;
        private readonly IDatabase _database;
        private readonly SampleDbContext _context;

        public ClockCalculatorRepository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ClockCalculatorRepository>();
        }

        public async Task<double> CalculateClockAngleAsync(double hr, double min)
        {
            if (hr == 12)
            {
                hr = 0;
            }

            double hourInDegrees = (hr * 30) + (min * 30.0 / 60);
            double minuteInDegrees = min * 6;
            double angle = Math.Abs(hourInDegrees - minuteInDegrees);

            if (angle > 180)
            {
                angle = 360 - angle;
            }

            await SaveClockAngleAsync(hr, min, angle);
            return angle;
        }

        public async Task<bool> SaveClockAngleAsync(double hr, double min, double angle)
        {
            try
            {
                //Connect to an event hub and pump the message to it
                //Event hub calls async method to save data to the database. 
                await Task.FromResult(0);  //Dummy code to avoid compiler warning and show some async process.
                _logger.LogInformation("Clock Angle Saved succesfully.");
                return true;
            }
            catch (ClockCalculatorException ex)
            {
                _logger.LogInformation("Error saving Data.");
                return false;
            }
        }
    }
}
