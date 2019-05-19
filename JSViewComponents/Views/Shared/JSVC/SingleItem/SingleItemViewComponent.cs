namespace JSViewComponents.JSVC.SingleItem
{
    /// <summary>
    /// JSViewComponent to show properties from a single item
    /// </summary>
    public class SingleItemViewComponent 
        : JSVC.BaseViewComponent
    {
        /// <summary>
        /// Object to be show
        /// </summary>
        public object Data { get;  }

        /// <summary>
        /// Create component
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataUrl"></param>
        public SingleItemViewComponent(string name, object data, string dataUrl = null)
            :base(name, dataUrl)
        {
            this.Data = data;
        }
    }
}
