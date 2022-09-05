using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descricap de projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha descricap de projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha descricap de projeto 3", 1, 1, 30000)
            };
            Users = new List<User>
            {
                new User("Luis felipe", "luisdev@luisdev.com", new DateTime(1992, 12, 15)),
                new User("Robert C Martin", "robert@luisdev.com", new DateTime(1960, 11, 11)),
                new User("Caio Cesar", "caiocs@luisdev.com", new DateTime(1982, 5, 25)),
            };
            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }
        public List<User> Users { get; set; }
    }
}