using Dapper;
using Dapper.Transaction;
using FondApi.Repository.ConnectionFactory;
using FondApi.Repository.Feedback.Model;

namespace FondApi.Repository.Feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public FeedbackRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> CreateFeedbackAsync(FeedbackDb request)
        {
            using var db = _dbConnectionFactory.GetConnection();

            var command = new CommandDefinition(
                    @"SELECT id
                      FROM f_api_create_feedback(
                        @in_first_name, 
                        @in_last_name, 
                        @in_middle_name, 
                        @in_email, 
                        @in_phone, 
                        @in_text, 
                        @in_topic,
                        @in_city, 
                        @in_street, 
                        @in_building, 
                        @in_room)",
                    new
                    {
                        in_first_name = request.FirstName,
                        in_last_name = request.LastName,
                        in_middle_name = request.MiddleName,
                        in_email = request.Email,
                        in_phone = request.Phone,
                        in_text = request.Text,
                        in_topic = request.Topic,
                        in_city = request.City,
                        in_street = request.Street,
                        in_building = request.Building,
                        in_room = request.Room,
                    });

            return await db.QueryFirstOrDefaultAsync<int>(command);
        }

        public async Task CreateFeedbackFilesAsync(int feedbackId, string[] filesPaths)
        {
            using var db = _dbConnectionFactory.GetConnection();

            using var transaction = db.BeginTransaction();

            foreach (var path in filesPaths)
            {
                var command = new CommandDefinition(
                    @"SELECT 
                          FROM f_api_create_feedback_file(@in_feedback_id, @in_path)",
                    new
                    {
                        in_feedback_id = feedbackId,
                        in_path = path,
                    });

                await transaction.ExecuteAsync(command);
            }

            await transaction.CommitAsync();
        }
    }
}
