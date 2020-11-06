﻿using AnonQ;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnonQTests
{
    public class QuestionControllerTests : IClassFixture<AnonQFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly AnonQFactory<Startup> _factory;

        public QuestionControllerTests(
        AnonQFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Request_Should_Return_Ok_One()
        {
            var response = await _client.GetAsync("api/Question/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Request_Should_Return_Ok_All()
        {
            var response = await _client.GetAsync("api/Question/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Request_Wrong_ID()
        {
            var response = await _client.GetAsync("api/Questions/4");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Get_Request_Should_Return_Ok_GetRandomQuestionId()
        {
            var response = await _client.GetAsync("api/Question/GetRandomQuestionId");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Request_Should_Return_Ok_QuestionAndPolls()
        {
            var response = await _client.GetAsync("api/Question/1/QuestionAndPolls");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}