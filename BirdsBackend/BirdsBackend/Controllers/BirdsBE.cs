using BirdsBE.Core;
using BirdsBE.Models;
using BirdsBE.Models.InputModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdsBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BirdsBE : ControllerBase
    {
        private readonly IProcessCore processCore;
        public BirdsBE(IProcessCore processCore)
        {
            this.processCore = processCore;
        }

        [HttpPost]
        public async Task<OutPutModel> Post(Users user)
        {
            return await processCore.CreateUser(user);
        }

        [HttpPut]
        public async Task<OutPutModel> Put(Users user)
        {
            return await processCore.UpdateUser(user);
        }
    }
}
