using ConnectionByADO.Models;

namespace ConnectionByADO.Implementations
{
    public interface IFetchServerInformation
    {

        public List<ServerData> GetInformationOfDataServer();
    }
}
