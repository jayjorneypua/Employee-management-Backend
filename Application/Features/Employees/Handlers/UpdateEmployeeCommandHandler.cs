using Application.Features.Employees.Commands;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Application.Features.Employees.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment environment;

        public UpdateEmployeeCommandHandler(AppDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await context.Employees.FindAsync(request.Id) ?? throw new KeyNotFoundException($"Employee with Id {request.Id} does not exist.");

            // Update only provided fields
            if (!string.IsNullOrEmpty(request.FirstName))
            {
                employee.FirstName = request.FirstName;
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                employee.LastName = request.LastName;
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                employee.Email = request.Email;
            }

            if (request.DepartmentId.HasValue)
            {
                employee.DepartmentId = request.DepartmentId.Value;
            }

            if (request.PositionId.HasValue)
            {
                employee.PositionId = request.PositionId.Value; 
            }

            if (request.ProfilePicture != null)
            {
                employee.ProfilePicturePath = await SaveFile(request.ProfilePicture);
            }
            await context.SaveChangesAsync(cancellationToken); 
            return Unit.Value;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            var uploadPath = Path.Combine(environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/uploads/{fileName}";
        }
    }
}
