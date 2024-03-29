﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wevi.Models;

namespace wevi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryEventsController : ControllerBase
    {
        private readonly WevDbContext _context;

        public HistoryEventsController(WevDbContext context)
        {
            _context = context;
        }

        // GET: api/HistoryEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryEvent>>> GetHistoryEvent()
        {
            return await _context.HistoryEvent.ToListAsync();
        }

        // GET: api/HistoryEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryEvent>> GetHistoryEvent(int id)
        {
            var historyEvent = await _context.HistoryEvent.FindAsync(id);

            if (historyEvent == null)
            {
                return NotFound();
            }

            return historyEvent;
        }

        // PUT: api/HistoryEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryEvent(int id, HistoryEvent historyEvent)
        {
            if (id != historyEvent.hisevid)
            {
                return BadRequest();
            }

            _context.Entry(historyEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryEventExists(id))
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

        // POST: api/HistoryEvents
        //[HttpPost]
        //public async Task<ActionResult<HistoryEvent>> PostHistoryEvent(HistoryEvent historyEvent)
        //{
        //    outputHisEvt output = new outputHisEvt();

        //    _context.HistoryEvent.Add(historyEvent);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetHistoryEvent", new { id = historyEvent.hisevid }, historyEvent);
        //}

        [HttpPost]
        public async Task<outputHisEvt> PostHistoryEvent(HistoryEvent historyEvent)
        {
            outputHisEvt output = new outputHisEvt();
            var result = new HistoryEvent();

            try
            {
                var checkJoin = _context.HistoryEvent.Where(haha => haha.userid == historyEvent.userid && haha.eventid == historyEvent.eventid).FirstOrDefault();

                if(checkJoin == null)
                {
                    _context.HistoryEvent.Add(historyEvent);
                    await _context.SaveChangesAsync();

                    if (historyEvent.hisevid != 0)
                    {
                        result = historyEvent;

                        output.Result = "OK";
                        output.hisevt = result;
                        output.Message = "Success";
                    }
                    else
                    {
                        output.Result = "NG";
                        output.Message = "Gagalbosque";
                    }
                }
                else
                {
                    output.Result = "NG";
                    output.Message = "Ora oleh join peng pindo bosss pisan ae wes mari peyan";
                }
            }
            catch (Exception ex)
            {
                output.Result = "MG";
                output.Message = ex.ToString();
            }
            return output;
        }

        // DELETE: api/HistoryEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HistoryEvent>> DeleteHistoryEvent(int id)
        {
            var historyEvent = await _context.HistoryEvent.FindAsync(id);
            if (historyEvent == null)
            {
                return NotFound();
            }

            _context.HistoryEvent.Remove(historyEvent);
            await _context.SaveChangesAsync();

            return historyEvent;
        }

        private bool HistoryEventExists(int id)
        {
            return _context.HistoryEvent.Any(e => e.hisevid == id);
        }
    }
}
