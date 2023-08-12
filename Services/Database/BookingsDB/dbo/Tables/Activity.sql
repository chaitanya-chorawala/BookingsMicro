CREATE TABLE [dbo].[Activity] (
    [activityId]  INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (255) NOT NULL,
    [description] VARCHAR (255) NOT NULL,
    [price]       INT           NOT NULL,
    [created_at]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [updated_at]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [deleted_at]  BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([activityId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [idx_Activity_name]
    ON [dbo].[Activity]([name] ASC);

