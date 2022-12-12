using Capstone.Models; 

namespace Capstone.DAO.Interfaces
{
    public interface ICurriculumDAO
    {
        BotMessage GetCurriculumResponse(UserMessage message);
    }
}
