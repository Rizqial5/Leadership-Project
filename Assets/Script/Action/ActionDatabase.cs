using UnityEngine;
using UnityEngine.UI;


namespace Leadership.Action
{
    public class ActionDatabase : MonoBehaviour
    {
        [SerializeField] ActionSystem[] totalInteractionRooms;
        

        
        
        public ActionSO[] GetActionSO( DivisionEnum name)
        {
            foreach (ActionSystem item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    return item.GetActionSO();
                }
            }

            return null;
        }
    }
}