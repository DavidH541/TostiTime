using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TostiTime.API.DTOs;
using TostiTime.API.HubConfig;
using TostiTime.Core.Entities;
using TostiTime.Core.Interfaces;
using TostiTime.Data.Specifications;

namespace TostiTime.API.Controllers;

[ApiController]
[EnableCors]
[Route("api/offices")]
public class OfficeController : ControllerBase
{
    private readonly IHubContext<OfficeHub> _hub;
    private readonly IRepository<Office> _officeRepo;
    private readonly IRepository<Slot> _slotRepo;
    private readonly IRepository<Person> _personRepo;
    private readonly IMapper _mapper;

    public OfficeController(IHubContext<OfficeHub> hub, IRepository<Office> officeRepo, IRepository<Slot> slotRepo, IRepository<Person> personRepo, IMapper mapper)
    {
        _hub = hub ?? throw new ArgumentNullException(nameof(hub));
        _officeRepo = officeRepo ?? throw new ArgumentNullException(nameof(officeRepo));
        _slotRepo = slotRepo ?? throw new ArgumentNullException(nameof(slotRepo));
        _personRepo = personRepo ?? throw new ArgumentNullException(nameof(personRepo));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet(Name = "GetOffices")]
    public async Task<IActionResult> GetAll()
    {
        var offices = await _officeRepo.Get(new OfficeSpec());

        if (offices is null) return NotFound();

        return Ok(_mapper.Map<IEnumerable<OfficeWithoutIronsDto>>(offices));
    }

    [HttpGet($"{{{nameof(officeName)}}}/persons", Name = "GetOfficeWithPersons")]
    public async Task<IActionResult> Get(string officeName)
    {
        var office = await _officeRepo.GetSingle(new OfficeWithPersonsSpec(officeName));

        if (office is null) return NotFound();

        return Ok(_mapper.Map<OfficeWithPersonsDto>(office));
    }

    [HttpGet($"{{{nameof(officeName)}}}/irons", Name = "GetOfficeWithIronsWithSlots")]
    public async Task<IActionResult> GetOfficeWithIronsWithSlots(string officeName)
    {
        var office = await _officeRepo.GetSingle(new OfficeWithIronsWithSlotsSpec(officeName));

        if (office is null) return NotFound();

        return Ok(_mapper.Map<OfficeDto>(office));
    }

    [HttpPost($"{{{nameof(oid)}}}/createReservation/{{{nameof(sid)}}}", Name = "CreateReservation")]
    public async Task<IActionResult> CreateReservation(int oid, int sid, string firstName)
    {
        var slot = await _slotRepo.GetSingle(new SlotWithLastReservationSpec(sid));
        if (slot is null)
        {
            return NotFound($"Slot with id {sid} not found!");
        }
        var lastReservation = slot.Reservations.OrderByDescending(e => e.OccupiedUntil).FirstOrDefault();
        if (lastReservation is not null && lastReservation.OccupiedUntil == DateTime.MaxValue)
        {
            return BadRequest($"Slot with id {sid} is occupied!");
        }
        var person = await _personRepo.GetSingle(new PersonSpec(firstName)) ?? await _personRepo.Insert(new Person { FirstName = firstName, OfficeId = oid });
        slot.AddReservation(person, DateTime.UtcNow);
        await _slotRepo.Commit();
        await RefreshOffice(oid);
        return Ok();
    }

    [HttpPut($"{{{nameof(oid)}}}/completeReservation/{{{nameof(sid)}}}", Name = "CompleteReservation")]
    public async Task<IActionResult> CompleteReservation(int oid, int sid)
    {
        var stopTime = DateTime.UtcNow;
        var slot = await _slotRepo.GetSingle(new SlotWithLastReservationSpec(sid));
        if (slot is null)
        {
            return NotFound($"Slot with id {sid} not found!");
        }
        if (slot.LastReservation is null || slot.LastReservation.OccupiedUntil != DateTime.MaxValue)
        {
            return BadRequest($"Slot with id {sid} is not occupied!");
        }
        slot.LastReservation.OccupiedUntil = stopTime;
        await _slotRepo.Commit();
        await RefreshOffice(oid);
        return Ok();
    }

    private async Task RefreshOffice(int oid)
    {
        var office = await _officeRepo.GetSingle(new OfficeWithIronsWithSlotsSpec(oid));
        if (office is not null)
        {
            await _hub.Clients.All.SendAsync($"{office.City}");
        }
    }
}
