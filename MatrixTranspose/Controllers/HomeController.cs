using System.Web.Mvc;
using MatrixTranspose.Services.Interfaces;

namespace MatrixTranspose.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileParser _fileParser;
        private readonly IMatrixHeper _matrixHelper;

        public HomeController(IFileParser fileParser, IMatrixHeper matrixHelper)
        {
            _fileParser = fileParser;
            _matrixHelper = matrixHelper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Import()
        {
            var file = Request.Files[0];

            if (file != null)
            {
                return Json(_fileParser.Parse(file.InputStream));
            }

            return Json(null);
        }

        [HttpPost]
        public JsonResult Rotate(string[][] model)
        {
            if (model != null)
            {
                model = _matrixHelper.Rotate(model);
            }

            return Json(model);
        }

        [HttpPost]
        public JsonResult Export(string[][] model)
        {
            if (model != null)
            {
                return Json(_fileParser.Unparse(model));
            }

            return Json(null);
        }

        [HttpGet]
        public JsonResult GenerateRandom()
        {
            return Json(_matrixHelper.GenerateRandom(), JsonRequestBehavior.AllowGet);
        }
    }
}
