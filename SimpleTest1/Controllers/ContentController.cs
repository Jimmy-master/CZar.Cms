using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SimpleTest1.Models;

namespace SimpleTest1.Controllers
{
    public class ContentController : Controller
        
    {
        private readonly Content contents;
        public ContentController(IOptions<Content> option)
        {
            contents = option.Value;
        }
        public IActionResult Index()
        {

            //var content = new List<Content>();
            //for (int i = 1; i < 11; i++) {
            //    content.Add(new Content{ Id = i ,title=$"{i}的标题",content=$"{i}的内容",status=1,Addtime=DateTime.Now.AddDays(-1)});
              
            //}
            return View(new ContentViewModel { Contents =new List<Content> { contents } });
        }
    }
}