using Dapper;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Document.Models;

namespace FondApi.Repository.Document;

public class DocumentRepository : IDocumentRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public DocumentRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<DocumentDb>> GetListByTypeAsync(string page)
    {
        using var db = _dbConnectionFactory.GetConnection();

        var command = new CommandDefinition(
                @"SELECT * FROM f_api_get_documents(@in_page)",
                new
                {
                    in_page = page,
                });

        return await db.QueryAsync<DocumentDb>(command);
    }
}
