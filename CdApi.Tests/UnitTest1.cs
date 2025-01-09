using System.Net.Http.Json;
using FluentAssertions;
using CdApi.Models;
using UsersInDbEfApiTests;

namespace CdApi.Tests;

public class UserTest : IClassFixture<OurApiWebFactory>
{
    private OurApiWebFactory _ourApiWebFactory;

    public UserTest(OurApiWebFactory ourApiWebFactory)
    {
        _ourApiWebFactory = ourApiWebFactory;
    }


    [Fact]
    public async Task Test1()
    {
        var compactDiskRequest = new CDResponse
        {
            name = "Min cd",
            artistName = "Glenn Glennsson",
            description = "Min cd description"
        };

        var createResponse = await _ourApiWebFactory.Client.PostAsJsonAsync("/api/CDs?name=1&artistName=haha&description=hehe", compactDiskRequest);

        var response = await _ourApiWebFactory.Client.GetFromJsonAsync<CDResponse>(createResponse.Headers.Location);

        response.Should().NotBeNull();
    }
}