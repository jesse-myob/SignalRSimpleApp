using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.Svc.Dashboard.Users
{
    public class UserLogInformationVM: IValidatableObject
    {
        public string UserId { get; set; }
        public DateTime LogDate { get; set; }
        public string Message { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (1 == 1)
                yield return new ValidationResult("");
        }
    }
}
