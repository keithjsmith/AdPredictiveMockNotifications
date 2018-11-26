using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DomainModels
{
    public class Preferences
    {
        //Using simple boolean values for this, but could tie this into bitflags instead.
        //Defaulting notifications to true for this example.  It was not a requirement,
        //but typically notifications are turned on by default in my experience.  Easy to change.

        //Not really a need for data annotations in this example

        [Required(ErrorMessage = "This is a non nullable bool so this error won't occur.")]
        //bit 1 
        public bool NewCommentNotificaiton { get; set; } = true;

        //bit 2
        public bool CampaignStatusChangedNotificaiton { get; set; } = true;

        //bit 4
        public bool NewReportAvailableNotification { get; set; } = true;

        //bit 8 for the next preference etc.

    }
}
