using GraphQLProject.Models;

namespace GraphQLProject.Schema;

public class AuthorType: ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.Field(x => x.Id).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.Name).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.Bio).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.Books).Type<ListType<BookType>>();
    }
}
