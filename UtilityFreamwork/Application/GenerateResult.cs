namespace UtilityFreamwork.Application
{
    public class GenerateResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public GenerateResult()
        {
            IsSuccedded = true;
        }

        public GenerateResult Succedded(string message = "عملیات با موفقیت انجام شد.")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public GenerateResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
