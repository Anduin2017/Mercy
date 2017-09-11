﻿using Mercy.Models;
using Mercy.Models.ActionResults;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mercy.Library
{
    public abstract class Controller
    {
        public string ViewLocation { get; set; }
        public HttpContext HttpContext { get; set; }
        public StringResult String(string input)
        {
            return new StringResult(input);
        }
        public JsonResult Json(object input)
        {
            return new JsonResult(input);
        }
        public ViewResult View()
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            var actionName = methodBase.Name;
            var controllerName = Methods.GetControllerName(methodBase.DeclaringType);
            var result = new ViewResult();
            result.ViewFilePath = $"{ViewLocation}{Path.DirectorySeparatorChar}{controllerName}{Path.DirectorySeparatorChar}{actionName}.html";
            return result;
        }
    }
}
