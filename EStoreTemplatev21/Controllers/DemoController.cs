using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStoreTemplatev21.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreTemplatev21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        static List<string> ds = new List<string>()
        { "Mận", "Đào", "Cam", "Xã"};
        // GET: api/Demo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ds;
        }

        // GET: api/Demo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            if (id < 0 || id >= ds.Count)
                return "Không có";
            return ds[id];
        }

        [HttpGet("Search/{keyword}")]
        public List<string> TimKiem(string keyword)
        {
            var result = ds.Where(p => p.Contains(keyword));
            return result.ToList();
        }

        // POST: api/Demo
        //[HttpPost("{value}")]
        //public void Post([FromRoute] string value)
        //{
        //    ds.Add(value);
        //}

        [HttpPost]
        public void Post([FromBody] DemoModel model)
        {
            ds.Add(model.Data);
        }

        // PUT: api/Demo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DemoModel model)
        {
            if (id < 0 || id >= ds.Count)
                return;
            ds[id] = model.Data;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id < 0 || id >= ds.Count)
                return;
            ds.RemoveAt(id);
        }
    }
}
