USE [DealcoinDB]
GO

USE [DealcoinDB]
GO

INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('T�l�phonie',0,2,'T�l�phones',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('High-Tech et Informatique',0,2,'High-Tech et Informatique',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Sports et Loisirs',0,2,'Sports et Loisirs',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('V�tements, Chaussures, Bijoux',0,2,'V�tements, Chaussures, Bijoux',0,0,'2010-04-02')
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

INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,2,'MacBookPro','./maphoto.png','Super etat reconditioner a neuf','1000�',null,null,null,null,'2017-04-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,3,'Chausure de foot','./maphoto.png','Le top du son !','100�',null,null,null,null,'2017-05-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,4,'Jean','./maphoto.png','Jean desiel','100�',null,null,null,null,'2017-01-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,2,'Enceinte JBL','./maphoto.png','Le top du son !','1000�',null,null,null,null,'2017-02-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,3,'Balon de rugby','./maphoto.png','Gilbert','10�',null,null,null,null,'2017-03-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,4,'Tong','./maphoto.png','Havaiana','10�',null,null,null,null,'2017-06-02',null,null)
GO

--//orders

INSERT INTO [dc].[orders]([usersId],[fname],[lname],[phone],[addresse],[departement],[city],[postale],[delivery_fname],[delivery_lname],[delivery_phone],[delivery_adresse],[delivery_departement],[delivery_city],[delivery_postale],[shipping_cost],[sales_date])VALUES(2,'Patrick','dupond','0146832170','14 rue du generale de gaule','idf','Paris','75016',null,null,null,null,null,null,null,10,'2017-06-02')
INSERT INTO [dc].[orders]([usersId],[fname],[lname],[phone],[addresse],[departement],[city],[postale],[delivery_fname],[delivery_lname],[delivery_phone],[delivery_adresse],[delivery_departement],[delivery_city],[delivery_postale],[shipping_cost],[sales_date])VALUES(1,'jojo','dupond','0146782170','26 rue du generale de gaule','idf','Paris','75016',null,null,null,null,null,null,null,10,'2017-10-02')
--orderProduct

INSERT INTO [dc].[ordersProducts]([ordersId],[productsId],[title],[photo],[desc1],[price])VALUES(0,8,'Ce site vent que des t�l�phones ?','./maphoto.png','Super 3310 !','10�')




