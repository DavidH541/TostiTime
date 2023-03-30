using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TostiTime.API.DTOs;
using TostiTime.Core.Entities;
using TostiTime.Core.Interfaces;
using TostiTime.Data.Specifications;

namespace TostiTime.API.Controllers;

[ApiController]
[EnableCors]
[Route("api/persons")]
public class PersonController : ControllerBase
{
    private readonly IRepository<Person> _personRepo;
    private readonly IMapper _mapper;

    public PersonController(IRepository<Person> personRepo, IMapper mapper)
    {
        _personRepo = personRepo;
        _mapper = mapper;
    }

    [HttpGet($"{{{nameof(personId)}}}", Name = "GetPerson")]
    public async Task<IActionResult> Get(int personId)
    {
        var person = await _personRepo.GetSingle(new PersonSpec(personId));

        if (person is null) return NotFound();

        return Ok(_mapper.Map<PersonWithoutReservationsDto>(person));
    }

    [HttpGet(Name = "GetPersons")]
    public async Task<IActionResult> GetAll()
    {
        var persons = await _personRepo.Get(new PersonSpec());

        if (persons is null) return NotFound();

        return Ok(_mapper.Map<IEnumerable<PersonWithoutReservationsDto>>(persons));
    }
}
