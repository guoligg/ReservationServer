﻿using System.Net;
using System.Threading.Tasks;
using ActivityReservation.Models;
using Newtonsoft.Json;
using WeihanLi.Common.Models;
using Xunit;

namespace ActivityReservation.API.Test.Controllers
{
    public class NoticeControllerTest : ControllerTestBase
    {
        public NoticeControllerTest(APITestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetNoticeList()
        {
            using (var response = await Client.GetAsync("/api/notice"))
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                var result = JsonConvert.DeserializeObject<PagedListModel<Notice>>(await response.Content.ReadAsStringAsync());
                Assert.NotNull(result);
            }
        }
    }
}
