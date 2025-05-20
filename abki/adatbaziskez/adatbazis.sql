-- Szulok
CREATE TABLE `szulo` (
    `id` int(5) NOT NULL AUTO_INCREMENT,
    `nev` VARCHAR(32) COLLATE utf8_hungarian_ci DEFAULT NULL,
    `telefon` VARCHAR(20) COLLATE utf8_hungarian_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- Gyermekek
CREATE TABLE `gyermek` (
    `id` int(5) NOT NULL AUTO_INCREMENT,
    `nev` VARCHAR(32) COLLATE utf8_hungarian_ci DEFAULT NULL UNIQUE,
    `telepules` VARCHAR(30) COLLATE utf8_hungarian_ci DEFAULT NULL,
    `szuloId` INT(5) COLLATE utf8_hungarian_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `szuloId` (`szuloId`),
  CONSTRAINT FK_szulok_szuloId FOREIGN KEY (szuloId)
    REFERENCES szulo(id)
);

-- Fejlesztők
CREATE TABLE `fejleszto`  (
    `id` int(5) NOT NULL AUTO_INCREMENT, 
    `nev` VARCHAR(32) COLLATE utf8_hungarian_ci DEFAULT NULL UNIQUE,
    `szakma` VARCHAR(32) COLLATE utf8_hungarian_ci DEFAULT NULL,
    `telefon` VARCHAR(20) COLLATE utf8_hungarian_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- Témakörök
CREATE TABLE `temakor`  (
    `id` int(5) NOT NULL AUTO_INCREMENT,
    `megnevezes` VARCHAR(20) COLLATE utf8_hungarian_ci DEFAULT NULL,	
    `leiras` VARCHAR(100) COLLATE utf8_hungarian_ci DEFAULT NULL,	
  PRIMARY KEY (`id`)
);

-- Foglalkozások
CREATE TABLE `foglalkozas`  (
    `id` int(5) NOT NULL AUTO_INCREMENT, 
    `fejlesztoId` INT(5) NULL,
    `gyermekId` INT(5) NULL,
    `datum` DATE NULL, 
    `ido` INT(5) NULL,
    `temakorId` INT(5) NULL,
  PRIMARY KEY (`id`),
  KEY `fejlesztoId` (`fejlesztoId`),
  KEY `gyermekId` (`gyermekId`),
  KEY `temakorId` (`temakorId`),
  CONSTRAINT FK_fejlesztok_fejlesztoId FOREIGN KEY (fejlesztoId)
    REFERENCES fejleszto(id),
  CONSTRAINT FK_gyermekek_gyermekId FOREIGN KEY (gyermekId)
    REFERENCES gyermek(id),
  CONSTRAINT FK_temakorok_temakorId FOREIGN KEY (temakorId)
    REFERENCES temakor(id)
);


INSERT INTO szulo(id, nev, telefon) VALUES
(1,'Rozsda Mária','06 (20) 223-1232'),
(2,'Nagy Marianna','06 (30) 123-1234'),
(3,'Kiss László','06 (70) 424-1634'),
(4,'Boldogh Andrea','06 (30) 103-1938'),
(5,'Szőke Anita','06 (70) 423-1636'),
(6,'Kovács Viktor','06 (30) 823-1269'),
(7,'Horváth Bernadett','06 (30) 320-1637'),
(8,'Fehér László','06 (30) 443-4789');

INSERT INTO gyermek(id, nev, telepules,szuloId) VALUES
(1,'Horváth Mia','Budapest',1),
(2,'Nagy Márk','Budapest',2),
(3,'Kiss Barna','Pécel',3),
(4,'Boldogh Anett','Érd',4),
(5,'Major Anna','Vác',5),
(6,'Kovács Mónika','Budapest',6),
(7,'Kiss Bálint','Pécel',3),
(8,'Kovács Máté','Budapest',6),
(9,'Dénes Virág','Gödöllő',7),
(10,'Fehér Tamás','Budapest',8);

INSERT INTO fejleszto(id,nev,szakma,telefon) VALUES
(1,'Nagy Géza','tehetségfejlesztő','06 (70) 543-7709'),
(2,'Szabó Szilvia','fejlesztőpedagógus','06 (20) 643-2481'),
(3,'Vass Virág','tehetségfejlesztő','06 (30) 573-2789'),
(4,'Horváth Béla','fejlesztőpedagógus','06 (70) 433-5785'),
(5,'Szél Bálint','logopédus','06 (30) 645-4714'),
(6,'Nagy Hajnalka','tehetségfejlesztő','06 (30) 663-6696'),
(7,'Major Norbert','szaktanácsadó','06 (20) 443-5759'),
(8,'Balogh Anita','gyógypedagógus','06 (20) 448-7756');

INSERT INTO temakor(id,megnevezes,leiras) VALUES
(1,'érvelés','Érvek, ellenérvek összegyűjtése'),
(2,'szervezés','Rendszerezési képesség fejlesztése'),
(3,'beszédtechnika','R hang gyakorlása'),
(4,'tehetségtanácsadás','Tehetségdiagnosztika'),
(5,'logika','Logikai készségfejlesztő feladatok'),
(6,'szervezés','Időbeosztás tervezése'),
(7,'érvelés','Vitakészség fejlesztés'),
(8,'programozás','Programozás bevezetés'),
(9,'programozás','Játékos programozást tanító oldalak'),
(10,'beszédtechnika','S és sz hangok gyakorlása');


INSERT INTO foglalkozas(id,fejlesztoId,gyermekId,datum,ido,temakorId) VALUES
(1,1,4,'2022.12.01',15,1),
(2,2,10,'2022.12.01',15,2),
(3,2,10,'2022.12.01',16,2),
(4,1,7,'2022.12.01',17,1),
(5,5,2,'2022.12.02',15,3),
(6,2,4,'2022.12.02',15,2),
(7,7,6,'2022.12.02',15,4),
(8,1,4,'2022.12.02',17,1),
(9,6,3,'2022.12.05',16,5),
(10,3,6,'2022.12.05',16,5),
(11,7,2,'2022.12.05',17,4),
(12,2,10,'2022.12.05',18,6),
(13,6,3,'2022.12.06',15,5),
(14,1,4,'2022.12.06',16,7),
(15,7,9,'2022.12.06',16,8),
(16,2,8,'2022.12.06',17,6),
(17,3,8,'2022.12.07',15,5),
(18,6,6,'2022.12.07',16,5),
(19,3,9,'2022.12.07',16,5),
(20,1,7,'2022.12.07',17,1),
(21,6,1,'2022.12.08',15,5),
(22,3,9,'2022.12.08',15,5),
(23,1,2,'2022.12.08',16,7),
(24,6,6,'2022.12.08',16,8),
(25,6,1,'2022.12.09',15,8),
(26,3,10,'2022.12.12',15,5),
(27,6,6,'2022.12.12',15,9),
(28,3,5,'2022.12.12',17,5),
(29,5,2,'2022.12.12',17,10),
(30,6,9,'2022.12.12',17,8);


