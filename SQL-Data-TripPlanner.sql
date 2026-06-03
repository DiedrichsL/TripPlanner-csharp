--------------------------------------------------
-- UTILISATEURS (50)
--------------------------------------------------

INSERT INTO Utilisateur (Nom, Prenom, Email, MotDePasse, DateInscription) VALUES
('Dupont','Jean','jean.dupont@mail.com','mdp123','2025-01-05'),
('Martin','Claire','claire.martin@mail.com','mdp123','2025-01-06'),
('Bernard','Lucas','lucas.bernard@mail.com','mdp123','2025-01-07'),
('Thomas','Emma','emma.thomas@mail.com','mdp123','2025-01-08'),
('Petit','Louis','louis.petit@mail.com','mdp123','2025-01-09'),
('Robert','Lea','lea.robert@mail.com','mdp123','2025-01-10'),
('Richard','Hugo','hugo.richard@mail.com','mdp123','2025-01-11'),
('Durand','Chloe','chloe.durand@mail.com','mdp123','2025-01-12'),
('Dubois','Nathan','nathan.dubois@mail.com','mdp123','2025-01-13'),
('Moreau','Jade','jade.moreau@mail.com','mdp123','2025-01-14'),
('Laurent','Noah','noah.laurent@mail.com','mdp123','2025-01-15'),
('Simon','Eva','eva.simon@mail.com','mdp123','2025-01-16'),
('Michel','Theo','theo.michel@mail.com','mdp123','2025-01-17'),
('Lefevre','Camille','camille.lefevre@mail.com','mdp123','2025-01-18'),
('Leroy','Tom','tom.leroy@mail.com','mdp123','2025-01-19'),
('Roux','Sarah','sarah.roux@mail.com','mdp123','2025-01-20'),
('David','Leo','leo.david@mail.com','mdp123','2025-01-21'),
('Bertrand','Lina','lina.bertrand@mail.com','mdp123','2025-01-22'),
('Morel','Enzo','enzo.morel@mail.com','mdp123','2025-01-23'),
('Fournier','Ines','ines.fournier@mail.com','mdp123','2025-01-24'),
('Girard','Mathis','mathis.girard@mail.com','mdp123','2025-01-25'),
('Bonnet','Louise','louise.bonnet@mail.com','mdp123','2025-01-26'),
('Andre','Raphael','raphael.andre@mail.com','mdp123','2025-01-27'),
('Lambert','Mila','mila.lambert@mail.com','mdp123','2025-01-28'),
('Fontaine','Arthur','arthur.fontaine@mail.com','mdp123','2025-01-29'),
('Vincent','Rose','rose.vincent@mail.com','mdp123','2025-01-30'),
('Muller','Gabriel','gabriel.muller@mail.com','mdp123','2025-01-31'),
('Rousseau','Alice','alice.rousseau@mail.com','mdp123','2025-02-01'),
('Blanc','Jules','jules.blanc@mail.com','mdp123','2025-02-02'),
('Henry','Manon','manon.henry@mail.com','mdp123','2025-02-03'),
('Garnier','Axel','axel.garnier@mail.com','mdp123','2025-02-04'),
('Chevalier','Nina','nina.chevalier@mail.com','mdp123','2025-02-05'),
('Francois','Victor','victor.francois@mail.com','mdp123','2025-02-06'),
('Legrand','Elise','elise.legrand@mail.com','mdp123','2025-02-07'),
('Gauthier','Antoine','antoine.gauthier@mail.com','mdp123','2025-02-08'),
('Garcia','Marine','marine.garcia@mail.com','mdp123','2025-02-09'),
('Perrin','Liam','liam.perrin@mail.com','mdp123','2025-02-10'),
('Robin','Noemie','noemie.robin@mail.com','mdp123','2025-02-11'),
('Clement','Paul','paul.clement@mail.com','mdp123','2025-02-12'),
('Morin','Zoé','zoe.morin@mail.com','mdp123','2025-02-13'),
('Nicolas','Florian','florian.nicolas@mail.com','mdp123','2025-02-14'),
('Masson','Julie','julie.masson@mail.com','mdp123','2025-02-15'),
('Marchand','Adrien','adrien.marchand@mail.com','mdp123','2025-02-16'),
('Duval','Laura','laura.duval@mail.com','mdp123','2025-02-17'),
('Denis','Maxime','maxime.denis@mail.com','mdp123','2025-02-18'),
('Lemoine','Amelie','amelie.lemoine@mail.com','mdp123','2025-02-19'),
('Renard','Simon','simon.renard@mail.com','mdp123','2025-02-20'),
('Schmitt','Pauline','pauline.schmitt@mail.com','mdp123','2025-02-21'),
('Colin','Bastien','bastien.colin@mail.com','mdp123','2025-02-22'),
('Picard','Lucie','lucie.picard@mail.com','mdp123','2025-02-23');

