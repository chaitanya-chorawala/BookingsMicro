CREATE TABLE [dbo].[Guest] (
    [guestId]      INT           IDENTITY (1, 1) NOT NULL,
    [first_name]   VARCHAR (255) NOT NULL,
    [last_name]    VARCHAR (255) NOT NULL,
    [email]        VARCHAR (255) NOT NULL,
    [phone_number] VARCHAR (20)  NOT NULL,
    [created_at]   DATETIME      CONSTRAINT [DF__Guest__created_a__300424B4] DEFAULT (getdate()) NOT NULL,
    [updated_at]   DATETIME      CONSTRAINT [DF__Guest__updated_a__30F848ED] DEFAULT (getdate()) NOT NULL,
    [deleted_at]   BIT           CONSTRAINT [DF__Guest__deleted_a__31EC6D26] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__Guest__8D59CD1C0FAFDCFF] PRIMARY KEY CLUSTERED ([guestId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [idx_Guest_first_name]
    ON [dbo].[Guest]([first_name] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_Guest_last_name]
    ON [dbo].[Guest]([last_name] ASC);

