USE [DealcoinDB]
GO

USE [DealcoinDB]
GO

INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Téléphonie',0,1,'Téléphones',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('High-Tech et Informatique',0,1,'High-Tech et Informatique',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Sports et Loisirs',0,1,'Sports et Loisirs',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Vêtements, Chaussures, Bijoux',0,1,'Vêtements, Chaussures, Bijoux',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Téléphone portable',1,2,'Téléphone portable',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Téléphone fixe',1,2,'Téléphone fixe',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Housse et étuis',1,2,'Housse et étuis',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Accessoires',1,2,'Accessoires',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Appareil photo, Caméscopes',2,2,'Appareil photo, Caméscopes',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('TV, Home Cinéma',2,2,'TV, Home Cinéma',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Audio, HiFi',2,2,'Audio, HiFi',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Ordinateur',2,2,'Ordinateur',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Fitness, Musculation',3,2,'Fitness, Musculation',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Camping',3,2,'Camping',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Football',3,2,'Football',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Golf',3,2,'Golf',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Vêtements de sport',3,2,'Vêtements de sport',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Homme',4,2,'Homme',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Femme',4,2,'Femme',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Enfants',4,2,'Enfants',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Bijoux',4,2,'Bijoux',0,0,'2010-04-02')
INSERT INTO [dc].[categories]([name],[parentId],[type],[description],[status],[position],[posted_date])VALUES('Accessoires de mode',4,2,'Accessoires de mode',0,0,'2010-04-02')


GO
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,5,'Portable 1','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,5,'Portable 2','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,6,'Fixe1','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,6,'Fixe2','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,7,'Housse1','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,8,'Chargeur','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,8,'Ecouteurs','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,9,'GoPro','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,9,'Appareil photo Nikon','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,10,'Smart TV','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,10,'LG TV UHD','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,11,'Bose Speaker','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,11,'Enceinte JBL','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,12,'MacBookPro','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,12,'Lenovo Win10','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,13,'Whey Proteine','./maphoto.png','Super 3310 !','10€',0,null,null,null,null,null,null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,13,'Tapis de course','./maphoto.png','Super etat reconditioner a neuf','1000€',0,null,null,null,null,'2017-04-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,14,'Sac à dos multifonction','./maphoto.png','Le top du son !','100€',0,null,null,null,null,'2017-05-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,14,'Couteau suisse','./maphoto.png','Jean desiel','100€',0,null,null,null,null,'2017-01-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,15,'Balle de football','./maphoto.png','Le top du son !','1000€',0,null,null,null,null,'2017-02-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,16,'Sac de golf','./maphoto.png','Gilbert','10€',0,null,null,null,null,'2017-03-02',null,null)
INSERT INTO [dc].[products]([userId],[categoriesId],[title],[photo],[desc1],[price],[visits],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip])VALUES(1,17,'Chaussure de running','./maphoto.png','Havaiana','10€',0,null,null,null,null,'2017-06-02',null,null)
GO

--//orders

INSERT INTO [dc].[orders]([usersId],[fname],[lname],[phone],[addresse],[departement],[city],[postale],[delivery_fname],[delivery_lname],[delivery_phone],[delivery_adresse],[delivery_departement],[delivery_city],[delivery_postale],[shipping_cost],[sales_date])VALUES(2,'Patrick','dupond','0146832170','14 rue du generale de gaule','idf','Paris','75016',null,null,null,null,null,null,null,10,'2017-06-02')
INSERT INTO [dc].[orders]([usersId],[fname],[lname],[phone],[addresse],[departement],[city],[postale],[delivery_fname],[delivery_lname],[delivery_phone],[delivery_adresse],[delivery_departement],[delivery_city],[delivery_postale],[shipping_cost],[sales_date])VALUES(1,'jojo','dupond','0146782170','26 rue du generale de gaule','idf','Paris','75016',null,null,null,null,null,null,null,10,'2017-10-02')
--orderProduct

INSERT INTO [dc].[ordersProducts]([ordersId],[productsId],[title],[photo],[desc1],[price])VALUES(0,8,'Ce site vent que des téléphones ?','./maphoto.png','Super 3310 !','10€')




