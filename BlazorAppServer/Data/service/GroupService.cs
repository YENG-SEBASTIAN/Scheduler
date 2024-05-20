using BlazorAppServer.Data.DTOs;
using BlazorAppServer.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppServer.Services
{
    public class GroupService
    {
        private readonly GroupRepository _groupRepository;

        public GroupService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<GroupDTO>> GetAllGroupsAsync()
        {
            return await _groupRepository.GetAllGroupsAsync();
        }

        public async Task<GroupDTO> GetGroupByIdAsync(int id)
        {
            return await _groupRepository.GetGroupByIdAsync(id);
        }

        public async Task AddGroupAsync(GroupDTO group)
        {
            await _groupRepository.AddGroupAsync(group);
        }

        public async Task UpdateGroupAsync(GroupDTO group)
        {
            await _groupRepository.UpdateGroupAsync(group);
        }

        public async Task DeleteGroupAsync(int id)
        {
            await _groupRepository.DeleteGroupAsync(id);
        }
    }
}
