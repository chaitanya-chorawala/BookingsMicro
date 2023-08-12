CREATE TABLE [dbo].[Reservation] (
    [reservationId]  INT           IDENTITY (1, 1) NOT NULL,
    [guestId]        INT           NOT NULL,
    [roomId]         INT           NOT NULL,
    [check_in_date]  DATE          NOT NULL,
    [check_out_date] DATE          NOT NULL,
    [status]         VARCHAR (255) NOT NULL,
    [created_at]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [updated_at]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [deleted_at]     BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([reservationId] ASC),
    FOREIGN KEY ([roomId]) REFERENCES [dbo].[Room] ([roomId]),
    FOREIGN KEY ([roomId]) REFERENCES [dbo].[Room] ([roomId]),
    CONSTRAINT [FK__Reservati__guest__34C8D9D1] FOREIGN KEY ([guestId]) REFERENCES [dbo].[Guest] ([guestId]),
    CONSTRAINT [FK__Reservati__guest__398D8EEE] FOREIGN KEY ([guestId]) REFERENCES [dbo].[Guest] ([guestId])
);


GO
CREATE NONCLUSTERED INDEX [idx_Reservation_check_in_date]
    ON [dbo].[Reservation]([check_in_date] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_Reservation_check_out_date]
    ON [dbo].[Reservation]([check_out_date] ASC);

