using FM4017Library.Dtos.SpaceX;

namespace FM4017Library.DataServices.SpaceX;

public interface ISpaceXDataService
{
    Task<LaunchDto[]> GetAllLaunches();
}
