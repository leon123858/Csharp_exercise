drop table if exists TodoItem;
create table TodoItem (
    Id nvarchar(50) not null,
    Name nvarchar(50),
    IsComplete bool ,
    PRIMARY KEY (Id)
);