--------------------------------------------------
-- VOYAGES (10)
--------------------------------------------------

INSERT INTO Voyage (Destination, DateDebut, DateFin, DatelimiteVote, StatutVote) VALUES
('Paris','2025-06-10','2025-06-15','2025-05-25','Ouvert'),
('Rome','2025-07-05','2025-07-12','2025-06-20','Ferme'),
('Barcelone','2025-08-01','2025-08-08','2025-07-15','Ouvert'),
('Lisbonne','2025-09-10','2025-09-16','2025-08-25','Ferme'),
('Amsterdam','2025-10-03','2025-10-08','2025-09-18','Ouvert'),
('Prague','2025-11-12','2025-11-17','2025-10-28','Ouvert'),
('Berlin','2025-12-05','2025-12-10','2025-11-20','Ferme'),
('New York','2026-01-15','2026-01-22','2025-12-20','Ouvert'),
('Tokyo','2026-03-10','2026-03-20','2026-02-10','Ouvert'),
('Bali','2026-05-05','2026-05-15','2026-04-05','Ouvert');

--------------------------------------------------
-- PARTICIPATIONS (50)
--------------------------------------------------

INSERT INTO Participation (UtilisateurId, VoyageId, Role, DateParticipation) VALUES
(1,1,'Organisateur','2025-02-01'),
(2,1,'Participant','2025-02-02'),
(3,1,'Participant','2025-02-03'),
(4,1,'Participant','2025-02-04'),
(5,1,'Participant','2025-02-05'),

(6,2,'Organisateur','2025-02-06'),
(7,2,'Participant','2025-02-07'),
(8,2,'Participant','2025-02-08'),
(9,2,'Participant','2025-02-09'),
(10,2,'Participant','2025-02-10'),

(11,3,'Organisateur','2025-02-11'),
(12,3,'Participant','2025-02-12'),
(13,3,'Participant','2025-02-13'),
(14,3,'Participant','2025-02-14'),
(15,3,'Participant','2025-02-15'),

(16,4,'Organisateur','2025-02-16'),
(17,4,'Participant','2025-02-17'),
(18,4,'Participant','2025-02-18'),
(19,4,'Participant','2025-02-19'),
(20,4,'Participant','2025-02-20'),

(21,5,'Organisateur','2025-02-21'),
(22,5,'Participant','2025-02-22'),
(23,5,'Participant','2025-02-23'),
(24,5,'Participant','2025-02-24'),
(25,5,'Participant','2025-02-25'),

(26,6,'Organisateur','2025-02-26'),
(27,6,'Participant','2025-02-27'),
(28,6,'Participant','2025-02-28'),
(29,6,'Participant','2025-03-01'),
(30,6,'Participant','2025-03-02'),

(31,7,'Organisateur','2025-03-03'),
(32,7,'Participant','2025-03-04'),
(33,7,'Participant','2025-03-05'),
(34,7,'Participant','2025-03-06'),
(35,7,'Participant','2025-03-07'),

