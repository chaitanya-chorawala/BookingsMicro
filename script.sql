
USE [BookingsDB]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[activityId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[price] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[deleted_at] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[activityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorCode] [varchar](255) NULL,
	[ErrorDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[guestId] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NOT NULL,
	[last_name] [varchar](255) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[phone_number] [varchar](20) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[deleted_at] [bit] NOT NULL,
 CONSTRAINT [PK__Guest__8D59CD1C0FAFDCFF] PRIMARY KEY CLUSTERED 
(
	[guestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[hotelId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[address] [varchar](255) NOT NULL,
	[city] [varchar](255) NOT NULL,
	[state] [varchar](2) NOT NULL,
	[zip_code] [varchar](10) NOT NULL,
	[phone_number] [varchar](20) NOT NULL,
	[website] [varchar](255) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[deleted_at] [bit] NOT NULL,
 CONSTRAINT [PK__Hotel__17ADC4720D4C6422] PRIMARY KEY CLUSTERED 
(
	[hotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[Username] [varchar](50) NOT NULL,
	[Token] [varchar](max) NOT NULL,
 CONSTRAINT [PK_UserRefreshToken] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[reservationId] [int] IDENTITY(1,1) NOT NULL,
	[check_in_date] [date] NOT NULL,
	[check_out_date] [date] NOT NULL,
	[status] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[deleted_at] [bit] NOT NULL,
	[userId] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[reservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[reviewId] [int] IDENTITY(1,1) NOT NULL,
	[guestId] [int] NOT NULL,
	[activityId] [int] NOT NULL,
	[rating] [int] NOT NULL,
	[review_text] [varchar](255) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[deleted_at] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[reviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomId] [int] IDENTITY(1,1) NOT NULL,
	[hotelId] [int] NOT NULL,
	[room_number] [varchar](10) NOT NULL,
	[room_type] [varchar](255) NOT NULL,
	[number_of_beds] [int] NOT NULL,
	[price] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[deleted_at] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Email] [varchar](100) NULL,
	[Role] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([activityId], [name], [description], [price], [created_at], [updated_at], [deleted_at]) VALUES (1, N'The Statue of Liberty Tour', N'Take a ferry to Liberty Island and explore the Statue of Liberty and Ellis Island.', 100, CAST(N'2023-08-10T11:01:52.390' AS DateTime), CAST(N'2023-08-10T11:01:52.390' AS DateTime), 0)
INSERT [dbo].[Activity] ([activityId], [name], [description], [price], [created_at], [updated_at], [deleted_at]) VALUES (2, N'Top of the Rock Observation Deck', N'Enjoy 360-degree views of New York City from the top of the Rockefeller Center.', 30, CAST(N'2023-08-10T11:01:52.390' AS DateTime), CAST(N'2023-08-10T11:01:52.390' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([guestId], [first_name], [last_name], [email], [phone_number], [created_at], [updated_at], [deleted_at]) VALUES (1, N'John', N'Doe', N'john.doe@example.com', N'123-456-7890', CAST(N'2023-08-10T11:00:16.270' AS DateTime), CAST(N'2023-08-10T11:00:16.270' AS DateTime), 0)
INSERT [dbo].[Guest] ([guestId], [first_name], [last_name], [email], [phone_number], [created_at], [updated_at], [deleted_at]) VALUES (2, N'Jane', N'Doe', N'jane.doe@example.com', N'212-759-3000', CAST(N'2023-08-10T11:00:16.270' AS DateTime), CAST(N'2023-08-10T11:00:16.270' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Guest] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([hotelId], [name], [address], [city], [state], [zip_code], [phone_number], [website], [created_at], [updated_at], [deleted_at]) VALUES (1, N'The Ritz-Carlton', N'123 Main Street', N'New York City', N'NY', N'10001', N'123-456-7890', N'https://www.ritzcarlton.com/', CAST(N'2023-08-10T10:57:53.473' AS DateTime), CAST(N'2023-08-10T10:57:53.473' AS DateTime), 0)
INSERT [dbo].[Hotel] ([hotelId], [name], [address], [city], [state], [zip_code], [phone_number], [website], [created_at], [updated_at], [deleted_at]) VALUES (2, N'The Plaza Hotel', N'5th Avenue', N'New York City', N'NY', N'10019', N'212-759-3000', N'https://www.plazahotel.com/', CAST(N'2023-08-10T10:57:53.487' AS DateTime), CAST(N'2023-08-10T10:57:53.487' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
INSERT [dbo].[RefreshToken] ([Username], [Token]) VALUES (N'admin', N'28Pegf6b1DsxfLDt/6zQTNq9sVtz3UYNmT5QbYC0+oM=')
INSERT [dbo].[RefreshToken] ([Username], [Token]) VALUES (N'user', N'ZrLvLSgQv2VeU5nJDx5RkezfpCZ3+anUjzt3Pr0O6lM=')
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([reservationId], [check_in_date], [check_out_date], [status], [created_at], [updated_at], [deleted_at], [userId], [Id], [Type]) VALUES (1, CAST(N'2023-08-15' AS Date), CAST(N'2023-08-17' AS Date), 1, CAST(N'2023-08-15T12:25:34.520' AS DateTime), CAST(N'2023-08-15T12:25:34.520' AS DateTime), 0, N'9cf98afb-3252-45c5-bf6e-724517d3566f', 1, 0)
INSERT [dbo].[Reservation] ([reservationId], [check_in_date], [check_out_date], [status], [created_at], [updated_at], [deleted_at], [userId], [Id], [Type]) VALUES (2, CAST(N'2023-08-15' AS Date), CAST(N'2023-08-16' AS Date), 1, CAST(N'2023-08-15T12:25:49.770' AS DateTime), CAST(N'2023-08-15T12:25:49.770' AS DateTime), 0, N'9cf98afb-3252-45c5-bf6e-724517d3566f', 1, 1)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([reviewId], [guestId], [activityId], [rating], [review_text], [created_at], [updated_at], [deleted_at]) VALUES (1, 1, 1, 5, N'The Statue of Liberty Tour was amazing! The views from the top were incredible.', CAST(N'2023-08-10T11:02:33.730' AS DateTime), CAST(N'2023-08-10T11:02:33.730' AS DateTime), 0)
INSERT [dbo].[Review] ([reviewId], [guestId], [activityId], [rating], [review_text], [created_at], [updated_at], [deleted_at]) VALUES (2, 2, 2, 4, N'The Top of the Rock Observation Deck was great! The views were amazing and the experience was really fun.', CAST(N'2023-08-10T11:02:33.730' AS DateTime), CAST(N'2023-08-10T11:02:33.730' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([roomId], [hotelId], [room_number], [room_type], [number_of_beds], [price], [created_at], [updated_at], [deleted_at]) VALUES (1, 1, N'1001', N'King Suite', 2, 2000, CAST(N'2023-08-10T10:59:22.733' AS DateTime), CAST(N'2023-08-10T10:59:22.733' AS DateTime), 0)
INSERT [dbo].[Room] ([roomId], [hotelId], [room_number], [room_type], [number_of_beds], [price], [created_at], [updated_at], [deleted_at]) VALUES (2, 1, N'1002', N'Deluxe Room', 1, 1000, CAST(N'2023-08-10T10:59:22.737' AS DateTime), CAST(N'2023-08-10T10:59:22.737' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
INSERT [dbo].[User] ([UserId], [Name], [Password], [Email], [Role], [IsActive]) VALUES (N'9cf98afb-3252-45c5-bf6e-724517d3566f', N'admin', N'admin', N'admin@admin.com', N'ADMIN', 1)
INSERT [dbo].[User] ([UserId], [Name], [Password], [Email], [Role], [IsActive]) VALUES (N'b0dbe349-7bca-4d43-8e5e-2342c6e3004f', N'user', N'user', N'user@user.com', N'USER', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Activity_name]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Activity_name] ON [dbo].[Activity]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Guest_first_name]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Guest_first_name] ON [dbo].[Guest]
(
	[first_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Guest_last_name]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Guest_last_name] ON [dbo].[Guest]
(
	[last_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Hotel_city]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Hotel_city] ON [dbo].[Hotel]
(
	[city] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Hotel_name]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Hotel_name] ON [dbo].[Hotel]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Hotel_state]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Hotel_state] ON [dbo].[Hotel]
(
	[state] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_Reservation_check_in_date]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Reservation_check_in_date] ON [dbo].[Reservation]
(
	[check_in_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_Reservation_check_out_date]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Reservation_check_out_date] ON [dbo].[Reservation]
(
	[check_out_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_Review_activityId]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Review_activityId] ON [dbo].[Review]
(
	[activityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_Review_guestId]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Review_guestId] ON [dbo].[Review]
(
	[guestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Room_room_number]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Room_room_number] ON [dbo].[Room]
(
	[room_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Room_room_type]    Script Date: 08-15-2023 18:07:24 ******/
CREATE NONCLUSTERED INDEX [idx_Room_room_type] ON [dbo].[Room]
(
	[room_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT ((0)) FOR [deleted_at]
GO
ALTER TABLE [dbo].[Guest] ADD  CONSTRAINT [DF__Guest__created_a__300424B4]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Guest] ADD  CONSTRAINT [DF__Guest__updated_a__30F848ED]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Guest] ADD  CONSTRAINT [DF__Guest__deleted_a__31EC6D26]  DEFAULT ((0)) FOR [deleted_at]
GO
ALTER TABLE [dbo].[Hotel] ADD  CONSTRAINT [DF__Hotel__created_a__24927208]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Hotel] ADD  CONSTRAINT [DF__Hotel__updated_a__25869641]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Hotel] ADD  CONSTRAINT [DF__Hotel__deleted_a__267ABA7A]  DEFAULT ((0)) FOR [deleted_at]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT ((0)) FOR [deleted_at]
GO
ALTER TABLE [dbo].[Review] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Review] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Review] ADD  DEFAULT ((0)) FOR [deleted_at]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT ((0)) FOR [deleted_at]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([activityId])
REFERENCES [dbo].[Activity] ([activityId])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK__Review__guestId__4222D4EF] FOREIGN KEY([guestId])
REFERENCES [dbo].[Guest] ([guestId])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__guestId__4222D4EF]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK__Room__hotelId__29572725] FOREIGN KEY([hotelId])
REFERENCES [dbo].[Hotel] ([hotelId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK__Room__hotelId__29572725]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK__Room__hotelId__2D27B809] FOREIGN KEY([hotelId])
REFERENCES [dbo].[Hotel] ([hotelId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK__Room__hotelId__2D27B809]
GO
/****** Object:  StoredProcedure [dbo].[ActivityGet]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActivityGet]	
AS
BEGIN
	SELECT 
		activityId
		, name
		, description
		, price
	FROM Activity A WITH(NOLOCK) 
	WHERE A.deleted_at = 0
END
GO
/****** Object:  StoredProcedure [dbo].[ActivityGetById]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActivityGetById] 
	@activityId int
AS
BEGIN
	SELECT 
		activityId
		, name
		, description
		, price
	FROM Activity A WITH(NOLOCK) 
	WHERE A.deleted_at = 0 AND activityId = @activityId
END
GO
/****** Object:  StoredProcedure [dbo].[HotelGet]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Get Hotel List
-- =============================================
CREATE PROCEDURE [dbo].[HotelGet]
AS
BEGIN
	SELECT 
		hotelId
		, name
		, address
		, city
		, state
		, zip_code
		, phone_number
		, website
	FROM Hotel WITH(NOLOCK)
END
GO
/****** Object:  StoredProcedure [dbo].[HotelGetById]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Get Hotel by Id
-- =============================================
CREATE PROCEDURE [dbo].[HotelGetById]
	@hotelId int = 0	
AS
BEGIN
	SELECT 
		hotelId
		, name
		, address
		, city
		, state
		, zip_code
		, phone_number
		, website
	FROM Hotel A WITH(NOLOCK) WHERE A.hotelId = @hotelId
END
GO
/****** Object:  StoredProcedure [dbo].[ReservationAdd]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReservationAdd] 
	  @check_in_date    date
	, @check_out_date date
	, @status		  int
	, @userId		  varchar(50)
	, @id			  int
	, @type			  int
AS
BEGIN		
	BEGIN TRY

		INSERT INTO Reservation (
			check_in_date 
			,check_out_date
			,status		 
			,userId		 
			,Id			 
			,Type			 
		) VALUES (
			 @check_in_date 
			,@check_out_date
			,@status		 
			,@userId		 
			,@id			 
			,@type
		)
	    
	END TRY  
	BEGIN CATCH  
		INSERT INTO ErrorLogs(ErrorCode, ErrorDescription)
		SELECT
			CAST(ERROR_NUMBER() AS NVARCHAR(200))  
			,CAST(ERROR_LINE() AS NVARCHAR(100)) + ' : ' + ERROR_MESSAGE()    
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ReservationGet]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- [ReservationGet] 1, 1
-- =============================================
CREATE PROCEDURE [dbo].[ReservationGet] 	 
	@PageIndex INT = 1,
	@PageSize INT = 10
AS
BEGIN	
	DECLARE @CurrentPageIndex1 INT = @PageIndex,
			@CurrentPageSize1 INT = @PageSize
			
	DECLARE @PreviousPageIndex1 INT = @CurrentPageIndex1 - 1, 
			@NextPageIndex1 INT =  @CurrentPageIndex1 + 1
	

	SELECT
		  reservationId
		, CONVERT(VARCHAR(20), check_in_date, 103) AS check_in_date
		, CONVERT(VARCHAR(20), check_out_date, 103) AS check_out_date
		, status		
		, userId
		, Id
		, Type
	FROM Reservation A WITH(NOLOCK) 
	WHERE deleted_at = 0
	ORDER BY created_at DESC OFFSET (@CurrentPageIndex1-1)*@CurrentPageSize1 ROWS FETCH NEXT @CurrentPageSize1 ROWS ONLY

	SELECT @CurrentPageIndex1 as CurrentPageIndex, @PreviousPageIndex1 as PreviousPageIndex,
			   @NextPageIndex1 as NextPageIndex, @CurrentPageSize1 as CurrentPageSize,
			   (SELECT COUNT(reservationId) FROM Reservation A WITH(NOLOCK) 
					WHERE deleted_at = 0) as TotalRecord
	  
END
GO
/****** Object:  StoredProcedure [dbo].[ReservationGetById]    Script Date: 08-15-2023 18:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReservationGetById] 
	  @reservationId int
AS
BEGIN		
	SELECT
		  reservationId
		, check_in_date
		, check_out_date
		, status		
		, userId
		, Id
		, Type
	FROM Reservation A WITH(NOLOCK) 
	WHERE deleted_at = 0 AND reservationId = @reservationId
END
GO
USE [master]
GO
ALTER DATABASE [BookingsDB] SET  READ_WRITE 
GO
