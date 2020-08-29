﻿using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Moq;
using SpeakerMeet.Core.Cache;
using SpeakerMeet.Core.Entities;
using SpeakerMeet.Core.Interfaces.Caching;
using SpeakerMeet.Core.Interfaces.Repositories;
using SpeakerMeet.Core.Services;
using SpeakerMeet.Core.Specifications;

namespace SpeakerMeet.Core.Tests.Services.CommunityServiceTests
{
    public class CommunityServiceTestBase
    {
        protected internal CommunityService Service;
        protected internal Mock<IDistributedCacheAdapter> Cache;
        protected internal Mock<ISpeakerMeetRepository> Repository;
        protected readonly Mock<IOptions<CacheConfig>> CacheOptions;

        public CommunityServiceTestBase()
        {
            Cache = new Mock<IDistributedCacheAdapter>();
            Repository = new Mock<ISpeakerMeetRepository>();
            CacheOptions = new Mock<IOptions<CacheConfig>>();

            Repository.Setup(x => x.List(It.IsAny<CommunitySpecification>()))
                .ReturnsAsync(new List<Community>());

            CacheOptions.Setup(x => x.Value).Returns(() => new CacheConfig { DefaultExpirationMinutes = 2 });

            Service = new CommunityService(Cache.Object, Repository.Object, CacheOptions.Object);
        }
    }
}
