using System;

namespace TesteProverService.Interface
{
    public interface IUnitofWork : IDisposable
    {
        void Dispose(bool disposing);
        ICargoRepository CargoRepository { get; }
        IContatoRepository ContatoRepository { get; }
        ILoginRepository LoginRepository { get; }
        void Save();
    }
}
