using AutoMapper;
using AutoMapper.QueryableExtensions;
using TicketFlow.Application.Common.Interfaces;
using TicketFlow.Application.Common.Mappings;
using TicketFlow.Application.Common.Models;
using MediatR;

namespace TicketFlow.Application.Tickets.Queries.GetTicketsWithPagination;
public class GetTicketsWithPaginationQuery : IRequest<PaginatedList<TicketBriefDto>>
{
    public int CategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTicketsWithPaginationQueryHandler : IRequestHandler<GetTicketsWithPaginationQuery, PaginatedList<TicketBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTicketsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TicketBriefDto>> Handle(GetTicketsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tickets
            .Where(x => x.CategoryId == request.CategoryId)
            .OrderBy(x => x.Title)
            .ProjectTo<TicketBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
