// File:    ReportRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 5:07:25 AM
// Purpose: Definition of Class ReportRepository

using Model.Reports;
using SimsProjekat.Repository;
using System;
using System.Collections.Generic;

namespace Repository.ReportRepository
{
   public class ReportRepository : JSONRepository<Report, int>,
        IReportRepository 
    { 


        public Stream<Report> stream;

        public ReportRepository(Stream<Report> stream) : base(stream, "Report")
        {
            this.stream = stream;
        }

        public  new Model.Reports.Report Create(Model.Reports.Report entity)
        {
            throw new NotImplementedException();
        }

        public new bool Delete(Model.Reports.Report entity)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Report> GetAll()
        {
            throw new NotImplementedException();
        }

       
        public new Report GetObject(int id)
        {
            throw new NotImplementedException();
        }

        public new Report Update(Report entity)
        {
            throw  new NotImplementedException();
        }
    }
}