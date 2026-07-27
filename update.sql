-- ==========================================
-- THÊM CỘT GHI CHÚ (NẾU CHƯA TỒN TẠI)
-- ==========================================

ALTER TABLE QuanLyNapRut
ADD COLUMN IF NOT EXISTS GhiChu TEXT;

ALTER TABLE ChiTietKhoanVay
ADD COLUMN IF NOT EXISTS GhiChu TEXT;