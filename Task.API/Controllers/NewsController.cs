using Microsoft.AspNetCore.Mvc;
using Task.Application.Contracts;
using Task.Application.Models.News.Add;
using Task.Application.Models.News.Edit;
using Task.Shared.API;

namespace Task.API.Controllers
{
    [Route("api/news/")]
    public class NewsController : ApiControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] NewsRequest newsRequest)
        {
            var respons = await _newsService.Add(newsRequest);
            return ProcessResponse(respons);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit([FromBody] EditNewsRequest editNewsRequest)
        {
            var respons = await _newsService.Edit(editNewsRequest);
            return ProcessResponse(respons);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var respons = await _newsService.Delete(id);
            return ProcessResponse(respons);
        }
    }
}
