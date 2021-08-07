drop database sistemaRepartoBD;
create database sistemaRepartoBD;
use sistemaRepartoBD;

create table permisos(
	idPermiso varchar(10) primary key,
	tipoPermiso varchar(60),
	ingresarUser boolean, 
	modificarUser boolean, 
	eliminarUser boolean, 
	consultarUser boolean,
    ingresarUserTipo boolean, 
	modificarUserTipo boolean, 
	eliminarUserTipo boolean, 
	consultarUserTipo boolean,
    ingresarCliente boolean,
    modificarCliente boolean,
    eliminarCliente boolean,
    consultarCliente boolean,
    ingresarDepartamento boolean,
	modificarDepartamento boolean,
	eliminarDepartamento boolean,
	consultarDepartamento boolean,
    ingresarPuesto boolean,
    modificarPuesto boolean,
    eliminarPuesto boolean,
    consultarPuesto boolean, 
	ingresarEmpleado boolean,
	modificarEmpleado boolean,
	eliminarEmpleado boolean,
	consultarEmpleado boolean,
    ingresarTipoEmpleado boolean,
    modificarTipoEmpleado boolean,
    eliminarTipoEmpleado boolean,
    consultarTipoEmpleado boolean,
    ingresarPaqueteEncabezado boolean,
    modificarPaqueteEncabezado boolean,
    eliminarPaqueteEncabezado boolean,
    consultarPaqueteEncabezado boolean,
    ingresarPaqueteDetalle boolean,
    modificarPaqueteDetalle boolean,
    eliminarPaqueteDetalle boolean,
    consultarPaqueteDetalle boolean,
    insertarUbicacion boolean,
    modificarUbicacion boolean,
    eliminarUbicacion boolean,
    consultarUbicacion boolean,
    insertarSububicacion boolean,
    modificarSububicacion boolean,
    eliminarSububicacion boolean,
    consultarSububicacion boolean,
    insertarBodega boolean,
    modifcarBodega boolean,
    eliminarBodega boolean,
    consultarBodega boolean,
    insertarInventario boolean,
    modificarInventario boolean,
    eliminarInventario boolean,
    consultarInventario boolean,
    insertarTipoMov boolean,
    modificarTipoMov boolean,
    eliminarTipoMov boolean,
    consultarTipoMov boolean,
    insertarMovBodega boolean,
    modificarMovBodega boolean,
    eliminarMovBodega boolean,
    consultarMovBodega boolean,
    insertarTipoTransp boolean,
    modificarTipoTransp boolean,
    eliminarTipoTransp boolean,
    consultarTipoTransp boolean,
    insertarTransporte boolean,
    modificarTransporte boolean,
    eliminarTransporte boolean,
    consultarTransporte boolean,
    ingresarRuta boolean,
    modificarRuta boolean,
    eliminarRuta boolean,
    consultarRuta boolean,
    ingresarEnvio boolean,
    modificarEnvio boolean,
    eliminarEnvio boolean,
    consultarEnvio boolean
) engine = InnoDB default char set latin1;

create table usuario(
	idUser varchar(10) primary key not null,
	idPermiso varchar(10) not null,
	nombreUsuario varchar(60) not null,
	passwordUsuario varchar(60) not null,
    estatusUsuario char(1) not null,
	foreign key (idPermiso) references permisos(idPermiso)
) engine = InnoDB default char set latin1;

create table cliente(  
	idCliente varchar(10) primary key not null,
    nombreCliente varchar(30) not null,
    apellidoCliente varchar(30) not null,
    telefonoCliente varchar(15) not null,
    correoCliente varchar(50) not null,
    direccionCliente varchar(80) not null,
    estatusCliente char(1) not null
) engine = InnoDB default char set latin1;

/*create table tipoEnvio(
	idTipoEnvio varchar(10) primary key,
    nombreTipoEnvio varchar(35),
    estatusTipoEnvio char(1)
) engine = InnoDB default char set latin1;*/

create table departamento(
	idDepartamento varchar(10) primary key not null,
    nombreDepartamentos varchar(35) not null,
    estatusDepartamento char(1) not null
) engine = InnoDB default char set latin1;

create table puesto(
	idPuesto varchar(10) primary key not null,
    nombrePuesto varchar(35) not null,
    estatusPuesto char(1) not null
) engine = InnoDB default char set latin1;

create table tipoEmpleado(
	idTipoEmpleado varchar(10) primary key not null,
    nombreTipoEmpleado varchar(35) not null,
	estatusTipoEmpleado char(1) not null
) engine = InnoDB default char set latin1;

