using SupportHelper.Blazor.DTOs;
using SupportHelper.Blazor.DTOs.Machines;

namespace SupportHelper.Blazor.Interfaces
{
    public interface IMachineServices
    {
        ResponseBase<IEnumerable<MachineDto>> RequestGetAllMachineAsync(int pageCount, int pageSize);
        ResponseBase<MachineDto> RequestOnlyMachineAsync(string id);
    }
}
