using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SafeCap.Application.DTOs.Response;
using SafeCap.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using SafeCap.Application.DTOs.Request;
using SafeCap.Domain.Entities;

namespace SafeCap.Presentation.Controllers
{
    [ApiController]
    [Route("api/alerts")]
    [Tags("Alertas")]
    public class AlertController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AlertController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AlertResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<AlertResponse>>> GetAll(
            [FromQuery] Guid? userId,
            [FromQuery] string? alertType)
        {
            var query = _context.Alerts.AsQueryable();

            if (userId.HasValue)
                query = query.Where(a => a.UserId == userId.Value);

            if (!string.IsNullOrWhiteSpace(alertType))
                query = query.Where(a => a.AlertType == alertType);

            var alerts = await query.ToListAsync();
            var alertDtos = _mapper.Map<List<AlertResponse>>(alerts);
            return Ok(alertDtos);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<AlertResponse>> GetById(Guid id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) return NotFound();
            var alertDto = _mapper.Map<AlertResponse>(alert);
            return Ok(alertDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AlertResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AlertResponse>> Create(AlertRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var alert = _mapper.Map<Alert>(request);
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            var alertDto = _mapper.Map<AlertResponse>(alert);
            return CreatedAtAction(nameof(GetById), new { id = alertDto.Id }, alertDto);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update(Guid id, NoUserAlertRequest request)
        {
            var existingAlert = await _context.Alerts.FindAsync(id);
            if (existingAlert == null) return NotFound("Alerta não encontrado.");

            existingAlert.AlertType = request.AlertType;
            existingAlert.Message = request.Message;

            _context.Alerts.Update(existingAlert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) return NotFound("Alerta não encontrado.");

            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
