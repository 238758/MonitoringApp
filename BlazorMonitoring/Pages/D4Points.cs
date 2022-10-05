using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorMonitoring.Pages
{
    public partial class D4Points
    {
        [Inject]
        ID4DataService? D4DataService { get; set; }

        private List<PointNode> _pointList = new();

        protected override async Task OnInitializedAsync()
        {
            if (D4DataService != null)
            {
                if (D4DataService != null)
                {
                    _pointList = await D4DataService.GetAllPointsSignals();
                }
            }

            
        }

    }
}
