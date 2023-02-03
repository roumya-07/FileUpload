Create Table FileUpload
(
Name Varchar(100),
Photo Varchar(100)
);


Create Procedure SP_FileUpload
(
@Name Varchar(100) = null,
@Photo Varchar(100) = null,
@Action Varchar(50))
as
begin
if(@Action= 'Insert')
Insert Into FileUpload 
Values(@Name,@Photo);
end

select * From FileUpload

