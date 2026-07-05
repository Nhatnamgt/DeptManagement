using DeptManagement.Repository.Generic_Repository;
using DeptManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Chitietkhoanvay> ChiTietKhoanVayRepository { get; }
        GenericRepository<Quanlykhoanno> QuanLyKhoanNoRepository { get; }
        GenericRepository<Quanlynaprut> QuanLyNapRutRepository { get; }
        int Save();
        Task<int> SaveAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}