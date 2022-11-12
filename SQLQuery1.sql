create database Employee_MVC


use Employee_MVC

create table EmployeeDetails(
Id int primary key identity,
Name varchar(20) not null,
ProfImg varchar(max) not null,
Gender varchar(20) not null,
Department varchar(50) not null,
Salary money not null,
StartDate date
)

select * from EmployeeDetails

--AddEmp
create procedure sp_AddEmployee(@Name varchar(100),@ProfImg varchar(max),@Gender varchar(20),@Department varchar(50),@Salary money,@StartDate date)
as
begin
insert into EmployeeDetails values(@Name,@ProfImg,@Gender,@Department,@Salary,@StartDate)
end

--GetAllEmp
create procedure sp_getAllEmp
as
begin
select * from EmployeeDetails
end

--DeleteEmp
create procedure sp_DeleteEmp(@Id int)
as
begin
delete from EmployeeDetails where Id=@Id
end

--get Empdetails by Id
create procedure sp_getDetailsbyId(@Id int)
as
begin
 where Id=@Id
end

exec sp_getDetailsbyId 2


--update
create procedure sp_UpdateDetails(@Id int,@Name varchar(100),@ProfImg varchar(max),@Gender varchar(20),@Department varchar(50),@Salary money,@StartDate date)
as
begin
update EmployeeDetails 
set Name=@Name,ProfImg=@ProfImg,Gender=@Gender,Department=@Department,Salary=@Salary,StartDate=@StartDate
where Id=@Id
end
 
