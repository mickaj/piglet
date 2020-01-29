using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranslateLib;

namespace WebAPI.Controllers
{
    [Route("api/translate")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private const string _errorMessage = "Translation(s) failed. Please check the source string(s).";

        private readonly ITranslator _translator;

        public TranslateController(ITranslator translator)
        {
            _translator = translator;
        }

        [HttpGet]
        public ActionResult<object> Get(string source)
        {
            try
            {
                var result = _translator.Translate(source);
                return new { Source = source, Target = result };
            }
            catch
            {
                return new { Source = source, ErrorMessage = _errorMessage };
            }
        }

        [HttpPost]
        public ActionResult<PostModel> Post(PostModel postModel)
        {
            postModel.TargetStrings.Clear();
            try
            {
                foreach(var str in postModel.SourceStrings)
                {
                    postModel.TargetStrings.Add(_translator.Translate(str));
                }
            }
            catch
            {
                postModel.ErrorMessage = _errorMessage;
            }
            return postModel;
        }
    }
}