using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyService.DAL;
using CompanyService.Logic;
using CompanyService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CompanyService.Controllers
{
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyLogic _companyLogic;
        private static string _queueName = "company-review-queue";

        public CompanyController(CompanyDbContext dbContext)
        {
            _companyLogic = new CompanyLogic(dbContext);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Company company)
        {
            company.Id = Guid.NewGuid();
            await _companyLogic.AddCompany(company);

            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://user:BHAQDuK!%3@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(_queueName, true, false, false, null);
            var message = new {CompanyId = company.Id, CompanyPlaceId = company.PlaceId};
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", _queueName, null, body);

            return Ok();
        }
    }
}
