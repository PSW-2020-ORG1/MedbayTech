
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Repository;

namespace MedbayTech.Appointment.Application.Common.Interfaces.Persistance
{
    public interface ISurveyRepository : ICreate<Survey>, IGetAll<Survey>
    {
    }
}
