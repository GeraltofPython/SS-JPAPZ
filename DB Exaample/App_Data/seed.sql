INSERT INTO [dbo].[Countries]([Name]) VALUES
('Russia'),
('Italy'),
('USA'),
('Japan');

INSERT INTO [dbo].[Missions]([Desig], [Descr]) VALUES
    ('Expedition 53', 'Expedition 53 is the 53rd expedition to the International Space Station'),
    ('Expedition 52', 'Expedition 52 is the 52nd expedition to the International Space Station'),
    ('STS-112', 'STS-112 was an 11-day space shuttle mission to the Internation Space Station');

INSERT INTO[dbo].[Astronauts]([Name], [BDate], [NID]) VALUES
    ('Randy Bresnik', 'September 11, 1967', 3),
    ('Sergey Ryazansky', 'November 13, 1974', 1),
    ('Paolo Nespoli', 'April 6, 1957', 2),
    ('Fyodor Yurchikhin', 'January 3, 1959', 1);

INSERT INTO [dbo].[Crews]([AID], [MID], [Position]) VALUES 
    (4, 3, 'Mission Specialist 4'),
    (1, 1, 'Commander'),
    (2, 1, 'Flight Engineer 1'),
    (3, 2, 'Flight Enginner 5');