using FreelancerData.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerData
{
    public interface IFreelancerApplicationUser
    {

        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetTopUsers();
        Task<IdentityResult> AddFundsAsync(string id, int value);
        Task<IdentityResult> WithdrawFundsAsync(string id, int value);
        Task<IdentityResult> SetFirstNameAsync(string id, string FirstName);
        Task<IdentityResult> SetLastNameAsync(string id, string LastName);


        Task<IdentityResult> AddStarValueToHiringExperience(string id, int value);
        Task<IdentityResult> AddStarValueToJobExperience(string id, int value);

        Task<IdentityResult> SetSkillsAsync(string id, string Skills);
        Task<IdentityResult> SetAddressAsync(string id, string Address);
        Task<IdentityResult>  SetDateOfBirthAsync(string id, DateTime DateOfBirth);
        Task<IdentityResult> SetUserPhoto(string id, string photo);
    }
}
