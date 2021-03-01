﻿using MammothWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MammothWeb.Controllers

{
    public class ParksController : Controller
    {
        // GET: ParksController
        public ActionResult Index()
        {
            IEnumerable<Park> park = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var response = client.GetAsync("parks");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<IList<Park>>();
                    read.Wait();
                    park = read.Result;
                }
                else
                {
                    //erro
                    park = Enumerable.Empty<Park>();
                    ModelState.AddModelError(string.Empty, "Server error occured");
                }
                return View(park);
            }
        }

        // GET: ParksController/Details/5
        public ActionResult Details(int id)
        {
            Park park = new Park();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/parks/");
                var response = client.GetAsync(id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<Park>();
                    read.Wait();
                    park = read.Result;
                }
                else
                {
                    //erro
                    park = null;
                    ModelState.AddModelError(string.Empty, "Server error occured");
                }
                return View(park);
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        // POST: ParksController/Create
        [HttpPost]
        public ActionResult Create(Park park)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var response = client.PostAsJsonAsync("parks", park);
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<Park>();
                    read.Wait();
                    park = read.Result;
                }
                else
                {
                    //erro
                    park = null;
                    ModelState.AddModelError(string.Empty, "Server error occured");
                }
                return RedirectToAction("Index", "Parks");
            }


        }
    }
}