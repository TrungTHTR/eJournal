using BusinessObject;

namespace GrpcService.InterfaceRepository
{
    public interface IIssueRepository:IGenericRepository<Issue>
    {
        Task<List<Issue>> GetAllIssue();
        void RemoveIssue(Guid issueId);
    }
}