create table empleado(
	idEmpleado varchar(10) primary key not null,
    dpiEmpleado varchar(13) not null,
    idUser varchar(10) not null,
    nombreEmpleado varchar(30) not null,
    apellidoEmpleado varchar(30) not null,
    telefonoEmpleado varchar(15) not null,
    direccionEmpledo varchar(80) not null,
    sueldoEmpleado float not null,
    /*foreign key*/
    idTipoEmpleado varchar(10) not null,
    idDepartamentoEmpleado varchar(10) not null,
    idPuestoEmpleado varchar(10) not null,
    estatusEmpleado char(1) not null,
    
    foreign key (idUser) references usuario (idUser),
    foreign key (idTipoEmpleado) references tipoEmpleado(idTipoEmpleado),
    foreign key (idDepartamentoEmpleado) references departamento(idDepartamento),
    foreign key (idPuestoEmpleado) references puesto(idPuesto)
) engine = InnoDB default char set latin1;

/*
create table empresa(
	idEmpresa varchar(10) primary key not null,
    nombreEmpresa varchar(35) not null,
    direccionEmpresa varchar(80) not null,
    estatusEmpresa char(1) not null
) engine = InnoDB default char set latin1;

create table proveedor(
	idProveedor varchar(10) primary key not null,
    nombreProveedor varchar(35) not null,
    telefonoProveedor varchar(15) not null,
    -- direccionProveedor varchar(80) not null,
    estatusProveedor char(1) not null,
    
    /*foreign key
    idEmpresaProveedor varchar(10) not null,
    foreign key (idEmpresaProveedor) references empresa (idEmpresa)
) engine = InnoDB default char set latin1;*/
/*create table producto(
	idProducto varchar(10) primary key not null,
    nombreProducto varchar(35) not null,
    precioProducto float not null
) engine = InnoDB default char set latin1;*/

create table paqueteEncabezado(
	idPaqueteEncabezado varchar(10) not null, 
    idCliente varchar(10) not null,
    fechaRecepcion datetime,
    fechaClienteEntrega date,
    NombreRemitente varchar(35),
    direccionRemitente varchar(80),
    telefonoRemitente varchar(15),
    estatusPaqEncabezado char(1),
    primary key(idPaqueteEncabezado, idCliente),
    /* foreign key */
    foreign key (idCliente) references cliente(idCliente)
) engine = InnoDB default char set latin1;

create table paqueteDetallado(
	idPaqueteEncabezado varchar(10) not null, 
    idCliente varchar(10) not null,
    idOrden int auto_increment not null,
    descripcionProducto varchar(80) not null,
    
    primary key (idOrden, idPaqueteEncabezado, idCliente),
    -- foreign keys
    foreign key (idPaqueteEncabezado) references paqueteEncabezado(idPaqueteEncabezado),
    foreign key (idCliente) references cliente(idCliente)
) engine = InnoDB default char set latin1;

/*create table paqueteDetalle(
	idPaqueteEncabezado varchar(10) not null,
    idCliente varchar(10) not null,
    idOrdenPaquete int auto_increment not null,
    idProducto varchar(10) not null,
    cantidad varchar(10) not null
) engine = InnoDB default char set latin1;*/

create table ubicacion(
	idUbicacion varchar(10) primary key not null,
    nombreUbicacion varchar(35) not null,
    estatusUbicacion char(1) not null
) engine = InnoDB default char set latin1;

create table subUbicacion(
	idSububicacion varchar(10) primary key not null,
    nombreSubUbicacion varchar(35) not null,
    estatusSubUbicacion char(1) not null
) engine = InnoDB default char set latin1;

create table bodega(
	idBodega varchar(10) not null,
    /*foreign key*/
    idUbicacionBodega varchar(10) not null,
    idSububicacionBodega varchar(10) not null,
    /*Llave compuesta paquete*/
    idPaquete varchar(10) not null, 
    idCliente varchar(10) not null,
    
    primary key (idBodega, idUbicacionBodega, idSububicacionBodega, idPaquete, idCliente),
    
    estatusBodega char(1) not null,
    /*foreign key*/
    foreign key (idUbicacionBodega) references ubicacion(idUbicacion),
    foreign key (idSububicacionBodega) references subUbicacion(idSububicacion),
	foreign key (idPaquete) references paqueteEncabezado(idPaqueteEncabezado),
    foreign key (idCliente) references cliente(idCliente)
) engine = InnoDB default char set latin1;

