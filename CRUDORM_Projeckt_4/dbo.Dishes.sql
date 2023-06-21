CREATE TABLE [dbo].[Dishes] (
    [DishId]      INT             IDENTITY (1, 1) NOT NULL,
    [DishName]    NVARCHAR (MAX)  NOT NULL,
    [Description] NVARCHAR (MAX)  NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [Weight]      DECIMAL (18, 2) NOT NULL,
    [DishTypeId]  INT             NOT NULL,
    CONSTRAINT [PK_dbo.Dishes] PRIMARY KEY CLUSTERED ([DishId] ASC),
    CONSTRAINT [FK_dbo.Dishes_dbo.DishTypes_DishTypeId] FOREIGN KEY ([DishTypeId]) REFERENCES [dbo].[DishTypes] ([DishTypeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DishTypeId]
    ON [dbo].[Dishes]([DishTypeId] ASC);

