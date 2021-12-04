

/**************************************************************************************************************
***************************************************************************************************************
CREACION DE LA BASE DE DATOS
***************************************************************************************************************
***************************************************************************************************************/
GO
CREATE DATABASE CrudApi 
GO

	USE CrudApi
	/**************************************************************************************************************
	TABLA [DOCUMENTO]
	***************************************************************************************************************/
	IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DOCUMENTO]') AND type in (N'U'))
	BEGIN
	CREATE TABLE [dbo].[DOCUMENTO](
		[ID] [int] NOT NULL IDENTITY(1, 1) ,
		[NOMBRE] [varchar](100) NOT NULL,
	 CONSTRAINT [PK_DOCUMENTO] PRIMARY KEY  CLUSTERED 
	(
		[ID] ASC
	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	END

	/**************************************************************************************************************
	TABLA [ESTADOCIVIL]
	***************************************************************************************************************/
	IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESTADOCIVIL]') AND type in (N'U'))
	BEGIN
	CREATE TABLE [dbo].[ESTADOCIVIL](
		[ID] [int] NOT NULL IDENTITY(1, 1) ,
		[NOMBRE] [varchar](100) NOT NULL,
	 CONSTRAINT [PK_ESTADOCIVIL] PRIMARY KEY  CLUSTERED 
	(
		[ID] ASC
	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	END
	

	/**************************************************************************************************************
	TABLA [EMPLEADO]
	***************************************************************************************************************/
	IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMPLEADO]') AND type in (N'U'))
	BEGIN
	CREATE TABLE [dbo].[EMPLEADO](
		[ID] [int] NOT NULL IDENTITY(1, 1) ,
		[NOMBRES] [varchar](100) NOT NULL,
		[APELLIDOS] [varchar](100) NOT NULL,
		[IDTIPODOCUMENTO] INT NOT NULL,
		[FECHANACIMIENTO] datetime NOT NULL,
		[VALORAGANAR] [varchar](100)NOT NULL,	
		[IDESTADOCIVIL] INT NOT NULL,
	 CONSTRAINT [PK_EMPLEADO] PRIMARY KEY  CLUSTERED 
	(
		[ID] ASC
	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	END
	

	/**************************************************************************************************************
	LLAVE FORANEA [FK_EMPLEADO_DOCUMENTO]
	
	***************************************************************************************************************/

	IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_DOCUMENTO]')
	AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
	ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_DOCUMENTO] FOREIGN KEY([IDTIPODOCUMENTO])
	REFERENCES [dbo].[DOCUMENTO] ([ID])
	
	/**************************************************************************************************************
	LLAVE FORANEA [FK_EMPLEADO_ESTADOCIVIL]
	
	***************************************************************************************************************/

	IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_ESTADOCIVIL]')
	AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
	ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_ESTADOCIVIL] FOREIGN KEY([IDESTADOCIVIL])
	REFERENCES [dbo].[ESTADOCIVIL] ([ID])

	insert into DOCUMENTO   values 
	 ('Tarjeta de Identidad'), ('Cédula de Ciudadanía')
	 insert into ESTADOCIVIL   values 
	 ('Soltero'), ('Casado')


