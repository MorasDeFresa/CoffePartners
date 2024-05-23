using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IPostsRepository
    {
        Task<List<Posts>> GetPosts();
        Task<Posts> GetPosts(int IdPosts);
        Task<Posts> CreatePosts(Posts Posts);
        Task<Posts> UpdatePosts(Posts Posts);
        Task<bool> DeletePosts(int IdPosts);
    }

    public class PostsRepository : IPostsRepository
    {
        private readonly DataContext _db;

        public PostsRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Posts> CreatePosts(Posts Posts)
        {
            await _db.Posts.AddAsync(Posts);
            _db.SaveChanges();
            return Posts;
        }

        public async Task<bool> DeletePosts(int IdPosts)
        {
            var PostsAtDelete = await GetPosts(IdPosts);
            _db.Posts.Remove(PostsAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Posts> GetPosts(int IdPosts)
        {
            return await _db.Posts.FirstOrDefaultAsync(cu => cu.IdPost == IdPosts);
        }

        public async Task<List<Posts>> GetPosts()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Posts> UpdatePosts(Posts Posts)
        {
            _db.Posts.Update(Posts);
            await _db.SaveChangesAsync();
            return Posts;
        }
    }
}