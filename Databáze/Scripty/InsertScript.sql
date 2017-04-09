
/* Languages */

INSERT INTO Languages (Language_Code, Name) VALUES ('EN', 'English')
INSERT INTO Languages (Language_Code, Name) VALUES ('CS', 'Èeština')

/* Scenario */

SET IDENTITY_INSERT Scenarios ON
INSERT INTO Scenarios (ID_Scenario) VALUES (1)
INSERT INTO Scenarios (ID_Scenario) VALUES (2)
INSERT INTO Scenarios (ID_Scenario) VALUES (3)
SET IDENTITY_INSERT Scenarios OFF

/* EN-Scenario */

INSERT INTO Scenarios_Translation (ID_Scenario, Language_Code, Name) VALUES (1, 'EN', 'Lights check')
INSERT INTO Scenarios_Translation (ID_Scenario, Language_Code, Name) VALUES (2, 'EN', 'Engine check')
INSERT INTO Scenarios_Translation (ID_Scenario, Language_Code, Name) VALUES (3, 'EN', 'Glass check')

/* CZ-Scenario */

INSERT INTO Scenarios_Translation (ID_Scenario, Language_Code, Name) VALUES (1, 'CS', 'Kontrola svetel')
INSERT INTO Scenarios_Translation (ID_Scenario, Language_Code, Name) VALUES (2, 'CS', 'Kontrola motoru')
INSERT INTO Scenarios_Translation (ID_Scenario, Language_Code, Name) VALUES (3, 'CS', 'Kontrola skel')

/* Section */

SET IDENTITY_INSERT Sections ON
INSERT INTO Sections (ID_Section) VALUES (1)
INSERT INTO Sections (ID_Section) VALUES (2)
INSERT INTO Sections (ID_Section) VALUES (3)
INSERT INTO Sections (ID_Section) VALUES (4)
SET IDENTITY_INSERT Sections OFF

/* EN-Section */

INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (1, 'EN', 'Front of car')
INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (2, 'EN', 'Back of car')
INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (3, 'EN', 'Left side of car')
INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (4, 'EN', 'Right side of car')

/* CZ-Section */

INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (1, 'CS', 'Pøedek vozu')
INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (2, 'CS', 'Zadek vozu')
INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (3, 'CS', 'Levá strana vozu')
INSERT INTO Sections_Translation (ID_Section, Language_Code, Name) VALUES (4, 'CS', 'Pravá strana vozu')


/* CheckPoint */

SET IDENTITY_INSERT CheckPoints ON
INSERT INTO CheckPoints (ID_CheckPoint) VALUES (1)
INSERT INTO CheckPoints (ID_CheckPoint) VALUES (2)
INSERT INTO CheckPoints (ID_CheckPoint) VALUES (3)
INSERT INTO CheckPoints (ID_CheckPoint) VALUES (4)
SET IDENTITY_INSERT CheckPoints OFF

/* EN-CheckPoint */

INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (1, 'EN', 'Left light')
INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (2, 'EN', 'Paint')
INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (3, 'EN', 'Exhaust')
INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (4, 'EN', 'Glass')

/* CZ-CheckPoint */

INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (1, 'CS', 'Levé svìtlo')
INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (2, 'CS', 'Barva')
INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (3, 'CS', 'Výfuk')
INSERT INTO CheckPoints_Translation (ID_CheckPoint, Language_Code, Name) VALUES (4, 'CS', 'Sklo')

/* Operation */

SET IDENTITY_INSERT Operations ON
INSERT INTO Operations (ID_Operation) VALUES (1)
INSERT INTO Operations (ID_Operation) VALUES (2)
INSERT INTO Operations (ID_Operation) VALUES (3)
INSERT INTO Operations (ID_Operation) VALUES (4)
INSERT INTO Operations (ID_Operation) VALUES (5)
INSERT INTO Operations (ID_Operation) VALUES (6)
INSERT INTO Operations (ID_Operation) VALUES (7)
INSERT INTO Operations (ID_Operation) VALUES (8)
SET IDENTITY_INSERT Operations OFF

/* EN-CheckPoint */

INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (1, 'EN', 'Check in hurry')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (2, 'EN', 'Check in detail')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (3, 'EN', 'Light on it')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (4, 'EN', 'Check around')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (5, 'EN', 'Take a look')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (6, 'EN', 'Knock')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (7, 'EN', 'Clean')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (8, 'EN', 'Whisp')

/* CZ-CheckPoint */

INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (1, 'CS', 'Zkontrolovat lehce')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (2, 'CS', 'Zkontrolovat detailnì')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (3, 'CS', 'Posvítit')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (4, 'CS', 'Obejít')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (5, 'CS', 'Nahlédnout')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (6, 'CS', 'Zaklepat')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (7, 'CS', 'Umýt')
INSERT INTO Operations_Translation (ID_Operation, Language_Code, Name) VALUES (8, 'CS', 'Profouknout')

/* Variants: CheckPoints_Operations */

INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (1, 1, 1)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (1, 4, 2)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (1, 5, 3)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (1, 8, 4)

INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (2, 1, 1)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (2, 2, 2)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (2, 3, 3)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (2, 5, 4)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (2, 7, 5)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (2, 8, 6)

INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (3, 5, 1)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (3, 8, 2)

INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (4, 2, 1)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (4, 7, 2)
INSERT INTO CheckPoints_Operations (ID_CheckPoint, ID_Operation, Order_Number) VALUES (4, 8, 3)

/* Variants: Sections_CheckPoints */
/*
INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 1, 1)
INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 2, 2)
INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 3, 3)
INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 4, 4)

INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 1, 1)
INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 4, 2)

INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (3, 3, 1)

INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (4, 1, 1)
INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (4, 2, 2)
INSERT INTO Sections_CheckPoints (ID_Section, ID_CheckPoint, Order_Number) VALUES (4, 3, 3)
*/
/* CRITICAL ============= Variants: Scenarios_Sections */

INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 1, 1, 1)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 1, 2, 2)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 1, 4, 3)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 2, 2, 4)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (1, 1, 3, 5)

INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 1, 1, 1)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 1, 2, 2)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 2, 4, 3)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 1, 3, 4)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 4, 2, 5)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (2, 3, 3, 6)

INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (3, 1, 1, 1)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (3, 4, 1, 2)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (3, 2, 4, 3)
INSERT INTO Scenarios_Sections (ID_Scenario, ID_Section, ID_CheckPoint, Order_Number) VALUES (3, 4, 3, 4)