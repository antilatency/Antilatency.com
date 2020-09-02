using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Antilatency.com.Server.Controllers {
  
    [ApiController]
    public class RootController : ControllerBase
    {
        private static Dictionary<Scope, Dictionary<string, Dictionary<Language, IMaterial>>> ScopedMaterials;

        private readonly ILogger<RootController> _logger;
        public RootController(ILogger<RootController> logger) {
            _logger = logger;
        }


        private void InitMaterials()
        {
            if (ScopedMaterials == null) {
                var context = new Context();
                ScopedMaterials = new Dictionary<Scope, Dictionary<string, Dictionary<Language, IMaterial>>>();

                var s = ScopeHelper.All.ToArray();
                foreach (var scope in s) {
                    ScopedMaterials.Add(scope, scope.GenerateMaterialMatrix(context));
                }
            }
        }

        private Htmlilka.Tag GetMaterial(string url) {
            var languages = Language.All;
            foreach (var scopedMaterial in ScopedMaterials) {
                var scope = scopedMaterial.Key;
                var materialsMatrix = scopedMaterial.Value;

                foreach (var materialsLanguageGroup in materialsMatrix) {
                    foreach (IMaterial material in materialsLanguageGroup.Value.Values) {
                        foreach (var language in languages) {
                            if (material.GetUri(language) == url) {
                                Context context = new Context();
                                context.Language = language;
                                return scope.GetTemplate().GenerateDom(context, material);
                            }
                        }

                    }
                }
            }
            return null;
        }

        [Route("/{**catchAll}")]
        [HttpGet]
        public IActionResult Get() {
            InitMaterials();

            var requestPath = ControllerContext.HttpContext.Request.Path;
            string resourcePath = (requestPath == "/" ? @"/Root/Index_en.html" : requestPath.Value).Substring(1);
            
            var mimeType = MimeTypes.MimeTypeMap.GetMimeType(Path.GetExtension(resourcePath));

            //Procedural HTML page
            if (Path.GetExtension(resourcePath).ToLower() == ".html") {
                var material = GetMaterial(CsmlApplication.WwwRootUri + resourcePath);
                StringBuilder stringBuilder = new StringBuilder();
                material.WriteHtml(stringBuilder);
                return Content(stringBuilder.ToString(), mimeType);
            }

            //File
            resourcePath = Path.Combine(CsmlApplication.WwwRootDirectory, resourcePath);

            if (System.IO.File.Exists(resourcePath)) {
                return PhysicalFile(resourcePath, mimeType);
            }
            Log.Warning.Here("FILE NOT FOUND: " + resourcePath);
            return NotFound();
        }
    }
}
