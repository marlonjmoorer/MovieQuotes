using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieQuotes.Data;
using MovieQuotes.Data.Models;

namespace MovieQuotes.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

        User Register(string username, string password);
       
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        

        private readonly MovieContext context;
        private readonly string secret;

        public UserService(MovieContext context,string secret)
        {
            this.context=context;
            this.secret=secret;
        }

        public User Authenticate(string username, string password)
        {
            var user = context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            
            
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
 
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims:  new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "User")
                    
                },
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signinCredentials
            );
            // authentication successful so generate jwt token
          
            user.Token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            user.Password = null;

            return user;
        }

        public User Register(string username, string password){
            
           var user = context.Users.SingleOrDefault(u => u.Username == username);
           if(user==null){
                user= new User();
                user.Username=username;
                user.Password=password;
                user= context.Users.Add(user).Entity; 
                if(context.SaveChanges()==1)
                    return user;
           }
           
           return null;
        }
      
    }
}