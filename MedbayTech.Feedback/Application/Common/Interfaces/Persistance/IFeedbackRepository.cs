﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Common.Repository;

using MedbayTech.Common.Repository;
using System.Collections.Generic;

namespace MedbayTech.Feedback.Infrastructure.Database
{
    public interface IFeedbackRepository : IRepository<Domain.Entities.Feedback, int>
    {
        bool UpdateStatus(int feedbackId, bool status);
        List<Domain.Entities.Feedback> GetAllApprovedFeedback();
        bool CheckIfExists(Domain.Entities.Feedback feedback);
    }
}
