using Capstone.Models; 

namespace Capstone.DAO.Interfaces
{
    public interface IPathwayDAO
    {
        Pathway GetPathwayResponse(UserMessage message);
    }
}
