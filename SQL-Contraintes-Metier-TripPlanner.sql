ALTER TABLE Vote
ADD CONSTRAINT UQ_Vote_Utilisateur_Proposition
UNIQUE (UtilsateurId, PropositionId);


ALTER TABLE Participation
ADD CONSTRAINT UQ_Participation_Utilisateur_Voyage
UNIQUE (UtilisateurId, VoyageId);



CREATE UNIQUE INDEX UQ_Proposition_Voyage_Type_Retenue
ON Proposition (VoyageId, TypeProposition)
WHERE EstRetenue = 1;