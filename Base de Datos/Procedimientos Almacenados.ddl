-- Generado por Oracle SQL Developer Data Modeler 19.1.0.081.0911
--   en:        2021-06-09 21:18:33 CLT
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g



CREATE OR REPLACE PROCEDURE SP_BARCODE_NEXT 
is
v_max_secuencia productos.secuencia%type;
begin
    select max(secuencia) into v_max_secuencia from productos;
    v_max_secuencia := v_max_secuencia + 1;
    dbms_output.put_line(v_max_secuencia);
end;
/

CREATE OR REPLACE PROCEDURE SP_FAMILIA_CREATE (v_codigo IN familia.codigo%type ,v_descripcion IN familia.descripcion%type)
is
v_max_familia_secuencia number;
begin
    select max(secuencia) into v_max_familia_secuencia from familia;
    if (v_max_familia_secuencia is null) then
        v_max_familia_secuencia := 1;
    else
        v_max_familia_secuencia := v_max_familia_secuencia + 1;
    end if;

    insert into familia (codigo, secuencia, descripcion) values (upper(v_codigo), lpad(v_max_familia_secuencia,3,'0'), upper(v_descripcion));
    dbms_output.put_line('Registro creado');
end;
/

CREATE OR REPLACE PROCEDURE SP_FAMILIA_DESTROY (v_codigo IN familia.codigo%type)
is
begin
    delete from familia where codigo = upper(v_codigo);
    dbms_output.put_line('Registro eliminado');
end;
/

CREATE OR REPLACE PROCEDURE SP_FAMILIA_HASPRODUCT ( v_codigo_familia IN productos.codigo_familia%type)
is
cursor cur_productos is select codigo from productos where codigo_familia = upper(v_codigo_familia);
v_codigo_producto productos.codigo%type;
begin
    open cur_productos;
        loop
            fetch cur_productos into v_codigo_producto;
            if (cur_productos%found) then
                dbms_output.put_line('Hay ' || cur_productos%rowcount || ' productos relacionados');
            else
                dbms_output.put_line('Hay ' || cur_productos%rowcount || ' productos relacionados');
                exit;
            end if;
        end loop;
    close cur_productos;
end;
/

CREATE OR REPLACE PROCEDURE SP_FAMILIA_LIST (registros out sys_refcursor)
is
begin
    open registros for select codigo, descripcion from familia order by descripcion;
end sp_familia_list;
/

CREATE OR REPLACE PROCEDURE SP_FAMILIA_SEARCH (v_palabra IN varchar)
is
v_codigo familia.codigo%type;
v_descripcion familia.descripcion%type;
v_secuencia familia.secuencia%type;
cursor cur_familia is 
    select codigo, secuencia, descripcion from familia where upper(descripcion) like '%' || upper(v_palabra) || '%' order by descripcion;
begin
    open cur_familia;
        loop
            fetch cur_familia into v_codigo, v_secuencia, v_descripcion;
            exit when cur_familia%notfound;
            dbms_output.put_line(v_codigo || v_descripcion || v_secuencia);
        end loop;
    close cur_familia;
end;
/

CREATE OR REPLACE PROCEDURE SP_FAMILIA_UPDATE (v_codigo IN familia.codigo%type, v_descripcion IN familia.descripcion%type)
is
begin
    update familia set descripcion = upper(v_descripcion) where codigo = upper(v_codigo);
    dbms_output.put_line('Registro actualizado');
end;
/

CREATE OR REPLACE PROCEDURE SP_PRODUCTOS_CREATE (v_codigo IN productos.codigo%type
,v_rut_proveedor IN productos.rut_proveedor%type
,v_codigo_barra IN productos.codigo_barra%type
,v_codigo_familia IN productos.codigo_familia%type
,v_fecha_vencimiento IN productos.fecha_vencimiento%type
,v_descripcion IN productos.descripcion%type
,v_unidad_medida IN productos.unidad_medida%type
,v_precio_compra IN productos.precio_compra%type
,v_precio_venta IN productos.precio_venta%type
,v_stock IN productos.stock%type
,v_stock_critico IN productos.stock_critico%type
,v_imagen IN productos.imagen%type
)
is
v_max_productos_secuencia number;
v_secuencia_familia familia.secuencia%type;
cursor cur_familia is select secuencia from familia where codigo = v_codigo_familia;
begin
    open cur_familia;
        loop
            fetch cur_familia into v_secuencia_familia;
            exit when cur_familia%notfound;
        end loop;
    close cur_familia;
    select max(secuencia) into v_max_productos_secuencia from productos;
    select secuencia into v_secuencia_familia from familia where codigo = upper(v_codigo_familia);
    if (v_max_productos_secuencia is null) then
        v_max_productos_secuencia := 1;
    else
        v_max_productos_secuencia := v_max_productos_secuencia + 1;
    end if;

    insert into productos 
        (codigo, secuencia, rut_proveedor, codigo_barra, codigo_familia, secuencia_familia, fecha_vencimiento, descripcion,
        unidad_medida, precio_compra, precio_venta, stock, stock_critico, imagen) 
        values 
        (upper(v_codigo), lpad(v_max_productos_secuencia,3,'0'), v_rut_proveedor, v_codigo_barra, upper(v_codigo_familia), v_secuencia_familia,
        v_fecha_vencimiento, upper(v_descripcion), upper(v_unidad_medida), v_precio_compra, v_precio_venta, v_stock, v_stock_critico, v_imagen);
    dbms_output.put_line('Registro creado');
