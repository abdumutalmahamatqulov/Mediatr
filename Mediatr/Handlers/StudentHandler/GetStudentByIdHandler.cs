using Mediator.Queries;
using Mediatr.Domains;
using Mediatr.Interface;
using MediatR;

namespace Mediator.Handlers.StudentHandler;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
        => _studentRepository = studentRepository;

    public async Task<StudentDetails> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        => await _studentRepository.GetStudentByIdAsync(query.Id);
}
