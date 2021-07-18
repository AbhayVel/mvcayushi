USE [StudentMS]
GO
/****** Object:  Table [dbo].[TblLoginUserClaim]    Script Date: 18-07-2021 18:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblLoginUserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
	[Value] [varchar](50) NULL,
	[LoginUserId] [int] NULL,
 CONSTRAINT [PK_TblLoginUserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblLoginUserClaim]  WITH CHECK ADD  CONSTRAINT [FK_TblLoginUserClaim_TblLoginUser] FOREIGN KEY([LoginUserId])
REFERENCES [dbo].[TblLoginUser] ([Id])
GO
ALTER TABLE [dbo].[TblLoginUserClaim] CHECK CONSTRAINT [FK_TblLoginUserClaim_TblLoginUser]
GO
