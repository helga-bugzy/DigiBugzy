using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.InfrastructureLayer.JsonPlaceholderApi
{
    public class Endpoints
    {
        public class Posts
        {
            private const string PostsPath = "/posts";

            public static string GetAllPosts => PostsPath;
            public static string CreatePost => PostsPath;
            public static string GetPostById(int postId) => $"{PostsPath}/{postId}";
            public static string GetCommentsForPost(int postId) => $"{PostsPath}/{postId}/comments";
        }
    }
}
