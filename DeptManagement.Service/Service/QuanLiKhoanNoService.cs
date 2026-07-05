using DeptManagement.Repository.Models;
using DeptManagement.Repository.UnitOfWork;
using DeptManagement.Service.DTO;
using DeptManagement.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptManagement.Service.Service
{
    public class QuanLiKhoanNoService : QuanLiKhoanNo
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuanLiKhoanNoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<QuanLiKhoanNoDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.QuanLyKhoanNoRepository.GetAllAsync();

            return entities.Select(x => new QuanLiKhoanNoDTO
            {
                Id = x.Id,
                TenKhoanNo = x.Tenkhoanno,
                GhiChu = x.Ghichu
            }).ToList();
        }

        public async Task<UpdateQuanLiKhoanNoDTO> CreateAsync(UpdateQuanLiKhoanNoDTO dto)
        {
            var entity = new Quanlykhoanno
            {
                Tenkhoanno = dto.TenKhoanNo,
                Ghichu = dto.GhiChu
            };

            await _unitOfWork.QuanLyKhoanNoRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            dto.Id = entity.Id;

            return dto;
        }

        public async Task<UpdateQuanLiKhoanNoDTO> UpdateAsync(UpdateQuanLiKhoanNoDTO dto)
        {
            var entity = await _unitOfWork.QuanLyKhoanNoRepository.GetByIdAsync(dto.Id);

            if (entity == null)
                throw new Exception("Không tìm thấy khoản nợ.");

            entity.Tenkhoanno = dto.TenKhoanNo;
            entity.Ghichu = dto.GhiChu;

            await _unitOfWork.QuanLyKhoanNoRepository.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.QuanLyKhoanNoRepository.GetByIdAsync(id);

            if (entity == null)
                return false;

            await _unitOfWork.QuanLyKhoanNoRepository.RemoveAsync(entity);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
