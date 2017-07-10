using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using IssuesManager.APIControllers;
using Microsoft.EntityFrameworkCore;
using DataLayer.Context;

namespace IssuesManager.Test
{
    public class UserControllerTests
    {
        private IdentityContext db;

        public UserControllerTests()
        {

        }

        private void Initialize()
        {
            var dboptions = new DbContextOptionsBuilder<IdentityContext>();
            dboptions.UseInMemoryDatabase();

            db = new IdentityContext(dboptions.Options);
        }

        [Fact]
        public async void Login_Test_Valid()
        {
            Initialize();
        }

        [Fact]
        public async void Login_Test_Invalid()
        {
            Initialize();
        }
    }
}