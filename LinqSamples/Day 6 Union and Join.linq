<Query Kind="Statements">
  <Connection>
    <ID>58e8792e-17b8-4cab-8fb7-b182b5bc078f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Union
//In a union you need to ensure cast typing is correct and
//  column cast type match is identically
//Union will combine 2 or more queries into one result
//Each query needs to have the same number of columns, in the
//   same order
//Remember that Average returns a double 
//
//syntax
//  (query1).union(query2).union(queryn).OrderBy(first sort).ThenBy(nth sort)

//generate a report covering all albums showing their title
//   their track count, the album price, and average track length
//Order by number of tracks on album, then by album title

var unionresults = (from x in Albums
					where x.Tracks.Count > 0
					select new
					{
						title = x.Title,
						trackcount = x.Tracks.Count(),
						albumprice = x.Tracks.Sum(y => y.UnitPrice),
						averagelength = x.Tracks.Average(y =>y.Milliseconds/1000.0d)
					}
					).Union(from x in Albums
							where x.Tracks.Count == 0
							select new
							{
								title = x.Title,
								trackcount = 0,
								albumprice = 0.00m,
								averagelength = 0.0
							}).OrderBy(y => y.trackcount).ThenBy(y => y.title);					
//unionresults.Dump();

//Joins

// www.dotnetlearners.com/linq

//Avoid joins if there is an acceptable navigational property (auto inner joins)
//joins can be used where navigational property DO NOT EXIST
//joins can be used between associated entities
//   scarenio fkey <==> pkey

//left side of the join should be the support data
//right side of the join is the record collection to be processed

//assume there is NO navigational property between artist and album

//create a list of albums showing their title, release year, relase label( or Unknown),
//  the associate artist and number of tracks for the album

//  syntax
//  leftside entity join rightside entity on leftside.pkey == rightside.fkey
//    supportside join processside on supportpkey == processfkey
//
//our question support => artist, processing => album

var joinResults = from supportside in Artists
					join processside in Albums
					on supportside.ArtistId equals processside.ArtistId
					select new
					{
						title = processside.Title,
						year = processside.ReleaseYear,
						label = processside.ReleaseLabel == null ? "Unknown" : processside.ReleaseLabel,
						artist = supportside.Name,
						trackcount = processside.Tracks.Count()
					};
joinResults.Dump();





















