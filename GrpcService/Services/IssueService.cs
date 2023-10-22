using AutoMapper;
using Grpc.Core;
using GrpcService.issueCRUD;
using  BusinessObject;
using Google.Protobuf.WellKnownTypes;
using Empty = GrpcService.issueCRUD.Empty;

namespace GrpcService.Services
{
    public class IssueService:IssueCRUD.IssueCRUDBase
    {
        private readonly ILogger<IssueService> _iLogger;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public IssueService(ILogger<IssueService> iLogger, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _iLogger = iLogger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<IssueStatus> CreateIssue(AddIssue request, ServerCallContext context)
        {
           Issue addIssue = _mapper.Map<Issue>(request);
           await _unitOfWork.IssueRepository.AddAsync(addIssue);
           bool isCreated= await _unitOfWork.SaveChangeAsync()>0;
            IssueStatus status = new IssueStatus() 
            { 
                IsTrue= isCreated,
            };
            return status;
        }

        public override async Task<ListIssues> GetAllIssue(Empty request, ServerCallContext context)
        {
            ListIssues responseData=new ListIssues();
        List<Issue> issues=   await _unitOfWork.IssueRepository.GetAllIssue();
            foreach (var issue in issues)
            {
                IssueViewModel issueViewModel = new IssueViewModel
                {
                    Volumn = issue.Volumn,
                    Description = issue.Description,
                    DateRelease = Timestamp.FromDateTime(issue.DateRelease.ToUniversalTime()) // Convert issue.DateRelease to Google.Protobuf.Timestamp
                };
                if (issue.Articles!= null)
                {
                    foreach (var article in issue.Articles)
                    {
                        ArticleViewModel articleViewModel = new ArticleViewModel
                        {
                            Title = article.Title,
                            Content = article.Content,
                            Status = article.Status,
                            AuthorName = article.AuthorName
                        };

                        issueViewModel.Articles.Add(articleViewModel);
                    }
                } 
                   responseData.Item.Add(issueViewModel);
                
            }
            return responseData;
        }

        public override async Task<Empty> UpdateIssue(ModifyIssue request, ServerCallContext context)
        {
          Issue updatedIssue=_mapper.Map<Issue>(request); ;
            _unitOfWork.IssueRepository.Update(updatedIssue);
            await _unitOfWork.SaveChangeAsync();
            return new Empty();
        }
    }
}
