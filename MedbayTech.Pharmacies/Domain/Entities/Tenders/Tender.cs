using MedbayTech.Common.Domain.Entities;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Domain.Enums;
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

        public string TenderDescription { get; set; }
        public TenderStatus TenderStatus { get; set; }
        public int WinnerTenderOfferId { get; set; }

        public virtual List<TenderMedication> TenderMedications { get; set; }

        public Tender(DateTime startDate, DateTime endDate, TenderStatus tenderStatus, List<TenderMedication> tenderMedication)
        {
            StartDate = startDate;
            EndDate = endDate;
            TenderStatus = tenderStatus;
            TenderMedications = tenderMedication;
        } 
        
        public Tender(int id, DateTime startDate, DateTime endDate, TenderStatus tenderStatus)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            TenderStatus = tenderStatus;
            TenderMedications = new List<TenderMedication>();
        }

        public Tender(TenderDTO tenderDTO)
        {
            StartDate = DateTime.Now;
            EndDate = tenderDTO.EndDate;
            TenderStatus = TenderStatus.Active;
            TenderMedications = new List<TenderMedication>();
            TenderDescription = tenderDTO.TenderDescription;
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

        public override string ToString()
        {
            string text = "\tTender: " + Id +
                "\n\t " + TenderDescription + "." +
                "\n\t Tender published: " + StartDate.Day + "/" + StartDate.Month + "/" + StartDate.Year + "." +
                "\n\t Tender ending: " + EndDate.Day + "/" + EndDate.Month + "/" + EndDate.Year + ".";

            return text;
        }
    }
}
