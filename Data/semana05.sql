use Neptuno

GO
ALTER PROC [dbo].[USP_FECHAFECHA]
	@Fec1 DATETIME,
	@Fec2 DATETIME
AS
BEGIN
	SELECT IdPedido,
	   IdCliente,
	   IdEmpleado,
	   FechaPedido,
	   FechaEntrega,
	   FechaEnvio,
	   FormaEnvio,
	   Cargo,
	   Destinatario,
	   CiudadDestinatario,
	   RegionDestinatario,
	   CodPostalDestinatario,
	   PaisDestinatario
	FROM Pedidos
	WHERE FechaEnvio BETWEEN @Fec1 AND @Fec2
END

EXEC [dbo].USP_FECHAFECHA @Fec1 = '1990-01-01', @Fec2 = '2020-01-01'

GO
CREATE PROC [dbo].[USP_GetDetallePedidos]
	@IdPedido INT
AS
BEGIN
	SELECT idpedido,
		   idproducto,
		   preciounidad,
		   cantidad,
		   descuento
	FROM detallesdepedidos
	WHERE idpedido = @IdPedido
END

EXEC [dbo].USP_GetDetallePedidos @IdPedido = 10250

select * from detallesdepedidos