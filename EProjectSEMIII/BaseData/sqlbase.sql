use EProjectSEMIII
go 
insert into Admin(UserName,Password,Status,AdminName,Email,Phone) values
('admin','2251022057731868917119086224872421513662',0,'Admin 1','admin1@gmail.com','0373188911')
go
insert into CustomerRecord(UserName,Password,Status,CustomerName,CustomerAdd,CustomerPhone) values
('user1','2251022057731868917119086224872421513662',0,'Nguyen Van Hoang','Ha Noi','0373188913'),
('user2','2251022057731868917119086224872421513662',0,'Hoang Duc Anh','Ha Noi','0373124322')
go
insert into VehicleType(NameOfVehicleType,Status)values
('Toyota',0),
('Hyundai',0),
('Honda',0),
('Mazda',0),
('Suzuki',0)
go
insert into InsideVehicleType(Name,Status,VehicleTypeId)values
('Toyota cross',0,1),
('Hyundai creta',0,2),
('Mazda 5',0,4),
('Honda City',0,3)
go

insert into InsuranceType(TypeOfInsurence,Price,Status)values
('Liability Coverage',20,0),
('Collision insurance',30,0),
('Comprehensive insurance',35,0)
go

insert into Sitemap(Address,Position,LinkedMap)values('Ha Noi',1,'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d59587.94583112209!2d105.80194395895832!3d21.022816135727428!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135ab9bd9861ca1%3A0xe7887f7b72ca17a9!2zSMOgIE7hu5lpLCBIb8OgbiBLaeG6v20sIEjDoCBO4buZaSwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1674209137343!5m2!1svi!2s'),
('Ho Chi Minh',2,'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1003449.6852539227!2d106.13469869341654!3d10.755639034903155!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317529292e8d3dd1%3A0xf15f5aad773c112b!2zSOG7kyBDaMOtIE1pbmgsIFRow6BuaCBwaOG7kSBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1674209210177!5m2!1svi!2s'),
('Nha Trang',3,'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d249525.13026459425!2d109.10641261569273!3d12.259770139693583!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3170677811cc886f%3A0x5c4bbc0aa81edcb9!2zTmhhIFRyYW5nLCBLaMOhbmggSMOyYSwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1674209274237!5m2!1svi!2s'),
('Da Nang',4,'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d245367.8539767511!2d107.93803724807793!3d16.072093426326763!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x314219c792252a13%3A0x1df0cb4b86727e06!2zxJDDoCBO4bq1bmcsIFZp4buHdCBOYW0!5e0!3m2!1svi!2s!4v1674209340125!5m2!1svi!2s'),
('Ha Long',5,'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d238439.88475085507!2d106.90278532376807!3d20.967641743853417!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x314a583f825ff2c9%3A0xc5d143510be28d44!2zVHAuIEjhuqEgTG9uZywgUXXhuqNuZyBOaW5oLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1674209406061!5m2!1svi!2s')
go
insert into VehicleInfomation values
('Toyota cross','Nguyen Van Hoang','Model 2022','V1',1,'213121','3123123','31231',0,1,1),
('Hyundai creta','Nguyen Van Hoang','Model 2022','V2',1,'324323','4324323','12345',0,1,2),
('Mazda 5','Nguyen Van Hoang','Model 2021','V3',1,'432312','6545647','65444',0,1,3),
('Honda City','Nguyen Van Hoang','Model 2023','V2',1,'983121','4234076','88888',0,1,4)
go
insert into Estimate(CustomerName,CustomerPhone,EstimateNumber,VehicleName,VehicleModel,VehicleRate,VehicleWarranty,VehiclePolicyType,Status,VehicleInfomationId,InsuranceTypeId) values
('Nguyen Van Hoang','0373188913',5000,'Toyota cross','Model 2022',1,'Airbags, Seat Belts','Collision Coverage',0,1,1),
('Nguyen Van Hoang','0373188913',6000,'Toyota cross','Model 2022',1,'Engine','Auto Liability Coverage',0,1,2),
('Nguyen Van Hoang','0373188913',7000,'Toyota cross','Model 2022',1,'Gearbox','Auto Liability Coverage',0,1,3),
('Nguyen Van Hoang','0373188913',4500,'Hyundai creta','Model 2023',1,'Engine','Auto Liability Coverage',0,1,3)
go 
insert into CustomerSupport(Question,Answer)values('How much money do you need to buy insurance?','There are many types of prices you can choose according to your requirements'),
('What do you need to buy car insurance?','Need buyer information and car information to buy insurance'),
('Should I buy or not buy insurance?','Should buy because insurance will pay a sum if the car has damage or deformation of the outer shell')