create table inventario(     
	idInventario varchar(10) primary key not null,
    /*foreign key*/
    idBodegaI varchar(10) not null, /*campo que conforma llave compuesta de bodega*/
    idUbicacionBodega varchar(10) not null,
    idSububicacionBodega varchar(10) not null,
	idPaquete varchar(10) not null, /*campo que conforma llave compuesta de bodega*/
    idCliente varchar(10) not null, /*campo que conforma llave compuesta de bodega*/
    
    cantidadInventario float not null,
    fechaIngresoInventario datetime not null,
    /*foreign key*/
    foreign key (idBodegaI) references bodega (idBodega),
	foreign key (idUbicacionBodega) references ubicacion(idUbicacion),
    foreign key (idSububicacionBodega) references subUbicacion(idSububicacion),
    foreign key (idPaquete) references paqueteEncabezado (idPaqueteEncabezado),
    foreign key (idCliente) references cliente(idCliente)
) engine = InnoDB default char set latin1;

/*Pedido que va a hacer el cliente al empleado*/
/*
create table pedidoEncabezado(
	idPedidoEncabezado varchar(10) not null,
    /*foreign key
	idProveedorPE varchar(10) not null,
    idEmpleadoPE varchar(10) not null,
    direccionRealizacionPE varchar(80) not null,         -- Direccion de donde se emite el pedido
    direccionEnvioPE varchar(80) not null,     -- Direccion a donde sera enviado el producto
    fechaPE datetime not null,
    totalPE float not null,
    totalEnvioPE float not null,
    
    estatusPE char(1) not null,
    primary key (idPedidoEncabezado, idProveedorPE,idEmpleadoPE),
    
    /*foreign key
    foreign key (idEmpleadoPE) references empleado(idEmpleado),
    foreign key (idProveedorPE) references proveedor(idProveedor)
) engine = InnoDB default char set latin1;

create table pedidoDetalle(
	idPedidoDetalle varchar(10) not null,
    idProveedorPD varchar(10) not null,
    idEmpleadoPD varchar(10) not null,
    idProductoPD varchar(10) not null,
    ordenPD int auto_increment,
    cantidadPD int not null,
    precioPD float not null,
    subtotalPD float not null,
    
    -- primary key (ordenPedidoDetalle, idPedidoDetalle, idClientePedidoDetalle, idEmpleadoPedidoDetalle, idProductoPedidoDetalle),
    primary key (ordenPD, idPedidoDetalle, idProveedorPD, idEmpleadoPD, idProductoPD),
    
    /*foreign key
    foreign key (idPedidoDetalle) references pedidoEncabezado (idPedidoEncabezado),
    foreign key (idProveedorPD) references proveedor (idProveedor),
    foreign key (idEmpleadoPD) references empleado(idEmpleado),
    foreign key (idProductoPD) references producto(idProducto)
) engine = InnoDB default char set latin1;

create table facturaEncabezado(
	idFactEncabezado varchar(10) not null,
    idClienteFactEncabezado varchar(10) not null,
    idEmpleadoFactEncabezado varchar(10) not null,
    fechaFactEncabezado datetime not null,
    direccionPagoFacEncabezado varchar(80) not null,
    estatusFactura char(1) not null,
    totalFactura float not null,
    
    /*primary keys
    primary key (idFactEncabezado, idClienteFactEncabezado, idEmpleadoFactEncabezado),
    
    /*foreign keys
    foreign key (idClienteFactEncabezado) references cliente(idCliente),
    foreign key (idEmpleadoFactEncabezado) references empleado(idEmpleado)
) engine = InnoDB default char set latin1;

create table facturaDetalle(
	idFactEncFD varchar(10) not null,
    idClienteFactEncFD varchar(10) not null,
    idEmpleadoFactEncFD varchar(10) not null,
    idOrdenFacturaDetalle int auto_increment,
    idProductoFD varchar(10) not null,
    cantidadDF int not null,
    subtotalFD float not null,

    /*Primary key
    primary key (idOrdenFacturaDetalle, idFactEncFD, idClienteFactEncFD, idEmpleadoFactEncFD, idProductoFD),
    
    /*FK
    foreign key (idClienteFactEncFD) references cliente (idCliente),
    foreign key (idEmpleadoFactEncFD) references empleado (idEmpleado),
    foreign key (idProductoFD) references producto (idProducto)
) engine = InnoDB default char set latin1;*/

