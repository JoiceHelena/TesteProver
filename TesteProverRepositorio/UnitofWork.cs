using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteProverRepositorio.Contexto;
using TesteProverRepositorio.Repositorio;
using TesteProverService;
using TesteProverService.Interface;

namespace TesteProverRepositorio
{
   public class UnitofWork : IUnitofWork
    {
        private TesteProverContexto _context = new TesteProverContexto();

     
        private ICargoRepository _cargoRepositorio;
        private IContatoRepository _contatoRepository;

        private ILoginRepository _loginRepository;



        private bool disposed = false;


        public object Context
        {
            get
            {
                return this._context;
            }
        }

        public TesteProverContexto Create()
        {
            return _context;
        }


    
        public ICargoRepository CargoRepository
        {
            get
            {
                if (this._cargoRepositorio == null)
                {
                    this._cargoRepositorio = new CargoRepository(_context);
                }

                return _cargoRepositorio;
            }
        }
        public IContatoRepository ContatoRepository
        {
            get
            {
                if (this._contatoRepository == null)
                {
                    this._contatoRepository = new ContatoRepository(_context);
                }

                return _contatoRepository;
            }
        }
        public ILoginRepository LoginRepository
        {
            get
            {
                if (this._loginRepository == null)
                {
                    this._loginRepository = new LoginRepository(_context);
                }

                return _loginRepository;
            }
        }
        public async void Save()
        {
             await _context.SaveChangesAsync();
        }        

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void IUnitofWork.Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }


    }
}
