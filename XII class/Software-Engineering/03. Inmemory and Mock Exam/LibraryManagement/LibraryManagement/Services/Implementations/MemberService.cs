using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly LibraryDbContext _context;

        public MemberService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAllAsync()
        {
            return await _context.Members
                .OrderBy(m => m.LastName)
                .ThenBy(m => m.FirstName)
                .ToListAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members
                .Include(m => m.Loans)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Member> CreateAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<bool> UpdateAsync(Member member)
        {
            if (!await _context.Members.AnyAsync(m => m.Id == member.Id))
                return false;

            _context.Members.Update(member);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
                return false;

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
