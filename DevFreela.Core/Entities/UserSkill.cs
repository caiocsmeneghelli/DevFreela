using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkil)
        {
            IdUser = idUser;
            IdSkil = idSkil;
        }

        public int IdUser { get; private set; }
        public int IdSkil { get; private set; }
    }
}