--Users Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'users')
Begin
	Create table users(
		id int primary key not null identity(1,1),
		name varchar(255)
	);
End

--Groups  Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'groups')
Begin
	Create table groups(
		id int primary key not null identity(1,1),
		name varchar(255),
		creator_id int,
		created_at datetime default(getdate()),
		constraint group_created_by foreign key(creator_id) references dbo.users(id) on update cascade on delete cascade
	);
End

--Group Members  Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'group_members')
Begin
	Create table group_members(
		group_id int not null,
		member_id int not null,
		primary key(group_id, member_id),
		constraint group_member foreign key(member_id) references dbo.users(id) on update no action on delete no action,
		constraint group_name foreign key(group_id) references dbo.groups(id) on update cascade on delete cascade,
	);
End

--document types  Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'document_types')
Begin
	Create table document_types(
		id int primary key identity(1, 1),
		type varchar(255) not null,
	);
End

--document  Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'documents')
Begin
	Create table documents (
		id int primary key identity(1, 1),
		name varchar(255) not null,
		created_at datetime default(getdate()),
		creator_id int not null,
		type_id int not null,
		constraint document_type foreign key(type_id) references dbo.document_types(id) on update cascade on delete cascade,
	);
End

--roles  Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'roles')
Begin
	Create table roles(
		id int primary key identity(1, 1),
		role varchar(255) not null,
	);
End

--document_auth_groups  Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'document_auth_groups')
Begin
	CREATE TABLE document_auth_groups (
    document_id INT NOT NULL,
    group_id INT NOT NULL,
    role_id INT NOT NULL,
    PRIMARY KEY (document_id, group_id),
    CONSTRAINT group_auth_document FOREIGN KEY (document_id) REFERENCES dbo.documents(id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT group_auth_group FOREIGN KEY (group_id) REFERENCES dbo.groups(id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT group_auth_role FOREIGN KEY (role_id) REFERENCES dbo.roles(id) ON UPDATE CASCADE ON DELETE CASCADE
);

End

--document_auth_users Table
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'document_auth_users')
Begin
	Create table document_auth_users(
		document_id int not null,
		user_id int not null,
		role_id int not null,
		primary key(document_id, user_id),
		constraint user_auth_document foreign key(document_id) references dbo.documents(id) on update cascade on delete cascade,
		constraint user_auth_user foreign key(user_id) references dbo.users(id) on update cascade on delete cascade,
		constraint user_auth_role foreign key(role_id) references dbo.roles(id) on update cascade on delete cascade,
	);
End

-- insert roles into table
if not exists (select * from roles)
begin
	insert into roles values('owner');
	insert into roles values('editor');
	insert into roles values('read-only');
end

-- insert users into table
if not exists (select * from users)
begin
	insert into users values('saad');
	insert into users values('hamza');
end

-- create groups
if not exists (select * from groups)
begin
	insert into groups(name , creator_id) values('trainees', 1);
end

-- add group members
if not exists (select * from group_members)
begin
	insert into group_members values(1, 2);
end

-- add document types
if not exists (select * from document_types)
begin
	insert into document_types values('text');
	insert into document_types values('doc');
	insert into document_types values('spreadsheet');
end

-- add document
if not exists (select * from documents)
begin
	insert into documents(name, creator_id, type_id) values('Trainings Progress', 1, 3);
end

-- add group authorization to document
if not exists (select * from document_auth_groups)
begin
	insert into document_auth_groups values(1, 1, 2);
end

select * from INFORMATION_SCHEMA.TABLES;

select * from roles;

select * from users;

select * from groups;

select u.name as 'user', g.name as 'group', g.created_at from group_members gm 
inner join groups g on gm.group_id = g.id 
inner join users u on u.id = gm.member_id;

select * from document_types;

select d.id , d.name as 'document', u.name as 'creator', dt.type from documents d
inner join users u on u.id = d.creator_id
inner join document_types dt on dt.id = d.type_id;

select d.id, d.name as 'document', g.name as 'group', r.role  from document_auth_groups dg
inner join documents d on d.id = dg.document_id
inner join groups g on g.id = dg.group_id
inner join roles r on r.id = dg.role_id;