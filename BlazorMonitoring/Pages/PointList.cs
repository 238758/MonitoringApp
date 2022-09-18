using FM4017Library.DataModels;
using FM4017Library.DataModels.Sample;

namespace BlazorMonitoring.Pages
{
    public partial class PointList
    {
        private List<Point> _pointList = new ();

        public PointList()
        {

            // Add random sample data
            for (int i = 0; i < 2; i++)
            {
                _pointList.Add(new SamplePoint());
            }
        }

        public void AddPoint()
        {
            _pointList.Add(new SamplePoint());
        }

        public void RemovePoint()
        {
            _pointList.Clear();
        }
    }
}
