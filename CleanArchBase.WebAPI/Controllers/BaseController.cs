using CleanArchBase.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArchBase.WebAPI.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        #region Dependency Injection



        private IMediator _mediator;
        private IApplicationDbContext _ctx;
        protected IApplicationDbContext _context => _ctx ?? (_ctx = HttpContext.RequestServices.GetService<IApplicationDbContext>());
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected string CurrentUserId => User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
        protected string CurrentUserName => User.FindFirstValue(ClaimTypes.NameIdentifier);
        #endregion



    }
}
