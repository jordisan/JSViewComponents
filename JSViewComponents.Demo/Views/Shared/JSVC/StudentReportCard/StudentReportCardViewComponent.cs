namespace JSViewComponents.Demo.Views.JSVC.StudentReportCard
{
    /// <summary>
    /// JSViewComponent to show a student's report card
    /// </summary>
    public class StudentReportCardViewComponent 
        : JSViewComponents.JSVC.SingleItem.SingleItemViewComponent
    {
        /// <summary>
        /// Create component
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataUrl"></param>
        public StudentReportCardViewComponent(string name, Models.Alumn alumn, string dataUrl = null)
            : base(name, alumn, dataUrl)
        {
        }
    }
}
