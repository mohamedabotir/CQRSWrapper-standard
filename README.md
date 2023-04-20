# CQRSWrapper
structure of pattern
![file structure](https://user-images.githubusercontent.com/52336027/233233181-dd7873ef-3b97-481e-a287-94da1711f283.png)

## Command 
- Entity inherit from ICommand interface  example UserCommand:ICommand
- handler should inherit from ICommandHandler<your entity> Example UserCommandHandler:ICommandHandler<UserCommand>
write what you want to handler make
- you should inject  your handler example : 
builder.Services
             .AddTransient<ICommandHandler<UserCommand>, UserCommandHandler>();
## Query
- Entity inherit from IQuery<EntityModel> interface  example GetUserList : IQuery<UserDTO>
- handler should inherit from IQueryHandler<Entity, EntityModel>> Example : GetUserListHandler : IQueryHandler<GetUserList, UserDTO>
write what you want to handler make
- you should inject  your handler example : 
 builder.Services
             .AddTransient<IQueryHandler<GetUserList, UserDTO>, GetUserListHandler>();
 ## inject cqrs service
 you should inject cqrs service as this manager of pattern and by this can ship your service
 example 
             builder.Services.AddSingleton<CQSScane>();
