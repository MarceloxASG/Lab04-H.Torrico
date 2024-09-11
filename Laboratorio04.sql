CREATE PROC USP_ListarProductos
AS
BEGIN
SELECT*FROM productos
END


CREATE PROC USP_ListarCategorias
AS
BEGIN
SELECT*FROM categorias
END


CREATE PROC USP_ListarProveedores
AS
BEGIN
SELECT*FROM proveedores
END


-- Esto para los proveedores
ALTER PROC USP_ListarProveedores
    @NombreContacto VARCHAR(50) = NULL,
    @Ciudad VARCHAR(50) = NULL
AS
BEGIN
    SELECT * FROM proveedores
    WHERE 
        (@NombreContacto IS NULL OR nombrecontacto LIKE '%' + @NombreContacto + '%') AND
        (@Ciudad IS NULL OR ciudad LIKE '%' + @Ciudad + '%');
END;

EXEC USP_ListarProveedores
    @NombreContacto = 'Yoshi Nagase',
    @Ciudad = 'Tokyo';

USP_ListarProveedores 'Yoshi',''

SELECT * FROM proveedores



    -- Esto para los pedidos
CREATE PROCEDURE USP_ListarPedidos
    @FechaPedido DATE,
    @FechaEntrega DATE
AS
BEGIN
    SELECT * FROM Pedidos p
    INNER JOIN Pedidos dp ON p.IdPedido = dp.IdPedido
    WHERE p.FechaPedido BETWEEN @FechaPedido AND @FechaEntrega;
END;

EXEC USP_ListarPedidos
    @FechaPedido = '1994-08-04',
    @FechaEntrega = '1994-08-12';

SELECT * FROM Pedidos