using Task.Shared.Data.Repository;
using Task.Application.Contracts;
using Task.Shared.OperationResponse;
using Task.Shared.Services;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Task.Core.Resources;
using Microsoft.Extensions.Logging;
using Task.Shared.API;
using Task.Domain.Entites;
using Task.Application.Models.News.Add;
using Task.Domain.Enums;
using Task.Application.Models.News.Edit;

namespace Task.Services.Implementation
{
    public class NewsService : SharedServices<NewsService>, INewsService
    {
        private readonly ISharedRepository<News, int> _newsRepository;
        public NewsService(ISharedRepository<News, int> newsRepository,
                           IMapper mapper,
                           IStringLocalizer<Resource> localizer,
                           ILogger<NewsService> logger) : base(mapper, localizer, logger)
        {
            _newsRepository = newsRepository;
        }


        public async Task<OperationResult<int>> Add(NewsRequest newsRequest)
        {
            try
            {
                _logger.LogInformation($"Start Add Method In News Service");
                if (newsRequest.PublishedOn != null)
                {
                    if (newsRequest.PublishedOn.Value.Date <= DateTime.Now.Date)
                    {
                        _logger.LogInformation($"Invalid Published Date {newsRequest.PublishedOn} In Add Method In News Service");
                        return OperationResult<int>.Fail(HttpErrorCode.InvalidInput, CommonErrorCodes.INVALID_INPUT, _localizer["InvalidPublishedDate"].Value);
                    }
                }

                if (newsRequest.NewsType == null)
                    newsRequest.NewsType = NewsType.Normal;
                News newsEnitity = _mapper.Map<News>(newsRequest);
                await _newsRepository.Add(newsEnitity);

                return OperationResult<int>.Success(newsEnitity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Add Method In News Service");
                return OperationResult<int>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }


        public async Task<OperationResult<bool>> Edit(EditNewsRequest editNewsRequest)
        {
            try
            {
                _logger.LogInformation($"Start Edit News Method In News Service");
                if (editNewsRequest.PublishedOn != null)
                {
                    if (editNewsRequest.PublishedOn.Value.Date <= DateTime.Now.Date)
                    {
                        _logger.LogInformation($"Invalid Published Date {editNewsRequest.PublishedOn} In Add Method In News Service");
                        return OperationResult<bool>.Fail(HttpErrorCode.InvalidInput, CommonErrorCodes.INVALID_INPUT, _localizer["InvalidPublishedDate"].Value);
                    }
                }

                if (editNewsRequest.NewsType == null)
                    editNewsRequest.NewsType = NewsType.Normal;
                var newsResult = await _newsRepository.FindOneAsync(a => a.Id == editNewsRequest.Id && !a.IsDeleted);
                if (newsResult == null)
                {
                    _logger.LogInformation($"News with Id : {editNewsRequest.Id} is Null In Edit Method In News Service");
                    return OperationResult<bool>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["NewsNotFound", editNewsRequest.Id].Value);
                }
                News newsEnitity = _mapper.Map<News>(editNewsRequest);
                newsEnitity.ModificationOn = DateTime.Now;
                await _newsRepository.Update(newsEnitity);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Edit News Method In News Service");
                return OperationResult<bool>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }

        public async Task<OperationResult<bool>> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Start Delete News Method In News Service");
                var newsEnitity = await _newsRepository.FindOneAsync(a => a.Id == id && !a.IsDeleted);
                if (newsEnitity == null)
                {
                    _logger.LogInformation($"News with Id : {id} is Null In Delete Method In News Service");
                    return OperationResult<bool>.Fail(HttpErrorCode.NotFound, CommonErrorCodes.NOT_FOUND, _localizer["NewsNotFound", id].Value);
                }
                await _newsRepository.Delete(newsEnitity);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception In Delete News Method In News Service");
                return OperationResult<bool>.Fail(HttpErrorCode.ServerError, CommonErrorCodes.SERVER_ERROR, _localizer["ServerError"].Value);
            }
        }


    }
}
