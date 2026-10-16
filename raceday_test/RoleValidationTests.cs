using Xunit;
namespace raceday_test
{
    public class RoleValidationTests
    {
        [Fact]
        public void Test1()
        {
            [Theory]
            [InlineData("Organiser", true)]
            [InlineData("Participant", true)]
            [InlineData("Guest", false)]
            [InlineData("", false)]
            public void RoleMustBeSupported(
           string role, bool expected)
            {
                bool actual =
                    role == "Organiser" ||
                    role == "Participant";

                Assert.Equal(expected, actual);
            }

        }
    }
}