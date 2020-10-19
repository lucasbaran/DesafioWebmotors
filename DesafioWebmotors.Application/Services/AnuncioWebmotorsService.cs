using DesafioWebmotors.Application.Interfaces;
using DesafioWebmotors.Application.Models;
using DesafioWebmotors.Domain.Entities;
using DesafioWebmotors.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioWebmotors.Application.Services
{
    public class AnuncioWebmotorsService : IAnuncioWebmotorsService
    {
        private readonly IAnuncioWebmotorsRepository _repository;
        private readonly IExternalService _externalService;

        public AnuncioWebmotorsService(IAnuncioWebmotorsRepository repository, IExternalService externalService)
        {
            _repository = repository;
            _externalService = externalService;
        }

        public Task AddAsync(AnuncioWebmotors obj) => _repository.AddAsync(obj);

        public Task<IEnumerable<AnuncioWebmotors>> GetAsync() => _repository.GetAsync();

        public Task<AnuncioWebmotors> GetAsync(int id) => _repository.GetAsync(id);

        private static Expression<Func<AnuncioWebmotors, bool>> SetupWhere(AnuncioFilter filter)
        {
            return s =>
            (string.IsNullOrEmpty(filter.Marca) || s.Marca.Contains(filter.Marca)) &&
            (string.IsNullOrEmpty(filter.Modelo) || s.Modelo.Contains(filter.Modelo)) &&
            (string.IsNullOrEmpty(filter.Versao) || s.Versao.Contains(filter.Versao));
        }

        public Task<IEnumerable<AnuncioWebmotors>> GetAsync(AnuncioFilter filter)
        {
            var where = SetupWhere(filter);
            return _repository.GetAsync(where);
        }

        public void Update(AnuncioWebmotors obj) => _repository.Update(obj);

        public Task<IEnumerable<Base>> GetMakes() => _externalService.GetMakesAsync();

        public Task<IEnumerable<Model>> GetModels(int makeId) => _externalService.GetModelsAsync(makeId);

        public Task<IEnumerable<Models.Version>> GetVersions(int modelId) => _externalService.GetVersionsAsync(modelId);

        public async Task<int> GetMakeId(string make)
        {
            var makes = await GetMakes();
            return makes.Where(x => x.Name.Equals(make)).FirstOrDefault().ID; 
        }

        public async Task<int> GetModelId(string make, string model)
        {
            var makeId = await GetMakeId(make);
            var models = await GetModels(makeId);
            return models.Where(x => x.Name.Equals(model)).FirstOrDefault().ID;
        }

        public void Remove(AnuncioWebmotors obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
