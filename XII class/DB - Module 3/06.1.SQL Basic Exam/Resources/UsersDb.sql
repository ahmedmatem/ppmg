GO
CREATE DATABASE Users
GO

GO
USE Users
GO

CREATE TABLE Users (
    Id INT IDENTITY PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Age INT
)