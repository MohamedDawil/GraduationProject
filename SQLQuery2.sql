create schema fresh
go
create table fresh.product (
	Id int primary key identity not null,
	[Name] nvarchar(256) not null,
	Freshness int not null,
	ExpiryDate datetime2 not null,
	[Description] nvarchar(max) not null,
	PickUpDate1 datetime2 not null,
	PickUpDate2 datetime2 not null,
	Claimed bit not null,
	Collected bit not null,
	Picture nvarchar(max) not null,
	PublishDate datetime2 not null,
	GiverId nvarchar(450) references dbo.AspNetUsers(Id) not null,
	ReceiverId nvarchar(450) references dbo.AspNetUsers(Id) null,
	Latitude nvarchar(max) not null,
	Longitude nvarchar(max) not null
)
Go

drop table fresh.product
go

create procedure CreateProduct
@name nvarchar(256), 
@freshness int, 
@expiryDate datetime2,
@amount int,
@pickUpDate1 datetime2,
@pickUpDate2 datetime2,
@claimed bit,
@collected bit,
@picture nvarchar(max),
@publishDate datetime2,
@giverId nvarchar(450),
@latitude geography,
@longitude geography as


begin
    insert into
        Product
    values
        (@name, @freshness, @expiryDate, @amount, @pickUpDate1, @pickUpDate2, @claimed,
		@collected, @picture, @publishDate, @giverId, @latitude, @longitude)
end
go
