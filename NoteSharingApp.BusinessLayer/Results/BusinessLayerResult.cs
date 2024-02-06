using NoteSharingApp.Entities.Messages;
using System.Collections.Generic;

namespace NoteSharingApp.BusinessLayer.Results
{
    public class BusinessLayerResult<T> where T : class
    {

        public List<ErrorMessageObject> Errors { get; set; }
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObject>();
        }

        public void AddError(ErrorMessageEnum code, string message)
        {
            Errors.Add(new ErrorMessageObject() { code = code, message = message });
        }
    }
}
