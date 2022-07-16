if(not exists(select 1 from dbo.[User]))
begin
	insert into dbo.[User] (FirstName,LastName)
	values('sujith','kumar'),('Renuka','L'),('Sagar','Y'),('Manoj','known'),('Jhon','Smit');
end
