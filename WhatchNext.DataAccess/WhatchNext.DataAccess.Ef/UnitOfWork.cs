using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatchNext.DataAccess.Ef.CoreModel;

namespace WhatchNext.DataAccess.Ef
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;

        internal WhatchNextModelContainer Session { get; private set; }

        public UnitOfWork()
        {
            Session = new WhatchNextModelContainer();
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Session.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        #endregion

        public int Commit()
        {
            return Session.SaveChanges();
        }

       
    }
}
