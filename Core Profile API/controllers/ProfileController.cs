using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly IProfileService _ProfileService;

    public ProfilesController(IProfileService ProfileService)
    {
        _ProfileService = ProfileService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Profile>> GetProfiles()
    {
        var Profiles = _ProfileService.GetAll();
        return Ok(Profiles);
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(int id)
    {
        var Profile = _ProfileService.GetById(id);
        if (Profile == null)
        {
            return NotFound();
        }
        return Ok(Profile);
    }

    [HttpPost]
    public ActionResult<Profile> CreateProfile([FromBody] CreateProfileDto dto)
    {
        try
        {
            var Profile = _ProfileService.Create(dto);
            return CreatedAtAction(nameof(GetProfile), new { id = Profile.Id }, Profile);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProfile(int id, [FromBody] UpdateProfileDto dto)
    {
        try
        {
            bool updated = _ProfileService.Update(id, dto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProfile(int id)
    {
        bool deleted = _ProfileService.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}

public class CreateProfileDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class UpdateProfileDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}
