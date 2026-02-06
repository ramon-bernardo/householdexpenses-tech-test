using MediatR;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Application.Person.Commands;
using HouseholdExpenses.Application.Person.Queries;

namespace HouseholdExpenses.Api.Person.Controllers;

[ApiController]
[Route("api/people")]
public sealed class PeopleController(ISender sender) : Controller
{
    private readonly ISender Sender = sender;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePeopleCommand command)
    {
        var people = await Sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = people.Id }, people);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] uint id, [FromBody] UpdatePeopleCommand command)
    {
        command = command with { Id = id };
        var people = await Sender.Send(command);
        return Ok(people);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(uint id)
    {
        await Sender.Send(new DeletePeopleCommand(id));
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
        var peoples = await Sender.Send(new GetAllPeopleQuery());
        return Ok(peoples);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(uint id)
    {
        var people = await Sender.Send(new GetPeopleByIdQuery(id));
        return Ok(people);
    }
}
