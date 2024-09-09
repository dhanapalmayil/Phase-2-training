using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Mini_Project_Recruitment_Agency_.Models;

namespace API_Mini_Project_Recruitment_Agency_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;

        public CandidatesController(RecruitmentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
        {
            return await _context.Candidates.Include(c => c.Skillsets).ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            var candidate = await _context.Candidates.Include(c => c.Skillsets)
                                                     .FirstOrDefaultAsync(c => c.CandidateId == id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidate", new { id = candidate.CandidateId }, candidate);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CandidateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CandidateExists(int id)
        {
            return await _context.Candidates.AnyAsync(e => e.CandidateId == id);
        }

        [HttpGet("download")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DownloadCandidatesData()
        {
            var candidates = await _context.Candidates.Include(c => c.Skillsets).ToListAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Candidates");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "CandidateId";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "IsPlaced";
                worksheet.Cell(currentRow, 4).Value = "Skills";

                foreach (var candidate in candidates)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = candidate.CandidateId;
                    worksheet.Cell(currentRow, 2).Value = candidate.Name;
                    worksheet.Cell(currentRow, 3).Value = candidate.IsPlaced ? "Yes" : "No";
                    worksheet.Cell(currentRow, 4).Value = candidate.Skillsets != null
                        ? string.Join(", ", candidate.Skillsets.Select(s => s.SkillName))
                        : "N/A";
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Candidates.xlsx");
                }
            }
        }

        [HttpGet("Advanced-search")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Candidate>>> SearchCandidates(
            [FromQuery] string? name,
            [FromQuery] string? skill,
            [FromQuery] bool? isPlaced)
        {
            var query = _context.Candidates.Include(c => c.Skillsets).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(skill))
            {
                query = query.Where(c => c.Skillsets.Any(s => s.SkillName.Contains(skill)));
            }

            if (isPlaced.HasValue)
            {
                query = query.Where(c => c.IsPlaced == isPlaced.Value);
            }

            var result = await query.ToListAsync();
            return Ok(result);
        }
        [HttpPost("bulk-upload/csv")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BulkUploadCandidatesCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var line = await reader.ReadLineAsync(); 
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var values = line.Split(',');

                    var candidate = new Candidate
                    {
                        Name = values[0],
                        IsPlaced = bool.Parse(values[1])
                    };

                    _context.Candidates.Add(candidate);
                }

                await _context.SaveChangesAsync();
            }

            return Ok("Candidates uploaded successfully.");
        }

    }
}
