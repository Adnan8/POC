using POC.API.GraphQLSchema.Types;
using POC.Application.DTO;

namespace POC.API.GraphQLSchema
{
    public class AuthorType : ObjectType<AuthorDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<AuthorDTO> descriptor)
        {
            descriptor.Field(a => a.Id).Type<NonNullType<IntType>>(); 
            descriptor.Field(a => a.Name).Type<NonNullType<StringType>>(); 
            descriptor.Field(a => a.Books).Type<ListType<BookType>>(); 
        }
    }
}
