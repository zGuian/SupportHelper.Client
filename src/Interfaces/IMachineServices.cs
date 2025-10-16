using SupportHelper.Blazor.DTOs;
using SupportHelper.Blazor.DTOs.Machines;

namespace SupportHelper.Blazor.Interfaces
{
    public interface IMachineServices
    {
        Task<ResponseBase<IEnumerable<MachineDto>>> RequestGetAllMachineAsync();
        Task<ResponseBase<MachineDto>> RequestOnlyMachineAsync(string hostname);
        Task<ResponseBase<string>> RequestResetSgpClient(string hostname);
    }
}
