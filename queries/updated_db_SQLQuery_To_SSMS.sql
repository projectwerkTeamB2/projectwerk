
DROP TABLE IF EXISTS [Strip_has_Auteur] ;

DROP TABLE IF EXISTS [Strip_has_Stripcollection_has_strip] ;
DROP TABLE IF EXISTS [Strip] ;

DROP TABLE IF EXISTS [Reeks] ;
DROP TABLE IF EXISTS [Auteur] ;
DROP TABLE IF EXISTS [Uitgeverij] ;
DROP TABLE IF EXISTS [Stripcollection] ;


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
  [Name] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([Id]))
;


-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Uitgeverij`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Uitgeverij] ;

CREATE TABLE Uitgeverij (
  [id] INT NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([id]))
;


-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Strip`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Strip] ;

CREATE TABLE Strip (
   [id] INT NOT NULL,
  [Titel] VARCHAR(255) NOT NULL,
  [Nummer] INT NOT NULL,
  [Reeks_id] INT NOT NULL,
  [Uitgeverij_id] INT NOT NULL,
 PRIMARY KEY ([id]),
 
  CONSTRAINT [fk_Strip_Reeks1] FOREIGN KEY ([Reeks_id]) REFERENCES Reeks ([id])    
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Strip_Uitgeverij1] FOREIGN KEY ([Uitgeverij_id]) REFERENCES Uitgeverij ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

CREATE INDEX fk_Strip_Reeks1_idx ON Strip ([Reeks_id] ASC) ;
CREATE INDEX fk_Strip_Uitgeverij1_idx ON Strip ([Uitgeverij_id] ASC) ;
-- SQLINES DEMO *** ------------------------------------
-- SQLINES DEMO *** k`.`Strip_has_Auteur`
-- SQLINES DEMO *** ------------------------------------
DROP TABLE IF EXISTS [Strip_has_Auteur] ;

CREATE TABLE Strip_has_Auteur (
  [Strip_id] INT NOT NULL,
  [Auteur_id] INT NOT NULL,
  PRIMARY KEY ([Strip_id], [Auteur_id]),

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



DROP TABLE IF EXISTS [Strip_has_Stripcollection_has_strip] ;

CREATE TABLE Strip_has_Stripcollection_has_strip (
  [Strip_id] INT NOT NULL,
  [Strip_Reeks_id] INT NOT NULL,
  [Stripcollection_has_strip_id] INT NOT NULL,
  PRIMARY KEY ([Stripcollection_has_strip_id]),

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



