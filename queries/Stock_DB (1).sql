
DROP TABLE IF EXISTS [Strip_has_Auteur] ;

DROP TABLE IF EXISTS [Verkoop] ;
DROP TABLE IF EXISTS [Aankoop] ;


DROP TABLE IF EXISTS [Stock] ;
DROP TABLE IF EXISTS [Stock_Has_Verkoop] ;
DROP TABLE IF EXISTS [Stock_Has_Aankoop] ;

DROP TABLE IF EXISTS [Auteur] ;

DROP TABLE IF EXISTS Strip_has_Stripcollection_has_strip ;



DROP TABLE IF EXISTS [Strip] ;
DROP TABLE IF EXISTS [Stripcollection] ;
DROP TABLE IF EXISTS [Uitgeverij] ;
DROP TABLE IF EXISTS [Reeks] ;




-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Reeks`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Reeks] ;

CREATE TABLE Reeks (
  [id] INT NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([id]))
;

-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Auteur`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Auteur] ;

CREATE TABLE Auteur (
  [Id] INT NOT NULL,
  [Name] VARCHAR(255) NULL,
  PRIMARY KEY ([Id]))
;




-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Uitgeverij`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Uitgeverij] ;

CREATE TABLE Uitgeverij (
  [id] INT NOT NULL,
  [Name] VARCHAR(255) NULL,
  PRIMARY KEY ([id]));



-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Strip`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Strip];

CREATE TABLE Strip (
  [id] INT NOT NULL,
  [Titel] VARCHAR(255) NULL,
  [Nummer] INT NULL,
  [Reeks_id] INT NOT NULL,
  [isEenLosseStrip] SMALLINT NULL,
  [Uitgeverij_id] INT NOT NULL,
	PRIMARY KEY ([id]),

	CONSTRAINT [fk_Strip_Reeks1]  FOREIGN KEY ([Reeks_id])    REFERENCES Reeks ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
	CONSTRAINT [fk_Strip_Uitgeverij1] FOREIGN KEY ([Uitgeverij_id]) REFERENCES Uitgeverij ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


  CREATE INDEX fk_Strip_Reeks1_idxx ON Strip ([Reeks_id] ASC) ;
CREATE INDEX fk_Strip_Uitgeverij1_idx ON Strip ([Uitgeverij_id] ASC) ;
 



-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Strip_has_Auteur`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Strip_has_Auteur] ;

CREATE TABLE Strip_has_Auteur (
  [Strip_id] INT NOT NULL,
  [Auteur_Id] INT NOT NULL,
  PRIMARY KEY ([Strip_id], [Auteur_Id]),


  CONSTRAINT [fk_Strip_has_Auteur_Strip1]
    FOREIGN KEY ([Strip_id])
    REFERENCES Strip ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Strip_has_Auteur_Auteur1]
    FOREIGN KEY ([Auteur_id])
    REFERENCES Auteur ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
 CREATE INDEX fk_Strip_has_Auteur_Auteur1_idx ON Strip_has_Auteur ([Auteur_id] ASC) ;
CREATE INDEX fk_Strip_has_Auteur_Strip1_idx ON Strip_has_Auteur ([Strip_id] ASC) ;


-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Stripcollection`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Stripcollection] ;

