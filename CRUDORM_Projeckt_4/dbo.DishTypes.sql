CREATE TABLE [dbo].[DishTypes] (
    [DishTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [DishTypeName] NVARCHAR (MAX)  NOT NULL,
    CONSTRAINT [PK_dbo.DishTypes] PRIMARY KEY CLUSTERED ([DishTypeId] ASC)
);

