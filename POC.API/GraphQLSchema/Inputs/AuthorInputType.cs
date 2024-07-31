using HotChocolate.Types;
using POC.Application.DTO;
namespace POC.API.GraphQLSchema.Inputs
{
    public class AuthorInputType : InputObjectType<AuthorInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AuthorInput> descriptor)
        {
            descriptor.Field(f => f.Name).Type<NonNullType<StringType>>();
        }
    }
}
