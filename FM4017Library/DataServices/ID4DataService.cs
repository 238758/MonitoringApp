using FM4017Library.Dtos;

namespace FM4017Library.DataServices;

public interface ID4DataService
{
    Task<List<SpaceNode>?> GetAllSpacesPointsSignals();
    Task<List<PointNode>?> GetAllPointsSignals();

    Task DeleteSpace(string spaceId);
    Task CreateSpace(string spaceId);
}
