using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Leadership Project/ActionEvent")]
public class ActionEventSO : ScriptableObject
{
    [SerializeField] string titleEvent;

    [TextArea(3, 10)]
    [SerializeField] string descEvent;

    [Header("Option Answer")]
    [SerializeField] AnswerAction[] answerAction;

    public string GetTitleEvent() {  return titleEvent; }
    public string GetDescEvent() {  return descEvent; }
    public AnswerAction[] GetAnswerActions() { return answerAction; }


}


[System.Serializable]
public class AnswerAction
{
    [TextArea(3, 10)]
    [SerializeField] public string descAnswer;

    [SerializeField] public float effectUpAnswer;
}
