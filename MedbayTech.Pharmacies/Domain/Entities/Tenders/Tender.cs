using MedbayTech.Common.Domain.Entities;
using MedbayTech.Pharmacies.Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedbayTech.Pharmacies.Domain.Entities.Tenders
{
    public class Tender : IIdentifiable<int>
    {
        [Key]   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool TenderStatus { get; set; }

        public virtual List<TenderMedication> TenderMedications { get; set; }

        public Tender(int id, DateTime startDate, DateTime endDate, bool tenderStatus, List<TenderMedication> tenderMedication)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            TenderStatus = tenderStatus;
            TenderMedications = tenderMedication;
        } 
        
        public Tender(int id, DateTime startDate, DateTime endDate, bool tenderStatus)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            TenderStatus = tenderStatus;
            TenderMedications = new List<TenderMedication>();
        }

        public Tender(TenderDTO tenderDTO)
        {
            Id = 0;
            StartDate = DateTime.Now;
            EndDate = tenderDTO.EndDate;
            TenderStatus = true;
            TenderMedications = new List<TenderMedication>();
        }

        public Tender()
        {
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
