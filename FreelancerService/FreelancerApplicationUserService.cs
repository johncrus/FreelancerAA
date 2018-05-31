using FreelancerData;
using FreelancerData.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerService
{
    public class FreelancerApplicationUserService : IFreelancerApplicationUser
    {
        private FreelancerContext _context;
        public FreelancerApplicationUserService(FreelancerContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users;
        }
        public ApplicationUser GetById(string id)
        {
            return GetAll()
               .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ApplicationUser> GetTopUsers()
        {
            return GetAll().OrderByDescending(u => u.HiringExperience+u.Jobexperience).Take(5);
        }

       

        public async Task<IdentityResult> SetDateOfBirthAsync(string id, DateTime DateOfBirth)
        {
            GetById(id).DateOfBirth = DateOfBirth;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> SetFirstNameAsync(string id, string FirstName)
        {
            GetById(id).FirstName = FirstName;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> SetLastNameAsync(string id, string LastName)
        {
            GetById(id).LastName = LastName;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> SetSkillsAsync(string id, string Skills)
        {
            GetById(id).Skills = Skills;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }
        public async Task<IdentityResult> SetAddressAsync(string id, string Address)
        {
            GetById(id).Address = Address;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }
        public async Task<IdentityResult> SetUserPhoto(string id, string photo)
        {
            GetById(id).UserPhoto = photo;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> AddFundsAsync(string id, int value)
        {
            GetById(id).Currency += value;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> WithdrawFundsAsync(string id, int value)
        {
            if (GetById(id).Currency - value < 0)
                return IdentityResult.Success;
            GetById(id).Currency -= value;
            int x = await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        
    }
}
