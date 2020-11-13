using JWT.Service.Domain.Token;
using System;
using Xunit;

namespace JWT.Service.Tests.Token
{
    public class TokenServiceTests
    {

        [Fact]
        public void GenerateToken_ReturnsToken()
        {
            var userId = new int().ToString();
            var secret = Guid.NewGuid().ToString();
            var expiredToken = 6;

            var token = TokenService.GenerateToken(userId, secret, expiredToken);

            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }

        [Fact]
        public void GenerateToken_WhenSecretIsNull_ReturnsException()
        {
            var userId = new int().ToString();
            var expiredToken = 6;

            var ex = TokenService.GenerateToken(userId, null, expiredToken);

            Assert.Equal("String reference not set to an instance of a String. (Parameter 's')", ex);
        }

        [Fact]
        public void GenerateToken_WhenUserIdIsNull_ReturnsException()
        {
            var secret = Guid.NewGuid().ToString();
            var expiredToken = 6;

            var ex = TokenService.GenerateToken(null, secret, expiredToken);

            Assert.Equal("Value cannot be null. (Parameter 'value')", ex);
        }

        [Fact]
        public void GenerateToken_WhenExpiredTokenIsNull_ReturnsException()
        {
            var userId = new int().ToString();
            var secret = Guid.NewGuid().ToString();
            var expiredToken = 0;

            var ex = TokenService.GenerateToken(userId, secret, expiredToken);

            Assert.Equal("IDX12401: Expires: '[PII is hidden]' must be after NotBefore: '[PII is hidden]'.", ex);
        }

    }
}
