using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module3WebApi.Model;
using Module3WebApi.Model.DTOs.FranchiceDTO;
using Module3WebApi.Services;

namespace Module3WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesV2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFranchiseService _franchiseService;

        public FranchisesV2Controller(IMapper mapper, IFranchiseService franchiseService)
        {
            _mapper = mapper;
            _franchiseService = franchiseService;
        }

        // GET: api/FranchisesV2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _franchiseService.GetAllFranchisesAsync());
        }

        // GET: api/FranchisesV2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            Franchise franchise = await _franchiseService.GetSpecificFranchiseAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }
            return _mapper.Map<FranchiseReadDTO>(franchise);
        }
        [HttpGet("{id}/character")]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetMoviesInAFranchise(int id)
        {
            Franchise moviesInFranchise = (Franchise)await _franchiseService.GetAllMoviesInFranchiseAsync(id);

            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }

            return _mapper.Map<List<FranchiseReadDTO>>(moviesInFranchise);
        }

        // PUT: api/FranchisesV2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseUpdateDTO dtoFranchise)
        {
            if (id != dtoFranchise.Id)
            {
                return BadRequest();
            }

            if(!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }
            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            await _franchiseService.UpdateFranchiseAsync(domainFranchise);
            return NoContent();
        }

        // POST: api/FranchisesV2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO dtoFranchise)
        {
            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            domainFranchise = await _franchiseService.AddFranchiseAsync(domainFranchise);

            return CreatedAtAction("GetFranchise", new { id = domainFranchise.Id }, _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        // DELETE: api/FranchisesV2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }
            await _franchiseService.DeleteFranchiseAsync(id);
            return NoContent();
        }
        // PUT: api/FranchiseV2/movies
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int id, List<int> movies)
        {
            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }

            try
            {
                await _franchiseService.UpdateMovieInFranchiseAsync(id, movies);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid character.");
            }

            return NoContent();
        }
    }
}
