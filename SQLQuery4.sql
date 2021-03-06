USE [obracunBaza]
GO
/****** Object:  StoredProcedure [dbo].[dodajObracun]    Script Date: 10/19/2021 8:19:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[dodajObracun]  
(  
   @Ime varchar (50),  
   @Prezime varchar (50),  
   @Adresa varchar (50),  
   @fondCasova int,
   @osnNetoZarada decimal(18,2),
   @iznPoreza decimal(18,2),
   @iznDoprinosaPio decimal(18,2),
   @iznDoprinosaZaZdrav decimal(18,2),
   @iznDoprinosaZaNezap decimal(18,2),
   @netoOsnovica decimal(18,2),
   @BrutoPlata decimal(18,2),
   @ObracunID int out
)  
as  
begin  
   Insert into Obracun values(@Ime,@Prezime,@Adresa,@fondCasova,@osnNetoZarada,
   @iznPoreza,@iznDoprinosaPio,@iznDoprinosaZaZdrav,@iznDoprinosaZaNezap,@netoOsnovica,@BrutoPlata)  set @ObracunID=SCOPE_IDENTITY() return @ObracunID 
End