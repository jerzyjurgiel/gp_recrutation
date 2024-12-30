USE [master];
GO

IF NOT EXISTS (SELECT * FROM sys.sql_logins WHERE name = 'chatbotApp')
BEGIN
    CREATE LOGIN [chatbotApp] WITH PASSWORD = '340$Uuxwp7Mcxo7Khy', CHECK_POLICY = OFF;
    ALTER SERVER ROLE [sysadmin] ADD MEMBER [chatbotApp];
END
GO

select * from sys.sql_logins