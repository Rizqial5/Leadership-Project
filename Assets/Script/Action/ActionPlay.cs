using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leadership.UI;
using Leadership.Management;

namespace Leadership.Action
{
    public class ActionPlay : MonoBehaviour
    {
        [SerializeField] DivisionEnum divisionEnum;

        [SerializeField] GameObject showActionPanel;
        [SerializeField] Transform parentPanel;

        [SerializeField] GameObject showActionEventPanel;

        private GameObject actionPanel;
        private bool isActionPanelDone;
        private bool isActionPlay;
        private GameObject actionEventPanel;

        private int indexNumber = 0;
        private float accumulationPoint;
        
        public void ActionStart(ActionSO actionSO)
        {
            ShowImageAction(actionSO);
            isActionPlay = true;
        }

        private void ShowImageAction(ActionSO actionSO)
        {
            if (actionPanel != null) return;
            if (isActionPanelDone == true) return;

            isActionPanelDone = true;
            actionPanel = Instantiate(showActionPanel,parentPanel);
            actionPanel.GetComponent<PanelEvent>().SetNameEvent(actionSO.GetNameAction());
            actionPanel.GetComponent<PanelEvent>().SetImageEvent(actionSO.GetImageAction());

            
            actionPanel.GetComponentInChildren<Button>().onClick.AddListener(() => ShowActionEvent(actionSO,0));
            
        }

        private void ShowActionEvent(ActionSO actionSO, int i)
        {
            if(actionEventPanel == null)
            {
                actionEventPanel = Instantiate(showActionEventPanel, parentPanel);
            }
            

            Destroy(actionPanel);

            actionEventPanel.GetComponent<PanelStoryEvent>().SetNameEvent(actionSO.GetNameAction());
            actionEventPanel.GetComponent<PanelStoryEvent>().SetImageEvent(actionSO.GetImageAction());

            actionEventPanel.GetComponent<PanelStoryEvent>().SetDescEvent(actionSO.GetActionEventSO()[i].GetDescEvent());
            indexNumber = 0;
            foreach (var item in actionSO.GetActionEventSO()[i].GetAnswerActions())
            {

                actionEventPanel.GetComponent<PanelStoryEvent>().SetButtonEvent(item.descAnswer,item.effectUpAnswer, indexNumber);
                if(i < 2)
                {
                    actionEventPanel.GetComponent<PanelStoryEvent>().SetButtonFunction(indexNumber).onClick.AddListener(() => ShowActionEvent(actionSO, i + 1));
                }else if(i == 2)
                {
                    actionEventPanel.GetComponent<PanelStoryEvent>().SetButtonFunction(indexNumber).onClick.AddListener(() => ActionDone());
                }
                


                indexNumber++;
            }

        }

        public void ActionDone()
        {
            indexNumber = 0;
            isActionPanelDone = false;
            isActionPlay = false;
            accumulationPoint = actionEventPanel.GetComponent<PanelStoryEvent>().GetAccumulation();


            Destroy(actionEventPanel);

            GetComponent<ActionSystem>().EffectActivated(accumulationPoint);
            GetComponent<ActionSystem>().SetNullPlannedAction();
            
        }

        public bool GetActionPLay()
        {
            return isActionPlay;
        }
    }
}
