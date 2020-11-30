-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema projectwerk
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema projectwerk
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `projectwerk` DEFAULT CHARACTER SET utf8 ;
USE `projectwerk` ;

-- -----------------------------------------------------
-- Table `projectwerk`.`Reeks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projectwerk`.`Reeks` (
  `id` INT NOT NULL,
  `Name` VARCHAR(255) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projectwerk`.`Strip`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projectwerk`.`Strip` (
  `id` INT NOT NULL,
  `Titel` VARCHAR(255) NULL,
  `Nummer` INT NULL,
  `Reeks_id` INT NOT NULL,
  PRIMARY KEY (`id`, `Reeks_id`),
  INDEX `fk_Strip_Reeks1_idx` (`Reeks_id` ASC) VISIBLE,
  CONSTRAINT `fk_Strip_Reeks1`
    FOREIGN KEY (`Reeks_id`)
    REFERENCES `projectwerk`.`Reeks` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projectwerk`.`Auteur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projectwerk`.`Auteur` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(255) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projectwerk`.`Uitgeverij`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projectwerk`.`Uitgeverij` (
  `id` INT NOT NULL,
  `Name` VARCHAR(255) NULL,
  `Strip_id` INT NOT NULL,
  PRIMARY KEY (`id`, `Strip_id`),
  INDEX `fk_Uitgeverij_Strip1_idx` (`Strip_id` ASC) VISIBLE,
  CONSTRAINT `fk_Uitgeverij_Strip1`
    FOREIGN KEY (`Strip_id`)
    REFERENCES `projectwerk`.`Strip` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projectwerk`.`Strip_has_Auteur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projectwerk`.`Strip_has_Auteur` (
  `Strip_id` INT NOT NULL,
  `Auteur_Id` INT NOT NULL,
  PRIMARY KEY (`Strip_id`, `Auteur_Id`),
  INDEX `fk_Strip_has_Auteur_Auteur1_idx` (`Auteur_Id` ASC) VISIBLE,
  INDEX `fk_Strip_has_Auteur_Strip1_idx` (`Strip_id` ASC) VISIBLE,
  CONSTRAINT `fk_Strip_has_Auteur_Strip1`
    FOREIGN KEY (`Strip_id`)
    REFERENCES `projectwerk`.`Strip` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Strip_has_Auteur_Auteur1`
    FOREIGN KEY (`Auteur_Id`)
    REFERENCES `projectwerk`.`Auteur` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projectwerk`.`Stripcollection`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projectwerk`.`Stripcollection` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(255) NOT NULL,
  `nr` INT NOT NULL,
  `uitgeverij` VARCHAR(255) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projectwerk`.`Strip_has_Stripcollection_has_strip`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projectwerk`.`Strip_has_Stripcollection_has_strip` (
  `Strip_id` INT NOT NULL,
  `Strip_Reeks_id` INT NOT NULL,
  `Stripcollection_has_strip_id` INT NOT NULL,
  PRIMARY KEY (`Strip_id`, `Strip_Reeks_id`, `Stripcollection_has_strip_id`),
  INDEX `fk_Strip_has_Stripcollection_has_strip_Stripcollection_has__idx` (`Stripcollection_has_strip_id` ASC) VISIBLE,
  INDEX `fk_Strip_has_Stripcollection_has_strip_Strip1_idx` (`Strip_id` ASC, `Strip_Reeks_id` ASC) VISIBLE,
  CONSTRAINT `fk_Strip_has_Stripcollection_has_strip_Strip1`
    FOREIGN KEY (`Strip_id` , `Strip_Reeks_id`)
    REFERENCES `projectwerk`.`Strip` (`id` , `Reeks_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Strip_has_Stripcollection_has_strip_Stripcollection_has_st1`
    FOREIGN KEY (`Stripcollection_has_strip_id`)
    REFERENCES `projectwerk`.`Stripcollection` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
