namespace MagniUniversity.UI.VIewModel
{
    public class ReturnViewModel
    {
        public ReturnViewModel(bool error, string message, object content)
        {
            this.Error = error;
            this.Message = message;
            this.Content = content;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}