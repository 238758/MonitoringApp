using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorMonitoring.Pages;

public partial class D4Tenant
{
    [Inject]
    ID4DataService? D4DataService { get; set; }

    private string? _d4TenantName;
    private List<SpaceNode>? spaceNodes;

    protected override async Task OnInitializedAsync()
    {
        _d4TenantName = _config["DimensionFour:Header1Value"];

        spaceNodes = await D4DataService.GetAllSpacesPointsSignals();
    }

}
