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
