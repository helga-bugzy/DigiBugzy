using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.InfrastructureLayer.JsonPlaceholderApi
{
    public class JsonPlaceholderClient : BaseHttpClient
    {
        public JsonPlaceholderClient(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<IEnumerable<GetAllPostsResponse>> GetAllPosts()
        {
            return await Get<IEnumerable<GetAllPostsResponse>>(Endpoints.Posts.GetAllPosts);
        }

        public async Task<CreatePostResponse> CreatePost(CreatePostRequest request)
        {
            return await Post<CreatePostResponse>(Endpoints.Posts.CreatePost, request);
        }
    }
}