end;
/

CREATE OR REPLACE PROCEDURE SP_PRODUCTOS_DATA (registros out sys_refcursor)
is
begin
    open registros for select p.secuencia AS NRO
                                      ,p.codigo AS ID
                                      ,p.descripcion AS NOMBRE
                                      ,p.unidad_medida AS "UMEDIDA"
                                      ,p.codigo_barra AS "CODIGO"
                                      ,f.descripcion AS FAMILIA
                                      ,p.fecha_vencimiento AS "VENCIMIENTO"
                                      ,p.precio_compra AS "COSTO"
                                      ,p.precio_venta AS "PRECIO"
                                      ,p.stock AS STOCK
                                      ,p.stock_critico AS "ALERTAS"
                                      ,p.imagen AS IMAGEN
                                from productos p, familia f
                                where p.codigo_familia = f.codigo
                                order by p.descripcion;
end;
/

CREATE OR REPLACE PROCEDURE SP_PRODUCTOS_DATA_TOUCH ( v_familia_codigo IN familia.codigo%type, registros OUT sys_refcursor)
is
begin
    open registros for select codigo, descripcion, unidad_medida, codigo_barra, fecha_vencimiento, precio_compra, precio_venta
                               ,stock, stock_critico, imagen
                               from productos where codigo_familia = upper(v_familia_codigo) order by descripcion desc;
end;
/

CREATE OR REPLACE PROCEDURE SP_PRODUCTOS_DESTROY (v_codigo IN productos.codigo%type)
is
begin
    delete from productos where codigo = upper(v_codigo);
    dbms_output.put_line('Registro eliminado');
end;
/

CREATE OR REPLACE PROCEDURE SP_PRODUCTOS_LIST (registros out sys_refcursor)
is
begin
    open registros for select codigo, secuencia, rut_proveedor, codigo_barra, codigo_familia
                             , secuencia_familia, fecha_vencimiento, descripcion, unidad_medida 
                             , precio_compra, precio_venta, stock, stock_critico, imagen from productos;
end sp_productos_list;
/

CREATE OR REPLACE PROCEDURE SP_PRODUCTOS_SEARCH (v_palabra IN varchar)
is
v_codigo productos.codigo%type;
v_descripcion productos.descripcion%type;
v_secuencia productos.secuencia%type;
cursor cur_productos is 
    select codigo, secuencia, descripcion from productos where upper(descripcion) like '%' || upper(v_palabra) || '%' order by descripcion;
begin
    open cur_productos;
    loop
    fetch cur_productos into v_codigo, v_secuencia, v_descripcion;
    exit when cur_productos%notfound;
    dbms_output.put_line(v_codigo || v_secuencia ||v_descripcion);
    end loop;
    close cur_productos;
end;
/

CREATE OR REPLACE PROCEDURE SP_PRODUCTOS_UPDATE (
v_codigo IN productos.codigo%type
,v_rut_proveedor IN productos.rut_proveedor%type
,v_codigo_barra IN productos.codigo_barra%type
,v_codigo_familia IN productos.codigo_familia%type
,v_fecha_vencimiento IN productos.fecha_vencimiento%type
,v_descripcion IN productos.descripcion%type
,v_unidad_medida IN productos.unidad_medida%type
,v_precio_compra IN productos.precio_compra%type
,v_precio_venta IN productos.precio_venta%type
,v_stock IN productos.stock%type
,v_stock_critico IN productos.stock_critico%type
,v_imagen IN productos.imagen%type
)
is
begin
    update productos set rut_proveedor = v_rut_proveedor
                         ,codigo_barra = v_codigo_barra
                         ,codigo_familia = v_codigo_familia
                         ,fecha_vencimiento = v_fecha_vencimiento
                         ,descripcion = upper(v_descripcion)
                         ,unidad_medida = v_unidad_medida
                         ,precio_compra = v_precio_compra
                         ,precio_venta = v_precio_venta
                         ,stock = v_stock
                         ,stock_critico = v_stock_critico
                         ,imagen = v_imagen
    where codigo = upper(v_codigo);
    dbms_output.put_line('Registro actualizado');
end;
/

CREATE TABLE sgi.umedida (
    codigo        VARCHAR2(4 CHAR) NOT NULL,
    descripcion   VARCHAR2(50 CHAR) NOT NULL
)
LOGGING;

ALTER TABLE sgi.umedida ADD CONSTRAINT umedida_pk PRIMARY KEY ( codigo );



-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                             1
-- CREATE INDEX                             0
-- ALTER TABLE                              1
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                        14
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
