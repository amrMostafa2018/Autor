using Task.Application.Models.News.Add;
using Task.Application.Models.News.Edit;
using Task.Shared.OperationResponse;

namespace Task.Application.Contracts
{
    public interface INewsService
    {
  
        Task<OperationResult<int>> Add(NewsRequest newsRequest);
        Task<OperationResult<bool>> Edit(EditNewsRequest editTeamRequest);
        Task<OperationResult<bool>> Delete(int id);


    }
}
