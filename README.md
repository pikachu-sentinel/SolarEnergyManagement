# SolarEnergyManagement

This document outlines the technical specifications for the design and implementation of a Smart PV/Generator Energy Management System. The system integrates multiple energy sources, including a PV system, Diesel Generator, Hybrid Inverter, and Battery, with an IoT Building Management System (BMS) and a central Smart Energy Management System.

## Tables
CREATE TABLE Strategy (
    ID         INTEGER    PRIMARY KEY,
    Descrition TEXT (100) NOT NULL
);

CREATE TABLE Register (
    ID      INTEGER     PRIMARY KEY AUTOINCREMENT,
    Name    TEXT (30)   NOT NULL,
    Type    TEXT (20)   NOT NULL,
    Address INTEGER (5) NOT NULL,
    VarType TEXT (20)   NOT NULL,
    Unit    TEXT (10) 
);

CREATE TABLE StrategyDetail (
    ID         INTEGER     PRIMARY KEY,
    StrategyID INTEGER (5) REFERENCES Strategy (ID) ON DELETE CASCADE
                                                    ON UPDATE CASCADE,
    Address    INTEGER (4) REFERENCES Register (Address) ON DELETE CASCADE
                                                         ON UPDATE CASCADE,
    Value      INTEGER (5) 
);


##Table Creation begins here!.

USE SQL_STRATEGY;

#-- strategy table start here--
CREATE TABLE Strategy (
    ID INTEGER PRIMARY KEY,
    Description TEXT NOT NULL
);

DESCRIBE Strategy;

INSERT INTO Strategy VALUES
(1001, 'Maximise Import from GRID'),
(1002, 'Prioritise Charging the Battery'),
(1003, 'Max charge Battery - Zero Exort'),
(1004, 'PV to Load, Battery and Sell'),
(1005, 'PV to load and Battery-No sell'),
(1006, 'Max Export to Grid'),
(1007, 'Safe Mode'),
(1008, 'Maintenance'),
(1009, 'Maximise import-No Exort');

SELECT * FROM Strategy;

#-- REGISTER TABLE START HERE--
CREATE TABLE Register (
    ID INTEGER PRIMARY KEY,
    Name TEXT NOT NULL,
    Type TEXT NOT NULL,
    Address INTEGER NOT NULL,
    VarType TEXT NOT NULL,
    Unit TEXT
);

DESCRIBE Register;

INSERT INTO Register (ID, Name, Type, Address, VarType, Unit) VALUES
(1, 'Generator Charge', 'Logic', 129, 'Boolean', 'Binary'),
(2, 'Grid Charge', 'Logic', 130, 'Boolean', 'Binary'),
(3, 'TOU Selling', 'Logic', 146, 'Boolean', 'Binary'),
(4, 'Work Mode', 'Value', 0, 'Binary', NULL),
(5, 'Gen Start Charging V', 'Threshold', 123, 'Numeric', 'Volt'),
(6, 'Gen Start Charging %', 'Threshold', 124, 'Numeric', '%'),
(7, 'Gen Charge Curr Limit', 'Threshold', 125, 'Numeric', 'Amp'),
(8, 'Grid Charge Start V', 'Threshold', 126, 'Numeric', 'Volt'),
(9, 'Grid Charge Start %', 'Threshold', 127, 'Numeric', '%'),
(10, 'Grid Charge Curr Limit', 'Threshold', 128, 'Numeric', 'Amp'),
(11, 'Charge Curr Limit', 'Threshold', 212, 'Numeric', 'Amp'),
(12, 'Max Solar Sell power', 'Threshold', 340, 'Numeric', 'Watt');

SELECT * FROM Register;

#-- STRATEGYDETAIL TABLE START HERE--
CREATE TABLE StrategyDetail (
    ID INTEGER PRIMARY KEY,
    StrategyID INTEGER REFERENCES Strategy(ID) ON DELETE CASCADE ON UPDATE CASCADE,
    Address INTEGER REFERENCES Register(Address) ON DELETE CASCADE ON UPDATE CASCADE,
    Value INTEGER
);

DESCRIBE StrategyDetail;

INSERT INTO StrategyDetail VALUES
(1, 1001, 129, 0),
(2, 1001, 130, 1),
(3, 1001, 146, 0),
(4, 1001, 0, 0),
(5, 1001, 123, 0),
(6, 1001, 124, 0),
(7, 1001, 125, 0),
(8, 1001, 126, 53),
(9, 1001, 127, 99),
(10, 1001, 128, 150),
(11, 1001, 212, 0),
(12, 1001, 340, 0),
(13, 1002, 129, 0),
(14, 1002, 130, 1),
(15, 1002, 146, 0),
(16, 1002, 0, 0),
(17, 1002, 123, 0),
(18, 1002, 124, 0),
(19, 1002, 125, 0),
(20, 1002, 126, 0),
(21, 1002, 127, 0),
(22, 1002, 128, 0),
(23, 1002, 212, 0),
(24, 1002, 340, 0),
(25, 1003, 129, 0);

SELECT * FROM StrategyDetail;



 SHOW DATABASES;
 use SQL_Strategy;
 show tables;
