
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2022 20:19:21
-- Generated from EDMX file: D:\Clothes-Shop-Management-Project\Clothes Shop Management Demo\Demo\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLBH];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CN_PN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CTPN] DROP CONSTRAINT [FK_CN_PN];
GO
IF OBJECT_ID(N'[dbo].[FK_CN_SP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CTPN] DROP CONSTRAINT [FK_CN_SP];
GO
IF OBJECT_ID(N'[dbo].[FK_CT_HD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CTHD] DROP CONSTRAINT [FK_CT_HD];
GO
IF OBJECT_ID(N'[dbo].[FK_CT_SP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CTHD] DROP CONSTRAINT [FK_CT_SP];
GO
IF OBJECT_ID(N'[dbo].[FK_HD_ND]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOADON] DROP CONSTRAINT [FK_HD_ND];
GO
IF OBJECT_ID(N'[dbo].[FK_KH_HD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOADON] DROP CONSTRAINT [FK_KH_HD];
GO
IF OBJECT_ID(N'[dbo].[FK_PN_ND]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHIEUNHAP] DROP CONSTRAINT [FK_PN_ND];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CTHD]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CTHD];
GO
IF OBJECT_ID(N'[dbo].[CTPN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CTPN];
GO
IF OBJECT_ID(N'[dbo].[HOADON]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HOADON];
GO
IF OBJECT_ID(N'[dbo].[KHACHHANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KHACHHANG];
GO
IF OBJECT_ID(N'[dbo].[NGUOIDUNG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NGUOIDUNG];
GO
IF OBJECT_ID(N'[dbo].[PHIEUNHAP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PHIEUNHAP];
GO
IF OBJECT_ID(N'[dbo].[SANPHAM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SANPHAM];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CTHDs'
CREATE TABLE [dbo].[CTHDs] (
    [SOHD] int  NOT NULL,
    [MASP] varchar(50)  NOT NULL,
    [SL] int  NOT NULL
);
GO

-- Creating table 'CTPNs'
CREATE TABLE [dbo].[CTPNs] (
    [MAPN] int  NOT NULL,
    [MASP] varchar(50)  NOT NULL,
    [SL] int  NOT NULL
);
GO

-- Creating table 'HOADONs'
CREATE TABLE [dbo].[HOADONs] (
    [SOHD] int  NOT NULL,
    [MAND] varchar(50)  NULL,
    [MAKH] varchar(50)  NULL,
    [NGHD] datetime  NOT NULL,
    [TRIGIA] int  NOT NULL,
    [KHUYENMAI] int  NULL
);
GO

-- Creating table 'KHACHHANGs'
CREATE TABLE [dbo].[KHACHHANGs] (
    [MAKH] varchar(50)  NOT NULL,
    [HOTEN] nvarchar(50)  NOT NULL,
    [GIOITINH] nvarchar(5)  NULL,
    [DCHI] nvarchar(50)  NULL,
    [SDT] varchar(50)  NOT NULL
);
GO

-- Creating table 'NGUOIDUNGs'
CREATE TABLE [dbo].[NGUOIDUNGs] (
    [MAND] varchar(50)  NOT NULL,
    [TENND] nvarchar(50)  NOT NULL,
    [NGSINH] datetime  NULL,
    [GIOITINH] nvarchar(5)  NULL,
    [SDT] char(50)  NOT NULL,
    [DIACHI] nvarchar(50)  NULL,
    [USERNAME] char(50)  NULL,
    [PASS] nvarchar(max)  NULL,
    [QTV] bit  NOT NULL,
    [TTND] bit  NOT NULL,
    [AVA] varchar(max)  NULL,
    [MAIL] varchar(100)  NULL
);
GO

-- Creating table 'PHIEUNHAPs'
CREATE TABLE [dbo].[PHIEUNHAPs] (
    [MAPN] int  NOT NULL,
    [MAND] varchar(50)  NULL,
    [NGAYNHAP] datetime  NOT NULL
);
GO

-- Creating table 'SANPHAMs'
CREATE TABLE [dbo].[SANPHAMs] (
    [MASP] varchar(50)  NOT NULL,
    [TENSP] nvarchar(50)  NOT NULL,
    [GIA] int  NOT NULL,
    [MOTA] nvarchar(max)  NULL,
    [HINHSP] nvarchar(max)  NULL,
    [SL] int  NOT NULL,
    [LOAISP] nvarchar(50)  NULL,
    [SIZE] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SOHD], [MASP] in table 'CTHDs'
ALTER TABLE [dbo].[CTHDs]
ADD CONSTRAINT [PK_CTHDs]
    PRIMARY KEY CLUSTERED ([SOHD], [MASP] ASC);
GO

-- Creating primary key on [MAPN], [MASP] in table 'CTPNs'
ALTER TABLE [dbo].[CTPNs]
ADD CONSTRAINT [PK_CTPNs]
    PRIMARY KEY CLUSTERED ([MAPN], [MASP] ASC);
GO

-- Creating primary key on [SOHD] in table 'HOADONs'
ALTER TABLE [dbo].[HOADONs]
ADD CONSTRAINT [PK_HOADONs]
    PRIMARY KEY CLUSTERED ([SOHD] ASC);
GO

-- Creating primary key on [MAKH] in table 'KHACHHANGs'
ALTER TABLE [dbo].[KHACHHANGs]
ADD CONSTRAINT [PK_KHACHHANGs]
    PRIMARY KEY CLUSTERED ([MAKH] ASC);
GO

-- Creating primary key on [MAND] in table 'NGUOIDUNGs'
ALTER TABLE [dbo].[NGUOIDUNGs]
ADD CONSTRAINT [PK_NGUOIDUNGs]
    PRIMARY KEY CLUSTERED ([MAND] ASC);
GO

-- Creating primary key on [MAPN] in table 'PHIEUNHAPs'
ALTER TABLE [dbo].[PHIEUNHAPs]
ADD CONSTRAINT [PK_PHIEUNHAPs]
    PRIMARY KEY CLUSTERED ([MAPN] ASC);
GO

-- Creating primary key on [MASP] in table 'SANPHAMs'
ALTER TABLE [dbo].[SANPHAMs]
ADD CONSTRAINT [PK_SANPHAMs]
    PRIMARY KEY CLUSTERED ([MASP] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SOHD] in table 'CTHDs'
ALTER TABLE [dbo].[CTHDs]
ADD CONSTRAINT [FK_CT_HD]
    FOREIGN KEY ([SOHD])
    REFERENCES [dbo].[HOADONs]
        ([SOHD])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MASP] in table 'CTHDs'
ALTER TABLE [dbo].[CTHDs]
ADD CONSTRAINT [FK_CT_SP]
    FOREIGN KEY ([MASP])
    REFERENCES [dbo].[SANPHAMs]
        ([MASP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CT_SP'
CREATE INDEX [IX_FK_CT_SP]
ON [dbo].[CTHDs]
    ([MASP]);
GO

-- Creating foreign key on [MAPN] in table 'CTPNs'
ALTER TABLE [dbo].[CTPNs]
ADD CONSTRAINT [FK_CN_PN]
    FOREIGN KEY ([MAPN])
    REFERENCES [dbo].[PHIEUNHAPs]
        ([MAPN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MASP] in table 'CTPNs'
ALTER TABLE [dbo].[CTPNs]
ADD CONSTRAINT [FK_CN_SP]
    FOREIGN KEY ([MASP])
    REFERENCES [dbo].[SANPHAMs]
        ([MASP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CN_SP'
CREATE INDEX [IX_FK_CN_SP]
ON [dbo].[CTPNs]
    ([MASP]);
GO

-- Creating foreign key on [MAND] in table 'HOADONs'
ALTER TABLE [dbo].[HOADONs]
ADD CONSTRAINT [FK_HD_ND]
    FOREIGN KEY ([MAND])
    REFERENCES [dbo].[NGUOIDUNGs]
        ([MAND])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HD_ND'
CREATE INDEX [IX_FK_HD_ND]
ON [dbo].[HOADONs]
    ([MAND]);
GO

-- Creating foreign key on [MAKH] in table 'HOADONs'
ALTER TABLE [dbo].[HOADONs]
ADD CONSTRAINT [FK_KH_HD]
    FOREIGN KEY ([MAKH])
    REFERENCES [dbo].[KHACHHANGs]
        ([MAKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KH_HD'
CREATE INDEX [IX_FK_KH_HD]
ON [dbo].[HOADONs]
    ([MAKH]);
GO

-- Creating foreign key on [MAND] in table 'PHIEUNHAPs'
ALTER TABLE [dbo].[PHIEUNHAPs]
ADD CONSTRAINT [FK_PN_ND]
    FOREIGN KEY ([MAND])
    REFERENCES [dbo].[NGUOIDUNGs]
        ([MAND])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PN_ND'
CREATE INDEX [IX_FK_PN_ND]
ON [dbo].[PHIEUNHAPs]
    ([MAND]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------