using Labb_1_ASP.NET_API___Databas.Data;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Services;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
		private readonly ITableService _tableService;

		public TableController(ITableService tableService)
		{
			_tableService = tableService;
		}

		[HttpGet("GetAllTables")]
		public async Task<IActionResult> GetAllTables()
		{
			var tables = await _tableService.GetAllTablesAsync();
			return Ok(tables);
		}

		[HttpGet("GetTableById")]
		public async Task<IActionResult> GetTableById(int id)
		{
			var table = await _tableService.GetTableByIdAsync(id);
			if (table == null) return NotFound();
			return Ok(table);
		}

		[HttpPost("AddTable")]
		public async Task<IActionResult> AddTable([FromBody] TableDTO table)
		{
			await _tableService.AddTableAsync(table);
			return CreatedAtAction(nameof(GetTableById), new { id = table.TableId }, table);
		}

		[HttpPut("UpdateTable")]
		public async Task<IActionResult> UpdateTable(int id, [FromBody] TableDTO table)
		{
			await _tableService.UpdateTableAsync(table, id);
			return NoContent();
		}

		[HttpDelete("DeleteTable")]
		public async Task<IActionResult> DeleteTable(int id)
		{
			await _tableService.DeleteTableAsync(id);
			return NoContent();
		}
	}
}
