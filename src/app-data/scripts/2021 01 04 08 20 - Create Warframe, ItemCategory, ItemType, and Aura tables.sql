CREATE TABLE dbo.ItemType (
  [Id] INT NOT NULL IDENTITY PRIMARY KEY,
  [Name] VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE dbo.ItemCategory (
  [Id] INT NOT NULL IDENTITY PRIMARY KEY,
  [Name] VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE dbo.Aura (
  [Id] INT NOT NULL IDENTITY PRIMARY KEY,
  [Name] VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE dbo.Warframe (
  [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [UniqueName] VARCHAR(100) NOT NULL UNIQUE,
  [Name] VARCHAR(20) NOT NULL,
  [Description] VARCHAR(MAX) NULL,
  [Health] INT NOT NULL,
  [Shield] INT NOT NULL,
  [Armor] INT NOT NULL,
  [Stamina] INT NOT NULL,
  [Power] INT NOT NULL,
  [Sprint] FLOAT(2) NOT NULL,
  [SprintSpeed] FLOAT(2) NOT NULL,
  [MasteryRequirement] INT NOT NULL,
  [PassiveDescription] VARCHAR(MAX) NULL,
  [ProductCategory] VARCHAR(100) NOT NULL,
  [BuildPrice] INT NOT NULL,
  [BuildTime] INT NOT NULL,
  [SkipBuildTimePrice] INT NOT NULL,
  [BuildQuantity] INT NOT NULL,
  [ConsumeOnBuild] BIT NOT NULL,
  [Tradable] BIT NOT NULL,
  [Conclave] BIT NOT NULL,
  [Color] INT NOT NULL,
  [FirstAppearance] VARCHAR(20) NOT NULL,
  [Sex] VARCHAR(10) NULL,
  [WikiaUrl] VARCHAR(MAX) NULL,
  [WikiaThumbnail] VARCHAR(MAX) NULL,
  [ImageName] VARCHAR(100) NULL,
  [ItemTypeId] INT NOT NULL,
  [ItemCategoryId] INT NOT NULL,
  [AuraId] INT NOT NULL,

  FOREIGN KEY (ItemTypeId) REFERENCES dbo.ItemType(Id),
  FOREIGN KEY (ItemCategoryId) REFERENCES dbo.ItemCategory(Id),
  FOREIGN KEY (AuraId) REFERENCES dbo.Aura(Id),
);