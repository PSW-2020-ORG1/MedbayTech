using System.IO;
namespace MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders
{
    public interface IRssService
    {
        public MemoryStream GenerateTenderRss();
    }
}
