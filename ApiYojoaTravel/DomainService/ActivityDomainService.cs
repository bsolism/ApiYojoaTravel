using ApiYojoaTravel.Models;
using System;

namespace ApiYojoaTravel.DomainService
{
    public class ActivityDomainService
    {
        public bool PostActivity(Activity activity)
        {
            bool requiredField;
            requiredField = (activity.Name == null) ? true : false;
            requiredField = (activity.Description == null) ? true : false;
            requiredField = (activity.InitTime == new DateTime(0)) ? true : false;
            requiredField = (activity.EndTime == new DateTime(0)) ? true : false;
            requiredField = (activity.Price == 0) ? true : false;
            requiredField = (activity.ImageURL == null) ? true : false;
            return requiredField;

        }
    }
}