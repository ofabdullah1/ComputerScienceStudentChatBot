using Capstone.Models; 

namespace Capstone.DAO.Interfaces
{
    public interface IPathwayDAO
    {
        BotMessage GetPathwayResponse(UserMessage message);
    }
}
