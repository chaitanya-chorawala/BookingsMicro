CREATE TABLE [dbo].[Room] (
    [roomId]         INT           IDENTITY (1, 1) NOT NULL,
    [hotelId]        INT           NOT NULL,
    [room_number]    VARCHAR (10)  NOT NULL,
    [room_type]      VARCHAR (255) NOT NULL,
    [number_of_beds] INT           NOT NULL,
    [price]          INT           NOT NULL,
    [created_at]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [updated_at]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [deleted_at]     BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([roomId] ASC),
    CONSTRAINT [FK__Room__hotelId__29572725] FOREIGN KEY ([hotelId]) REFERENCES [dbo].[Hotel] ([hotelId]),
    CONSTRAINT [FK__Room__hotelId__2D27B809] FOREIGN KEY ([hotelId]) REFERENCES [dbo].[Hotel] ([hotelId])
);


GO
CREATE NONCLUSTERED INDEX [idx_Room_room_number]
    ON [dbo].[Room]([room_number] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_Room_room_type]
    ON [dbo].[Room]([room_type] ASC);

