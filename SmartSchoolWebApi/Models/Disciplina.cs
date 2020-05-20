﻿namespace SmartSchoolWebApi.Models
{
    public class Disciplina
    {
        public Disciplina(int id, string nome, int professorId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
        }
        public Disciplina()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        
    }
}
