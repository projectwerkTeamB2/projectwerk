
-- -----------------------------------------------------
-- Table `projectwerk`.`Reeks`
-- -----------------------------------------------------
DROP TABLE IF EXISTS [Reeks] ;

CREATE TABLE Reeks (
  [id] INT NOT NULL,
  [Name] VARCHAR(255) NULL,
  PRIMARY KEY ([id]))
;


-- -----------------------------------------------------
-- Table `projectwerk`.`Uitgeverij`
-- -----------------------------------------------------
DROP TABLE IF EXISTS [projectwerk`.`Uitgeverij] ;

CREATE TABLE Uitgeverij (
  [id] INT NOT NULL,
  [Name] VARCHAR(255) NULL,
  PRIMARY KEY ([id]))
;

-- -----------------------------------------------------
-- Table `projectwerk`.`Auteur`
-- -----------------------------------------------------
DROP TABLE IF EXISTS [projectwerk`.`Auteur] ;

CREATE TABLE Auteur (
  [id] INT NOT NULL,
  [Name] VARCHAR(255) NULL,
  PRIMARY KEY ([id]))
;


-- -----------------------------------------------------
-- Table `projectwerk`.`Strip`
-- -----------------------------------------------------
DROP TABLE IF EXISTS [projectwerk`.`Strip] ;

CREATE TABLE Strip (
  [id] INT NOT NULL,
  [Titel] VARCHAR(255) NULL,
  [Nummer] INT NULL,
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




-- -----------------------------------------------------
-- Table `projectwerk`.`Strip_has_Auteur`
-- -----------------------------------------------------
DROP TABLE IF EXISTS [projectwerk`.`Strip_has_Auteur] ;

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
;

CREATE INDEX fk_Strip_has_Auteur_Auteur1_idx ON Strip_has_Auteur ([Auteur_id] ASC) ;

CREATE INDEX fk_Strip_has_Auteur_Strip1_idx ON Strip_has_Auteur ([Strip_id] ASC) ;

