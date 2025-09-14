using PoseLibrary.Models;

namespace PosePassword
{
    public class RemoveCard
    {
        public List<CardModel> RemoveCards(int id,List<CardModel> cards)
        {
            cards.RemoveAt(id-1);
             return cards;
        }
    }
}