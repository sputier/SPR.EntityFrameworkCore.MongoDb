
This repository is intended to host a basic MongoDB provider implementation for Entity Framework Core. **You should not try to use it for a real-life development** as it won't support all of the functionalities you'd want to use. These plans may eventually change in the future.

As of the writing of these lines, everything you could find here is a **really early stage**, so you shouldn't expect anything from it. 

On the other hand, if anyone want to provide help, I'd be glad to receive it. 

###### Current status

[![Build status](https://ci.appveyor.com/api/projects/status/jrcxkt8g43j278ho?svg=true)](https://ci.appveyor.com/project/sputier/spr-entityframeworkcore-mongodb)

At the moment, the provider can handle very simple Find queries, without any filter or projection. In the SQL world, we'd say it can handle SELECT * FROM table queries. 

The test application execute 3 Find queries and display their results in the console. 

The sample database used to test the provider contains 3 collections : 

**Customer** :
One document described below.
~~~~
{
    "_id": {
        "$oid": "583407e7f36d28568d3171eb"
    },
    "FirstName": "Jean",
    "LastName": "Dupont",
    "PhoneNumber": "0102030405"
}
~~~~

**City** :
29353 documents built from http://media.mongodb.org/zips.json 

The first one is described below : 
~~~~
{
    "_id": {
        "$oid": "583996e86b658852bc27ffd0"
    },
    "Zip": "01001",
    "Name": "AGAWAM",
    "Location": [
        "-72.622739",
        "42.070206"
    ],
    "Population": 15338,
    "State": "MA"
}
~~~~

**Persons** :
2 documents described below : 
~~~~
{
    "_id": {
        "$oid": "583407e7f36d28568d3171eb"
    },
    "FirstName": "Jean",
    "LastName": "Dupont",
    "PhoneNumber": "0102030405"
},
{
    "_id": {
        "$oid": "585c4f09734d1d400d12898a"
    },
    "FirstName": "Michel",
    "LastName": "Martin",
    "PhoneNumber": "0504030201"
}
~~~~

###### Usage informations
At the moment, two Data Annotations have been implemented : [Field(name)] and [Collection(name)].
They are used to configure the field name relative to a property and the collection name relative to an entity type.

###### Technical informations

The underlying connection will be handled at first using the .NET driver for MongoDB :

* Nuget Package : https://www.nuget.org/packages/MongoDB.Driver/
* Github : https://github.com/mongodb/mongo-csharp-driver

Using a low-level driver may be a better way of doing things, I'll check it later.
