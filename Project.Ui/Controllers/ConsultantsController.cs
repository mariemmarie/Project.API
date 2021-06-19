using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Dto;
using Project.Core.Entities;
using Project.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Ui.Controllers
{
    [Route("api/consultants")]
    public class ConsultantsController : ControllerBase
    {
        private readonly IUoW uoW;
        private readonly IMapper mapper;

        public ConsultantsController(IUoW uoW, IMapper mapper)
        {
            this.uoW = uoW;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConsultants()
        {
            var consultants = await uoW.ConsultantsRepository.GetAllConsultants();
            var consultanstDto = mapper.Map<IEnumerable<GetConsultantDto>>(consultants);

            return Ok(consultanstDto);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<GetConsultantDto>> GetConsultantAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var consultant = await uoW.ConsultantsRepository.GetConsultant((int)id);
            if (consultant is null)
            {
                return NotFound();
            }
            var dto = mapper.Map<GetConsultantDto>(consultant);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<AddConsultantDto>> PostConsultant([FromBody]AddConsultantDto dto)
        {
            var consultant = mapper.Map<Consultant>(dto);
            await uoW.ConsultantsRepository.AddAsync(consultant);
            if (await uoW.ConsultantsRepository.SaveAsync())
            {


            var model = mapper.Map<AddConsultantDto>(consultant);

            return CreatedAtAction("GetConsultant", new { id = consultant.Id }, model);
            }
            else
            {
                return StatusCode(500);

            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultant(int id)
        {
            var consultant = await uoW.ConsultantsRepository.GetConsultant(id);
            if (consultant is null)
            {
                return NotFound();
            }

            uoW.ConsultantsRepository.Remove(consultant);
            if (await uoW.ConsultantsRepository.SaveAsync())
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
           
        }
    }
}