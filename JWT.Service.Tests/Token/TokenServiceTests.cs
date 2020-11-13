using JWT.Service.Domain.Token;
using System;
using Xunit;

namespace JWT.Service.Tests.Token
{
    public class TokenServiceTests
    {
        private readonly string _userId;
        private readonly string _secret;
        private readonly double _expiredToken;

        public TokenServiceTests()
        {
            _userId = new int().ToString();
            _secret = Guid.NewGuid().ToString();
            _expiredToken = 6;
        }

        [Fact]
        public void GenerateToken_ReturnsToken()
        {
            var token = TokenService.GenerateToken(_userId, _secret, _expiredToken);

            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }

        [Fact]
        public void GenerateToken_WhenSecretIsNull_ReturnsException()
        {
            var ex = TokenService.GenerateToken(_userId, null, _expiredToken);

            Assert.Equal("String reference not set to an instance of a String. (Parameter 's')", ex);
        }

        [Fact]
        public void GenerateToken_WhenUserIdIsNull_ReturnsException()
        {
            var ex = TokenService.GenerateToken(null, _secret, _expiredToken);

            Assert.Equal("Value cannot be null. (Parameter 'value')", ex);
        }

        [Fact]
        public void GenerateToken_WhenExpiredTokenIsNull_ReturnsException()
        {
            var ex = TokenService.GenerateToken(_userId, _secret, 0);

            Assert.Equal("IDX12401: Expires: '[PII is hidden]' must be after NotBefore: '[PII is hidden]'.", ex);
        }

    }
}
