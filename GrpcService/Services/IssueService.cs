using AutoMapper;
using Grpc.Core;
using GrpcService.issueCRUD;
using  BusinessObject;
using Google.Protobuf.WellKnownTypes;
using Empty = GrpcService.issueCRUD.Empty;
using System.Globalization;

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
           /* DateTime releaseDate;
            if (!DateTime.TryParseExact(request.DateRelease, "dd-mm-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate))
            {
                throw new Exception("Invalid release date format. Please use 'dd-mm-yyyy' format.");
            }*/
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
                    Id=issue.Id.ToString(),
                    Volumn = issue.Volumn,
                    Description = issue.Description,
                    DateRelease = issue.DateRelease.ToString("dd-MM-yyyy")// Convert issue.DateRelease to Google.Protobuf.Timestamp
                };
             /*   if (issue.Articles!= null)
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
                } */
                   responseData.Item.Add(issueViewModel);
                
            }
            return responseData;
        }

        public override async Task<IssueStatus> UpdateIssue(ModifyIssue request, ServerCallContext context)
        {
            DateTime releaseDate;
            if (!DateTime.TryParseExact(request.DateRelease, "dd-mm-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate))
            {
                throw new Exception("Invalid release date format. Please use 'dd-mm-yyyy' format.");
            }
            Issue updatedIssue=_mapper.Map<Issue>(request); ;
            _unitOfWork.IssueRepository.Update(updatedIssue);
            bool isUpdated = await _unitOfWork.SaveChangeAsync() > 0;
            IssueStatus status = new IssueStatus()
            {
                IsTrue = isUpdated,
            };
            return status;
        }

        public override async Task<IssueStatus> DeleteIssue(IssueId request, ServerCallContext context)
        {
            if(Guid.TryParse(request.Id, out var id))
            {
                _unitOfWork.IssueRepository.RemoveIssue(id);
            }
            bool isDeleted= await _unitOfWork.SaveChangeAsync()>0;
            IssueStatus status = new IssueStatus()
            {
                IsTrue = isDeleted,
            };
            return status;  
        }

        public override async Task<IssueViewModel> GetIssueById(IssueId request, ServerCallContext context)
        {
            Issue issue=new Issue();
            if (Guid.TryParse(request.Id, out var id))
            {
                issue = await _unitOfWork.IssueRepository.GetByIdAsync(id);
            }
            IssueViewModel issueViewModel = new IssueViewModel()
            {
                Id = issue.Id.ToString(),
                DateRelease = issue.DateRelease.ToString("dd/MM/yyyy"),
                Description = issue.Description,
                Volumn = issue.Volumn,
            };
            return issueViewModel;
          
        }
    }
}
