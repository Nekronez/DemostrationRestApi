using FondApi.Business.Tender.Models;
using FondApi.Repository.Tender;

namespace FondApi.Business.Tender;

public class TenderService : ITenderService
{
    private readonly ITenderRepository _tenderRepository;

    public TenderService(
        ITenderRepository tenderRepository)
    {
        _tenderRepository = tenderRepository;
    }

    public async Task<IEnumerable<GetTendersResponse>> GetTendersAsync()
    {
        var tendersDb = await _tenderRepository.GetListAsync();
        var tenders = new List<GetTendersResponse>();

        foreach (var tenderId in tendersDb.Select(t => t.TenderId).Distinct())
        {
            var tempTenders = tendersDb.Where(t => t.TenderId == tenderId);
            var response = new GetTendersResponse
            {
                Id = tenderId,
                Name = tempTenders.First().TenderName,
                Items = new List<TenderInfo>(),
            };

            foreach (var tenderInfoId in tempTenders.Select(t => t.TenderInfoId).Distinct())
            {
                var tempTenderInfo = tendersDb.Where(t => t.TenderInfoId == tenderInfoId);
                var tenderInfo = new TenderInfo
                {
                    Id = tenderInfoId,
                    Name = tempTenderInfo.First().TenderInfoName,
                    TargetUrl = tempTenderInfo.First().TenderInfoUrl,
                    Documents = new List<Business.Models.Document>(),
                };

                foreach (var documentId in tempTenderInfo.Select(t => t.DocumentId).Distinct())
                {
                    var tempDocs = tendersDb.Where(t => t.DocumentId == documentId);
                    if (documentId != null)
                    {
                        var document = new Business.Models.Document
                        {
                            Id = (int)documentId,
                            Name = tempDocs.First().DocumentName!,
                            Url = tempDocs.First().DocumentPath!,
                        };

                        tenderInfo.Documents.Add(document);
                    }
                }

                response.Items.Add(tenderInfo);
            }

            tenders.Add(response);
        }

        return tenders;
    }
}
