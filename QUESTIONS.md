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

### Meetup 4 (31.3.2023)


### Question pool
- How do you determine if the requested website application is complex and requires something like Angular + .NET, compared to it being simple and just requiring WordPress?

- So usually we get data into some page by parsing the URL arguments and then calling the database. But in cases where we need some additional data, how to we move it from one page to another? Do you use cookies or session storage or local storage? Is there some correct way of handling these storage types, like how long they're valid and when they're deleted?

- In regards to CSS, how do you learn this well or get used to it as a programmer, who doesn't use it much? I'm guessing this is a things that most developers don't deal with often?

- How do you keep all this knowledge that you accumulate through the years, especially as you don't touch it for several months or years? I think I forgot a decent amount of things due to time.
  
- What's the logic or usage of interfaces? I'd like to understand when it's worth using them and when not, because I use them and I understand what they are, but I'm not completely sure when to create them to be useful and not just be worthless.

- How do you deal with different library versions between projects, especially the key ones, like Angular or Node? Do you just install them in the project folder for that project and skip the global versions?

- What's the best way to debug the front-end part of the web application? Is it worth it to set everything inside the IDE to debug or do you just do it via the web console?

- What are some useful extensions for VS Code? How do you find some that actually bring value and don't bloat your IDE?