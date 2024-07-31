using POC.API.GraphQLSchema.Inputs;
using POC.API.Utility;
using HotChocolate.Types;
using POC.API.GraphQLSchema.Types;

namespace POC.API.GraphQLSchema
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(t => t.AddBook(default!))
                .Name("addBook")
                .Argument("book", a => a.Type<NonNullType<BookInputType>>())
                .Type<BookType>();

            descriptor.Field(t => t.UpdateBook(default!))
                .Name("updateBook")
                .Argument("book", a => a.Type<NonNullType<BookInputType>>())
                .Type<BookType>();

            descriptor.Field(t => t.AddAuthor(default!))
                .Name("addAuthor")
                .Argument("author", a => a.Type<NonNullType<AuthorInputType>>())
                .Type<AuthorType>();
        }
    }


}
