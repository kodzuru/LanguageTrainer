use LanguageTrainer
go

select * from ApplicationStates


go
select 
u2as.Id,
u.FirstName,
u.LastName,
aps.Name
from User2ApplicationStates as u2as
join Users as u on u.Id = u2as.UserId
join ApplicationStates as aps on aps.Id = u2as.ApplicationStateId