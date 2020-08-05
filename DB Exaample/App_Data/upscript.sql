CREATE TABLE [dbo].[Countries]
(
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_dbo.Countries] PRIMARY KEY ([ID] ASC)
);

CREATE TABLE [dbo].[Missions]
(
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [Desig] NVARCHAR(50) NOT NULL,
    [Descr] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [PK_dbo.Missions] PRIMARY KEY ([ID] ASC)
);

CREATE TABLE [dbo].[Astronauts]
(
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [BDate] NVARCHAR(50) NOT NULL,
    [NID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Astronauts] PRIMARY KEY ([ID] ASC),
    CONSTRAINT [FK_dbo.Astronauts_dbo.Countries_ID] FOREIGN KEY ([NID]) REFERENCES [dbo].[Countries]([ID])
);

CREATE TABLE [dbo].[Crews]
(
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [AID] INT NOT NULL,
    [MID] INT NOT NULL,
    [Position] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_dbo.Crews] PRIMARY KEY ([ID] ASC),
    CONSTRAINT [FK_dbo.Crews_dbo.Astronauts_ID] FOREIGN KEY ([AID]) REFERENCES [dbo].[Astronauts]([ID]),
    CONSTRAINT [FK_dbo.Crews_dbo.Missions_ID] FOREIGN KEY ([MID]) REFERENCES [dbo].[Missions]([ID])
);

 