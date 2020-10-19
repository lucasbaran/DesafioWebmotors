using DesafioWebmotors.Domain.Entities;
using System.Collections.Generic;

namespace DesafioWebmotors.Models
{
    public class AnuncioIndexViewModel
    {
        public AnuncioIndexViewModel()
        {
            AnuncioWebmotors = new List<AnuncioWebmotors>();
        }

        public IEnumerable<AnuncioWebmotors> AnuncioWebmotors { get; set; }
        public IEnumerable<string> Marcas { get; set; }
        public IEnumerable<string> Modelos { get; set; }
        public IEnumerable<string> Versoes { get; set; }
    }
}
