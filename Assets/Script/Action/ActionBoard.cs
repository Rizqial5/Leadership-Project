using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leadership.UI;

namespace Leadership.Action
{
    public class ActionBoard : MonoBehaviour
    {
        [SerializeField] PanelBoard actionBoardPanel;
        [SerializeField] Transform parentSpawn;

        public void ShowActionBoard()
        {
            List<ActionSO> totalActions = GetComponent<ActionDatabase>().GetTotalActionSO();

            List<string> totalItems = new List<string>();

            foreach (var item in totalActions)
            {
                totalItems.Add(item.GetNameAction());
            }

            string[] totalActionName = totalItems.ToArray();



            PanelBoard spawnPanelBoard = Instantiate(actionBoardPanel, parentSpawn);
            spawnPanelBoard.windowTitle.text = "Action Board";
            spawnPanelBoard.SpawnObjectList(totalActionName);
        }
    }
}

