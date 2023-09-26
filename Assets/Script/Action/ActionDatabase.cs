using UnityEngine;
using UnityEngine.UI;
using Leadership.Attribute;
using TMPro;
using System.Collections.Generic;

namespace Leadership.Action
{
    public class ActionDatabase : MonoBehaviour
    {
        [SerializeField] ActionSystem[] totalInteractionRooms;
        [SerializeField] ActionSO choosedActionSOTemp;
        [SerializeField] GameObject warningText;

        [SerializeField] OrganisationAttributesSO attributesSO;

        [Header("Total Actions")]
        [SerializeField] List<ActionSO> totalActions;
        [SerializeField] Button showActionBoard;


        private void Awake()
        {
            totalActions = new List<ActionSO>();
        }


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
            if(choosedActionSOTemp == null) return;
            //if(choosedActionSOTemp.GetRespawnActionTime)
            if(attributesSO.GetOrgAttributes(OrganisationEnum.Money) < choosedActionSOTemp.GetMoneyRequirement())
            {
                warningText.GetComponent<TextMeshProUGUI>().text = "Uang tidak cukup !!";
                return;
            }


            warningText.GetComponent<TextMeshProUGUI>().text = "";
            
            //Persyaratan

            foreach (var item in FindObjectsOfType<ActionSystem>())
            {
                if(item.GetDivisionEnum() == choosedActionSOTemp.GetDivisionEnum())
                {
                    if(item.GetPlannedAction() != null)
                    {
                        warningText.GetComponent<TextMeshProUGUI>().text = "Sudah ada Program!!";
                        return;
                    }

                    if (choosedActionSOTemp.RespawnActionTime > 0) 
                    {
                        warningText.GetComponent<TextMeshProUGUI>().text = "Kegiatan baru dilaksanakan, tunggu "
                            + choosedActionSOTemp.GetRespawnActionTimeLimit() + " Turn lagi";
                        return;
                    }


                    
                    totalActions.Add(choosedActionSOTemp);
                    item.SetChosenAction(choosedActionSOTemp);
                }
            }

            attributesSO.SetOrgAttributes(OrganisationEnum.Money, -choosedActionSOTemp.GetMoneyRequirement());
        }

        public void DecreaseRespawn()
        {
            foreach (var item in totalInteractionRooms)
            {
                foreach (var action in item.GetActionSO())
                {
                    if (action.RespawnActionTime == 0) continue;

                    action.RespawnActionTime-- ;
                }
            }
        }

        public List<ActionSO> GetTotalActionSO()
        {
            return totalActions;
        }

        public void DeleteTotalAction(ActionSO actionSO)
        {
            totalActions.Remove(actionSO);
        }

        public bool GetActionIsPlay()
        {
            foreach (var item in totalInteractionRooms)
            {
                if(item.GetIsPLayAction() == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}