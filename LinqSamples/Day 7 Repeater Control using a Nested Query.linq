<Query Kind="Program">
  <Connection>
    <ID>ecafa140-05d4-414f-af79-0d35352e5dfd</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	var lowestplaylistsize = 20;
	var results = from x in Playlists
					orderby x.UserName
					where x.PlaylistTracks.Count() >= lowestplaylistsize
					select new PlayListItem
					{
						Name = x.Name,
						TrackCount = x.PlaylistTracks.Count(),
						UserName = x.UserName,
						Songs = from y in x.PlaylistTracks
								orderby y.Track.Genre.Name, y.Track.Name
								select new PlayListSong
								{
									Song = y.Track.Name,
									GenreName = y.Track.Genre.Name
								}
					};
	results.Dump();
}

// You can define other methods, fields, classes and namespaces here
public class PlayListItem
{
	public string Name{get;set;}
	public int TrackCount{get;set;}
	public string UserName{get;set;}
	public IEnumerable<PlayListSong> Songs{get;set;}
}

public class PlayListSong
{
	public string Song{get;set;}
	public string GenreName{get;set;}
}