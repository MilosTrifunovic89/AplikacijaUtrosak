create database Wood

use Wood

create table LagerLista
(
	MaterijalID bigint primary key not null identity(1,1),
	NazivMaterijala nvarchar(50) not null,
	Duzina int not null,
	Sirina int not null,
	Debljina int not null,
	PovrsinaTable float,
	StanjePovrsina float,
	StanjeBrTabli int,
	Vrsta nvarchar(50) not null,
	Cena money,
	Tekstura bit,
	
	check (Vrsta ='IVERICA' or Vrsta ='MDF' or Vrsta='Lesonit')
)

create table KantTraka
(
	KantTrakaID bigint primary key not null identity(1,1),
	NazivKantTrake nvarchar(50) not null,
	Sirina int not null,
	Debljina float not null,
	Vrsta nvarchar(50) not null,
	Stanje int,
	Cena money,
	
	check (Vrsta='ABS' or Vrsta='MELAMIN')
)

create table Okov
(
	OkovID bigint primary key not null identity(1,1),
	NazivOkova nvarchar(50) not null,
	JedinicaMere nvarchar(10),
	Stanje float,
	Cena money
)

create table Sastavnica
(
	SastavnicaID bigint primary key not null identity(1,1),
	NazivSastavnice nvarchar(50),
)

create table SastavnicaOkov
(
	SastavnicaID bigint not null references Sastavnica(SastavnicaID),
	OkovID bigint not null references Okov(OkovID),
	Kolicina float not null,
	constraint PK_SastavnicaOkov primary key (SastavnicaID, OkovID)
)

create table SastavnicaKantTraka
(
	SastavnicaID bigint not null references Sastavnica(SastavnicaID),
	KantTrakaID bigint not null references KantTraka(KantTrakaID),	
	Kolicina float not null,
	constraint PK_SastavnicaKantTraka primary key (SastavnicaID, KantTrakaID)
)

create table SastavnicaMaterijal
(
	SastavnicaID bigint not null references Sastavnica(SastavnicaID),
	MaterijalID bigint not null references LagerLista(MaterijalID),	
	Kolicina float not null,
	constraint PK_SastavnicaMaterijal primary key (SastavnicaID, MaterijalID)
)

create table Prodavac
(
	ProdavacID bigint primary key not null identity(1,1),
	Ime nvarchar(50) not null check (upper(Ime) = Ime collate Latin1_General_BIN2),
	Prezime nvarchar(50) not null check (upper(Prezime) = Prezime collate Latin1_General_BIN2),
	Sifra nvarchar(50) not null check (upper(Sifra) = Sifra collate Latin1_General_BIN2),
)

create table GotovProizvod
(
	ProizvodID bigint primary key not null,
	Naziv nvarchar(50) not null,
	Dimenzije nvarchar(50) not null,
	PlanskaCena money not null,
	Tip nvarchar(20) not null,
	UkupnaCena money not null,
	
	SastavnicaID bigint foreign key references Sastavnica(SastavnicaID),
	ProdavacID bigint foreign key references Prodavac(ProdavacID),
	
	check (Tip='TENDER' or Tip='OBICNA SIFRA')
)

create table Kupac
(
	KupacID bigint primary key not null identity(1,1),
	Tip nvarchar(50) not null,
	ProdavacID bigint foreign key references Prodavac(ProdavacID),
	
	check (tip='PRAVNO LICE' or tip='FIZICKO LICE')
)

create table PravnoLice
(
	KupacID bigint primary key references Kupac(KupacID),
	Firma nvarchar(50) not null,
	Adresa nvarchar(50),
	PIB nvarchar(10) not null,
	MaticniBroj nvarchar(8) not null
)

create table FizickoLice
(
	KupacID bigint primary key references Kupac(KupacID),
	Ime nvarchar(50) not null,
	Prezime nvarchar(50),
	Adresa nvarchar(50) not null,
	MaticniBroj nvarchar(13) not null
)

