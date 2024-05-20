using BlazorAppServer.Data.DTOs;
using BlazorAppServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetAllGroups()
        {
            try
            {
                var groups = await _groupService.GetAllGroupsAsync();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroupById(int id)
        {
            try
            {
                var group = await _groupService.GetGroupByIdAsync(id);
                if (group == null)
                {
                    return NotFound();
                }
                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GroupDTO>> AddGroup([FromBody] GroupDTO group)
        {
            try
            {
                await _groupService.AddGroupAsync(group);
                return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, [FromBody] GroupDTO group)
        {
            try
            {
                if (id != group.Id)
                {
                    return BadRequest("Group ID mismatch");
                }

                await _groupService.UpdateGroupAsync(group);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                await _groupService.DeleteGroupAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
