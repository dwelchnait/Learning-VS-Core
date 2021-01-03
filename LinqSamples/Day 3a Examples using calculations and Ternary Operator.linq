<Query Kind="Expression">
  <Connection>
    <ID>4d5959dc-8c9b-4b53-b483-2ac819afc214</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//create an alphabetic list of Albums by decades
//70s, 80s, 90s, modern. Show the Album title and the decade
//it was produced.
from x in Albums
where x.ReleaseYear > 1969
orderby x.Title
select new
{
	Title = x.Title,
	Year = x.ReleaseYear,
	Decade = x.ReleaseYear > 1969 && x.ReleaseYear < 1980 ? "70s" :
				x.ReleaseYear > 1979 && x.ReleaseYear < 1990 ? "80s" :
				x.ReleaseYear > 1989 && x.ReleaseYear < 2000 ? "70s" :
				"modern"
	}
	
//List all tracks and indicate the play time in minutes and storage to the nearest
//kilobytes (rounded up). Show track name, play time and storage.
from x in Tracks
select new
{
	Name = x.Name,
	PlayTime = (x.Milliseconds / 60000).ToString() + "min " +
				(x.Milliseconds % 60000 / 1000).ToString() + "sec",
	Storage = x.Bytes / 1024 + 1
}
	
	
	
	
	
	
	
	
	
	