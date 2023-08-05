using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leadership.Attribute;
using Leadership.Core;
using TMPro;
using Leadership.Management;

public class DecisionEventUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] TextMeshProUGUI storyText;
    [SerializeField] Button answerButton;
    [SerializeField] Transform spawnLoc;

    void Update()
    {
        AddCloseFunction();
    }

    private void AddCloseFunction()
    {
        Button[] ansButton = GetComponentsInChildren<Button>();

        for (int i = 0; i < ansButton.Length; i++)
        {
            ansButton[i].onClick.AddListener(() => CloseUI());
        }
    }

    public string SetHeaderText(string text)
    {
        return headerText.text = text;
    }

    public string SetStoryText(string text)
    {
        return storyText.text = text;
    }

    public void CloseUI()
    {
        Button[] ansButton = GetComponentsInChildren<Button>();

        for (int i = 0; i < ansButton.Length; i++)
        {
            Destroy(ansButton[i].gameObject);
        }

        

        gameObject.SetActive(false);

       
    }

    public void SpawnButton( string name, int i, float beda, CaseEffect[] caseEffect )
    {
        

        var answerOption = Instantiate(answerButton,spawnLoc.position,spawnLoc.rotation,transform);
        
        answerOption.transform.position = new Vector3(answerOption.transform.position.x, (answerOption.transform.position.y + (i - 1) * beda));

        answerOption.GetComponentInChildren<TextMeshProUGUI>().text = name;
        answerOption.GetComponent<OptionEffect>().SetEffect(caseEffect);
        
    }

    //SetOptions
}
