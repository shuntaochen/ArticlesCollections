Let's write a framework.
1. create a model var model={a:1,b:'b'}
2. let's create a router, router maps url to concrete object and returns response, router is a collection
3. let's create a manager for managing all our clients, to per request there is a client, or shared
4. let's organize our request params, and apply request pipeline filters, read identity from cookie
5. let's interact with database
6. let's create a configuration manager which handles configuration loaders from different sources
7. let's create a language manager
8. let's create a base facade for our service base class
9. let's create a type manager and apply di
9. let's find from our ioc container the type that matches our router
10. let's instantiate an object by the type
11. let's execute the method router requires
12. write the execution result to response
13. apply result filters
14. send to client.

14. for model binding type, mvvm requires to audit property changes and recalculates the whole view model, mvc just binds the value to ui, mvp abstracts the view into an interface and handles all view relevant logic in presenter, old store pattern first gets all data, and keeps a state which is bad for interaction type apps.

15. Further more, let's create a socket as server binded to a port and accepts data by tcp/ip protocol.

16. Whenever our server socket receives a socket connection as client, store the client to static memory by a manager class. 
