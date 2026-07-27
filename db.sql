-- ==========================================
-- POSTGRESQL SCHEMA: QUẢN LÝ NỢ & NẠP RÚT
-- ==========================================

-- ==========================================
-- BẢNG 1: QUẢN LÝ NẠP / RÚT
-- ==========================================
CREATE TABLE QuanLyNapRut (
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    NgayNap DATE,
    SoTienNap NUMERIC(18,2) NOT NULL DEFAULT 0,

    NgayRut DATE,
    SoTienRut NUMERIC(18,2) NOT NULL DEFAULT 0,

    LaiLo NUMERIC(18,2) GENERATED ALWAYS AS (SoTienRut - SoTienNap) STORED,

    GhiChu TEXT
);

-- ==========================================
-- BẢNG 2: QUẢN LÝ KHOẢN NỢ
-- ==========================================
CREATE TABLE QuanLyKhoanNo (
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    TenKhoanNo VARCHAR(255) NOT NULL,

    NguoiChoVay VARCHAR(255),

    GhiChu TEXT
);

-- ==========================================
-- BẢNG 3: CHI TIẾT KHOẢN VAY
-- ==========================================
CREATE TABLE ChiTietKhoanVay (
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    KhoanNoId INT NOT NULL,

    NgayVay DATE NOT NULL,

    SoTienVay NUMERIC(18,2) NOT NULL,

    SoTienLai NUMERIC(18,2) NOT NULL DEFAULT 0,

    SoTienTraMoiKy NUMERIC(18,2),

    SoNgayTra INT,

    TongTien NUMERIC(18,2) GENERATED ALWAYS AS (SoTienVay + SoTienLai) STORED,

    GhiChu TEXT,

    CONSTRAINT FK_ChiTietKhoanVay_QuanLyKhoanNo
        FOREIGN KEY (KhoanNoId)
        REFERENCES QuanLyKhoanNo(Id)
        ON DELETE CASCADE
);
