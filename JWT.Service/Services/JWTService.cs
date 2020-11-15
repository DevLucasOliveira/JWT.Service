using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWT.Service
{
    public class JWTService
    {
        public static void Authentication(
            IServiceCollection services, 
            string secret, 
            bool requireHttpsMetadata = false, 
            bool saveToken = true, 
            bool validateIssuerSigningKey = true,
            bool ValidateIssuer = false, 
            bool validateAudience = false)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(x =>
                 {
                     x.RequireHttpsMetadata = requireHttpsMetadata;
                     x.SaveToken = saveToken;
                     x.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = validateIssuerSigningKey,
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateIssuer = ValidateIssuer,
                         ValidateAudience = validateAudience
                     };
                 });
        }

    }
}
