using System;
using TesteProverDominio.Entidades;
using TesteProverService.Interface;
using System.Linq;

namespace TesteProverDominio
{
    public class Servicos
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly ILoginRepository _loginRepository;

        public Servicos(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Servicos(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public Servicos( ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public void SalvarContato(Contato contato)
        {
            try
            {
                //DateTime.TryParse(contato.DataNascimento, out DateTime dataNascimento);
                //contato.Idade = dataNascimento.Year - DateTime.Now.Year;
                _contatoRepository.Add(contato);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SalvarCargo(Cargo cargo)
        {
            try
            {
                _cargoRepository.Add(cargo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SalvarLogin(Login login)
        {
            try
            {
                _loginRepository.Add(login);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool LoginSistema(Login login)
        {
            try
            {
               var listaUsuario = _loginRepository.GetAll();
              var usuario =  listaUsuario.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                if (usuario != null)
                    return true;
                else
                    return false;
            
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
