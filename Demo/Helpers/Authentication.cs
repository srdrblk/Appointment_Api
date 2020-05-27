using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Service;
using Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Helpers
{
    public class Authentication 
    {
        // Kullanıcılar veritabanı yerine manuel olarak listede tutulamaktadır. Önerilen tabiki veritabanında hash lenmiş olarak tutmaktır.
        private List<User> _users = new List<User>
        {
            new User { Id = 4, Name = "Serdar", Surname = "Bilek", UserName = "black", Password = "123" },
            new User { Id = 5, Name = "Kemal", Surname = "Hakan", UserName = "hakan", Password = "234" }
        };

        private readonly AppSettings appSettings;
        private readonly IUserService userService;
        public Authentication(IOptions<AppSettings> _appSettings, IUserService _userService)
        {
            appSettings = _appSettings.Value;
            userService = _userService;
        }

        public User Authenticate(string kullaniciAdi, string sifre)
        {
            var user = userService.GetAll().Where(x => x.UserName == kullaniciAdi && x.Password == sifre).FirstOrDefault();

            // Kullanici bulunamadıysa null döner.
            if (user == null)
                return null;

            // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Sifre null olarak gonderilir.
            user.Password = null;

            return user;
        }



  
    }
}
