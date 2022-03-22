--	DATABASE DEL VAKSIN	--

CREATE DATABASE DEL_VAKSIN;

USE DEL_VAKSIN

CREATE TABLE Akun(
	username VARCHAR(32) PRIMARY KEY,
	pass VARCHAR(32),
	roll VARCHAR(16)
);

CREATE TABLE Vaksin(
	ID_vaksin VARCHAR(16) PRIMARY KEY,
	nama VARCHAR(32),
	status INT
);

CREATE TABLE Regis_Vaksin(
	ID_vaksin VARCHAR(16) PRIMARY KEY,
	nama VARCHAR(32),
	status INT
);

CREATE TABLE Vaksin_Veried(
	ID_vaksin VARCHAR(16) PRIMARY KEY,
	NIK VARCHAR(16),
	nama_perawat VARCHAR(16)
);

CREATE TABLE Penduduk(
	NIK VARCHAR(16) PRIMARY KEY,
	nama VARCHAR(32),
	umur INT,
	alamat vARCHAR(64),
	jenis_kelamin VARCHAR(1),
	username VARCHAR(32),
	pass VARCHAR(32),
	profil VARCHAR(128),
	status INT,
);

INSERT INTO Akun VALUES('produsen','produsen123','Produsen'),
					   ('rumahsakit', 'rumahsakit123', 'RumahSakit'),
					   ('badanpom', 'badanpom123', 'BadanPom'),
					   ('pemerintah', 'pemerintah123', 'Pemerintah');
					   
INSERT INTO Vaksin VALUES('if310io', 'gt-10', 0),
						 ('if311io', 'gt-11', 0),
						 ('if312io', 'gt-12', 0),
						 ('if313io', 'gt-13', 0),
						 ('if314io', 'gt-14', 0),
						 ('if315io', 'gt-15', 0),
						 ('if316io', 'gt-16', 0),
						 ('if317io', 'gt-17', 0),
						 ('if318io', 'gt-18', 0),
						 ('if319io', 'gt-19', 0),
						 ('if320io', 'gt-20', 0),
						 ('if321io', 'gt-21', 0),
						 ('if322io', 'gt-22', 0),
						 ('if323io', 'gt-23', 0),
						 ('if324io', 'gt-24', 0),
						 ('if325io', 'gt-25', 0),
						 ('if326io', 'gt-26', 0),
						 ('if327io', 'gt-27', 0),
						 ('if328io', 'gt-28', 0),
						 ('if329io', 'gt-29', 0),
						 ('if330io', 'gt-30', 0),
						 ('if331io', 'gt-31', 0),
						 ('if332io', 'gt-32', 0),
						 ('if333io', 'gt-33', 0),
						 ('if334io', 'gt-34', 0);

INSERT INTO Penduduk VALUES('1212012606010001', 'Leonardo Siagian', 19, 'Balige', 'L', 'leo', 'leo', 'cowok.jpg', 0),
						   ('1212012606010002', 'Putri Sitompul', 20, 'Jorlang Hataran', 'P', 'putri', 'putri', 'cewek.jpg', 0),
						   ('1212012606010003', 'Madelin Panjaitan', 20, 'Silaen', 'P', 'madelin', 'madelin', 'cewek.jpg', 0),
						   ('1212012606010004', 'Mia A Gultom', 20, 'Pangaribuan', 'P', 'mia', 'mia', 'cewek.jpg', 0),
						   ('1212012606010005', 'Pratiwi Sibarani', 20, 'Laguboti', 'P', 'pratiwi', 'pratiwi', 'cewek.jpg', 0),
						   ('1212012606010006', 'Suryanto Panjaitan', 20, 'Soposurung', 'L', 'anto', 'anto', 'cowok.jpg', 0);

