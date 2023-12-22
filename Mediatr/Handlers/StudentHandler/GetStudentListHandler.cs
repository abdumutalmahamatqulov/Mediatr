using Mediator.Queries;
using Mediatr.Domains;
using Mediatr.Interface;
using MediatR;

namespace Mediator.Handlers.StudentHandler;

internal sealed record GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentDetails>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
        => _studentRepository = studentRepository;

    public async Task<List<StudentDetails>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        => await _studentRepository.GetStudentListAsync();
}
