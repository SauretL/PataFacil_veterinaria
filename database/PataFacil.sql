-- =====================================================================
-- PataFacil: script completo de la base de datos (unión de las ramas).
-- Se puede ejecutar las veces que haga falta con F5: si la base ya existe, la BORRA
-- (con todos sus datos) y la crea de nuevo. Cerrá el programa antes de ejecutarlo.
-- No usa rutas de archivos: SQL Server elige solo dónde guardarla, así que
-- funciona en cualquier PC.
-- =====================================================================

-- Hay que estar en "master" para poder borrar la base PataFacil
USE [master];
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'PataFacil')
BEGIN
    ALTER DATABASE [PataFacil] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [PataFacil];
END
GO

CREATE DATABASE [PataFacil];
GO

USE [PataFacil];
GO

-- ==========================================
-- TABLA: Cliente
-- ==========================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
    [IdCliente] [int] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](100) NOT NULL,
    [Apellido] [varchar](100) NOT NULL,
    [DNI] [varchar](20) NOT NULL,
    [Telefono] [varchar](20) NULL,
    [Email] [varchar](100) NULL,
    [Direccion] [varchar](200) NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [UQ_Cliente_DNI] UNIQUE NONCLUSTERED ([DNI] ASC)
) ON [PRIMARY];
GO

-- ==========================================
-- TABLA: Mascota
-- ==========================================
CREATE TABLE [dbo].[Mascota](
    [IdMascota] [int] IDENTITY(1,1) NOT NULL,
    [IdCliente] [int] NOT NULL,
    [Nombre] [varchar](50) NOT NULL,
    [Especie] [varchar](50) NOT NULL,
    [Raza] [varchar](50) NULL,
    [Sexo] [varchar](20) NULL,
    [FechaNacimiento] [date] NULL,
    [Peso] [decimal](5, 2) NULL,
    CONSTRAINT [PK_Mascota] PRIMARY KEY CLUSTERED ([IdMascota] ASC)
) ON [PRIMARY];
GO

-- ==========================================
-- TABLA: Usuario
-- ==========================================
CREATE TABLE [dbo].[Usuario](
    [IdUsuario] [int] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](100) NOT NULL,
    [Email] [varchar](100) NOT NULL,
    [PasswordHash] [varchar](256) NOT NULL,
    [Rol] [varchar](50) NOT NULL,
    [Activo] [bit] NOT NULL DEFAULT ((1)),
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [UQ_Usuario_Email] UNIQUE NONCLUSTERED ([Email] ASC)
) ON [PRIMARY];
GO

-- ==========================================
-- TABLA: Turno
-- ==========================================
CREATE TABLE [dbo].[Turno](
    [IdTurno] [int] IDENTITY(1,1) NOT NULL,
    [IdMascota] [int] NOT NULL,
    [IdUsuario] [int] NOT NULL,
    [FechaHora] [datetime] NOT NULL,
    [Motivo] [varchar](250) NULL,
    [Estado] [varchar](30) NOT NULL DEFAULT ('Pendiente'),
    CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED ([IdTurno] ASC)
) ON [PRIMARY];
GO

-- ==========================================
-- TABLA: Consulta
-- ==========================================
CREATE TABLE [dbo].[Consulta](
    [IdConsulta] [int] IDENTITY(1,1) NOT NULL,
    [IdTurno] [int] NOT NULL,
    [IdMascota] [int] NOT NULL,
    [IdUsuario] [int] NOT NULL,
    [FechaHora] [datetime] NOT NULL DEFAULT (getdate()),
    [Diagnostico] [varchar](max) NOT NULL,
    [Tratamiento] [varchar](max) NULL,
    CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [UQ_Consulta_IdTurno] UNIQUE NONCLUSTERED ([IdTurno] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
GO

-- ==========================================
-- TABLA: Comprobante
-- ==========================================
CREATE TABLE [dbo].[Comprobante](
    [IdComprobante] [int] IDENTITY(1,1) NOT NULL,
    [IdCliente] [int] NOT NULL,
    [IdConsulta] [int] NULL,
    [FechaEmision] [datetime] NOT NULL DEFAULT (getdate()),
    [TipoComprobante] [varchar](20) NOT NULL,
    [MontoTotal] [decimal](10, 2) NOT NULL,
    CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED ([IdComprobante] ASC)
) ON [PRIMARY];
GO

-- ==========================================
-- TABLA: Producto
-- ==========================================
CREATE TABLE [dbo].[Producto](
    [IdProducto] [int] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](100) NOT NULL,
    [Descripcion] [varchar](250) NULL,
    [PrecioUnitario] [decimal](10, 2) NOT NULL DEFAULT ((0)),
    [StockActual] [int] NOT NULL DEFAULT ((0)),
    [StockMinimo] [int] NOT NULL DEFAULT ((5)),
    [Categoria] [varchar](50) NOT NULL DEFAULT ('Otros'),
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([IdProducto] ASC),
    CONSTRAINT [UQ_Producto_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [CK_Producto_Stock] CHECK ([StockActual] >= 0 AND [StockMinimo] >= 0)
) ON [PRIMARY];
GO

-- ==========================================
-- TABLA: MovimientoStock
-- ==========================================
CREATE TABLE [dbo].[MovimientoStock](
    [IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
    [IdProducto] [int] NOT NULL,
    [IdUsuario] [int] NOT NULL,
    [TipoMovimiento] [varchar](20) NOT NULL,
    [Cantidad] [int] NOT NULL,
    [FechaHora] [datetime] NOT NULL DEFAULT (getdate()),
    [Observacion] [varchar](250) NULL,
    CONSTRAINT [PK_MovimientoStock] PRIMARY KEY CLUSTERED ([IdMovimiento] ASC),
    CONSTRAINT [CK_Movimiento_Tipo] CHECK ([TipoMovimiento] IN ('Ingreso', 'Egreso')),
    CONSTRAINT [CK_Movimiento_Cantidad] CHECK ([Cantidad] > 0)
) ON [PRIMARY];
GO

-- ==========================================
-- CLAVES FORÁNEAS (RELACIONES)
-- ==========================================
ALTER TABLE [dbo].[Mascota] WITH CHECK ADD CONSTRAINT [FK_Mascota_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente]);
GO
ALTER TABLE [dbo].[Mascota] CHECK CONSTRAINT [FK_Mascota_Cliente];
GO

ALTER TABLE [dbo].[Turno] WITH CHECK ADD CONSTRAINT [FK_Turno_Mascota] FOREIGN KEY([IdMascota])
REFERENCES [dbo].[Mascota] ([IdMascota]);
GO
ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_Mascota];
GO

ALTER TABLE [dbo].[Turno] WITH CHECK ADD CONSTRAINT [FK_Turno_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario]);
GO
ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_Usuario];
GO

