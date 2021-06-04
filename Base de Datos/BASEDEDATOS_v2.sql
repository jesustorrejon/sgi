-- Generado por Oracle SQL Developer Data Modeler 20.4.1.406.0906
--   en:        2021-05-04 10:21:36 CLT
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g



-- predefined type, no DDL - MDSYS.SDO_GEOMETRY

-- predefined type, no DDL - XMLTYPE

CREATE TABLE boleta_detalle (
    numero_boleta  INTEGER NOT NULL,
    secuencia      INTEGER NOT NULL,
    cod_producto   VARCHAR2(10 CHAR) NOT NULL,
    cantidad       FLOAT NOT NULL,
    precio         FLOAT NOT NULL
);

ALTER TABLE boleta_detalle ADD CONSTRAINT boleta_detalle_pk PRIMARY KEY ( numero_boleta,
                                                                          secuencia );

CREATE TABLE boletas (
    numero            INTEGER NOT NULL,
    rut               VARCHAR2(9 CHAR) NOT NULL,
    fecha             DATE,
    total             FLOAT,
    mediopago         VARCHAR2(50 CHAR),
    fecha_compromiso  DATE
);

ALTER TABLE boletas ADD CONSTRAINT boletas_pk PRIMARY KEY ( numero );

CREATE TABLE clientes (
    rut        VARCHAR2(9 CHAR) NOT NULL,
    nombre     VARCHAR2(50 CHAR) NOT NULL,
    direccion  VARCHAR2(50 CHAR) NOT NULL,
    comuna     VARCHAR2(50 CHAR) NOT NULL,
    ciudad     VARCHAR2(50 CHAR) NOT NULL,
    telefono   INTEGER NOT NULL
);

ALTER TABLE clientes ADD CONSTRAINT clientes_pk PRIMARY KEY ( rut );

CREATE TABLE cuentas_corrientes (
    rut_cliente       VARCHAR2(9 CHAR) NOT NULL,
    secuencia         INTEGER NOT NULL,
    fecha             DATE NOT NULL,
    fecha_compromiso  DATE NOT NULL,
    cargo             FLOAT,
    abono             FLOAT,
    estado            VARCHAR2(50 CHAR) NOT NULL
);

ALTER TABLE cuentas_corrientes ADD CONSTRAINT cuentas_corrientes_pk PRIMARY KEY ( rut_cliente,
                                                                                  secuencia );

CREATE TABLE familia (
    codigo       VARCHAR2(50 CHAR) NOT NULL,
    secuencia    INTEGER NOT NULL,
    descripcion  VARCHAR2(50 CHAR) NOT NULL
);

ALTER TABLE familia ADD CONSTRAINT familia_pk PRIMARY KEY ( codigo,
                                                            secuencia );

CREATE TABLE kardex (
    correlativo    INTEGER NOT NULL,
    fecha          DATE NOT NULL,
    cod_producto   VARCHAR2(10 CHAR) NOT NULL,
    entrada        FLOAT,
    salida         FLOAT,
    numero_boleta  INTEGER NOT NULL
);

ALTER TABLE kardex ADD CONSTRAINT kardex_pk PRIMARY KEY ( correlativo );

CREATE TABLE oc (
    codigo               INTEGER NOT NULL,
    rut_proveedor        VARCHAR2(9 CHAR) NOT NULL,
    secuencia_proveedor  INTEGER NOT NULL,
    fecha                DATE NOT NULL,
    fecha_recepcion      DATE,
    total                FLOAT
);

ALTER TABLE oc ADD CONSTRAINT oc_pk PRIMARY KEY ( codigo );

CREATE TABLE oc_detalle (
    cod_oc           INTEGER NOT NULL,
    secuencia        INTEGER NOT NULL,
    cod_producto     VARCHAR2(10 CHAR) NOT NULL,
    cantidad         FLOAT NOT NULL,
    precio_unitario  FLOAT NOT NULL
);

ALTER TABLE oc_detalle ADD CONSTRAINT oc_detalle_pk PRIMARY KEY ( cod_oc,
                                                                  secuencia );

CREATE TABLE productos (
    codigo             VARCHAR2(10 CHAR) NOT NULL,
    secuencia          INTEGER NOT NULL,
    rut_proveedor      VARCHAR2(9 CHAR) NOT NULL,
    codigo_barra       INTEGER,
    codigo_familia     VARCHAR2(10 CHAR) NOT NULL,
    secuencia_familia  INTEGER NOT NULL,
    fecha_vencimiento  DATE,
    descripcion        VARCHAR2(50 CHAR) NOT NULL,
    unidad_medida      VARCHAR2(10 CHAR) NOT NULL,
    precio_compra      FLOAT,
    precio_venta       FLOAT,
    stock              FLOAT,
    stock_critico      FLOAT,
    imagen             VARCHAR2(255 CHAR)
);

