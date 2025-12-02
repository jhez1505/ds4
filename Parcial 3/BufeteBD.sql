CREATE DATABASE BD_Jhezrrel_Delgado;
GO

USE BD_Jhezrrel_Delgado;
GO

-- Tabla de abogados
CREATE TABLE JD_Abogados (
    AbogadoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre       VARCHAR(100) NOT NULL,
    Apellido     VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NULL,
    Telefono     VARCHAR(30)  NULL,
    Email        VARCHAR(100) NULL,
    EsActivo     BIT NOT NULL DEFAULT 1
);
GO

-- Tabla de clientes
CREATE TABLE JD_Clientes (
    ClienteID  INT IDENTITY(1,1) PRIMARY KEY,
    Nombre     VARCHAR(100) NOT NULL,
    Apellido   VARCHAR(100) NOT NULL,
    CedulaRUC  VARCHAR(50)  NULL,
    Telefono   VARCHAR(30)  NULL,
    Email      VARCHAR(100) NULL,
    Direccion  VARCHAR(250) NULL,
    EsActivo   BIT NOT NULL DEFAULT 1
);
GO

-- Tabla de casos
CREATE TABLE JD_Casos (
    CasoID          INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCaso      VARCHAR(50)  NOT NULL UNIQUE,   -- Ej: CAS-2025-001
    Titulo          VARCHAR(200) NOT NULL,
    Descripcion     VARCHAR(MAX) NULL,
    FechaInicio     DATE         NOT NULL,
    FechaVencimiento DATE        NULL,              -- Se puede actualizar si el caso se extiende
    EstadoCaso      VARCHAR(50)  NOT NULL,          -- Ej: Abierto, En Proceso, Cerrado
    Prioridad       VARCHAR(20)  NULL,              -- Alta, Media, Baja (opcional)
    
    -- Abogado asignado al caso
    AbogadoAsignadoID INT NOT NULL,

    CONSTRAINT FK_JD_Casos_Abogados
        FOREIGN KEY (AbogadoAsignadoID) REFERENCES JD_Abogados(AbogadoID)
);
GO

-- Relación NxN entre Casos y Clientes
CREATE TABLE JD_CasoCliente (
    CasoID    INT NOT NULL,
    ClienteID INT NOT NULL,
    RolCliente VARCHAR(50) NULL, -- Ej: Demandante, Demandado, Testigo

    CONSTRAINT PK_JD_CasoCliente PRIMARY KEY (CasoID, ClienteID),

    CONSTRAINT FK_JD_CasoCliente_Caso
        FOREIGN KEY (CasoID) REFERENCES JD_Casos(CasoID),

    CONSTRAINT FK_JD_CasoCliente_Cliente
        FOREIGN KEY (ClienteID) REFERENCES JD_Clientes(ClienteID)
);
GO


-- Eventos del caso: reuniones, audiencias, vencimientos, etc.
CREATE TABLE JD_Eventos (
    EventoID      INT IDENTITY(1,1) PRIMARY KEY,
    CasoID        INT NOT NULL,

    TipoEvento    VARCHAR(50) NOT NULL, -- Reunión, Audiencia, Vencimiento
    Titulo        VARCHAR(200) NOT NULL,
    Descripcion   VARCHAR(500) NULL,

    FechaHoraInicio DATETIME NOT NULL,
    FechaHoraFin    DATETIME NULL,

    Ubicacion     VARCHAR(200) NULL,

    -- Para seguimiento de plazos críticos
    EsPlazoLegal  BIT NOT NULL DEFAULT 0,   -- 1 = es un plazo legal importante
    EstadoEvento  VARCHAR(20) NOT NULL DEFAULT 'Pendiente', -- Pendiente, Realizado, Cancelado

    CONSTRAINT FK_JD_Eventos_Casos
        FOREIGN KEY (CasoID) REFERENCES JD_Casos(CasoID)
);
GO

-- Documentos y evidencias asociados a los casos
CREATE TABLE JD_Documentos (
    DocumentoID    INT IDENTITY(1,1) PRIMARY KEY,
    CasoID         INT NOT NULL,

    NombreDocumento VARCHAR(200) NOT NULL,  -- Ej: "Demanda inicial", "Foto evidencia A"
    TipoDocumento   VARCHAR(50)  NOT NULL,  -- Ej: Demanda, Evidencia, Contrato, Imagen
    NombreArchivo   VARCHAR(200) NOT NULL,  -- Ej: demanda_cas-2025-001.pdf
    RutaArchivo     VARCHAR(300) NOT NULL,  -- Ej: \\Servidor\Casos\CAS-2025-001\demanda.pdf

    FechaSubida     DATETIME NOT NULL DEFAULT GETDATE(),
    Notas           VARCHAR(500) NULL,

    CONSTRAINT FK_JD_Documentos_Casos
        FOREIGN KEY (CasoID) REFERENCES JD_Casos(CasoID)
);
GO


-- Abogados de prueba
INSERT INTO JD_Abogados (Nombre, Apellido, Especialidad, Telefono, Email)
VALUES 
('Carlos', 'Díaz', 'Derecho Civil', '6000-0001', 'cdiaz@bufete.com'),
('María', 'Gómez', 'Derecho Penal', '6000-0002', 'mgomez@bufete.com');

-- Clientes de prueba
INSERT INTO JD_Clientes (Nombre, Apellido, CedulaRUC, Telefono, Email, Direccion)
VALUES
('Javier', 'Pérez', '8-000-0001', '6000-1001', 'javier@example.com', 'Ciudad de Panamá'),
('Lucía', 'Martínez', '8-000-0002', '6000-1002', 'lucia@example.com', 'San Miguelito');

-- Caso de prueba
INSERT INTO JD_Casos (CodigoCaso, Titulo, Descripcion, FechaInicio, FechaVencimiento, EstadoCaso, Prioridad, AbogadoAsignadoID)
VALUES
('CAS-2025-001', 'Demanda por incumplimiento de contrato', 'Caso civil relacionado con contrato comercial.', '2025-11-01', '2026-01-15', 'Abierto', 'Alta', 1);

-- Relación Caso-Clientes
INSERT INTO JD_CasoCliente (CasoID, ClienteID, RolCliente)
VALUES
(1, 1, 'Demandante'),
(1, 2, 'Demandado');

-- Evento de prueba
INSERT INTO JD_Eventos (CasoID, TipoEvento, Titulo, Descripcion, FechaHoraInicio, Ubicacion, EsPlazoLegal)
VALUES
(1, 'Audiencia', 'Audiencia preliminar', 'Primera audiencia del caso.', '2025-12-10 09:00', 'Juzgado Primero', 1);

-- Documento de prueba
INSERT INTO JD_Documentos (CasoID, NombreDocumento, TipoDocumento, NombreArchivo, RutaArchivo, Notas)
VALUES
(1, 'Demanda inicial', 'Demanda', 'demanda_cas-2025-001.pdf', '\\\\Servidor\\Casos\\CAS-2025-001\\demanda_cas-2025-001.pdf', 'Documento escaneado firmado.');
GO

SELECT * FROM JD_Casos;
GO



