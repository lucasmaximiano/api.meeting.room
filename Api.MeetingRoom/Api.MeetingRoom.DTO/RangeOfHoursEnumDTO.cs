using System.ComponentModel.DataAnnotations;

namespace Api.MeetingRoom.DTO
{
    public enum RangeOfHoursEnumDTO
    {
        [Display(Name = "8:00")]
        EightOclockAM = 8,
        [Display(Name = "9:00")]
        NinetOclockAM = 9,
        [Display(Name = "10:00")]
        TenOclockAM = 10,
        [Display(Name = "11:00")]
        ElevenOclockAM = 11,
        [Display(Name = "12:00")]
        TwelveOclockAM = 12,
        [Display(Name = "13:00")]
        OneOclockPM = 13,
        [Display(Name = "14:00")]
        TwoOclockPM = 14,
        [Display(Name = "15:00")]
        TreeOclockPM = 15,
        [Display(Name = "16:00")]
        FourOclockPM = 16,
        [Display(Name = "17:00")]
        FiveclockPM = 17,
        [Display(Name = "18:00")]
        SixOclockPM = 18
    }
}