ALTER TABLE [dbo].[Consulta] WITH CHECK ADD CONSTRAINT [FK_Consulta_Mascota] FOREIGN KEY([IdMascota])
REFERENCES [dbo].[Mascota] ([IdMascota]);
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Mascota];
GO

ALTER TABLE [dbo].[Consulta] WITH CHECK ADD CONSTRAINT [FK_Consulta_Turno] FOREIGN KEY([IdTurno])
REFERENCES [dbo].[Turno] ([IdTurno]);
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Turno];
GO

ALTER TABLE [dbo].[Consulta] WITH CHECK ADD CONSTRAINT [FK_Consulta_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario]);
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Usuario];
GO

ALTER TABLE [dbo].[Comprobante] WITH CHECK ADD CONSTRAINT [FK_Comprobante_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente]);
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_Cliente];
GO

ALTER TABLE [dbo].[Comprobante] WITH CHECK ADD CONSTRAINT [FK_Comprobante_Consulta] FOREIGN KEY([IdConsulta])
REFERENCES [dbo].[Consulta] ([IdConsulta]);
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_Consulta];
GO

ALTER TABLE [dbo].[MovimientoStock] WITH CHECK ADD CONSTRAINT [FK_Movimiento_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto]);
GO
ALTER TABLE [dbo].[MovimientoStock] CHECK CONSTRAINT [FK_Movimiento_Producto];
GO

ALTER TABLE [dbo].[MovimientoStock] WITH CHECK ADD CONSTRAINT [FK_Movimiento_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario]);
GO
ALTER TABLE [dbo].[MovimientoStock] CHECK CONSTRAINT [FK_Movimiento_Usuario];
GO

-- ==========================================
-- CARGA DE DATOS INICIALES (USUARIOS)
-- ==========================================
INSERT INTO dbo.Usuario (Nombre, Email, PasswordHash, Rol, Activo)
VALUES 
    ('Laura Recepción', 'recepcion@patafacil.com', 'recepcionista123', 'Recepcionista', 1),
    ('Carlos Auxiliar', 'auxiliar@patafacil.com', 'auxiliar123', 'Auxiliar', 1),
    ('Dra. Maria Gomez', 'veterinaria@patafacil.com', 'veterinario123', 'Veterinario', 1),
    ('Admin Sistema', 'admin@patafacil.com', 'admin123', 'Administrador', 1);
GO

-- ==========================================
-- CARGA DE DATOS INICIALES (PRODUCTOS DE PRUEBA)
-- El precio no se manda: queda en 0 por el valor por defecto.
-- ==========================================
INSERT INTO dbo.Producto (Nombre, Descripcion, StockActual, StockMinimo, Categoria)
VALUES
    ('Vacuna Antirrábica',         NULL, 12,  5, 'Vacunas'),
    ('Vacuna Séxtuple',            NULL,  3,  8, 'Vacunas'),
    ('Amoxicilina 500mg',          NULL, 20, 10, 'Medicamentos'),
    ('Antiparasitario Interno',    NULL,  4,  6, 'Medicamentos'),
    ('Alimento Perro Adulto 15kg', NULL,  9,  5, 'Alimentos'),
    ('Alimento Gato 10kg',         NULL,  2,  5, 'Alimentos'),
    ('Guantes descartables',       NULL, 50, 20, 'Insumos'),
    ('Jeringas 5ml',               NULL, 15, 15, 'Insumos'),
    ('Collar antipulgas',          NULL,  7,  3, 'Otros');
GO
