using HotChocolate.Types;
using POC.Application.DTO;

namespace POC.API.GraphQLSchema.Types
{
    public class BookType : ObjectType<BookDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<BookDTO> descriptor)
        {
            descriptor.Field(f => f.Id).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.Title).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.ISBN).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.Author).Type<AuthorType>();
        }
    }
}
