using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLNetCore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecutor;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecutor = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Get(GraphQLQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var inputs = query.Variables.ToInputs();
            var executeOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecutor.ExecuteAsync(executeOptions).ConfigureAwait(false);

            return Ok(result);
        }
    }
}