create table tipoMovimiento(
	idTipoMov varchar(10) primary key not null,
    nombreTipoMov varchar(35) not null,
    estatusTipoMov char(1) not null
) engine = InnoDB default char set latin1;

/*Movimientos de bodega, --Abastecer/Desabastecer*/
create table movimientoBodega(
	idMovBodega varchar(10) primary key not null,
    idBodega varchar(10) not null,
    idUbicacionBodega varchar(10) not null,
    idSububicacionbodega varchar(10) not null,
    idPaquete varchar(10) not null,
    idCliente varchar(10) not null,
    
    idEmpleadoMB varchar(10) not null,
    idInventarioMB varchar(10) not null,       -- para que descuente/ sume en inventario, tambien a bodega
    idTipoMovMB varchar(10) not null,          -- carga
    fechaHoraMB datetime not null,             -- fecha/hora de realizacion de movimiento (carga/descarga)
    
    foreign key (idBodega) references bodega(idBodega),
    foreign key (idUbicacionBodega) references ubicacion(idUbicacion),
    foreign key (idSububicacionBodega) references subUbicacion(idSububicacion),
	foreign key (idPaquete) references paqueteEncabezado(idPaqueteEncabezado),
    foreign key (idCliente) references cliente(idCliente),
    
    foreign key (idEmpleadoMB) references empleado (idEmpleado),
    foreign key (idInventarioMB) references inventario (idInventario), 
    foreign key (idTipoMovMB) references tipoMovimiento (idTipoMov)
    
) engine = InnoDB default char set latin1;

create table tipoTransporte(
	idTipoTransporte varchar(10) primary key not null,
    nombreTipoTransporte varchar(35) not null,
    estatusTipoTransporte char(1) not null
) engine = InnoDB default char set latin1;

create table transporte(
	idTransporte varchar(10) primary key not null,
    nombreTransporte varchar(35) not null,
    idTipoTransporte varchar(10) not null,  -- foránea
    placaTransporte varchar(10) not null,
    colorTransporte varchar(35) not null,
    noChasisTransporte varchar(35) not null,
    modeloTransporte int not null,
    marcaTransporte varchar(35) not null,
    propietarioTransporte varchar(35) not null,
    estatusTransporte char(1) not null,
    
    /*foreign key*/
    foreign key (idTipoTransporte) references tipoTransporte (idTipoTransporte)
) engine = InnoDB default char set latin1;

create table ruta(
	idRuta varchar(10) primary key not null,
    inicioRuta varchar(80) not null,
    finalRuta varchar(80) not null,
    estatusRuta char(1) not null
) engine = InnoDB default char set latin1;

create table envio(
	idEmpleadoE varchar(10) not null,          -- piloto
    idOrdenE int auto_increment not null,
    idTransporteE varchar(10) not null,
    idRutaE varchar(10) not null,
	idMovBodegaE varchar(10) not null,
    fechaE datetime not null,
    estatusE char(1) not null,
    primary key (idOrdenE, idEmpleadoE, idTransporteE, idRutaE, idMovBodegaE),
    -- foreign key
    foreign key (idEmpleadoE) references empleado(idEmpleado),
    foreign key (idTransporteE) references transporte(idTransporte),
    foreign key (idRutaE) references ruta(idRuta)
) engine = InnoDB default char set latin1;
/*
-------- pendiente --------------
-- bitacora de transporte       ya
-- bitacora de usuario          ya 
-- usuarios (Permisos)           ya
-- calificacion
*/

create table bitacoraTransporte(
	idBitacora int primary key auto_increment not null,
    idTransporte varchar(10) not null,
    idEmpleado varchar(10) not null,
    kmInicial double not null,
    KmFinal double not null,
    fechaSalida date not null,
    fechaEntrada date not null,
    horaSalida time not null,
    horaEntrada time not null,
    lugarSalida varchar(35) not null,
    lugarLlegada varchar(35) not null,
    nivelGasolina varchar(35) not null,
    
    -- foreign key
    foreign key (idTransporte) references transporte(idTransporte),
    foreign key (idEmpleado) references empleado(idEmpleado)
) engine = InnoDB default char set latin1;

create table bitacoraUsuario(
	idBitacoraUsuario int primary key auto_increment not null,
    idUser varchar(10) not null,
    accionRealizada varchar(50),
    fechaIngreso date,
    fechaSalida date,
    horaEntrada datetime,
    horaSalida datetime,
    sesiones int,
    
    foreign key (idUser) references usuario(idUser)
) engine = InnoDB default char set latin1;