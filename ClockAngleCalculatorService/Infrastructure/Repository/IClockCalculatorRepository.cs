using System.Threading.Tasks;

namespace SampleService.Infrastructure.Repository
{
    public interface IClockCalculatorRepository
    {
        Task<double> CalculateClockAngleAsync(double hr, double min);
        Task<bool> SaveClockAngleAsync(double hr, double min, double value);
    }
}