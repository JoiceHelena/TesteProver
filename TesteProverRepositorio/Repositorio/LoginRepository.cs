using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteProverDominio.Entidades;
using TesteProverRepositorio.Contexto;
using TesteProverService.Interface;

namespace TesteProverRepositorio.Repositorio
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(TesteProverContexto context) : base(context)
        {
        }
    }
}
