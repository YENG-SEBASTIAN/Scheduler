using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAppServer.Data.DTOs;

namespace BlazorAppServer.Data.Repositories
{
    public class GroupRepository
    {
        private List<GroupDTO> _groups;

        public GroupRepository()
        {
            _groups = new List<GroupDTO>();
        }

        public async Task<IEnumerable<GroupDTO>> GetAllGroupsAsync()
        {
            return await Task.FromResult(_groups);
        }

        public async Task<GroupDTO> GetGroupByIdAsync(int id)
        {
            return await Task.FromResult(_groups.FirstOrDefault(g => g.Id == id));
        }

        public async Task AddGroupAsync(GroupDTO group)
        {
            group.Id = _groups.Any() ? _groups.Max(g => g.Id) + 1 : 1;
            _groups.Add(group);
            await Task.CompletedTask;
        }

        public async Task UpdateGroupAsync(GroupDTO group)
        {
            var existingGroup = _groups.FirstOrDefault(g => g.Id == group.Id);
            if (existingGroup != null)
            {
                existingGroup.Name = group.Name;
                existingGroup.Description = group.Description;
                existingGroup.CreatedBy = group.CreatedBy;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteGroupAsync(int id)
        {
            var groupToRemove = _groups.FirstOrDefault(g => g.Id == id);
            if (groupToRemove != null)
            {
                _groups.Remove(groupToRemove);
            }
            await Task.CompletedTask;
        }
    }
}