(36,8,'Organisateur','2025-03-08'),
(37,8,'Participant','2025-03-09'),
(38,8,'Participant','2025-03-10'),
(39,8,'Participant','2025-03-11'),
(40,8,'Participant','2025-03-12'),

(41,9,'Organisateur','2025-03-13'),
(42,9,'Participant','2025-03-14'),
(43,9,'Participant','2025-03-15'),
(44,9,'Participant','2025-03-16'),
(45,9,'Participant','2025-03-17'),

(46,10,'Organisateur','2025-03-18'),
(47,10,'Participant','2025-03-19'),
(48,10,'Participant','2025-03-20'),
(49,10,'Participant','2025-03-21'),
(50,10,'Participant','2025-03-22');

--------------------------------------------------
-- PROPOSITIONS (40)
--------------------------------------------------

INSERT INTO Proposition (VoyageId, UtilisateurId, TypeProposition, Titre, Description, PrixEstime, EstRetenue) VALUES
(1,1,'Activite','Tour Eiffel','Visite de la Tour Eiffel',45,1),
(1,2,'Restaurant','Bistrot parisien','Diner traditionnel francais',35,0),
(1,3,'Hebergement','Hotel centre Paris','Hotel 3 etoiles proche du centre',480,0),
(1,4,'Transport','TGV Lausanne-Paris','Aller-retour en train',180,0),

(2,6,'Activite','Colisee','Visite guidee du Colisee',40,1),
(2,7,'Restaurant','Trattoria Roma','Restaurant italien authentique',30,0),
(2,8,'Hebergement','Hotel Roma Centro','Hotel proche des monuments',520,0),
(2,9,'Transport','Vol Geneve-Rome','Billet avion aller-retour',220,0),

(3,11,'Activite','Sagrada Familia','Visite de la basilique',38,1),
(3,12,'Restaurant','Tapas Bar','Soiree tapas a Barcelone',28,0),
(3,13,'Hebergement','Appartement plage','Appartement pour le groupe',650,0),
(3,14,'Transport','Vol Zurich-Barcelone','Vol direct aller-retour',210,0),

(4,16,'Activite','Tour en tram','Visite touristique en tram',25,1),
(4,17,'Restaurant','Seafood Lisboa','Diner fruits de mer',42,0),
(4,18,'Hebergement','Hotel Alfama','Sejour quartier historique',470,0),
(4,19,'Transport','Vol Bale-Lisbonne','Vol aller-retour',240,0),

(5,21,'Activite','Canaux en bateau','Croisiere sur les canaux',32,1),
(5,22,'Restaurant','Burger Amsterdam','Repas convivial centre-ville',26,0),
(5,23,'Hebergement','Hotel Jordaan','Hotel dans quartier anime',510,0),
(5,24,'Transport','Train Bruxelles-Amsterdam','Trajet regional',95,0),

(6,26,'Activite','Chateau de Prague','Visite du chateau',30,1),
(6,27,'Restaurant','Czech Pub','Cuisine locale tcheque',24,0),
(6,28,'Hebergement','Hotel Prague Old Town','Hotel vieux centre',430,0),
(6,29,'Transport','Vol Geneve-Prague','Vol direct',190,0),

(7,31,'Activite','Mur de Berlin','Circuit historique',20,1),
(7,32,'Restaurant','Berlin Street Food','Repas street food',22,0),
(7,33,'Hebergement','Auberge Berlin Mitte','Auberge moderne',310,0),
(7,34,'Transport','Train de nuit Berlin','Transport ferroviaire',160,0),

(8,36,'Activite','Statue de la Liberte','Excursion ferry',55,1),
(8,37,'Restaurant','NY Steak House','Diner americain',70,0),
(8,38,'Hebergement','Hotel Manhattan','Hotel central',980,0),
(8,39,'Transport','Vol Geneve-New York','Billet transatlantique',780,0),

