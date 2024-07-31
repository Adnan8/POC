using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;
using POC.Application.DTO;
using GraphQL.Client.Abstractions;
using Newtonsoft.Json;

namespace POC.BlazorApp.GraphQLServices
{
    public class GraphQLService
    {

        private readonly IGraphQLClient _client;

        public GraphQLService(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query {
                    getBooks {
                        id
                        title
                        author {
                            name
                        }
                    }
                }"
            };

            try
            {
                var response = await _client.SendQueryAsync<ResponseType>(request);
                return response.Data?.Books ?? new List<BookDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<BookDTO>(); 
            }
        }
        public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
            query {
                getAuthors {
                    id
                    name
                }
            }"
            };
            try
            {
                var response = await _client.SendQueryAsync<ResponseType>(request);
                return response.Data.Authors ?? new List<AuthorDTO>();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<AuthorDTO>();
            }
        }
        public async Task<BookDTO> AddBookAsync(BookDTO bookDto)
        {
            var request = new GraphQLRequest
            {
                Query = @"
    mutation AddBook($bookInput: BookInput!) {  
        addBook(book: $bookInput) {  
            id
            title
            isbn
            authorId
            author {
                id
                name
            }
        }
    }",
                Variables = new
                {
                    bookInput = new  
                    {
                        Title = bookDto.Title,  
                        ISBN = bookDto.ISBN,
                        AuthorId = bookDto.AuthorId
                    }
                }
            };


            var response = await _client.SendMutationAsync<ResponseType>(request);
            if (response.Errors != null && response.Errors.Any())
            {
                throw new Exception("GraphQL mutation error: " + response.Errors.First().Message);
            }
            return response.Data.AddBook;
        }

        public async Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDto)
        {
            var request = new GraphQLRequest
            {
                Query = @"
    mutation AddAuthor($authorInput: AuthorInput!) {  
        addAuthor(author: $authorInput) {  
            id
            name
        }
    }",
                Variables = new
                {
                    authorInput = new
                    {
                        Name = authorDto.Name,
                    }
                }
            };


            var response = await _client.SendMutationAsync<ResponseType>(request);
            if (response.Errors != null && response.Errors.Any())
            {
                throw new Exception("GraphQL mutation error: " + response.Errors.First().Message);
            }
            return response.Data.AddAuthor;
        }
    }

    public class ResponseType
    {
        [JsonProperty("getBooks")]
        public List<BookDTO> Books { get; set; }
        [JsonProperty("getAuthors")]
        public List<AuthorDTO> Authors { get; set; }
        public BookDTO AddBook { get; set; }
        public AuthorDTO AddAuthor { get; set; }
    }

}
