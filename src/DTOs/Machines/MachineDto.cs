using SupportHelper.Blazor.ValueObjects;

namespace SupportHelper.Blazor.DTOs.Machines
{
    public class MachineDto
    {
        public required bool IsConnected { get; set; }
        public required string Hostname { get; set; }
        public bool? SgpIsRunning { get; set; }
        public required string CurrentUsername { get; set; }
        public required string DomainName { get; set; }
        public required string OperationalSystem { get; set; }
        public required IEnumerable<NetworkBoard> NetworkBoards { get; set; }
        public required string UpTime { get; set; }
        public required string LastUpdate { get; set; }

        public static MachineDto Create(bool isConnected, string hostname, bool sgpIsRunning, string currentUsername,
            string domainName, string operationalSystem, IEnumerable<NetworkBoard> networkBoardResponses, string upTime, string lastUpdate)
        {
            return new MachineDto
            {
                IsConnected = isConnected,
                Hostname = hostname.ToLower(),
                SgpIsRunning = sgpIsRunning,
                CurrentUsername = currentUsername,
                DomainName = domainName,
                OperationalSystem = operationalSystem,
                NetworkBoards = networkBoardResponses,
                UpTime = upTime,
                LastUpdate = lastUpdate
            };
        }
    }
}
