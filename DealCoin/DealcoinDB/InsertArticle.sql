USE [DealcoinDB]
GO

USE [DealcoinDB]
GO

INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('T�l�phonie',0,2,'T�l�phones',0,0,'2010-04-02')
GO
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Premier t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Second t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Troisieme t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'un autre t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'encore un autre t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Eh oui poto un t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Encore un t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Un t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'lol','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'T�l�phone sans fil','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'T�l�phone vol�','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'t�l�phone trouv�','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Vive les t�l�phones','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Ceci est un t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Encore un t�l�phone','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,1,'Ce site vent que des t�l�phones ?','./maphoto.png','Super 3310 !','10�',null,null,null,null,null,null,null)
GO

--//orders

INSERT INTO [dc].[orders]([usersId],[fname],[lname],[phone],[addresse],[departement],[city],[postale],[delivery_fname],[delivery_lname],[delivery_phone],[delivery_adresse],[delivery_departement],[delivery_city],[delivery_postale],[shipping_cost])VALUES(2,'Patrick','dupond','0146832170','14 rue du generale de gaule','idf','Paris','75016',null,null,null,null,null,null,null,10)

--orderProduct

INSERT INTO [dc].[ordersProducts]([ordersId],[productsId],[title],[photo],[desc1],[price])VALUES(0,8,'Ce site vent que des t�l�phones ?','./maphoto.png','Super 3310 !','10�')




