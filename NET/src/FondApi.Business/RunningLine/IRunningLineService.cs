using FondApi.Business.RunningLine.Models;

namespace FondApi.Business.RunningLine;
public interface IRunningLineService
{
    Task<GetRunnungLineResponse> GetRunnungLineAsync();
}