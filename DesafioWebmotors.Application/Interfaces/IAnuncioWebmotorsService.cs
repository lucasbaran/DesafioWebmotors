using DesafioWebmotors.Application.Models;
using DesafioWebmotors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioWebmotors.Application.Interfaces
{
    public interface IAnuncioWebmotorsService
    {
        Task AddAsync(AnuncioWebmotors obj);
        void Update(AnuncioWebmotors obj);
        void Remove(AnuncioWebmotors obj);
        Task<IEnumerable<AnuncioWebmotors>> GetAsync();
        Task<AnuncioWebmotors> GetAsync(int id);
        Task<IEnumerable<AnuncioWebmotors>> GetAsync(AnuncioFilter filter);
        Task<IEnumerable<Base>> GetMakes();
        Task<IEnumerable<Model>> GetModels(int makeId);
        Task<IEnumerable<Models.Version>> GetVersions(int modelId);
        Task<int> GetMakeId(string make);
        Task<int> GetModelId(string make, string model);
    }
}
