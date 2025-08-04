using SupportHelper.Blazor.DTOs;
using SupportHelper.Blazor.DTOs.Machines;

namespace SupportHelper.Blazor.Interfaces
{
    public interface IMachineServices
    {
        Task<ResponseBase<IEnumerable<MachineDto>>> RequestGetAllMachineAsync(int pageCount, int pageSize);
        Task<ResponseBase<MachineDto>> RequestOnlyMachineAsync(string id);
        Task<ResponseBase<MachineDto>> RequestStatusToMachineAsync(string hostname);
    }
}
