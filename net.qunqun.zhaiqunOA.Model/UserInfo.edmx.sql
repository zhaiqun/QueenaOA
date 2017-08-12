
-- Warning: There were errors validating the existing SSDL. Drop statements
-- will not be generated.
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2014 18:13:33
-- Generated from EDMX file: D:\黑马培训课程\zhaiqunOA\net.qunqun.zhaiqunOA.Model\UserInfo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [zhaiqunOADB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [UserPwd] nvarchar(50)  NOT NULL,
    [UserTrueName] nvarchar(50)  NULL,
    [IsDelete] bit  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(1000)  NULL
);
GO

-- Creating table 'DepartInfo'
CREATE TABLE [dbo].[DepartInfo] (
    [DepartId] int IDENTITY(1,1) NOT NULL,
    [DepartName] nvarchar(10)  NOT NULL,
    [DepartParentId] int  NULL,
    [IsDelete] bit  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(1000)  NULL
);
GO

-- Creating table 'RoleInfo'
CREATE TABLE [dbo].[RoleInfo] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(10)  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(1000)  NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ActionId] int IDENTITY(1,1) NOT NULL,
    [ActionTitle] nvarchar(50)  NOT NULL,
    [ContorllerName] nvarchar(50)  NOT NULL,
    [ActionName] nvarchar(50)  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(1000)  NULL,
    [IsMenu] bit  NOT NULL,
    [MenuIcon] nvarchar(max)  NULL
);
GO

-- Creating table 'UserAction'
CREATE TABLE [dbo].[UserAction] (
    [UserId] int  NOT NULL,
    [ActionId] int IDENTITY(1,1) NOT NULL,
    [HasPermission] bit  NOT NULL,
    [UserInfoUserId] int  NOT NULL,
    [ActionInfo_ActionId] int  NOT NULL
);
GO

-- Creating table 'UserInfoRoleInfo'
CREATE TABLE [dbo].[UserInfoRoleInfo] (
    [UserInfo_UserId] int  NOT NULL,
    [RoleInfo_RoleId] int  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [RoleInfo_RoleId] int  NOT NULL,
    [ActionInfo_ActionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [DepartId] in table 'DepartInfo'
ALTER TABLE [dbo].[DepartInfo]
ADD CONSTRAINT [PK_DepartInfo]
    PRIMARY KEY CLUSTERED ([DepartId] ASC);
GO

-- Creating primary key on [RoleId] in table 'RoleInfo'
ALTER TABLE [dbo].[RoleInfo]
ADD CONSTRAINT [PK_RoleInfo]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [ActionId] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ActionId] ASC);
GO

-- Creating primary key on [UserId], [ActionId] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [PK_UserAction]
    PRIMARY KEY CLUSTERED ([UserId], [ActionId] ASC);
GO

-- Creating primary key on [UserInfo_UserId], [RoleInfo_RoleId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [PK_UserInfoRoleInfo]
    PRIMARY KEY NONCLUSTERED ([UserInfo_UserId], [RoleInfo_RoleId] ASC);
GO

-- Creating primary key on [RoleInfo_RoleId], [ActionInfo_ActionId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY NONCLUSTERED ([RoleInfo_RoleId], [ActionInfo_ActionId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_UserId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_UserInfo]
    FOREIGN KEY ([UserInfo_UserId])
    REFERENCES [dbo].[UserInfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleInfo_RoleId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_RoleId])
    REFERENCES [dbo].[RoleInfo]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRoleInfo_RoleInfo'
CREATE INDEX [IX_FK_UserInfoRoleInfo_RoleInfo]
ON [dbo].[UserInfoRoleInfo]
    ([RoleInfo_RoleId]);
GO

-- Creating foreign key on [RoleInfo_RoleId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_RoleId])
    REFERENCES [dbo].[RoleInfo]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_ActionId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ActionId])
    REFERENCES [dbo].[ActionInfo]
        ([ActionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_ActionInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_ActionInfo]
ON [dbo].[RoleInfoActionInfo]
    ([ActionInfo_ActionId]);
GO

-- Creating foreign key on [UserInfoUserId] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [FK_UserInfoUserAction]
    FOREIGN KEY ([UserInfoUserId])
    REFERENCES [dbo].[UserInfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoUserAction'
CREATE INDEX [IX_FK_UserInfoUserAction]
ON [dbo].[UserAction]
    ([UserInfoUserId]);
GO

-- Creating foreign key on [ActionInfo_ActionId] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [FK_UserActionActionInfo]
    FOREIGN KEY ([ActionInfo_ActionId])
    REFERENCES [dbo].[ActionInfo]
        ([ActionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserActionActionInfo'
CREATE INDEX [IX_FK_UserActionActionInfo]
ON [dbo].[UserAction]
    ([ActionInfo_ActionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------