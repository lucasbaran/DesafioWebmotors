using DesafioWebmotors.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioWebmotors.Application.Interfaces
{
    public interface IExternalService
    {
        public Task<IEnumerable<Base>> GetMakesAsync();
        public Task<IEnumerable<Model>> GetModelsAsync(int makeId);
        public Task<IEnumerable<Version>> GetVersionsAsync(int modelId);

    }
}
