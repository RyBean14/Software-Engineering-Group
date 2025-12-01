
using Software_Engineering_Group.Data;
using Software_Engineering_Group.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using SensoreApp.Models;
using SensoreApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SensoreTests
{
    public class ReportsControllerTest
    {
        private Software_Engineering_GroupContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<Software_Engineering_GroupContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var context = new Software_Engineering_GroupContext(options);

            context.Report.AddRange(
                new Report { ID = 1, userID = 101, reportInfo = "Report 1", staffID = 201, staffResponse = "Response 1" },
                new Report { ID = 2, userID = 102, reportInfo = "Report 2", staffID = 202, staffResponse = "Response 2" }
            );
            context.SaveChanges();
            return context;
        }


        [Fact]
        public async Task Index_ReturnsView_ReportList()
        {
            var context = GetInMemoryContext();
            var controller = new ReportsController(context);
            var result = await controller.Index() as ViewResult;
            var model = Assert.IsAssignableFrom<IEnumerable<Report>>(result.Model);
            Assert.Equal(2, ((List<Report>)model).Count);
        }
    }
}
