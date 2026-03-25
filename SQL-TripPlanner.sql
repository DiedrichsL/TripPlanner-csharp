CREATE DATABASE TripPlanner;


CREATE TABLE [Utilisateur] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Nom] nvarchar(max) NOT NULL,
	[Prenom] nvarchar(max) NOT NULL,
	[Email] nvarchar(max) NOT NULL,
	[MotDePasse] nvarchar(max) NOT NULL,
	[DateInscription] date NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Voyage] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Destination] nvarchar(max) NOT NULL,
	[DateDebut] date NOT NULL,
	[DateFin] date NOT NULL,
	[DatelimiteVote] date NOT NULL,
	[StatutVote] nvarchar(max) NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Participation] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[UtilisateurId] int NOT NULL,
	[VoyageId] int NOT NULL,
	[Role] nvarchar(max) NOT NULL,
	[DateParticipation] date NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Proposition] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[VoyageId] int NOT NULL,
	[UtilisateurId] int NOT NULL,
	[TypeProposition] nvarchar(max) NOT NULL,
	[Titre] nvarchar(max) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[PrixEstime] decimal(18,0) NOT NULL,
	[EstRetenue] bit NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Vote] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[UtilsateurId] int NOT NULL,
	[PropositionId] int NOT NULL,
	[DateVote] date NOT NULL,
	PRIMARY KEY ([Id])
);



ALTER TABLE [Participation] ADD CONSTRAINT [Participation_fk1] FOREIGN KEY ([UtilisateurId]) REFERENCES [Utilisateur]([Id]);

ALTER TABLE [Participation] ADD CONSTRAINT [Participation_fk2] FOREIGN KEY ([VoyageId]) REFERENCES [Voyage]([Id]);
ALTER TABLE [Proposition] ADD CONSTRAINT [Proposition_fk1] FOREIGN KEY ([VoyageId]) REFERENCES [Voyage]([Id]);

ALTER TABLE [Proposition] ADD CONSTRAINT [Proposition_fk2] FOREIGN KEY ([UtilisateurId]) REFERENCES [Utilisateur]([Id]);
ALTER TABLE [Vote] ADD CONSTRAINT [Vote_fk1] FOREIGN KEY ([UtilsateurId]) REFERENCES [Utilisateur]([Id]);

ALTER TABLE [Vote] ADD CONSTRAINT [Vote_fk2] FOREIGN KEY ([PropositionId]) REFERENCES [Proposition]([Id]);