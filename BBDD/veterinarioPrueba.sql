CREATE DATABASE VETERINARIO_JUPAR;
use VETERINARIO_JUPAR;

CREATE TABLE t_USUARIOS(
	DNI varchar(20) PRIMARY KEY,
	password varchar(250) NOT NULL,
	Nombre varchar(50) NOT NULL ,
	Apellidos varchar(100),
	Sexo varchar(10),
	Edad Tinyint,
	email varchar(75) NOT NULL,
    mascota varchar(20) UNIQUE
);

ALTER TABLE t_USUARIOS add
CONSTRAINT ch_Sexo CHECK (Sexo='Hombre' OR Sexo='Mujer');

CREATE TABLE t_VETERINARIOS(	
	DNI varchar(20) PRIMARY KEY,
	Nombre varchar(25) NOT NULL,
	Apellidos varchar(50),
	email varchar(75) NOT NULL,
	Movil varchar(15) NOT NULL,
    Campo varchar (20) NOT NULL
);

ALTER TABLE t_VETERINARIOS add
CONSTRAINT CH_Campo CHECK (Campo='General' OR Campo='Dermatologia' OR Campo='Dermatologia' OR Campo='Cardiología ' OR Campo='Neurología'  OR Campo='Operaciones');

CREATE TABLE t_MASCOTAS(	
	Chip varchar(50) PRIMARY KEY,
	Nombre varchar(25),
	Raza varchar(25),
	Edad Tinyint,
	Genero varchar(10),
	VeterinarioPersonal varchar(20) NOT NULL
);

ALTER TABLE t_MASCOTAS add
CONSTRAINT ch_Raza CHECK (Raza='Canina' OR Raza='Felina' OR Raza='Otra');
ALTER TABLE t_MASCOTAS add
CONSTRAINT ch_Genero CHECK (Genero='Macho' OR Genero='Hembra');

ALTER TABLE t_USUARIOS add
CONSTRAINT fk_mascota FOREIGN KEY (mascota) REFERENCES t_MASCOTAS (Chip)
on update cascade;
ALTER TABLE t_MASCOTAS add
CONSTRAINT fk_Veterinario FOREIGN KEY (VeterinarioPersonal) REFERENCES t_VETERINARIOS (DNI)
on update cascade;

CREATE tABLE t_ADOPCIONES(
    id_Adoptar int() PRIMARY KEY,
    Nombre varchar(20) ,
    Edad int(),
    Sexo varchar(20)
;)

CREATE TABLE t_CITAS(
	ID_Citas varchar(100) PRIMARY KEY,
	Veterinario_Cita varchar(20),
	Mascota_Cita varchar(50),
	Fecha varchar(50) NOT NULL,
	Hora varchar(10) NOT NULL,
	Concepto varchar(100)
);

ALTER TABLE t_CITAS add
CONSTRAINT fk_VeterinarioCita FOREIGN KEY (Veterinario_Cita) REFERENCES t_VETERINARIOS (DNI);
ALTER TABLE t_CITAS add
CONSTRAINT fk_MascotaCita FOREIGN KEY (Mascota_Cita) REFERENCES t_MASCOTAS (Chip);

-- Insertar valores en las tablas
INSERT INTO t_VETERINARIOS VALUES
('20000000A', 'Jesus', 'Garrido', 'yisus@gmail.com', '600000000', 'General'),
('20000001A', 'Juan', 'Fernandez', 'ferxo11@gmail.com', '600000001', 'Dermatologia'),
('20000002A', 'Jimena', 'Guti', 'jime69@gmail.com', '600000002', 'Cardiología'),
('20000003A', 'Maria', 'DelaRosa', 'merisous@gmail.com', '600000003', 'Neurología');

INSERT INTO t_MASCOTAS VALUES
('A1111111', 'Luno', 'Canino', '3', 'Macho', '20000000A'),
('B1111111', 'Mika', 'Canino', '7', 'Hembra', '20000001A'),
('C1111111', 'Cosix', 'Canino', '2', 'Macho', '20000002A'),
('D1111111', 'Tedy', 'Felino', '10', 'Macho', '20000003A');
 

INSERT INTO t_USUARIOS VALUES
('00000000A', '1234', 'Jefe', 'Jefazo', 'Hombre', '50', 'jefemanda@gmail.com', 'A1111111'), 
('11111110A', '1234', 'Pepa', 'Rodríguez', 'Mujer', '57', 'pepita77@gmail.com', 'B1111111'), 
('11111111A', '1234', 'Manuel', 'Ros', 'Hombre', '41', 'manuros@gmail.com', 'C1111111'), 
('11111112A', '1234', 'Rosa', 'Alvarez', 'Mujer', '37', 'rosa644@gmail.com', 'D1111111');


INSERT INTO t_CITAS VALUES
('11111111', '20000000A', 'B1111111', '27/02/2020', '16:00', 'Revision para parto inminente'),
('11111112', '20000000A', 'D1111111', '21/12/2020', '17:00', 'Revision general rudimentaria'),
('11111113', '20000002A', 'C1111111', '14/02/2020', '08:00', 'Inyeccion contra posibles parasitos'),
('11111114', '20000001A', 'A1111111', '10/03/2020', '10:00', 'Revision general');

INSERT INTO t_ADOPCIONES VALUES
('1' 'Lolo', '2', 'macho'),
('2' 'Boby', '1', 'hembra'),
('3' 'Lula', '3', 'hembra'),
('4' 'Toreto', '2', 'macho'),
('5' 'Chispa', '1', 'hembra'),