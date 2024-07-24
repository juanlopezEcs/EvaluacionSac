SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](100) NULL,
	[firstName] [varchar](100) NULL,
	[lastName] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[dateOfBirth] [varchar](100) NULL,
	[userGroup] [varchar](100) NULL,
	[pass] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

