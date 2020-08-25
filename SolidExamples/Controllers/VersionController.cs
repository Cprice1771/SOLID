using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SolidExamples.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase {
        private const string MAJOR_VERSION_NUM = "3";
        private const string MINOR_VERSION_NUM = "2";
        private const string PATCH_VERSION_NUM = "1";

        [HttpGet("/version")]
        public string GetVersionNumber() {
            return MAJOR_VERSION_NUM + "." + MINOR_VERSION_NUM + "." + PATCH_VERSION_NUM;
        }

        [HttpGet("/major-version")]
        public string GetMajorVersionNumber() {
            return MAJOR_VERSION_NUM;
        }

        [HttpGet("/minor-version")]
        public string GetMinorVersionNumber() {
            return MINOR_VERSION_NUM;
        }

        [HttpGet("/patch-version")]
        public string GetPatchVersionNumber() {
            return PATCH_VERSION_NUM;
        }
    }
}
