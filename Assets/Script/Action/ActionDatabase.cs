using UnityEngine;
using UnityEngine.UI;


namespace Leadership.Action
{
    public class ActionDatabase : MonoBehaviour
    {
        [SerializeField] ActionSystem[] totalInteractionRooms;
        [SerializeField] ActionSO choosedActionSOTemp;
        

        
        
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

        public void SetActionItemTemp(ActionSO item)
        {
            choosedActionSOTemp = item;
        }

        public void MakeActionPlan()
        {
            if (choosedActionSOTemp == null) return;
            foreach (var item in FindObjectsOfType<ActionSystem>())
            {
                if(item.GetDivisionEnum() == choosedActionSOTemp.GetDivisionEnum())
                {
                    item.SetChosenAction(choosedActionSOTemp);
                }
            }
        }
    }
}