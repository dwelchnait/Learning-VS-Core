<Query Kind="Expression">
  <Connection>
    <ID>4d5959dc-8c9b-4b53-b483-2ac819afc214</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Aggregrates
//.Count(), .Sum(), .Max(), .Min(), .Average()

//.Sum, .Max, .Min, .Average require a delegate expression
//aggregrates work ONLY on a collection of data NOT on a single row
//a collection CAN have 0, 1 or more rows
from x in Tracks
select new
{
	Name = x.Name,
	AvgLength = x.Average(x => x.Milliseconds) //wrong a single row
	}
	
Tracks.Average(x => x.Milliseconds) //fine Tracks is a collection
Tracks.Count() //fine Tracks is a collection

//for most of my coding using aggregrate, I will be using method syntax

//List all Albums showing, the Title, Artist Name and number of tracks
//on that album

//x (is the current Album instance).Tracks(navigational property).aggregrate
//because Tracks is a collection of the Album instance (ICollection<T>)
//    we can used the aggregrate on the expression
//HOWEVER
//we can NOT go x.Artist.aggregrate BECAUSE Artist is NOT a collection


//the other interesting point shown here is the use of BOTH query syntax
//   AND method syntax
//query syntax for the general query
//method syntax for the aggregrate
from x in Albums
where x.Tracks.Count() > 1
orderby x.Tracks.Count()
select new
{
	Title = x.Title,
	Artist = x.Artist.Name,
	Tracks = x.Tracks.Count(),
	AvgLength = x.Tracks.Average(y => y.Milliseconds),
	MaxLength =x.Tracks.Max(y => y.Milliseconds),
	MinLength = x.Tracks.Min(y => y.Milliseconds),
	AlbumPrice = x.Tracks.Sum(y => y.UnitPrice),
	BadPricing = x.Tracks.Count() * 0.99
}





