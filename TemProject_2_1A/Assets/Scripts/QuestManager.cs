using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI questText;
    private Quest currentQuest;

    private void UpdateQuestText()
    {
        if (currentQuest.state == QuestState.InProgress)
        {
            questText.text =
                currentQuest.questName + "\n" +
                currentQuest.targetItemName + " " +
                currentQuest.currentAmount + "/ " +
                currentQuest.targetAmount;
        }
        else if(currentQuest.state == QuestState.ReadyToComplete)
        {
            questText.text = "수집 완료! \nNPC에게 돌아가세요";
        }
        else if(currentQuest.state == QuestState.Completed)
        {
            questText.text = currentQuest.questName + "\n퀘스트 완료";
        }
    }

    void StartQuest(Quest newQuest)
    {
        currentQuest = newQuest;
        currentQuest.currentAmount = 0;
        currentQuest.state = QuestState.InProgress;

        Debug.Log(currentQuest.questName + "퀘스트 시작!");
        UpdateQuestText();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
