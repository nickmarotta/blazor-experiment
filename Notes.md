# Notes for future use. 

## Helpful Links
* https://docs.mongodb.com/drivers/csharp/
* https://mongodb.github.io/mongo-csharp-driver/2.12/getting_started/installation/
* https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli
* [Mongo Shell Cheat Sheet](https://docs.mongodb.com/manual/reference/mongo-shell/)
* https://www.freecodecamp.org/news/how-to-perform-crud-operations-using-blazor-with-mongodb-8ee216ad513e/
* https://github.com/AnkitSharma-007/Blazor-CRUD-With-MongoDB
* [Mongo Text Search Index](https://stackoverflow.com/questions/6790819/searching-for-value-of-any-field-in-mongodb-without-explicitly-naming-it)
* [Mongo Text Index Docs](https://docs.mongodb.com/manual/core/index-text/)

## Command Help 

Start mongo docker container with appropriate ports exposed
```bash
docker run -d -p 27017:27017 -p 28017:28017 mongo
```

## Packages I Added 

Below are how I used the nuget package manager from the command line. 
The packages appear to go into the `blazor-experiment.csproj` file.

```bash
dotnet add package MongoDB.Driver
```
```bash
dotnet add package MongoDB.Bson
```

## Mongo Queries 

```javascript



db.Students.insertOne({
    "FirstName": "Harry",
    "LastName": "Potter",
    "House": "Gryffindor"
})

db.Students.insertOne({
    "FirstName": "Ron",
    "LastName": "Weasely",
    "House": "Gryffindor"
})

db.Students.insertOne({
    "FirstName": "Draco",
    "LastName": "Malfoy",
    "House": "Slytherin"
})

db.Students.insertOne({
    "FirstName": "Luna",
    "LastName": "Lovegood",
    "House": "Ravenclaw"
})

db.students.deleteOne({
    "firstName": { $eq: "Harry"}
})

db.students.deleteOne({
    "firstName": { $eq: "Draco"}
})

db.Students.createIndex( { FirstName: "text", LastName:"text", House:"text" } )


```