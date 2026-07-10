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
    public class ChiTietKhoanVayService : ChiTietKhoanVays
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChiTietKhoanVayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TongKhoanVayDTO> GetTongTienByKhoanNoIdAsync(int khoanNoId)
        {
            var entities = await _unitOfWork.ChiTietKhoanVayRepository.FindAsync(x => x.Khoannoid == khoanNoId);

            return new TongKhoanVayDTO
            {
                TongTienVay = entities.Sum(x => x.Sotienvay),
                TongTienLai = entities.Sum(x => x.Sotienlai),
                TongTienPhaiTra = entities.Sum(x => x.Tongtien ?? 0)
            };
        }
        public async Task<List<ChiTietKhoanVayDTO>> GetByKhoanNoIdAsync(int khoanNoId)
        {
            var entities = await _unitOfWork.ChiTietKhoanVayRepository.FindAsync(x => x.Khoannoid == khoanNoId);

            return entities.Select(x => new ChiTietKhoanVayDTO
            {
                Id = x.Id,
                KhoanNoId = x.Khoannoid,
                NgayVay = x.Ngayvay,
                SoTienVay = x.Sotienvay,
                SoTienLai = x.Sotienlai,
                SoTienTraMoiThang = x.Sotientramoiky,
                NgayDenHan = x.Songaytra,
                TongTien = x.Tongtien
            }).ToList();
        }

        public async Task<List<ChiTietKhoanVayDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.ChiTietKhoanVayRepository.GetAllAsync();

            return entities.Select(x => new ChiTietKhoanVayDTO
            {
                Id = x.Id,
                KhoanNoId = x.Khoannoid,
                NgayVay = x.Ngayvay,
                SoTienVay = x.Sotienvay,
                SoTienLai = x.Sotienlai,
                SoTienTraMoiThang = x.Sotientramoiky,
                NgayDenHan = x.Songaytra,
                TongTien = x.Tongtien
            }).ToList();
        }

        public async Task<ChiTietKhoanVayDTO> CreateAsync(ChiTietKhoanVayDTO dto)
        {
            var entity = new Chitietkhoanvay
            {
                Khoannoid = dto.KhoanNoId,
                Ngayvay = dto.NgayVay,
                Sotienvay = dto.SoTienVay,
                Sotienlai = dto.SoTienLai,
                Sotientramoiky = dto.SoTienTraMoiThang,
                Songaytra = dto.NgayDenHan
            };

            await _unitOfWork.ChiTietKhoanVayRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            dto.Id = entity.Id;
            dto.TongTien = entity.Tongtien;

            return dto;
        }

        public async Task<ChiTietKhoanVayDTO> UpdateAsync(ChiTietKhoanVayDTO dto)
        {
            var entity = await _unitOfWork.ChiTietKhoanVayRepository.GetByIdAsync(dto.Id);

            if (entity == null)
                throw new Exception("Không tìm thấy khoản vay.");

            entity.Khoannoid = dto.KhoanNoId;
            entity.Ngayvay = dto.NgayVay;
            entity.Sotienvay = dto.SoTienVay;
            entity.Sotienlai = dto.SoTienLai;
            entity.Sotientramoiky = dto.SoTienTraMoiThang;
            entity.Songaytra = dto.NgayDenHan;  

            await _unitOfWork.ChiTietKhoanVayRepository.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();

            dto.TongTien = entity.Tongtien;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ChiTietKhoanVayRepository.GetByIdAsync(id);

            if (entity == null)
                return false;

            await _unitOfWork.ChiTietKhoanVayRepository.RemoveAsync(entity);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
