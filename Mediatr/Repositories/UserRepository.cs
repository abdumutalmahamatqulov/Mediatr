using Mediator.Data;
using Mediator.Domains;
using Mediator.Extension;
using Mediator.Interface;
using Mediatr.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Mediator.Repositories;

public class UserRepository:IUserRepository
{
    private readonly AppDbContext _dbcontext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<UserDetail> _userManager;
    public UserRepository(RoleManager<IdentityRole> roleManager, AppDbContext context, UserManager<UserDetail> userManager)
    {
        _roleManager = roleManager;
        _dbcontext = context;
        _userManager = userManager;
    }

    public async Task<UserDetail> Register(UserDto request)
    {
        var user = new UserDetail
        {
            UserName = request.Name,
            Email = request.Email,
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Password isn't hashed");
        }

        await _userManager.AddToRoleAsync(user, Enum.GetName(request.Role).ToUpper());
        await _dbcontext.SaveChangesAsync();
        return user;
    }

    public async Task<string> Login(UserDto request)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(e => e.Email == request.Email);

        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            roleClaims.Add(new Claim(ClaimTypes.Name, request.Name));
            var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user, roleClaims);
            return token;
        }
          throw new BadHttpRequestException("User not found.");
    }


    public async Task<List<UserDetail>> GetUserListAsync()
        => await _dbcontext.Users.ToListAsync();

    public async Task<UserDetail> AddUserAsync(UserDetail userDetails)
    {
        var result = _dbcontext.Users.Add(userDetails);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<int> UpdateUserAsync(UserDetail userDetails)
    {
        _dbcontext.Users.Update(userDetails);
        return await _dbcontext.SaveChangesAsync();
    }

    public async  Task<int> DeleteUserAsync(String Id)
    {
        var filteredData = _dbcontext.Users.Where(x=>x.Id == Id).FirstOrDefault();
        _dbcontext.Users.Remove(filteredData);
        return await _dbcontext.SaveChangesAsync();
    }

    public async Task<UserDetail> GetUserByIdAsync(String Id)
        => await _dbcontext.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
}
