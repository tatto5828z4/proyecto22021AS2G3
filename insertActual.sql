use sistemaRepartoBD;

INSERT INTO `sistemarepartobd`.`tipopermiso` (`nombreTipoPermiso`) VALUES ('Admin');
INSERT INTO `sistemarepartobd`.`tipopermiso` (`nombreTipoPermiso`) VALUES ('Invitado');
select * from tipopermiso;


INSERT INTO `sistemarepartobd`.`permisos` (`idPermiso`, `idTipoPermiso`, `ingresarUser`, `modificarUser`, `dbUsuario`, `consultarUser`, `ingresarCliente`, `modificarCliente`, `dbCliente`, `consultarCliente`, `ingresarDepartamento`, `modificarDepartamento`, `dbDepartamento`, `consultarDepartamento`, `ingresarPuesto`, `modificarPuesto`, `dbPuesto`, `consultarPuesto`, `ingresarPiloto`, `modificarPiloto`, `dbPiloto`, `consultarPiloto`, `ingresarEmpleado`, `modificarEmpleado`, `dbEmpleado`, `consultarEmpleado`, `ingresarPaqueteEncabezado`, `modificarPaqueteEncabezado`, `dbPaqueteEncabezado`, `consultarPaqueteEncabezado`, `ingresarPaqueteDetalle`, `modificarPaqueteDetalle`, `dbPaqueteDetalle`, `consultarPaqueteDetalle`, `insertarUbicacion`, `modificarUbicacion`, `dbubicacion`, `consultarUbicacion`, `insertarSububicacion`, `modificarSububicacion`, `dbSububicacion`, `consultarSububicacion`, `insertarBodega`, `modifcarBodega`, `dbBodega`, `consultarBodega`, `insertarInventario`, `modificarInventario`, `consultarInventario`, `consultarMovBodega`, `insertarTipoTransp`, `modificarTipoTransp`, `dbTipoTransp`, `consultarTipoTransp`, `insertarTransporte`, `modificarTransporte`, `dbTransporte`, `consultarTransporte`, `ingresarRuta`, `modificarRuta`, `dbRuta`, `consultarRuta`, `ingresarEnvio`, `modificarEnvio`, `dbEnvio`, `consultarEnvio`, `ingresarBT`, `modificarBT`, `consultaBT`, `consultaBU`, `ingresarCalificacion`, `consultaCalificacion`, `modificarCalificacion`, `reportes`) VALUES ('001', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1');
select * from permisos;

INSERT INTO `sistemarepartobd`.`usuario` (`idUser`, `idPermiso`, `nombreUsuario`, `passwordUsuario`, `estatusUsuario`) VALUES ('1010', '001', 'Usuario1', '123', 'A');
INSERT INTO `sistemarepartobd`.`usuario` (`idUser`, `idPermiso`, `nombreUsuario`, `passwordUsuario`, `estatusUsuario`) VALUES ('1011', '001', 'Usuario2', '123', 'A');
INSERT INTO `sistemarepartobd`.`usuario` (`idUser`, `idPermiso`, `nombreUsuario`, `passwordUsuario`, `estatusUsuario`) VALUES ('1012', '001', 'Usuario3', '123', 'A');
select * from usuario;

INSERT INTO `sistemarepartobd`.`cliente` (`idCliente`, `nombreCliente`, `apellidoCliente`, `telefonoCliente`, `correoCliente`, `direccionCliente`, `estatusCliente`) VALUES ('000001', 'Juan', 'apellido', '562555', 'juan@gmail.com', 'Ciudad', 'A');
INSERT INTO `sistemarepartobd`.`cliente` (`idCliente`, `nombreCliente`, `apellidoCliente`, `telefonoCliente`, `correoCliente`, `direccionCliente`, `estatusCliente`) VALUES ('000002', 'Daniel', 'apellido', '562555', 'juan@gmail.com', 'Ciudad', 'A');
INSERT INTO `sistemarepartobd`.`cliente` (`idCliente`, `nombreCliente`, `apellidoCliente`, `telefonoCliente`, `correoCliente`, `direccionCliente`, `estatusCliente`) VALUES ('000003', 'Brayan', 'Cifuentes', '1515', 'brayan@gmail.com', 'Ciudad', 'A');
INSERT INTO `sistemarepartobd`.`cliente` (`idCliente`, `nombreCliente`, `apellidoCliente`, `telefonoCliente`, `correoCliente`, `direccionCliente`, `estatusCliente`) VALUES ('000004', 'Josue', 'Zapata', '4545', 'jZpata@yahoo.com', 'CIudad', 'A');
select * from cliente;

INSERT INTO `sistemarepartobd`.`puesto` (`idPuesto`, `nombrePuesto`, `estatusPuesto`) VALUES ('1', 'Puesto1', 'A');
select * from puesto;

INSERT INTO `sistemarepartobd`.`departamento` (`idDepartamento`, `nombreDepartamentos`, `estatusDepartamento`) VALUES ('1', 'Depto1', 'A');
select * from departamento;

select * from piloto;
INSERT INTO `sistemarepartobd`.`piloto` (`idPiloto`, `dpiPiloto`, `idUser`, `nombrePiloto`, `apellidoPiloto`, `telefonoPiloto`, `direccionPiloto`, `sueldoPiloto`, `estatusPiloto`) VALUES ('1010', '123212', '1', 'Juan', 'Carlos', '45654', 'Ciudad', '5000', 'A');
INSERT INTO `sistemarepartobd`.`piloto` (`idPiloto`, `dpiPiloto`, `idUser`, `nombrePiloto`, `apellidoPiloto`, `telefonoPiloto`, `direccionPiloto`, `sueldoPiloto`, `estatusPiloto`) VALUES ('1011', '4565452', '2', 'Daniel', 'Álvarez', '45622', 'Ciudad', '4500', 'A');

select * from empleado;
INSERT INTO `sistemarepartobd`.`empleado` (`idEmpleado`, `dpiEmpleado`, `idUser`, `nombreEmpleado`, `apellidoEmpleado`, `telefonoEmpleado`, `direccionEmpledo`, `sueldoEmpleado`, `idDepartamentoEmpleado`, `idPuestoEmpleado`, `estatusEmpleado`) VALUES ('12', '12123', '1010', 'Empleado1', 'Apellido', '456545', 'Ciudad', '8000', '1', '1', 'A');
INSERT INTO `sistemarepartobd`.`empleado` (`idEmpleado`, `dpiEmpleado`, `idUser`, `nombreEmpleado`, `apellidoEmpleado`, `telefonoEmpleado`, `direccionEmpledo`, `sueldoEmpleado`, `idDepartamentoEmpleado`, `idPuestoEmpleado`, `estatusEmpleado`) VALUES ('13', '12123', '1011', 'Empleado2', 'Apellido', '456545', 'Ciudad', '8000', '1', '1', 'A');
INSERT INTO `sistemarepartobd`.`empleado` (`idEmpleado`, `dpiEmpleado`, `idUser`, `nombreEmpleado`, `apellidoEmpleado`, `telefonoEmpleado`, `direccionEmpledo`, `sueldoEmpleado`, `idDepartamentoEmpleado`, `idPuestoEmpleado`, `estatusEmpleado`) VALUES ('14', '12123', '1012', 'Empleado3', 'Apellido', '456545', 'Ciudad', '8000', '1', '1', 'A');

select * from paqueteEncabezado;
INSERT INTO `sistemarepartobd`.`paqueteEncabezado` (`idPaqueteEncabezado`, `idCliente`, `fechaRecepcion`, `fechaClienteEntrega`, `NombreRemitente`, `direccionRemitente`, `telefonoRemitente`, `cantidadPaquetes`, `idEmpleado`, `estatusPaqEncabezado`) VALUES ('1', '000001', '2021-08-12', '2021-08-15', 'Esteban', 'Ciudad ', '45654', '22' , '12', 'A');
INSERT INTO `sistemarepartobd`.`paqueteEncabezado` (`idPaqueteEncabezado`, `idCliente`, `fechaRecepcion`, `fechaClienteEntrega`, `NombreRemitente`, `direccionRemitente`, `telefonoRemitente`,`cantidadPaquetes`, `idEmpleado`, `estatusPaqEncabezado`) VALUES ('2', '000002', '2021-08-11', '2021-08-22', 'David', 'Ciudad', '3323332', '23', '13', 'A');

select * from paqueteDetallado;
INSERT INTO `sistemarepartobd`.`paqueteDetallado` (`idPaqueteEncabezado`, `idCliente`, `idEmpleado`, `idOrden`, `descripcionProducto`) VALUES ('1', '000001', '12', '0', '2 productos al Interior');
INSERT INTO `sistemarepartobd`.`paqueteDetallado` (`idPaqueteEncabezado`, `idCliente`, `idEmpleado`, `idOrden`, `descripcionProducto`) VALUES ('2', '000002', '13', '0', '10 productos traidos');

select * from ubicacion;
INSERT INTO `sistemarepartobd`.`ubicacion` (`idUbicacion`, `nombreUbicacion`, `estatusUbicacion`) VALUES ('1', 'Guatemala', 'A');
INSERT INTO `sistemarepartobd`.`ubicacion` (`idUbicacion`, `nombreUbicacion`, `estatusUbicacion`) VALUES ('2', 'México', 'A');
INSERT INTO `sistemarepartobd`.`ubicacion` (`idUbicacion`, `nombreUbicacion`, `estatusUbicacion`) VALUES ('3', 'EEUU', 'A');

select * from subUbicacion;
INSERT INTO `sistemarepartobd`.`subUbicacion` (`idSububicacion`, `nombreSubUbicacion`, `estatusSubUbicacion`) VALUES ('1', 'Zona 5', 'A');
INSERT INTO `sistemarepartobd`.`subUbicacion` (`idSububicacion`, `nombreSubUbicacion`, `estatusSubUbicacion`) VALUES ('2', 'Zona 10', 'A');
INSERT INTO `sistemarepartobd`.`subUbicacion` (`idSububicacion`, `nombreSubUbicacion`, `estatusSubUbicacion`) VALUES ('3', 'Zona 15 ', 'A');
INSERT INTO `sistemarepartobd`.`subUbicacion` (`idSububicacion`, `nombreSubUbicacion`, `estatusSubUbicacion`) VALUES ('4', 'Yucatán', 'A');
INSERT INTO `sistemarepartobd`.`subUbicacion` (`idSububicacion`, `nombreSubUbicacion`, `estatusSubUbicacion`) VALUES ('5', 'New York', 'A');

select * from bodega;
INSERT INTO `sistemarepartobd`.`bodega` (`idBodega`, `idUbicacionBodega`, `idSububicacionBodega`, `estatusBodega`) VALUES ('100', '1', '2','A');

/*Pendiente Inventario*/

/**/

