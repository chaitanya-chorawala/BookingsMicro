CREATE TABLE [dbo].[Review] (
    [reviewId]    INT           IDENTITY (1, 1) NOT NULL,
    [guestId]     INT           NOT NULL,
    [activityId]  INT           NOT NULL,
    [rating]      INT           NOT NULL,
    [review_text] VARCHAR (255) NOT NULL,
    [created_at]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [updated_at]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [deleted_at]  BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([reviewId] ASC),
    FOREIGN KEY ([activityId]) REFERENCES [dbo].[Activity] ([activityId]),
    CONSTRAINT [FK__Review__guestId__4222D4EF] FOREIGN KEY ([guestId]) REFERENCES [dbo].[Guest] ([guestId])
);


GO
CREATE NONCLUSTERED INDEX [idx_Review_guestId]
    ON [dbo].[Review]([guestId] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_Review_activityId]
    ON [dbo].[Review]([activityId] ASC);

