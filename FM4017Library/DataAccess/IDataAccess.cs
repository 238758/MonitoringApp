using FM4017Library.Dtos;

namespace FM4017Library.DataAccess;

public interface IDataAccess
{
    Task<List<SpaceNode>?> GetAllSpacesPointsSignals();
    Task<List<PointNode>?> GetAllPointsSignals();

    Task<List<SignalNode>> GetLastSignalsInPointBetween2DateTime(string pointId, DateTime ltDateTime, DateTime gtDateTime, int n = 100);
    Task<List<SignalNode>> GetFirstSignalsInPointBetween2DateTime(string pointId, DateTime endDateTime, DateTime startDateTime, int n = 100);


    Task CreateSpace(string name, string? parentId, double? latitude, double? longitude, string? imageUrl);
    Task EditSpace(string name, string id, double? longitude = null, double? latitude = null, string? imageUrl = null);
    Task DeleteSpace(string spaceId);

    Task CreatePoint(string name, string? spaceId, double? latitude, double? longitude, string? imageUrl);
    Task EditPoint(string name, string id, double? longitude = null, double? latitude = null, string? imageUrl = null);
    Task DeletePoint(string pointId);

    Task CreateSignal(string pointId, string value, DateTime timestamp, string unit);
    Task EditSignal(string signalId);
    Task DeleteSignal(string signalId);




}
