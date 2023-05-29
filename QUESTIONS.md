### Description
This is a document containing all my questions to my mentor. Their priority is based on what's relevant for the next session of work. It's sorted by meetups in a chronological order, with a pool of unanswered questions at the bottom.

### Meetup 3 (17.3.2023)
- Is this type of a folder and UI structure ok? ../carpool-group/add-group OR ../carpool-group/edit-group OR ../carpool-group/view-group
    - It's fine.

- Should I start writing tests immediately or do some more work before?
    - Start testing.

- What's the best way of loading dynamic content based on ID? Via arguments in the URL path? Like URL/user/1 OR URL?user=1?
    - Look into REST specification (https://stackoverflow.blog/2020/03/02/best-practices-for-rest-api-design/).

- How do you properly update used libraries and dependencies?
    - If the functionality is as we want it, then you just update the minor version (for example 2.3.X), which updates vulnerabilities, but should leave the current functionality untouched. I believe "npm fix" is used for that.
    - Proper libraries also update legacy versions with vulnerability fixes, but eventually you'll need to upgrade to a newer version. When dealing with major version updates it's best to look at the documentation on how to change old functionality to the new one.
    - You should regularly update libraries so that you fix problems as they arrive, plus that you don't fall too far behind.
    - Here's how I would go about updating multiple libraries in an application: First update all minor versions and fix those where the functionality has broken. Afterwards I'd update major versions one by one, fix all issues and test it, before moving to the next one.

- What exactly do you do as an architect? I understand that you build a projects structure, but what about when that is already done? Do you also do tasks or do you update libraries or documentation? Or do you look at what you could add to the project? Or are you also like a high level programmer that deals with some important problems?
    - The main job is to look into new technical things. Like how to properly deal with HTML to PDF conversion, making a Proof-of-Concept before use, how to connect the different services, do you use HTTP or events, what DBs to use; basically you're dealing with internal and external architecture.
    - There's always something new to look at, like we were thinking abou packaging C# code into Blazer, if it would run the application faster or better, but I found out that .NET doesn't support such things just yet.
    - I'm also bettering what we currently have, like what new can we add to make this better. I usually have 2 lists, one of new things and one of improvements. For example, the new thing is Blazer and the improvement is switching from SQL Server to Postgresql.
    - How do you know that something new is useful and good? Where do you find these new things? 
        - Usually I look at the release notes of the major libraries, like .NET or TypeScript. You test it, and then start using it, and other people start copying what you're doing and slowly you get them all used to it.
        - The major changes usually find me by luck, suddenly everyone and everywhere is talking about it, then you check it out and try incorporating it. This is how I found out and started using microservices.

### Meetup 5 (14.4.2023)
- How do you properly deal with booleans, dates, etc. between the database, backend and UI? Do you store it as numbers or strings and then parse it?
    - The database stores the different data types as it does, there's nothing you can do about that. Obviously you should use the correct data type and not use strings to store "true" or "false". Then it becomes language dependent. C# will automatically convert the data into something that's valid for it, like transforming the date from the database to its own DateTime format. Then again it depends on your application. Some data between C# and JS might be the same, so you can just pass it forward, but some data might need additional transformations at the endpoint, to be properly displayed on the UI. Usually you transform the data to the correct format before storing it in an array of objects, or whatever you have in your case. You can easily do this with pipelines in JS.

- When do you create an interface vs a class, and when do you create both?
    - That depends on the languange. In JS you mostly use interfaces, because you can easily use them like: data = {name: 'XXX'}, where data is type of Interface. In C# you cannot initialize an interface with values in any way so you need to use classes. If you know you just need one class, then you can easily initialize one with "Records" (https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records), but if multiple classes are similiar, then you make an interface. So the logic of classes vs interfaces is very language dependent.

- Do you generally test just TS code or HTML code as well?
    - Generally both, but you should try to write complex logic in JS as a function and then insert it into HTML. Like NG IF and NG FOR and ok, but they should take a function if it's something complex, like if a condition has an AND or OR in it. In this case you just test the function in the JS file. But testing NG IF or NG FOR or [disabled] is not worth it, as I believe that the Angular code works correctly, I just need to test my own code.

- What's the best way to debug the front-end part of the web application? Is it worth it to set everything inside the IDE to debug or do you just do it via the web console?
    - That's up to you, both approaches are fine, though I prefer to debug via the web console. If you have multiple UI projects running, which are connected between each other, like we have, then it is definitely easier to just use the web console, instead of having to run every project on its own in debug mode.

### Meetup 6 (26.4.2023)
- How do you properly manipulate data on the UI when doing CRUD operations? If we take deletion for example, do you delete the entry from the database and do a refresh or do you delete from the database and then manually remove it from the UI?
    - Both ways are correct, it just depends on the type of the application and what's better for the user.

- How does a proper server-side application structure look like.
    - In C# we generally use the MVC framework so everything is based on that or well that is the baseline to which we add extra stuff. We usually have the controller class which calls the repository class. The repository class generally has only the basic CRUD calls that are made with Entity Framework. Any complex logic (we call this 'business logic') that happens with the data is then done in the controller, before being passed further down the line. If some business logic becomes useful elsewhere, then it's moved to it's own special repository that can be accessed by other controllers.

- Where do we store server or DB URLs in our application?
    - It's all stored in the environmental variables: https://angular.io/guide/build
    
- How do you sync models between the server and client.
    You can create a TS script and then call it in package.json. Look at the update-version.msc script in pe-ui or something similar.

- So usually we get data into some page by parsing the URL arguments and then calling the database. But in cases where we need some additional data, how to we move it from one page to another? Do you use cookies or session storage or local storage? Is there some correct way of handling these storage types, like how long they're valid and when they're deleted?
    - Depends on the situation. Generally we store things locally that are less important, in the URL we include things with medium importance or things that are good to share and for the important things that we want the user to always have, we store it in the database.

- How do you deal with different library versions between projects, especially the key ones, like Angular or Node? Do you just install them in the project folder for that project and skip the global versions?
    - Node.js, for example, has to be globally installed, but it's forwards and backwards compatible. Angular, however, can be just locally installed. For example you can use the 'npx' ('npx ng version') functionality from 'npm', which tells the application to use the local version instead of the global one, so you can have different versions even with a globally installed library. As an extra trick, 'npx' can also be used to call some library once to use it as a script without loading it into the project.

### Meetup 7 (17.5.2023)
- How do you keep all this knowledge that you accumulate through the years, especially as you don't touch it for several months or years? I think I forgot a decent amount of things due to time.
	- Generally I remember the basics and maybe some extra tricks, but I always open the documentation like some 'Getting started' page and go through it. Then I usually start remembering the details, but sometimes I also have to learn new things due things changing in months or years.

### Question pool
- How do you determine if the requested website application is complex and requires something like Angular + .NET, compared to it being simple and just requiring WordPress?

- In regards to CSS, how do you learn this well or get used to it as a programmer, who doesn't use it much? I'm guessing this is a things that most developers don't deal with often?

- What are some useful extensions for VS Code? How do you find some that actually bring value and don't bloat your IDE?