using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_EFCore_CodeFirst.Models
{

    public class Categoria
    {
        protected Categoria() => Livros = new List<Livro>();

        public int ID { get; set; }
        public string? Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }

        public Categoria(int id, string nome) : this()
        {
            ID = id;
            Nome = nome;
        }
    }
}