/*----------------------------------------------------
PROCEDIMIENTO PARA LISTAR REGISTROS DE PRODUCTOS
POR FAMILIA
----------------------------------------------------*/
create or replace procedure sp_productos_data(registros out sys_refcursor)
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

-- exec sp_productos_data;

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA LISTAR REGISTROS DE PRODUCTOS
POR FAMILIA
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA LISTAR REGISTROS DE PRODUCTOS
POR FAMILIA PRESIONADA
----------------------------------------------------*/
create or replace procedure sp_productos_data_touch( v_familia_codigo IN familia.codigo%type )
is
cursor cur_productos is select codigo, descripcion, unidad_medida, codigo_barra, fecha_vencimiento, precio_compra, precio_venta
                               ,stock, stock_critico, imagen
                               from productos where codigo_familia = upper(v_familia_codigo) order by descripcion desc;
begin
    for i in cur_productos loop
        DBMS_OUTPUT.PUT_LINE(i.codigo || ' ' || i.descripcion || ' ' || i.codigo_barra || ' ' ||
                             i.fecha_vencimiento || ' ' || i.precio_compra || ' ' || i.precio_venta
                             || ' ' || i.stock || ' ' || i.stock_critico || ' ' || i.imagen );
    end loop;
end;

-- exec sp_productos_data_touch('AB');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA LISTAR REGISTROS DE PRODUCTOS
POR CATEGORIA PRESIONADA
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA LISTAR REGISTROS DE PRODUCTOS
----------------------------------------------------*/
create or replace procedure sp_productos_list
is
cursor cur_productos is select * from productos;
begin
    for i IN cur_productos loop
        DBMS_OUTPUT.PUT_LINE(i.codigo || ' ' || i.secuencia ||' ' || i.rut_proveedor || ' ' || i.codigo_barra || ' ' || i.codigo_familia || ' ' ||
                             i.secuencia_familia || ' '  || i.fecha_vencimiento || ' ' || ' ' || i.descripcion || i.unidad_medida || ' ' || 
                             i.precio_compra || ' ' || i.precio_venta || ' ' || i.stock || ' ' || i.stock_critico || ' ' || i.imagen );
    end loop;
end sp_productos_list;

-- exec sp_productos_list;

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA LISTAR REGISTROS DE PRODUCTOS
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA INSERTAR REGISTRO DE PRODUCTOS
----------------------------------------------------*/
/* Secuencia se desordenaba cuando la consulta arroja error de primary key duplicada. Se descarta solución de secuencia.

CREATE SEQUENCE  "SGI"."SEC_productos_ID"  MINVALUE 001 MAXVALUE 99999 INCREMENT BY 1 START WITH 001 CACHE 20 NOORDER  NOCYCLE ;
*/

create or replace procedure sp_productos_create(v_codigo IN productos.codigo%type
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
        (upper(v_codigo), v_max_productos_secuencia, v_rut_proveedor, v_codigo_barra, upper(v_codigo_familia), v_secuencia_familia,
        v_fecha_vencimiento, upper(v_descripcion), upper(v_unidad_medida), v_precio_compra, v_precio_venta, v_stock, v_stock_critico, v_imagen);
    dbms_output.put_line('Registro creado');
    
EXCEPTION
when DUP_VAL_ON_INDEX then 
    sp_productos_update(v_codigo,v_rut_proveedor,v_codigo_barra,upper(v_codigo_familia),v_fecha_vencimiento,upper(v_descripcion),v_unidad_medida,
                        v_precio_compra,v_precio_venta,v_stock,v_stock_critico,v_imagen);
end;


exec sp_productos_create('a0001','796925906',123456789,'AB','12-12-2021','aceite','LT',900,1000,10,3,'N');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA INSERTAR REGISTRO DE productos
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA ACTUALIZAR REGISTRO DE productos
----------------------------------------------------*/

create or replace procedure sp_productos_update(
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

--exec sp_productos_update('a0001','796925906',123456789,'AB','12-12-2021','aceite_modificado','LT',900,1000,10,3,'N');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA ACTUALIZAR REGISTRO DE productos
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA ELIMINAR REGISTRO DE productos
----------------------------------------------------*/

create or replace procedure sp_productos_destroy(v_codigo IN productos.codigo%type)
is
begin
    delete from productos where codigo = upper(v_codigo);
    dbms_output.put_line('Registro eliminado');
end;

--exec sp_productos_destroy('CO');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA ELIMINAR REGISTRO DE PRODUCTOS
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA BUSCAR REGISTRO DE PRODUCTOS
----------------------------------------------------*/

create or replace procedure sp_productos_search(v_palabra IN varchar)
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

--exec sp_productos_search('ac');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA BUSCAR REGISTRO DE PRODUCTOS
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA BUSCAR REGISTRO DE PRODUCTOS
POR CODIGO DE BARRA
----------------------------------------------------*/
create or replace procedure sp_productos_search_bycode( v_codigo_barra IN productos.codigo_barra%type )
is
cursor cur_productos is select codigo, descripcion, unidad_medida, codigo_barra, fecha_vencimiento, precio_compra, precio_venta
                               ,stock, stock_critico, imagen
                               from productos where codigo_barra = v_codigo_barra;
begin
    for i in cur_productos loop
        DBMS_OUTPUT.PUT_LINE(i.codigo || ' ' || i.descripcion || ' ' || i.codigo_barra || ' ' ||
                             i.fecha_vencimiento || ' ' || i.precio_compra || ' ' || i.precio_venta
                             || ' ' || i.stock || ' ' || i.stock_critico || ' ' || i.imagen );
    end loop;
end;

-- exec sp_productos_search_bycode(123456789);
/*----------------------------------------------------
FIN PROCEDIMIENTO PARA BUSCAR REGISTRO DE PRODUCTOS
POR CODIGO DE BARRA
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA ENTREGAR SECUENCIA + 1
----------------------------------------------------*/
create or replace procedure sp_barcode_next
is
v_max_secuencia productos.secuencia%type;
begin
    select max(secuencia) into v_max_secuencia from productos;
    v_max_secuencia := v_max_secuencia + 1;
    dbms_output.put_line(v_max_secuencia);
end;

-- exec sp_barcode_next;