
This repository is intended to host a basic MongoDB provider implementation for Entity Framework Core. **You should not try to use it for a real-life development** as it won't support all of the functionalities you'd want to use. These plans may eventually change in the future.

As of the writing of these lines, everything you could find here is a **really early stage**, so you shouldn't expect anything from it. 

On the other hand, if anyone want to provide help, I'd be glad to receive it. 

###### Technical informations

The underlying connection will be handled at first using the .NET driver for MongoDB :

* Nuget Package : https://www.nuget.org/packages/MongoDB.Driver/
* Github : https://github.com/mongodb/mongo-csharp-driver

Using MongoDB.Driver.Core may be a better way of doing things, I'll check it later.
