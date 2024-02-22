using Core.Entities;

namespace Entities;

public class Application:BaseEntity<int>
{
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }

    public virtual Applicant Applicant { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }
    public virtual ApplicationState ApplicationState { get; set; }

    public Application()
    {
        
    }

    public Application(int id,int applicantId, int bootcampId, int applicationStateid):this()
    {
        Id = id;
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStateid;
    }
}
