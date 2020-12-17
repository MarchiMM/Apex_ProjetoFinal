using System.Collections.Generic;
using ProjetoFinal_API.Data.Interfaces;
using ProjetoFinal_API.Data.Repository.Interfaces;
using ProjetoFinal_API.Models;

namespace ProjetoFinal_API.Data.Services
{
  public class RequestTaxationService : IRequestTaxation
  {
    private readonly IRepository _repository;

    public RequestTaxationService(IRepository repository)
      {
      this._repository = repository;
    }

    public void SaveByListId(IEnumerable<int> taxationIdList, int requestId)
    {
        foreach (var taxationId in taxationIdList)
        {
            _repository.Add(
                new RequestTaxation(requestId, taxationId)
            );
        }
    }
  }
}