CREATE TABLE Stripcollection (
  [id] INT NOT NULL IDENTITY,
  [title] VARCHAR(255) NOT NULL,
  [nr] INT NOT NULL,
  [Uitgeverij_id] INT NOT NULL,
  PRIMARY KEY ([id]),
      
  CONSTRAINT [fk_Strip_has_Stripcollection_has_Uitgeverij]
    FOREIGN KEY (   [Uitgeverij_id])
    REFERENCES Uitgeverij ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

     CREATE INDEX [fk_Strip_has_Stripcollection_has_Uitgeverij] ON Stripcollection (   [Uitgeverij_id] ASC);




-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Strip_has_Stripcollection_has_strip`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS Strip_has_Stripcollection_has_strip ;

CREATE TABLE Strip_has_Stripcollection_has_strip (
  [Strip_id] INT NOT NULL,
  [Strip_Reeks_id] INT NOT NULL,
  [Stripcollection_has_strip_id] INT NOT NULL,
  
  PRIMARY KEY ( [Strip_id] ,[Strip_Reeks_id], [Stripcollection_has_strip_id]),

    CONSTRAINT[fk_Strip_has_Stripcollection_has_Stripcollection]
    FOREIGN KEY ([Stripcollection_has_strip_id] )
    REFERENCES Stripcollection ([id] )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,

  CONSTRAINT[fk_Strip_has_Stripcollection_has_strip_Strip1]
    FOREIGN KEY ([Strip_id] )
    REFERENCES Strip ([id] )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,

  CONSTRAINT [fk_Strip_has_Stripcollection_has_Reeks1]
    FOREIGN KEY ([Strip_Reeks_id])
    REFERENCES Reeks ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



     CREATE INDEX [fk_Strip_has_Stripcollection_has_Stripcollection] ON Strip_has_Stripcollection_has_strip (   [Stripcollection_has_strip_id] ASC);
  CREATE INDEX [fk_Strip_has_Stripcollection_has_strip_Strip1] ON Strip_has_Stripcollection_has_strip (  [Strip_id] ASC);
  CREATE INDEX [fk_Strip_has_Stripcollection_has_Reeks1] ON Strip_has_Stripcollection_has_strip (  [Strip_Reeks_id] ASC);








-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Verkoop`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Verkoop] ;

CREATE TABLE Verkoop (
  [id] INT NOT NULL IDENTITY,
  [datumBestelling] DATETIME2(0) NOT NULL,
  [hoeveelheid] INT NOT NULL,

  PRIMARY KEY ([id]))
;


-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Aankoop`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Aankoop] ;

CREATE TABLE Aankoop (
  [id] INT NOT NULL,
  [datumGeplaats] DATETIME2(0) NOT NULL,
  [datumOntvangen] DATETIME2(0),
  [hoeveelheid] INT NOT NULL,

  PRIMARY KEY ([id]))
;




-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Stock`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Stock] ;

CREATE TABLE Stock (
	[Hoeveelheid] INT NOT NULL,
	[Strip_id] INT NOT NULL,
   
    PRIMARY KEY (Strip_id),

   CONSTRAINT [fk_Strip_Stock1] FOREIGN KEY ([Strip_id]) REFERENCES Strip  ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  
 )
;

-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Stock_Has_Verkoop`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Stock_Has_Verkoop] ;

CREATE TABLE Stock_Has_Verkoop (
  [StockId] INT NOT NULL,
  [Verkoop_id] INT NOT NULL,
  PRIMARY KEY ([StockId], [Verkoop_id]),
  
  CONSTRAINT [fk_Stock_Has_Verkoop_Stock1]    FOREIGN KEY ([StockId])    REFERENCES Stock ([Strip_id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Stock_Has_Verkoop_Verkoop1]    FOREIGN KEY ([Verkoop_id])    REFERENCES Verkoop ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

  CREATE INDEX [fk_Stock_Has_Verkoop_Verkoop1_idx] ON Stock_Has_Verkoop ([Verkoop_id] ASC);
  



-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Stock_Has_Aankoop`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Stock_Has_Aankoop] ;

CREATE TABLE Stock_Has_Aankoop (
  [Aankoop_id] INT NOT NULL,
  [StockId] INT NOT NULL,
  PRIMARY KEY ([Aankoop_id], [StockId]),

   CONSTRAINT [fk_Stock_Has_Aankoop_Aankoop1]    FOREIGN KEY ([Aankoop_id])    REFERENCES Aankoop ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Stock_Has_Aankoop_Stock1]    FOREIGN KEY ([StockId])    REFERENCES Stock ([Strip_id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

  CREATE INDEX [fk_Stock_Has_Aankoop_Stock1_idx] ON Stock_Has_Aankoop ([StockId] ASC) ;
 



