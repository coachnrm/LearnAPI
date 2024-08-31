using LearnAPI.Service;
using LearnAPI.Data;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LearnAPI.Container
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly LearnDataContext context;
        public RefreshHandler(LearnDataContext context) { 
            this.context = context;
        }
        public async Task<string> GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using(var randomnumbergenerator= RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string refreshtoken=Convert.ToBase64String(randomnumber);
                var Existtoken = this.context.TblRefreshTokens.FirstOrDefaultAsync(item=>item.Userid==username).Result;
                if (Existtoken != null)
                {
                    Existtoken.Refreshtoken = refreshtoken;
                }
                else
                {
                   await this.context.TblRefreshTokens.AddAsync(new TblRefreshToken
                    {
                       Userid=username,
                       Tokenid= new Random().Next().ToString(),
                       Refreshtoken=refreshtoken
                   });
                }
                await this.context.SaveChangesAsync();

                return refreshtoken;

            }
        }
    }
}