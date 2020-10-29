// File:    IReportRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 5:07:22 AM
// Purpose: Definition of Interface IReportRepository

using System;

namespace Repository.ReportRepository
{
   public interface IReportRepository : IRepository<Model.Reports.Report,int>
   {
   }
}