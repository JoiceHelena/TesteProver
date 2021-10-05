using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteProverDominio.Entidades;
using TesteProverRepositorio.Contexto;
using TesteProverService.Interface;

namespace TesteProverRepositorio.Repositorio
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {

        internal TesteProverContexto _context;

        public BaseRepository(TesteProverContexto context)
        {
            _context = context;
        }

        public async Task<T> Add(T obj)
        {
            _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var result = new List<T>();
            try
            {
                result = _context.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = new List<T>();
            try
            {
                result = await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public async Task<T> Update(T obj)
        {

            _context.Entry(obj).State = EntityState.Modified;
            var contexto = _context.Set<T>().Find(obj.Id);

            if (!contexto.Equals(obj))
            {
                _context.Set<T>().Remove(contexto);
            }

            var resultado = await _context.SaveChangesAsync();

            return obj;

        }
    }
}
