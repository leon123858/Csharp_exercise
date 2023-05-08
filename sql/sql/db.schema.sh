# create database
create database TodoList; # 創建資料庫
show databases; # 顯示資料庫
use TodoList; # 使用資料庫

# create table
drop table if exists TodoItem;
create table TodoItem (
    Id nvarchar(50) not null,
    Name nvarchar(50),
    IsComplete bool ,
    PRIMARY KEY (Id)
);
