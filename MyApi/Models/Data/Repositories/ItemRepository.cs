using MongoDB.Driver;
using MyApi.Data;
using MyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Repositories
{
    public class ItemRepository
    {
        private readonly ItemContext _context;

        public ItemRepository(ItemContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items.Find(item => true).ToListAsync();
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            return await _context.Items.Find<Item>(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Item item)
        {
            await _context.Items.InsertOneAsync(item);
        }

        public async Task UpdateAsync(string id, Item itemIn)
        {
            await _context.Items.ReplaceOneAsync(item => item.Id == id, itemIn);
        }

        public async Task RemoveAsync(string id)
        {
            await _context.Items.DeleteOneAsync(item => item.Id == id);
        }
    }
}
