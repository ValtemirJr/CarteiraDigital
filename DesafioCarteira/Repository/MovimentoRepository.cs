using DesafioCarteira.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Repository
{
    public class MovimentoRepository : IRepository<IMovimento>
    {
        private ISession _session;
        public MovimentoRepository(ISession session) => _session = session;
        public async Task Add(IMovimento item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public IEnumerable<IMovimento> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IMovimento> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(IMovimento item)
        {
            throw new NotImplementedException();
        }
    }
}
