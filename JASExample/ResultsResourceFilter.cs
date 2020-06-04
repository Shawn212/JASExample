using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JASExample
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ResultsResourceFilter : Attribute, IAsyncResourceFilter
    {
        private readonly IConfiguration _config;
        private readonly IDataAccessService _dataAcess;
        private readonly string proc;

        public ResultsResourceFilter(IConfiguration configuration, IDataAccessService dataAccessService, object procName)
        {
            _config = configuration;
            _dataAcess = dataAccessService;
            proc = procName.ToString();
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var request = context.HttpContext.Request;

            using (var reader = new StreamReader(request.Body))
            {
                var body = await reader.ReadToEndAsync();

                var queryResult = await _dataAcess.SqlPostAsync(_config.GetConnectionString("JsonAutoServiceExample"), proc, body);
                if (queryResult)
                    context.Result = new OkResult();
                else
                    context.Result = new BadRequestResult();
                //await next();
            }
        }
    }
}