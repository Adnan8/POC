using HotChocolate.Types;
using POC.Application.DTO;

namespace POC.API.GraphQLSchema.Inputs
{
    public class BookInputType : InputObjectType<BookInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<BookInput> descriptor)
        {
            descriptor.Field(t => t.Title).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.ISBN).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.AuthorId).Type<NonNullType<IntType>>();
        }
    }


}
