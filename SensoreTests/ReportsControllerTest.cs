
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Options;
using SensoreApp.Controllers;
using SensoreApp.Models;
using Software_Engineering_Group.Data;
using Software_Engineering_Group.Models;

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
                new Report { ID = 2, userID = 102, reportInfo = "Report 2", staffID = 202, staffResponse = "Response 2" },
                new Report { ID = 3, userID = 103, reportInfo = "Report 3", staffID = null, staffResponse = null }
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

            Assert.Equal(3, ((List<Report>)model).Count);
        }

        [Fact]
        public async Task StaffCanBeNullable()
        {
            var options = new DbContextOptionsBuilder<Software_Engineering_GroupContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseNullable")
                .Options;
            var context = new Software_Engineering_GroupContext(options);

            context.Report.AddRange(
                new Report { ID = 1, userID = 101, reportInfo = "Report 1", staffID = 201, staffResponse = "Response 1" },
                new Report { ID = 2, userID = 102, reportInfo = "Report 2", staffID = 202, staffResponse = "Response 2" },
                new Report { ID = 3, userID = 103, reportInfo = "Report 3", staffID = null, staffResponse = null }
            );
            context.SaveChanges();

            var controller = new ReportsController(context);
            var result = await controller.Index() as ViewResult;
            var model = Assert.IsAssignableFrom<IEnumerable<Report>>(result.Model);
            var report = model.First(r => r.ID == 3);
            Assert.Null(report.staffID);
            Assert.Null(report.staffResponse);
        }

    }
}
