# Module_3_Create_Web_Api

Noroff .NET Fullstack - Module 3 weekly task to create Web Api with Entity Framework.

## Appendix A: EF Core Code First

We are to create SQL Server database through EF Core with a RESTful API allowing users to manipulate the data. Our database will store information about characters, movies and franchises.

Rules: 

- One movie contains many characters, and a character can play in multiple movies.

- One movie belongs to one franchise, but a franchise can contain many movies.

- Dummy data is done by seeding to database with EF.


## Example seeding to character table

```python
modelBuilder.Entity<Character>().HasData(new Character() { Id = 1, FullName = "Aragorn II", Alias = "Elessar", Gender = "Male"});
modelBuilder.Entity<Character>().HasData(new Character() { Id = 2, FullName = "Gimli", Alias = "Lockbearer", Gender = "Male"});
```
## Appendix B: Web Api using ASP.NET Core

We are to create WEB API with following criteria:
- This API need to have Generic CRUD

- ADDITIONAL:  Updating characters in a movie AND Updating movies in a franchise

- GET ALL:  Movies in a franchise, characters in a movie AND characters in  a franchise

- DTO's with Automapper

- Documentation with Swagger

- Handle controller functionality in Services or Repositories
## Contributing
Ville Hotakainen, Omar El Tokhy

## License
[MIT](https://choosealicense.com/licenses/mit/)

