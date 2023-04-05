IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Consulta] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] int NOT NULL,
    [DataSolicitacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Consulta] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Relatorio] (
    [Id] int NOT NULL IDENTITY,
    [DataSolicitacao] datetime2 NOT NULL,
    [DescricaoRelatorio] nvarchar(max) NOT NULL,
    [QuantidadeTotalVacinados] int NOT NULL,
    [Solicitante] nvarchar(max) NOT NULL,
    [ConsultaId] int NULL,
    CONSTRAINT [PK_Relatorio] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Relatorio_Consulta_ConsultaId] FOREIGN KEY ([ConsultaId]) REFERENCES [Consulta] ([Id])
);
GO

CREATE INDEX [IX_Relatorio_ConsultaId] ON [Relatorio] ([ConsultaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230404152625_InitialState', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Relatorio] DROP CONSTRAINT [FK_Relatorio_Consulta_ConsultaId];
GO

ALTER TABLE [Relatorio] DROP CONSTRAINT [PK_Relatorio];
GO

ALTER TABLE [Consulta] DROP CONSTRAINT [PK_Consulta];
GO

EXEC sp_rename N'[Relatorio]', N'tbl_relatorio';
GO

EXEC sp_rename N'[Consulta]', N'tbl_consulta';
GO

EXEC sp_rename N'[tbl_relatorio].[IX_Relatorio_ConsultaId]', N'IX_tbl_relatorio_ConsultaId', N'INDEX';
GO

ALTER TABLE [tbl_relatorio] ADD CONSTRAINT [PK_tbl_relatorio] PRIMARY KEY ([Id]);
GO

ALTER TABLE [tbl_consulta] ADD CONSTRAINT [PK_tbl_consulta] PRIMARY KEY ([Id]);
GO

ALTER TABLE [tbl_relatorio] ADD CONSTRAINT [FK_tbl_relatorio_tbl_consulta_ConsultaId] FOREIGN KEY ([ConsultaId]) REFERENCES [tbl_consulta] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230404163522_AlteracaoNomeTabelaRelatorioeConsulta', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [tbl_relatorio] DROP CONSTRAINT [FK_tbl_relatorio_tbl_consulta_ConsultaId];
GO

DROP INDEX [IX_tbl_relatorio_ConsultaId] ON [tbl_relatorio];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_relatorio]') AND [c].[name] = N'ConsultaId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [tbl_relatorio] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [tbl_relatorio] DROP COLUMN [ConsultaId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_relatorio]') AND [c].[name] = N'Solicitante');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [tbl_relatorio] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [tbl_relatorio] DROP COLUMN [Solicitante];
GO

ALTER TABLE [tbl_relatorio] ADD [SolicitanteId] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230404165117_AjustesNasClasses', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_consulta]') AND [c].[name] = N'Cpf');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [tbl_consulta] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [tbl_consulta] ALTER COLUMN [Cpf] nvarchar(max) NOT NULL;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataSolicitacao', N'Nome') AND [object_id] = OBJECT_ID(N'[tbl_consulta]'))
    SET IDENTITY_INSERT [tbl_consulta] ON;
INSERT INTO [tbl_consulta] ([Id], [Cpf], [DataSolicitacao], [Nome])
VALUES (1, N'13119056774', '2023-04-04T14:04:32.2003921-03:00', N'Lucas Galvão'),
(2, N'56898787874', '2023-04-04T14:04:32.2003996-03:00', N'Lucas Coutinho');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataSolicitacao', N'Nome') AND [object_id] = OBJECT_ID(N'[tbl_consulta]'))
    SET IDENTITY_INSERT [tbl_consulta] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataSolicitacao', N'DescricaoRelatorio', N'QuantidadeTotalVacinados', N'SolicitanteId') AND [object_id] = OBJECT_ID(N'[tbl_relatorio]'))
    SET IDENTITY_INSERT [tbl_relatorio] ON;
INSERT INTO [tbl_relatorio] ([Id], [DataSolicitacao], [DescricaoRelatorio], [QuantidadeTotalVacinados], [SolicitanteId])
VALUES (1, '2023-04-04T14:04:32.2003979-03:00', N'Relatório Vacinas Pfizer aplicadas no RJ dia 03/03/2023', 71, 1),
(2, '2023-04-04T14:04:32.2004010-03:00', N'Relatório Vacinas Pfizer aplicadas no RJ dia 15/03/2023', 50, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataSolicitacao', N'DescricaoRelatorio', N'QuantidadeTotalVacinados', N'SolicitanteId') AND [object_id] = OBJECT_ID(N'[tbl_relatorio]'))
    SET IDENTITY_INSERT [tbl_relatorio] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230404170432_InsertDados', N'7.0.4');
GO

COMMIT;
GO

