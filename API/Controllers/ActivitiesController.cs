using Domain;
using Application.Activities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetActivities()
    {
        return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, [FromBody] Activity activity)
    {
        activity.Id = id;
        return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
}