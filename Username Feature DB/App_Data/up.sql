/* This file is meant to create the tables for the database */

CREATE TABLE [dbo].Names 
(
    [ID]    INT IDENTITY(1, 1)    NOT NULL, /*set first ID as 1 and increments the rest +1 */
    [Name]    NVARCHAR(128)        NOT NULL,
    CONSTRAINT [PK_dbo.Names] PRIMARY KEY CLUSTERED([ID] ASC) /* Creates a primary key in the Names table that uses the ID column in assending order */
);