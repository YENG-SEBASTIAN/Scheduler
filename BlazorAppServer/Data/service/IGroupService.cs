using BlazorAppServer.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppServer.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetAllGroupsAsync();
        Task<GroupDTO> GetGroupByIdAsync(int id);
        Task AddGroupAsync(GroupDTO group);
        Task UpdateGroupAsync(GroupDTO group);
        Task DeleteGroupAsync(int id);
    }
}
