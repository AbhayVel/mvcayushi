USE [StudentMS]
GO
/****** Object:  Table [dbo].[TblStudent]    Script Date: 17-07-2021 18:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[SubjectId] [int] NULL,
	[Age] [decimal](18, 2) NOT NULL,
	[fees] [decimal](18, 2) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_TblStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblStudent]  WITH CHECK ADD  CONSTRAINT [FK_TblStudent_TblSubject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[TblSubject] ([Id])
GO
ALTER TABLE [dbo].[TblStudent] CHECK CONSTRAINT [FK_TblStudent_TblSubject]
GO
