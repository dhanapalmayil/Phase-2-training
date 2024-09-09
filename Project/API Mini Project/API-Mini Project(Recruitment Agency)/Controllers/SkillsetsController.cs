using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Mini_Project_Recruitment_Agency_.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_Mini_Project_Recruitment_Agency_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsetsController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;

        public SkillsetsController(RecruitmentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<Skillset>>> GetSkillsets()
        {
            return await _context.Skillsets.Include(e => e.Candidate).ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<Skillset>> GetSkillset(int id)
        {
            var skillset = await _context.Skillsets.Include(e => e.Candidate).FirstOrDefaultAsync(a => a.SkillsetId == id);

            if (skillset == null)
            {
                return NotFound();
            }

            return skillset;
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<Skillset>> PostSkillset(Skillset skillset)
        {
            _context.Skillsets.Add(skillset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkillset", new { id = skillset.SkillsetId }, skillset);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> PutSkillset(int id, Skillset skillset)
        {
            if (id != skillset.SkillsetId)
            {
                return BadRequest();
            }

            _context.Entry(skillset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SkillsetExists(id))
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
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> DeleteSkillset(int id)
        {
            var skillset = await _context.Skillsets.FindAsync(id);
            if (skillset == null)
            {
                return NotFound();
            }

            _context.Skillsets.Remove(skillset);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> SkillsetExists(int id)
        {
            return await _context.Skillsets.AnyAsync(e => e.SkillsetId == id);
        }

        [HttpGet("frequency")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult> GetSkillsetFrequency()
        {
            var skillsetFrequency = await _context.Skillsets
                .GroupBy(s => s.SkillName)
                .Select(g => new
                {
                    Skillset = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            return Ok(skillsetFrequency);
        }

        [HttpGet("bycandidate/{candidateId}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<Skillset>>> GetSkillsetsByCandidate(int candidateId)
        {
            var skillsets = await _context.Skillsets
                                          .Where(s => s.CandidateId == candidateId)
                                          .ToListAsync();

            if (!skillsets.Any())
            {
                return NotFound("No skillsets found for this candidate.");
            }

            return Ok(skillsets);
        }

        [HttpGet("candidates/{skillName}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidatesBySkill(string skillName)
        {
            var candidates = await _context.Skillsets
                                           .Where(s => s.SkillName == skillName)
                                           .Select(s => s.Candidate)
                                           .ToListAsync();

            if (!candidates.Any())
            {
                return NotFound("No candidates found with this skill.");
            }

            return Ok(candidates);
        }

        [HttpGet("popular/{count}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult> GetTopPopularSkillsets(int count)
        {
            var popularSkillsets = await _context.Skillsets
                .GroupBy(s => s.SkillName)
                .Select(g => new
                {
                    Skillset = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(s => s.Count)
                .Take(count)
                .ToListAsync();

            return Ok(popularSkillsets);
        }
        [HttpGet("suggest/{candidateId}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult> SuggestSkillsForCandidate(int candidateId)
        {
            var suggestedSkillsets = new List<string>
            {
                "Data Analysis",
                "Cloud Computing",
                "AI & Machine Learning"
            };

            return Ok(suggestedSkillsets);
        }

        [HttpGet("candidatecount")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetSkillsetCountByCandidate()
        {
            var skillsetCounts = await _context.Skillsets
                .GroupBy(s => s.CandidateId)
                .Select(g => new
                {
                    CandidateId = g.Key,
                    SkillCount = g.Count()
                })
                .ToListAsync();

            return Ok(skillsetCounts);
        }

    }
}
