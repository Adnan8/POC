using POC.API.GraphQLSchema.Inputs;
using POC.API.Utility;
using HotChocolate.Types;
using POC.API.GraphQLSchema.Types;

namespace POC.API.GraphQLSchema
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetBooksAsync())
                .Name("getBooks")
                .Type<ListType<NonNullType<BookType>>>(); 

            descriptor.Field(t => t.GetAuthorsAsync())
                .Name("getAuthors")
                .Type<ListType<NonNullType<AuthorType>>>(); 

            // descriptor.Field(t => t.GetAuthorById(default))
            //     .Name("getAuthorById")
            //     .Argument("id", a => a.Type<NonNullType<IntType>>())
            //     .Type<AuthorType>();
        }
    }


}
