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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250629131633_leaveType'
)
BEGIN
    CREATE TABLE [LeaveTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(150) NOT NULL,
        [NumberOfDays] int NOT NULL,
        CONSTRAINT [PK_LeaveTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250629131633_leaveType'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250629131633_leaveType', N'8.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630112508_SeedingDefaultRoleAndUser'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''8d7b6299-c6f8-4586-b623-2184b3c59b04'', NULL, N''Supervisor'', N''SUPERVISOR''),
    (N''a55f271b-e1f6-4121-a98c-2ee8c08ec747'', NULL, N''Employee'', N''EMPLYEE''),
    (N''e4bdfc66-ff31-4cae-9e50-b37bf4e84950'', NULL, N''Administrator'', N''ADMINISTRATOR'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630112508_SeedingDefaultRoleAndUser'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''3a96210e-53e2-48ee-bdc3-c6bffb644625'', 0, N''c97ada6c-9eed-4d76-b325-70a21e675b96'', N''admin@localhost.com'', CAST(1 AS bit), CAST(0 AS bit), NULL, N''ADMIN@LOCALHOST.COM'', N''ADMIN@LOCALHOST.COM'', N''AQAAAAIAAYagAAAAEMHioJ1/Hmkj3btA1sxmAWzZVS0Ra46KLbBCcin1TyCE/WzaVz+gmm/v7arVRU4niQ=='', NULL, CAST(0 AS bit), N''ac6c5e6b-7ac6-4800-8bbb-18b1ce47ffd0'', CAST(0 AS bit), N''admin@localhost.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630112508_SeedingDefaultRoleAndUser'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''e4bdfc66-ff31-4cae-9e50-b37bf4e84950'', N''3a96210e-53e2-48ee-bdc3-c6bffb644625'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630112508_SeedingDefaultRoleAndUser'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250630112508_SeedingDefaultRoleAndUser', N'8.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630122143_updateseedingdefaultroleaduser'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [DateOfBirth] date NOT NULL DEFAULT '0001-01-01';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630122143_updateseedingdefaultroleaduser'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630122143_updateseedingdefaultroleaduser'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630122143_updateseedingdefaultroleaduser'
)
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''fb0bd23c-68da-4366-b733-0f88aa83ab65'', [DateOfBirth] = ''1999-12-04'', [FirstName] = N''Admin'', [LastName] = N''Default'', [PasswordHash] = N''AQAAAAIAAYagAAAAEGvkNi7UgXltSyqoB/gS3hzfEJY3wspBx3U462iDKvPjy+hcQzTgnI5Z9FxFIgICHQ=='', [SecurityStamp] = N''62565764-bb49-4949-8b52-625bf4f64e02''
    WHERE [Id] = N''3a96210e-53e2-48ee-bdc3-c6bffb644625'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630122143_updateseedingdefaultroleaduser'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250630122143_updateseedingdefaultroleaduser', N'8.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630141615_updateseedData'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''e4bdfc66-ff31-4cae-9e50-b37bf4e84950'' AND [UserId] = N''3a96210e-53e2-48ee-bdc3-c6bffb644625'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630141615_updateseedData'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''e4bdfc66-ff31-4cae-9e50-b37bf4e84950'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630141615_updateseedData'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = N''3a96210e-53e2-48ee-bdc3-c6bffb644625'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630141615_updateseedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''1556e020-5f62-439e-b31d-394de93759fe'', NULL, N''Administrator'', N''ADMINISTRATOR'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630141615_updateseedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateOfBirth', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateOfBirth], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''584162ac-b288-4707-91ae-9b6c3c89bfb5'', 0, N''6be1af78-4086-4669-ada8-047c8ebafb45'', ''1999-12-04'', N''admin@localhost.com'', CAST(1 AS bit), N''Admin'', N''Default'', CAST(0 AS bit), NULL, N''ADMIN@LOCALHOST.COM'', N''ADMIN@LOCALHOST.COM'', N''AQAAAAIAAYagAAAAEF8DmTB2azKZeQY9dS6gnWxfy9nijYm59aUwzCmT/l9v9+rXctghPQp1GJ3Z/OjlMQ=='', NULL, CAST(0 AS bit), N''3987c8a1-425a-48c5-922c-ebe2b975c416'', CAST(0 AS bit), N''admin@localhost.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateOfBirth', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630141615_updateseedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''1556e020-5f62-439e-b31d-394de93759fe'', N''584162ac-b288-4707-91ae-9b6c3c89bfb5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630141615_updateseedData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250630141615_updateseedData', N'8.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630151736_LeaveAllocationEntity'
)
BEGIN
    CREATE TABLE [Periods] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [StartOn] date NOT NULL,
        [EndOn] date NOT NULL,
        CONSTRAINT [PK_Periods] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630151736_LeaveAllocationEntity'
)
BEGIN
    CREATE TABLE [LeaveAllocations] (
        [Id] int NOT NULL IDENTITY,
        [LeaveTypeId] int NOT NULL,
        [PeriodId] int NOT NULL,
        [EmployeeId] nvarchar(450) NOT NULL,
        [Days] int NOT NULL,
        CONSTRAINT [PK_LeaveAllocations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_LeaveAllocations_AspNetUsers_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_LeaveAllocations_LeaveTypes_LeaveTypeId] FOREIGN KEY ([LeaveTypeId]) REFERENCES [LeaveTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_LeaveAllocations_Periods_PeriodId] FOREIGN KEY ([PeriodId]) REFERENCES [Periods] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630151736_LeaveAllocationEntity'
)
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''64c29aed-2b6a-4e40-a40e-b028962d3fa4'', [PasswordHash] = N''AQAAAAIAAYagAAAAEMI3kmOJnV0MTgYL5ebM9f5r/eYwwhLAZK7SrO46REIgq5ogRjmSc9/MpWEwIzhYZQ=='', [SecurityStamp] = N''44b371d8-8cc8-4dd2-8551-df3e550e95c7''
    WHERE [Id] = N''584162ac-b288-4707-91ae-9b6c3c89bfb5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630151736_LeaveAllocationEntity'
)
BEGIN
    CREATE INDEX [IX_LeaveAllocations_EmployeeId] ON [LeaveAllocations] ([EmployeeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630151736_LeaveAllocationEntity'
)
BEGIN
    CREATE INDEX [IX_LeaveAllocations_LeaveTypeId] ON [LeaveAllocations] ([LeaveTypeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630151736_LeaveAllocationEntity'
)
BEGIN
    CREATE INDEX [IX_LeaveAllocations_PeriodId] ON [LeaveAllocations] ([PeriodId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250630151736_LeaveAllocationEntity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250630151736_LeaveAllocationEntity', N'8.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702094854_UpdateDefaultSeedData'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''1556e020-5f62-439e-b31d-394de93759fe'' AND [UserId] = N''584162ac-b288-4707-91ae-9b6c3c89bfb5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702094854_UpdateDefaultSeedData'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = N''584162ac-b288-4707-91ae-9b6c3c89bfb5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702094854_UpdateDefaultSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateOfBirth', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateOfBirth], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''b6be7770-6c3d-42ce-97a7-7efdba0fb30a'', 0, N''152e516a-0c45-4813-a83a-61942ab5b823'', ''1999-12-04'', N''admin@localhost.com'', CAST(1 AS bit), N''Admin'', N''Default'', CAST(0 AS bit), NULL, N''ADMIN@LOCALHOST.COM'', N''ADMIN@LOCALHOST.COM'', N''AQAAAAIAAYagAAAAEE8Yj4LaHQ2x4wzHHuN/2UWrWa/1e+7fH+lqL4ud1yr+RPm1qbcAYsp57QHEuMRUmQ=='', NULL, CAST(0 AS bit), N''4d24d753-2be3-49ba-a0ec-86c11242bae8'', CAST(0 AS bit), N''admin@localhost.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateOfBirth', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702094854_UpdateDefaultSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''1556e020-5f62-439e-b31d-394de93759fe'', N''b6be7770-6c3d-42ce-97a7-7efdba0fb30a'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702094854_UpdateDefaultSeedData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250702094854_UpdateDefaultSeedData', N'8.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    CREATE TABLE [LeaveRequestsStatus] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_LeaveRequestsStatus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    CREATE TABLE [LeaveRequests] (
        [Id] int NOT NULL IDENTITY,
        [StartDate] date NOT NULL,
        [EndDate] date NOT NULL,
        [LeaveTypeId] int NOT NULL,
        [LeaveRequestStatusId] int NOT NULL,
        [EmployeeId] nvarchar(450) NOT NULL,
        [ReviewerId] nvarchar(450) NULL,
        [RequestComments] nvarchar(max) NULL,
        CONSTRAINT [PK_LeaveRequests] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_LeaveRequests_AspNetUsers_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_LeaveRequests_AspNetUsers_ReviewerId] FOREIGN KEY ([ReviewerId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_LeaveRequests_LeaveRequestsStatus_LeaveRequestStatusId] FOREIGN KEY ([LeaveRequestStatusId]) REFERENCES [LeaveRequestsStatus] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_LeaveRequests_LeaveTypes_LeaveTypeId] FOREIGN KEY ([LeaveTypeId]) REFERENCES [LeaveTypes] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f3448854-8957-4b4f-9316-e83a3e6dc4cb'', [PasswordHash] = N''AQAAAAIAAYagAAAAEHOlaPexbZX+1tAgxaIj9qoGNHQZhuLTno1HSchKyAE8X6sZAx1Ge2Z7BvDbWKPolQ=='', [SecurityStamp] = N''5c6befcb-9682-4bbe-ac77-f09cf4a3ed67''
    WHERE [Id] = N''b6be7770-6c3d-42ce-97a7-7efdba0fb30a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[LeaveRequestsStatus]'))
        SET IDENTITY_INSERT [LeaveRequestsStatus] ON;
    EXEC(N'INSERT INTO [LeaveRequestsStatus] ([Id], [Name])
    VALUES (1, N''Pending''),
    (2, N''Approved''),
    (3, N''Declined''),
    (4, N''Cancelled'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[LeaveRequestsStatus]'))
        SET IDENTITY_INSERT [LeaveRequestsStatus] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    CREATE INDEX [IX_LeaveRequests_EmployeeId] ON [LeaveRequests] ([EmployeeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    CREATE INDEX [IX_LeaveRequests_LeaveRequestStatusId] ON [LeaveRequests] ([LeaveRequestStatusId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    CREATE INDEX [IX_LeaveRequests_LeaveTypeId] ON [LeaveRequests] ([LeaveTypeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    CREATE INDEX [IX_LeaveRequests_ReviewerId] ON [LeaveRequests] ([ReviewerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250702162353_LeaveRequestEntity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250702162353_LeaveRequestEntity', N'8.0.15');
END;
GO

COMMIT;
GO

