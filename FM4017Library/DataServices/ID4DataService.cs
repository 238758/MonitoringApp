using FM4017Library.Dtos;

namespace FM4017Library.DataServices;

public interface ID4DataService
{
    Task<D4PointDto[]> GetAllPoints();
}
