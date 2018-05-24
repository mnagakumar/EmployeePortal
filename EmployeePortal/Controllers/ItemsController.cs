using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePortal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Produces("application/json")]
    [Route("api/Items")]
    public class ItemsController : Controller
    {
        private int DefaultNumberOfItems
        {
            get
            {
                return 5;
            }
        }
        private int MaxNumberOfItems
        {
            get
            {
                return 100;
            }
        }
        // GET api/items/GetLatest/5
        [HttpGet("GetLatest/{num}")]
        public JsonResult GetLatest(int num)
        {
            var arr = new List<ItemViewModel>();
            if (num > MaxNumberOfItems) num = MaxNumberOfItems;
            for (int i = 1; i <= num; i++) arr.Add(new ItemViewModel()
            {
                Id = i,
                Title = String.Format("Item {0} Title", i),
                Description = String.Format("Item {0} Description", i)
            });

            return new JsonResult(arr);
        }
        /// <summary>
        /// GET: api/items/GetMostViewed/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing the items with most user views.</returns>
        [HttpGet("GetMostViewed/{n}")]
        public IActionResult GetMostViewed(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var items = GetSampleItems().OrderByDescending(i => i.ViewCount).Take(n);
            return new JsonResult(items);
        }
        /// <summary>
        /// GET: api/items/GetRandom/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing some randomly-picked items.</returns>
        [HttpGet("GetRandom/{n}")]
        public IActionResult GetRandom(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var items = GetSampleItems().OrderBy(i => Guid.NewGuid()).Take(n);
            return new JsonResult(items);
        }


        private List<ItemViewModel> GetSampleItems(int num = 999)
        {
            List<ItemViewModel> lst = new List<ItemViewModel>();
            DateTime date = new DateTime(2015, 12, 31).AddDays(-num);
            for (int id = 1; id <= num; id++)
            {
                lst.Add(new ItemViewModel()
                {
                    Id = id,
                    Title = String.Format("Item {0} Title", id),
                    Description = String.Format("This is a sample description for item {0}: Lorem ipsum dolor sit amet.", id),
                    CreatedDate = date.AddDays(id),
                    LastModifiedDate = date.AddDays(id),
                    ViewCount = num - id
                });
            }
            return lst;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(GetSampleItems()
            .Where(i => i.Id == id)
            .FirstOrDefault());
        }

        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatest(DefaultNumberOfItems);
        }
    }
}
