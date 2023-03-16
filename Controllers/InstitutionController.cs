using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InstitutionController : ControllerBase
{
    private readonly YourDbContext _context;

    public InstitutionController(YourDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
    {
        return await _context.Institutions.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Institution>> AddInstitution(Institution institution)
    {
        _context.Institutions.Add(institution);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInstitutions), new { id = institution.InstitutionId }, institution);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult
