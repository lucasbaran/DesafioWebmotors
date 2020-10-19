using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesafioWebmotors.Models;
using DesafioWebmotors.Application.Interfaces;
using DesafioWebmotors.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using DesafioWebmotors.Application.Models;

namespace DesafioWebmotors.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnuncioWebmotorsService _anuncioWebmotorsService;

        public HomeController(IAnuncioWebmotorsService anuncioWebmotorsService)
        {
            _anuncioWebmotorsService = anuncioWebmotorsService;
        }

        public async Task<IActionResult> Index(AnuncioFilter filter)
        {
            var anuncios = await _anuncioWebmotorsService.GetAsync(filter);

            var makes = await _anuncioWebmotorsService.GetMakes();

            var model = new AnuncioIndexViewModel
            {
                AnuncioWebmotors = anuncios,
                Marcas = makes.Select(x => x.Name),
                Modelos = new List<string>(),
                Versoes = new List<string>()
            };

            return View(model);
        }

        public async Task<IActionResult> Cadastrar()
        {
            var model = await CarregarInformacoes(new AnuncioWebmotors());
            return View("Editar", model);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var entity = await _anuncioWebmotorsService.GetAsync(id);
            if (entity is null)
                return BadRequest();

            var model = await CarregarInformacoes(entity);
            return View(model);
        }

        public async Task<JsonResult> Deletar(int id)
        {
            var entity = await _anuncioWebmotorsService.GetAsync(id);
            if (entity is null)
                return Json("Anuncio não encontrado");

            _anuncioWebmotorsService.Remove(entity);

            return Json("Anuncio excluído com sucesso");
        }

        public async Task<IActionResult> Gravar(AnuncioWebmotorsViewModel viewModel)
        {
            if (viewModel.ID > 0)
                _anuncioWebmotorsService.Update(viewModel);
            else
                await _anuncioWebmotorsService.AddAsync(viewModel);
            
            return RedirectToAction("Index");
        }

        private async Task<AnuncioWebmotorsViewModel> CarregarInformacoes(AnuncioWebmotors model)
        {
            var makes = await _anuncioWebmotorsService.GetMakes();
            return new AnuncioWebmotorsViewModel()
            {
                ID = model.ID,
                Ano = model.Ano,
                Marca = model.Marca ?? string.Empty,
                Modelo = model.Modelo ?? string.Empty,
                Versao = model.Versao ?? string.Empty,
                Quilometragem = model.Quilometragem,
                Observacao = model.Observacao,
                Marcas = makes.Select(x => x.Name),
                Modelos = new List<string>(),
                Versoes = new List<string>()
            };
        }

        public async Task<JsonResult> GetModels(string make)
        {
            if (string.IsNullOrEmpty(make))
                return Json(new List<string>());

            var makeId = await _anuncioWebmotorsService.GetMakeId(make);
            var models = await _anuncioWebmotorsService.GetModels(makeId);
            return Json(models);
        }

        public async Task<JsonResult> GetVersions(string make, string model)
        {
            if (string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model))
                return Json(new List<string>());

            var modelId = await _anuncioWebmotorsService.GetModelId(make, model);
            var versions = await _anuncioWebmotorsService.GetVersions(modelId);
            return Json(versions);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