create table Ponuda
(
	PonudaID bigint not null,
	Godina int not null,
	DatumIzrade datetime not null,
	RokIsporuke int not null,
	RokZaPlacanje int not null,
	VazenjePonude int not null,
	StatusPonude nvarchar(50),
	DatumOvereStatusa datetime,	
	ProdavacID bigint foreign key references Prodavac(ProdavacID),
	KupacID bigint foreign key references Kupac(KupacID)
	
	constraint PK_Ponuda primary key (PonudaID,Godina),
	check (StatusPonude='NA CEKANJU' or StatusPonude='PRIHVACENA' or StatusPonude='ODBIJENA')
)

create table SadrzajPonude
(
	PonudaID bigint not null,
	Godina int not null,
	ProizvodID bigint not null,
	NazivArtikla nvarchar(50) not null,
	Dimenzije nvarchar(50) not null,
	Cena money not null,
	Kolicina int not null,
	OpisArtikla nvarchar(500),
	Slika image
)

alter table SadrzajPonude add constraint FK_Ponuda foreign key (PonudaID, Godina) references Ponuda(PonudaID, Godina)
alter table SadrzajPonude add constraint PK_SadrzajPonude primary key (PonudaID, Godina, ProizvodID)

--operater
insert into Prodavac (Ime, Prezime, Sifra) values ('MILOS','TRIFUNOVIC', 'MILOS');


--iverica
insert into LagerLista (NazivMaterijala, Duzina, Sirina, Debljina, PovrsinaTable, StanjePovrsina, StanjeBrTabli, Vrsta, Cena, Tekstura)
values ('Bela 101PE', 2800, 2070, 18, 5.8, 11.6, 2, 'Iverica', 450, 'false')

insert into LagerLista (NazivMaterijala, Duzina, Sirina, Debljina, PovrsinaTable, StanjePovrsina, StanjeBrTabli, Vrsta, Cena, Tekstura)
values ('Sirovi MDF', 2800, 2070, 19, 5.8, 11.6, 2, 'MDF', 450, 'false')

insert into LagerLista (NazivMaterijala, Duzina, Sirina, Debljina, PovrsinaTable, StanjePovrsina, StanjeBrTabli, Vrsta, Cena, Tekstura)
values ('Siva 112PE', 2800, 2070, 25, 5.8, 11.6, 2, 'Iverica', 450, 'false')

insert into LagerLista (NazivMaterijala, Duzina, Sirina, Debljina, PovrsinaTable, StanjePovrsina, StanjeBrTabli, Vrsta, Cena, Tekstura)
values ('Svetli hrast 8921', 2800, 2070, 18, 5.8, 11.6, 2, 'Iverica', 450, 'true')


--kant traka
insert into KantTraka (NazivKantTrake, Sirina, Debljina, Vrsta, Stanje, Cena)
values ('Bela 101PE', 22, 2, 'ABS', 1000, 70)

insert into KantTraka (NazivKantTrake, Sirina, Debljina, Vrsta, Stanje, Cena)
values ('Bela 101PE', 28, 2, 'ABS', 1000, 150)

insert into KantTraka (NazivKantTrake, Sirina, Debljina, Vrsta, Stanje, Cena)
values ('Siva 112PE', 22, 0.4, 'Melamin', 1000, 20)

--Okov
insert into Okov (NazivOkova, JedinicaMere, Stanje, Cena)
values ('Sarka ravna', 'kom', 100, 25)

insert into Okov (NazivOkova, JedinicaMere, Stanje, Cena)
values ('Tipl fi 8', 'kom', 100, 1)

insert into Okov (NazivOkova, JedinicaMere, Stanje, Cena)
values ('Ekscentar', 'kom', 100, 7)

insert into Okov (NazivOkova, JedinicaMere, Stanje, Cena)
values ('Osovinica ekscentra', 'kom', 100, 7)

insert into Okov (NazivOkova, JedinicaMere, Stanje, Cena)
values ('Dvonavojna matica', 'kom', 100, 7)

insert into Okov (NazivOkova, JedinicaMere, Stanje, Cena)
values ('Garderobna sipka', 'm', 100, 50)

