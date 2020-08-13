using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplicationTest.Controllers
{
    public class SteerController : ApiController
    {
        // GET: api/steer
        public async Task<HttpResponseMessage> Get(string refId)
        {
            var url = @"https://devnotehub.azurewebsites.net/Automate";
            string token = @"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InFybm9wdGVzdC5henVyZXdlYnNpdGVzLm5lIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy91c2VyZGF0YSI6IntcIlByaXZhdGVLZXlcIjpudWxsLFwiSXNEaXNhYmxlZFwiOmZhbHNlLFwiRXhwaXJhdGlvbkRhdGVcIjpudWxsLFwiR2xvYmFsTWFjSWRcIjo4LFwiU2VydmljZUJ1c0Nvbm5lY3Rpb25TdHJpbmdcIjpudWxsLFwiVG9waWNJZFwiOm51bGwsXCJCdXNTdWJzY3JpcHRpb25cIjpudWxsLFwidG9rZW5VcmxcIjpcImh0dHBzOi8vbGl2ZS5xdWlja3JlYWNoLmNvL2lkZW50aXR5L0Nvbm5lY3QvVG9rZW5cIixcInNlbmRVcmxcIjpcImh0dHBzOi8vbGl2ZS5xdWlja3JlYWNoLmNvL2dhdGV3YXkvYXBpL3YyL2JvYXJkL2V4dGVybmFsL25vcGM_c291cmNlSWQ9IyNzb3VyY2VJZCMjJmxvZ2dlck5hbWU9IyNsb2dnZXJOYW1lIyNcIixcInNvdXJjZUlkXCI6bnVsbCxcImxvZ2dlck5hbWVcIjpcInFydGVzdF9Ob3BDb21tXCIsXCJDbGllbnRJZFwiOlwiMmI3ZWEzYWYtYjA5Zi00ZDhhLTllMGYtMDIxYzMyMDBmMjRiXCIsXCJBUElLZXlcIjpcImZAREdaaGckJSNGUkdkZnNhJmRnclRUUlwiLFwiTGljZW5zZVR5cGVcIjoyMDEsXCJMaWNlbnNlSW50XCI6MjAxLFwiTGljZW5zZVN0cmluZ1wiOlwiVG9rZW5Pbmx5XCIsXCJEb21haW5OYW1lXCI6XCJxcm5vcHRlc3QuYXp1cmV3ZWJzaXRlcy5uZVwiLFwiSWRcIjo4LFwiQ3JlYXRlZFwiOlwiMjAyMC0wNi0yM1QwNzo0OTo1NC44MTdcIixcIk1vZGlmaWVkXCI6XCIyMDIwLTA2LTIzVDA3OjQ5OjU0LjgxN1wifSIsIm5iZiI6MTU5NzMxMzM3MCwiZXhwIjoxNTk3MzE2OTcwLCJpYXQiOjE1OTczMTMzNzB9.xPnSewx6AgvYw2vMZrLs9Ea3kp2-ukOuP53ihQd185U";
            var result = await url.WithHeaders(new
            {
                Accept = "application/json",
                apikey = token
            })

                  .SetQueryParams(new
                  {
                      EventTag = "testvar",
                      MachineNo = 3,
                      ReferenceId = refId
                  })

                  .PostJsonAsync(new
                  {
                      username = "rgalvez@blastasia.com"
                      ,
                      password = "test123"
                  });

            Console.WriteLine(result.StatusCode.ToString());

            return Request.CreateResponse(result.StatusCode, result.StatusCode.ToString() + " @" + DateTime.Now.ToShortTimeString());

        }



    }
}