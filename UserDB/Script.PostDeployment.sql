IF NOT EXISTS (SELECT 1 FROM [dbo].[User])
BEGIN
INSERT INTO [dbo].[User] ([FirstName], [LastName])
	VALUES
		('John', 'Doe'),
		('Jane', 'Doe'),
		('John', 'Smith'),
		('Jane', 'Smith');
END