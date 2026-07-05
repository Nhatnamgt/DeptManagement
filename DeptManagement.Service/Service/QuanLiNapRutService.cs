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
    public class QuanLiNapRutService : QuanLiNapRut
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuanLiNapRutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetQuanLiNapRutDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.QuanLyNapRutRepository.GetAllAsync();

            return entities.Select(x => new GetQuanLiNapRutDTO
            {
                Id = x.Id,
                NgayNap = x.Ngaynap,
                SoTienNap = x.Sotiennap,
                NgayRut = x.Ngayrut,
                SoTienRut = x.Sotienrut,
                LaiLo = x.Lailo
            }).ToList();
        }

        public async Task<CreateEditQuanLiNapRutDTO> CreateAsync(CreateEditQuanLiNapRutDTO dto)
        {
            var entity = new Quanlynaprut
            {
                Ngaynap = dto.NgayNap,
                Sotiennap = dto.SoTienNap,
                Ngayrut = dto.NgayRut,
                Sotienrut = dto.SoTienRut
            };

            await _unitOfWork.QuanLyNapRutRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            dto.Id = entity.Id;
            dto.LaiLo = entity.Lailo;

            return dto;
        }

        public async Task<CreateEditQuanLiNapRutDTO> UpdateAsync(CreateEditQuanLiNapRutDTO dto)
        {
            var entity = await _unitOfWork.QuanLyNapRutRepository.GetByIdAsync(dto.Id);

            if (entity == null)
                throw new Exception("Không tìm thấy giao dịch.");

            entity.Ngaynap = dto.NgayNap;
            entity.Sotiennap = dto.SoTienNap;
            entity.Ngayrut = dto.NgayRut;
            entity.Sotienrut = dto.SoTienRut;

            await _unitOfWork.QuanLyNapRutRepository.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();

            dto.LaiLo = entity.Lailo;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.QuanLyNapRutRepository.GetByIdAsync(id);

            if (entity == null)
                return false;

            await _unitOfWork.QuanLyNapRutRepository.RemoveAsync(entity);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
