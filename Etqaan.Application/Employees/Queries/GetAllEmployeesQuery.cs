using Etqaan.Application.Common.Models;
using Etqaan.Application.Employees.DTOs;
using Etqaan.Application.Helpers;

namespace Etqaan.Application.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<ResultDto<PaginatedList<EmployeeDto>>>
    {
        public int PageNumber { get; set; }
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, ResultDto<PaginatedList<EmployeeDto>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllEmployeesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<PaginatedList<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = 10;

            var totalCount = await _context.Employees.CountAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var employees = await _context.Employees
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(employee => new EmployeeDto
                {
                    EmployeeId = employee.Id,
                    UserName = employee.AppUser.UserName,
                    Email = employee.AppUser.Email,
                    FirstName = employee.AppUser.FirstName,
                    LastName = employee.AppUser.LastName,
                    PhoneNumber = employee.AppUser.PhoneNumber,
                    DateOfBirth = employee.AppUser.DateOfBirth,
                    Gender = employee.AppUser.Gender,
                    NationalIdNumber = employee.AppUser.NationalIdNumber,
                    Religion = employee.AppUser.Religion,
                    AddressDetails = employee.AppUser.AddressDetails,
                    ProfilePicture = employee.AppUser.ProfilePicture,
                    UserType = employee.AppUser.UserType,
                    NationalityId = employee.AppUser.NationalityId,
                    JobTitle = employee.JobTitle,
                    YearsOfExperience = employee.YearsOfExperience,
                    JobType = employee.JobType,
                    Salary = employee.Salary,
                    BankId = employee.BankId,
                    BankAccountNumber = employee.BankAccountNumber,
                    IBAN = employee.IBAN,

                })
                .ToListAsync(cancellationToken);

            var paginatedList = new PaginatedList<EmployeeDto>
            {
                Items = employees,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return ResultDto<PaginatedList<EmployeeDto>>.Success(paginatedList);
        }
    }
}
