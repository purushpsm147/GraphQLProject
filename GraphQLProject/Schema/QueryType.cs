using GraphQLProject.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLProject.Schema;

public class QueryType : ObjectType
{
	public QueryType()
	{
        Field<ListType<BookType>>("books", resolve: context => GetBooks()); // Fetches all books
        Field<BookType>("book", argument: new Argument<IntType>("id"), resolve: context => GetBookById(context.Argument<int>("id"))); // Fetches book by ID
        Field<ListType<AuthorType>>("authors", resolve: context => GetAuthors()); // Fetches all authors
    }

	private List<Book> GetBooks()
	{
        return
        [
            new Book { Id = 1, Title = "Book 1", Genre = "Genre 1", AuthorId = 1 },
            new Book { Id = 2, Title = "Book 2", Genre = "Genre 2", AuthorId = 2 },
            new Book { Id = 3, Title = "Book 3", Genre = "Genre 3", AuthorId = 3 }
        ];
    }
	
	private List<Author> GetAuthors()
	{
        return
		[
            new Author { Id = 1, Name = "Author 1", Bio = "Bio 1" },
            new Author { Id = 2, Name = "Author 2", Bio = "Bio 2" },
            new Author { Id = 3, Name = "Author 3", Bio = "Bio 3" }
        ];
    }

    private Book GetBookById(int id)
    {
        return GetBooks().FirstOrDefault(x => x.Id == id);
    }

    private Author GetAuthorById(int id)
    {
        return GetAuthors().FirstOrDefault(x => x.Id == id);
    }
}
