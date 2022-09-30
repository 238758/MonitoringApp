using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorMonitoring.Pages;

public partial class D4Tenant
{
    [Inject]
    ID4DataService? D4DataService { get; set; }



    private List<SpaceNode>? spaceNodes;
    //private List<PointNode>? pointNodes;
    //private List<SignalNode>? signalNodes;

    private List<SpaceNode>? _selectedSpaceNodes;


    protected override async Task OnInitializedAsync()
    {
        spaceNodes = await D4DataService.GetAllSpacesPointsSignals();

        // Get spaces with no parent
        _selectedSpaceNodes = SelectSpaceNodes(null);
    }

    /// <summary>
    /// List Spaces where parentId equals param
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    private List<SpaceNode>? SelectSpaceNodes(string parentId)
    {
        var result = (from spaceNode in spaceNodes
                      where spaceNode.Parent?.Id == parentId
                      select spaceNode).ToList();

        return result;
    }
}
