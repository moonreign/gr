using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GRLib;
using System.IO;

namespace GRWeb.Controllers
{
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        private const string fileName = @"E:\code\GRWeb\GRConsole\input1.txt";

        // GET
        [HttpGet]
        public string Get()
        {
            return "get";
        }

        // GET records/gender
        [HttpGet("gender")]
        public string GetGender()
        {
            var records = new Parser().LoadFile(fileName);
            return JsonConvert.SerializeObject(records.OrderBy(r => r.Gender));
        }

        // GET records/birthdate
        [HttpGet("birthdate")]
        public string GetBirthdate()
        {
            var records = new Parser().LoadFile(fileName);
            return JsonConvert.SerializeObject(records.OrderBy(r => r.DOB));
        }

        // GET records/name
        [HttpGet("name")]
        public string GetName()
        {
            var records = new Parser().LoadFile(fileName);
            return JsonConvert.SerializeObject(records.OrderByDescending(r => r.LastName));
        }

        // POST records/values
        [HttpPost("{record}")]
        public void Post(string record)
        {
            var parsedRow = new Parser().LoadRow(record);

            using (var writer = new StreamWriter(new FileStream(fileName, FileMode.Append)))
                writer.WriteLine(parsedRow);
        }

    }
}
