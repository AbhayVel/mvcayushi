USE [StudentMS]
GO
/****** Object:  Table [dbo].[TblDepartment]    Script Date: 17-07-2021 18:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDepartment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[SubjectId] [int] NULL,
 CONSTRAINT [PK_TblDepartment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblDepartment]  WITH CHECK ADD  CONSTRAINT [FK_TblDepartment_TblDepartment] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[TblSubject] ([Id])
GO
ALTER TABLE [dbo].[TblDepartment] CHECK CONSTRAINT [FK_TblDepartment_TblDepartment]
GO
