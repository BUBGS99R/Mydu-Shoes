using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mydu_Shoes.Models;

public class CartService
{
    private readonly GiayContext _context;

    public CartService(GiayContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
    {
        return await _context.CartItems.Include(ci => ci.Product).ToListAsync();
    }

    public async Task AddToCartAsync(CartItem item)
    {
        if (item.Product != null)
        {
            await _context.CartItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveFromCartAsync(CartItem item)
    {
        var existingItem = await _context.CartItems.FindAsync(item.Id);
        if (existingItem != null)
        {
            _context.CartItems.Remove(existingItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateCartItemAsync(CartItem item)
    {
        var existingItem = await _context.CartItems.FindAsync(item.Id);
        if (existingItem != null)
        {
            existingItem.Quantity = item.Quantity;
            await _context.SaveChangesAsync();
        }
    }

    public async Task ClearCartAsync()
    {
        var cartItems = await _context.CartItems.ToListAsync();
        _context.CartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }
}
