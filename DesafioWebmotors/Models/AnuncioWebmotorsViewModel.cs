using DesafioWebmotors.Domain.Entities;
using System.Collections.Generic;

namespace DesafioWebmotors.Models
{
    public class AnuncioWebmotorsViewModel : AnuncioWebmotors
    {
        public IEnumerable<string> Marcas { get; set; }
        public IEnumerable<string> Modelos { get; set; }
        public IEnumerable<string> Versoes { get; set; }
    }
}
