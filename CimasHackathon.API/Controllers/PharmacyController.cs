﻿using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CimasHackathon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PharmacyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PharmacyRequest request)
        {
            var result = await _unitOfWork.Pharmacy.AddAsync(new Pharmacy
            {
                Name = request.Name,
                Address = request.Address,
                Email = request.Email
            });
            if (!result.Success) return BadRequest(result);

            _unitOfWork.SaveChanges();
            
            return Ok(result);
        }
    }
}