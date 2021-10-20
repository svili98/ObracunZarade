Create procedure [dbo].[dodajSQL]  
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
   @BrutoPlata decimal(18,2)
)  
as  
begin  
   Insert into Obracun values(@Ime,@Prezime,@Adresa,@fondCasova,@osnNetoZarada,
   @iznPoreza,@iznDoprinosaPio,@iznDoprinosaZaZdrav,@iznDoprinosaZaNezap,@netoOsnovica,@BrutoPlata)  
End  