ALTER TABLE productos ADD CONSTRAINT productos_pk PRIMARY KEY ( codigo,
                                                                secuencia );

CREATE TABLE proveedores (
    rut           VARCHAR2(9 CHAR) NOT NULL,
    secuencia     INTEGER NOT NULL,
    razon_social  VARCHAR2(50 CHAR),
    giro          VARCHAR2(50 CHAR),
    direccion     VARCHAR2(50 CHAR),
    comuna        VARCHAR2(50),
    ciudad        VARCHAR2(50 CHAR),
    telefono      INTEGER,
    contacto      VARCHAR2(50 CHAR)
);

ALTER TABLE proveedores ADD CONSTRAINT proveedores_pk PRIMARY KEY ( rut,
                                                                    secuencia );

CREATE TABLE rec_oc (
    cod_oc  INTEGER NOT NULL,
    fecha   DATE NOT NULL,
    estado  VARCHAR2(50 CHAR) NOT NULL
);

ALTER TABLE rec_oc ADD CONSTRAINT rec_oc_pk PRIMARY KEY ( cod_oc );

CREATE TABLE rec_oc_detalle (
    cod_oc        INTEGER NOT NULL,
    secuencia     INTEGER NOT NULL,
    cod_producto  VARCHAR2(10 CHAR) NOT NULL,
    cantidad      FLOAT NOT NULL,
    pendiente     FLOAT NOT NULL
);

ALTER TABLE rec_oc_detalle ADD CONSTRAINT rec_oc_detalle_pk PRIMARY KEY ( cod_oc,
                                                                          secuencia );

ALTER TABLE boleta_detalle
    ADD CONSTRAINT boleta_detalle_boletas_fk FOREIGN KEY ( numero_boleta )
        REFERENCES boletas ( numero );

ALTER TABLE boletas
    ADD CONSTRAINT boletas_clientes_fk FOREIGN KEY ( rut )
        REFERENCES clientes ( rut );

ALTER TABLE cuentas_corrientes
    ADD CONSTRAINT cuentas_corrientes_clientes_fk FOREIGN KEY ( rut_cliente )
        REFERENCES clientes ( rut );

ALTER TABLE oc_detalle
    ADD CONSTRAINT oc_detalle_oc_fk FOREIGN KEY ( cod_oc )
        REFERENCES oc ( codigo );

ALTER TABLE oc
    ADD CONSTRAINT oc_proveedores_fk FOREIGN KEY ( rut_proveedor,
                                                   secuencia_proveedor )
        REFERENCES proveedores ( rut,
                                 secuencia );

ALTER TABLE productos
    ADD CONSTRAINT productos_familia_fk FOREIGN KEY ( codigo_familia,
                                                      secuencia_familia )
        REFERENCES familia ( codigo,
                             secuencia );

ALTER TABLE rec_oc_detalle
    ADD CONSTRAINT rec_oc_detalle_rec_oc_fk FOREIGN KEY ( cod_oc )
        REFERENCES rec_oc ( cod_oc );



-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                            12
-- CREATE INDEX                             0
-- ALTER TABLE                             19
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE COLLECTION TYPE                   0
-- CREATE STRUCTURED TYPE                   0
-- CREATE STRUCTURED TYPE BODY              0
-- CREATE CLUSTER                           0
-- CREATE CONTEXT                           0
-- CREATE DATABASE                          0
-- CREATE DIMENSION                         0
-- CREATE DIRECTORY                         0
-- CREATE DISK GROUP                        0
-- CREATE ROLE                              0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE SEQUENCE                          0
-- CREATE MATERIALIZED VIEW                 0
-- CREATE MATERIALIZED VIEW LOG             0
-- CREATE SYNONYM                           0
-- CREATE TABLESPACE                        0
-- CREATE USER                              0
-- 
-- DROP TABLESPACE                          0
-- DROP DATABASE                            0
-- 
-- REDACTION POLICY                         0
-- 
-- ORDS DROP SCHEMA                         0
-- ORDS ENABLE SCHEMA                       0
-- ORDS ENABLE OBJECT                       0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
