using FondApi.Business.RunningLine.Models;

namespace FondApi.Business.RunningLine;
public interface IStructureService
{
    Task<GetStructureResponse> GetStructureAsync();
}