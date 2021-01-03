<Query Kind="Program">
  <Connection>
    <ID>4d5959dc-8c9b-4b53-b483-2ac819afc214</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	//to set lines as comments CRTL (HOLD) K, C
	//to uncomment CRTL (Hold) K, U
	
	//Anonymous Types
	
	//this is used when you are not selecting the entire
	//record using  Select x => x
	//
	//normally used when you have
	//a) subset of table
	//b) records from multiple tables
	
	//List all customers in alphabetic order by last name,
	//  firstname who live in the USA with a yahoo email.
	//Show only, the customer id, lastname, firstname (as one) and
	//the city and state in which they reside.
	
	var results = from x in Customers
					where x.Country.Equals("USA") 
						&& x.Email.Contains("yahoo")
					orderby x.LastName, x.FirstName
					select new
					{
						ID = x.CustomerId,
						Name = x.LastName + ", " + x.FirstName,
						City = x.City,
						State = x.State
					};
	
	//to display the results of a query code in the Statement
	//  environment, you need to use .Dump()
	//.Dump() is NOT C#
	//.Dump() is a method within LinqPad
	//.Dump() CAN NOT be used in your real code
	
	results.Dump();
	
	//List all the albums released in 1990, ordered by Title. Show
	//the Album title, the Artist Name, and the Release Label. If
	//there is no Label display "UnKnown".
	
	//subset
	//literial Unknown
	//both Album and Artist data
	
	var results2 = from x in Albums
					where x.ReleaseYear == 1990
					orderby x.Title
					select new AlbumsOfYear
					{
						Title = x.Title,
						Name = x.Artist.Name,
						Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
					};
	results2.Dump();
	
}

// Define other methods, classes and namespaces here
public class AlbumsOfYear
{
	public string Title{get;set;}
	public string Name{get;set;}
	public string Label{get;set;}
}


















