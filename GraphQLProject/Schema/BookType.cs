using GraphQLProject.Models;

namespace GraphQLProject.Schema;

public class BookType: ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(x => x.Id).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.Title).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.Genre).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.AuthorId);
        descriptor.Field(x => x.Author).Type<AuthorType>();
    }
}
