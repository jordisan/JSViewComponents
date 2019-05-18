namespace JSViewComponents.Demo.Views.Components.StudentReportCard
{
    /// <summary>
    /// JSViewComponent to show a student's report card
    /// </summary>
    public class StudentReportCardViewComponent 
        : JSViewComponents.Components.SingleItem.SingleItemViewComponent
    {
        /// <summary>
        /// Create component
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataUrl"></param>
        public StudentReportCardViewComponent(string name, object data, string dataUrl = null)
            : base(name, data, dataUrl)
        {
        }
    }
}
