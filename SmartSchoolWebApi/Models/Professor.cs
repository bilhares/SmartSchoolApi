using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebApi.Models
{
    public class Professor
    {
        public Professor()
        {

        }
        public Professor(int id, string nome, string disciplina)
        {
            Id = id;
            Nome = nome;
            Disciplina = disciplina;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Disciplina { get; set; }

    }
}
