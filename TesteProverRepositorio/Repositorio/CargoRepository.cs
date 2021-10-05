using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteProverDominio.Entidades;
using TesteProverRepositorio.Contexto;
using TesteProverService.Interface;

namespace TesteProverRepositorio.Repositorio
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(TesteProverContexto context) : base(context)
        {
        }
    }
}
