<Query Kind="Expression">
  <Connection>
    <ID>4d5959dc-8c9b-4b53-b483-2ac819afc214</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Method syntax
Artists

Artists.Select(x => x)

//query syntax
from x in Artists
select x

//ordering
from x in Artists
orderby x.Name
select x

//filtering data
from x in Artists
where x.Name.Contains("Q")
select x

//sorting a filter set of data
from x in Artists
where x.Name.Contains("Q")
orderby x.Name
select x

Artists
   .Where (x => x.Name.Contains ("Q"))
   .OrderBy (x => x.Name)
   
//using query syntax, show all Albums released in 
//the 90's (1990-1999)

from x in Albums
where x.ReleaseYear > 1990 && x.ReleaseYear <=1999
orderby x.ReleaseYear descending, x.Title ascending
select x

//using method syntax, show all albums sort by Title
Albums
   .OrderBy (x => x.Title)

//list all customers in alphabetic order by last name
//who live in the USA.

//list all customers in alphabetic order by last name
//who have a yahoo email.