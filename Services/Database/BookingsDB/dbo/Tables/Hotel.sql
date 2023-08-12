CREATE TABLE [dbo].[Hotel] (
    [hotelId]      INT           IDENTITY (1, 1) NOT NULL,
    [name]         VARCHAR (255) NOT NULL,
    [address]      VARCHAR (255) NOT NULL,
    [city]         VARCHAR (255) NOT NULL,
    [state]        VARCHAR (2)   NOT NULL,
    [zip_code]     VARCHAR (10)  NOT NULL,
    [phone_number] VARCHAR (20)  NOT NULL,
    [website]      VARCHAR (255) NOT NULL,
    [created_at]   DATETIME      CONSTRAINT [DF__Hotel__created_a__24927208] DEFAULT (getdate()) NOT NULL,
    [updated_at]   DATETIME      CONSTRAINT [DF__Hotel__updated_a__25869641] DEFAULT (getdate()) NOT NULL,
    [deleted_at]   BIT           CONSTRAINT [DF__Hotel__deleted_a__267ABA7A] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__Hotel__17ADC4720D4C6422] PRIMARY KEY CLUSTERED ([hotelId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [idx_Hotel_name]
    ON [dbo].[Hotel]([name] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_Hotel_city]
    ON [dbo].[Hotel]([city] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_Hotel_state]
    ON [dbo].[Hotel]([state] ASC);