(9,41,'Activite','Temple Senso-ji','Visite culturelle a Asakusa',18,1),
(9,42,'Restaurant','Sushi Tokyo','Degustation de sushi',50,0),
(9,43,'Hebergement','Hotel Shinjuku','Hotel dans Tokyo',1250,0),
(9,44,'Transport','Vol Zurich-Tokyo','Vol international',980,0),

(10,46,'Activite','Excursion riziere','Balade dans les rizieres',22,1),
(10,47,'Restaurant','Warung local','Cuisine balinaise',18,0),
(10,48,'Hebergement','Villa Bali','Villa avec piscine',1400,0),
(10,49,'Transport','Vol Geneve-Bali','Vol long courrier',1100,0);

--------------------------------------------------
-- VOTES (80)
--------------------------------------------------

INSERT INTO Vote (UtilsateurId, PropositionId, DateVote) VALUES
(2,1,'2025-05-01'),
(3,1,'2025-05-01'),
(4,1,'2025-05-02'),
(5,1,'2025-05-02'),
(1,2,'2025-05-03'),
(3,2,'2025-05-03'),
(4,3,'2025-05-04'),
(5,4,'2025-05-04'),

(7,5,'2025-06-01'),
(8,5,'2025-06-01'),
(9,5,'2025-06-02'),
(10,5,'2025-06-02'),
(6,6,'2025-06-03'),
(8,6,'2025-06-03'),
(9,7,'2025-06-04'),
(10,8,'2025-06-04'),

(12,9,'2025-07-01'),
(13,9,'2025-07-01'),
(14,9,'2025-07-02'),
(15,9,'2025-07-02'),
(11,10,'2025-07-03'),
(13,10,'2025-07-03'),
(14,11,'2025-07-04'),
(15,12,'2025-07-04'),

(17,13,'2025-08-01'),
(18,13,'2025-08-01'),
(19,13,'2025-08-02'),
(20,13,'2025-08-02'),
(16,14,'2025-08-03'),
(18,14,'2025-08-03'),
(19,15,'2025-08-04'),
(20,16,'2025-08-04'),

(22,17,'2025-09-01'),
(23,17,'2025-09-01'),
(24,17,'2025-09-02'),
(25,17,'2025-09-02'),
(21,18,'2025-09-03'),
(23,18,'2025-09-03'),
(24,19,'2025-09-04'),
(25,20,'2025-09-04'),

(27,21,'2025-10-01'),
(28,21,'2025-10-01'),
(29,21,'2025-10-02'),
(30,21,'2025-10-02'),
(26,22,'2025-10-03'),
(28,22,'2025-10-03'),
(29,23,'2025-10-04'),
(30,24,'2025-10-04'),

(32,25,'2025-11-01'),
(33,25,'2025-11-01'),
(34,25,'2025-11-02'),
(35,25,'2025-11-02'),
(31,26,'2025-11-03'),
(33,26,'2025-11-03'),
(34,27,'2025-11-04'),
(35,28,'2025-11-04'),

(37,29,'2025-12-01'),
(38,29,'2025-12-01'),
(39,29,'2025-12-02'),
(40,29,'2025-12-02'),
(36,30,'2025-12-03'),
(38,30,'2025-12-03'),
(39,31,'2025-12-04'),
(40,32,'2025-12-04'),

(42,33,'2026-02-01'),
(43,33,'2026-02-01'),
(44,33,'2026-02-02'),
(45,33,'2026-02-02'),
(41,34,'2026-02-03'),
(43,34,'2026-02-03'),
(44,35,'2026-02-04'),
(45,36,'2026-02-04'),

(47,37,'2026-04-01'),
(48,37,'2026-04-01'),
(49,37,'2026-04-02'),
(50,37,'2026-04-02'),
(46,38,'2026-04-03'),
(48,38,'2026-04-03'),
(49,39,'2026-04-04'),
(50,40,'2026-04-04');
GO
