using System.Collections.Generic;

namespace ProjetoFinal_API.Data.Interfaces
{
    public interface IRequestTaxation
    {
        void SaveByListId(IEnumerable<int> taxationIdList, int requestId);
    }
}