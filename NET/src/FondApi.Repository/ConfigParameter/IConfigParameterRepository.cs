using FondApi.Repository.ConfigParameter.Models;

namespace FondApi.Repository.ConfigParameter;
public interface IConfigParameterRepository
{
    Task<IEnumerable<ConfigParameterDb>> GetByKeysAsync();
}