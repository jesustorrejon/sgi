/*----------------------------------------------------
PROCEDIMIENTO PARA LISTAR REGISTROS DE FAMILIA
----------------------------------------------------*/
create or replace procedure sp_familia_list(registros out sys_refcursor)
is
begin
    open registros for select codigo, descripcion from familia order by descripcion;
end sp_familia_list;

set serveroutput on;
-- exec sp_familia_list(registros);

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA LISTAR REGISTROS DE FAMILIA
----------------------------------------------------*/

/*----------------------------------------------------
PROCEDIMIENTO PARA INSERTAR REGISTRO DE FAMILIA
----------------------------------------------------*/
/* Secuencia se desordenaba cuando la consulta arroja error de primary key duplicada. Se descarta solución de secuencia.

CREATE SEQUENCE  "SGI"."SEC_FAMILIA_ID"  MINVALUE 001 MAXVALUE 99999 INCREMENT BY 1 START WITH 001 CACHE 20 NOORDER  NOCYCLE ;
*/

create or replace procedure sp_familia_create(v_codigo IN familia.codigo%type ,v_descripcion IN familia.descripcion%type)
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

exec sp_familia_create('AB','ABARROTES');
exec sp_familia_create('CO','CONGELADOS');
exec sp_familia_create('BE','BEBIDAS');
exec sp_familia_create('CR','CARNES ROJAS');
exec sp_familia_create('CA','CARNES DE AVE');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA INSERTAR REGISTRO DE FAMILIA
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA ACTUALIZAR REGISTRO DE FAMILIA
----------------------------------------------------*/

create or replace procedure sp_familia_update(v_codigo IN familia.codigo%type, v_descripcion IN familia.descripcion%type)
is
begin
    update familia set descripcion = upper(v_descripcion) where codigo = upper(v_codigo);
    dbms_output.put_line('Registro actualizado');
end;

--exec sp_familia_update('CO', 'CONGELADOS_MODIFICADO');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA ACTUALIZAR REGISTRO DE FAMILIA
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA ELIMINAR REGISTRO DE FAMILIA
----------------------------------------------------*/

create or replace procedure sp_familia_destroy(v_codigo IN familia.codigo%type)
is
begin
    delete from familia where codigo = upper(v_codigo);
    dbms_output.put_line('Registro eliminado');
end;

--exec sp_familia_destroy('CO');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA ELIMINAR REGISTRO DE FAMILIA
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA BUSCAR REGISTRO DE FAMILIA
----------------------------------------------------*/

create or replace procedure sp_familia_search(v_palabra IN varchar)
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

--exec sp_familia_search('ab');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA BUSCAR REGISTRO DE FAMILIA
----------------------------------------------------*/
/*----------------------------------------------------
PROCEDIMIENTO PARA BUSCAR SI EL CODIGO DE FAMILIA
TIENE PRODUCTO RELACIONADO.
----------------------------------------------------*/

create or replace procedure sp_familia_hasproduct( v_codigo_familia IN productos.codigo_familia%type)
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

--exec sp_familia_hasproduct('CO');

/*----------------------------------------------------
FIN PROCEDIMIENTO PARA BUSCAR SI EL CODIGO DE FAMILIA
TIENE PRODUCTO RELACIONADO.
----------------------------------------------------*/