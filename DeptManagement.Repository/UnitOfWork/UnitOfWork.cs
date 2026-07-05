using DeptManagement.Repository.Generic_Repository;
using DeptManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private GenericRepository<Chitietkhoanvay> _khoanvayRepository = null!;
        private GenericRepository<Quanlykhoanno> _khoannoRepository = null!;
        private GenericRepository<Quanlynaprut> _naprutRepository = null!;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Chitietkhoanvay> ChiTietKhoanVayRepository => _khoanvayRepository ??= new GenericRepository<Chitietkhoanvay>(_context);
        public GenericRepository<Quanlykhoanno> QuanLyKhoanNoRepository => _khoannoRepository ??= new GenericRepository<Quanlykhoanno>(_context);
        public GenericRepository<Quanlynaprut> QuanLyNapRutRepository => _naprutRepository ??= new GenericRepository<Quanlynaprut>(_context);

        public int Save() => _context.SaveChanges();

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        // IDisposable
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
