


CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[status] [tinyint] NOT NULL,
	[modified_by] [int] NOT NULL,
	[modified_date] [datetime] NOT NULL,
	[role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



INSERT INTO [dbo].[users]
           ([username]
           ,[password]
           ,[firstname]
           ,[lastname]
           ,[status]
           ,[modified_by]
           ,[modified_date]
           ,[role])
     VALUES
           ('admin'
           ,'password'
           ,'Arun'
           ,'Kumar'
           ,1
           ,1
           ,'2023-01-2'
           ,'ADMIN'
		   )


INSERT INTO [dbo].[users]
           ([username]
           ,[password]
           ,[firstname]
           ,[lastname]
           ,[status]
           ,[modified_by]
           ,[modified_date]
           ,[role])
     VALUES
           ('test'
           ,'password'
           ,'Arun'
           ,'Kumar'
           ,1
           ,1
           ,'2023-01-2'
           ,'USER'
		   )
