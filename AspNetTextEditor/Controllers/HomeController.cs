using AspNetTextEditor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetTextEditor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Dictionary<int, string> list = TestData.Data.Posts.ToDictionary(i => i.Key, j => j.Value.Title);
            return View(list);
        }

        public IActionResult ShowPost(int id)
        {
            if (!TestData.Data.Posts.ContainsKey(id))
                return NotFound();

            TextEditorViewModel viewModel = TestData.Data.Posts[id];
            return View(viewModel);
        }

        public IActionResult Edit(int id = -1)
        {
            if (id == -1)
            {
                TextEditorViewModel newPost = new TextEditorViewModel();
                return View(newPost);
            }

            if (!TestData.Data.Posts.ContainsKey(id))
                return NotFound();

            TextEditorViewModel viewModel = TestData.Data.Posts[id];
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string editordata, string title, IEnumerable<string> images)
        {
            editordata = editordata.Replace("<script", "").Replace("onload=", "").Replace("javascript:", "");
            
            if (TestData.Data.Posts.ContainsKey(id))
            {
                TestData.Data.Posts[id].Message = editordata;
            }
            else
            {
                id = TestData.Data.Posts.Count;
                TextEditorViewModel viewModel = new TextEditorViewModel { Id = id, Title = title, Message = editordata };
                TestData.Data.Posts.Add(id, viewModel);
            }

            return RedirectToAction("ShowPost", new { id = id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}