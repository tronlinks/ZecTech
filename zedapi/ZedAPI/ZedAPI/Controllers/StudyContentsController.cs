using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ZedAPI.Models;

namespace ZedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyContentsController : ControllerBase
    {
        private readonly Study _context;

        public StudyContentsController(Study context)
        {
            _context = context;
        }

        // GET: api/StudyContents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyContent>>> GetStudyDB()
        {
            return await _context.StudyDB.ToListAsync();
        }

        // GET: api/StudyContents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyContent>> GetStudyContent(Guid id)
        {
            var studyContent = await _context.StudyDB.FindAsync(id);
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                string txtPath = Environment.CurrentDirectory + "/Data/" + id + ".json";
                string studyFile = FileReader(txtPath);

                if (studyFile == null)
                {
                    return NotFound();
                }
                StudyContent sc = JsonConvert.DeserializeObject<StudyContent>(studyFile);
                return Ok(sc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        private string FileReader(string path)
        {
            if (path is null)
            {
                Console.WriteLine("You did not supply a file path.");
                return null;
            }
            try
            {
                var studyFile = System.IO.File.ReadAllText(path);
                return studyFile;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return null;

        }


        // PUT: api/StudyContents/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyContent(Guid id, StudyContent studyContent)
        {
            if (id != studyContent.GUID)
            {
                return BadRequest();
            }

            _context.Entry(studyContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyContentExists(id))
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

        // POST: api/StudyContents
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudyContent>> PostStudyContent(StudyContent studyContent)
        {
            _context.StudyDB.Add(studyContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudyContent", new { id = studyContent.GUID }, studyContent);
        }

        // DELETE: api/StudyContents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudyContent>> DeleteStudyContent(Guid id)
        {
            var studyContent = await _context.StudyDB.FindAsync(id);
            if (studyContent == null)
            {
                return NotFound();
            }

            _context.StudyDB.Remove(studyContent);
            await _context.SaveChangesAsync();

            return studyContent;
        }

        private bool StudyContentExists(Guid id)
        {
            return _context.StudyDB.Any(e => e.GUID == id);
        }
    }
}
