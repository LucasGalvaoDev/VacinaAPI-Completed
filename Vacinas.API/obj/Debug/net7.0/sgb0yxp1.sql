CREATE TABLE [tbl_consulta] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] nvarchar(max) NOT NULL,
    [DataSolicitacao] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_consulta] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [tbl_relatorio] (
    [Id] int NOT NULL IDENTITY,
    [DataSolicitacao] datetime2 NOT NULL,
    [DescricaoRelatorio] nvarchar(max) NOT NULL,
    [QuantidadeTotalVacinados] int NOT NULL,
    [SolicitanteId] int NOT NULL,
    CONSTRAINT [PK_tbl_relatorio] PRIMARY KEY ([Id])
);
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataSolicitacao', N'Nome') AND [object_id] = OBJECT_ID(N'[tbl_consulta]'))
    SET IDENTITY_INSERT [tbl_consulta] ON;
INSERT INTO [tbl_consulta] ([Id], [Cpf], [DataSolicitacao], [Nome])
VALUES (1, N'13119056774', '2023-04-04T14:06:49.1097612-03:00', N'Lucas Galvão'),
(2, N'56898787874', '2023-04-04T14:06:49.1097691-03:00', N'Lucas Coutinho');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataSolicitacao', N'Nome') AND [object_id] = OBJECT_ID(N'[tbl_consulta]'))
    SET IDENTITY_INSERT [tbl_consulta] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataSolicitacao', N'DescricaoRelatorio', N'QuantidadeTotalVacinados', N'SolicitanteId') AND [object_id] = OBJECT_ID(N'[tbl_relatorio]'))
    SET IDENTITY_INSERT [tbl_relatorio] ON;
INSERT INTO [tbl_relatorio] ([Id], [DataSolicitacao], [DescricaoRelatorio], [QuantidadeTotalVacinados], [SolicitanteId])
VALUES (1, '2023-04-04T14:06:49.1097673-03:00', N'Relatório Vacinas Pfizer aplicadas no RJ dia 03/03/2023', 71, 1),
(2, '2023-04-04T14:06:49.1097704-03:00', N'Relatório Vacinas Pfizer aplicadas no RJ dia 15/03/2023', 50, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataSolicitacao', N'DescricaoRelatorio', N'QuantidadeTotalVacinados', N'SolicitanteId') AND [object_id] = OBJECT_ID(N'[tbl_relatorio]'))
    SET IDENTITY_INSERT [tbl_relatorio] OFF;
GO


