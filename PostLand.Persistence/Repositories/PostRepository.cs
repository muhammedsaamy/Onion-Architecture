using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PostLand.Application.Contracts;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext postDbContext) : base(postDbContext)
        {
        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> allPosts = new List<Post>();
            allPosts = includeCategory ? await _dbContext.Posts
                .Include(x => x.Category).ToListAsync() : 
                await _dbContext.Posts.ToListAsync();

            return allPosts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post post = new Post();
            post = includeCategory ? await _dbContext.Posts
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id) : 
                await GetByIdAsync(id);

            return post;
        }
    }
}
