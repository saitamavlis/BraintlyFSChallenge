For Running this API you'll need to follow this steps:

1 - Modify appsetting.json to connect with your DB: "DefaultConnection": "Server=....;DataBase=ToDoDB;User=....; Password=...."

2 - On PMC selecting ChallengeFS.DataAccess as your default project:
add-migration "MigrationName"*

And then

update-database*

Now you're ready to run the API!.

If you are trying to run this API with dotnet cli, you may want to take a look at this:
https://learn.microsoft.com/en-us/ef/core/cli/dotnet
