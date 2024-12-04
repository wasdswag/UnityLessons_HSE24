using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
   [SerializeField] private Quest[] allQuestsObjects;
   private List<IQuest> iQuests = new List<IQuest>();
   
   private IQuest currentQuest;
   private int currentQuestIndex;
   

   private void Awake()
   {
      foreach (var questObj in allQuestsObjects)
      {
         if (questObj.TryGetComponent(out IQuest quest))
         {
            iQuests.Add(quest);  
         }  
      }

      currentQuest = iQuests[currentQuestIndex];
      currentQuest.IsActive = true;

   }

   public void SetNextQuest()
   {
      if (currentQuest.IsComplete && currentQuestIndex < iQuests.Count-1)
      {
         currentQuestIndex++;
         currentQuest = iQuests[currentQuestIndex];
         currentQuest.IsActive = true;
      }

   }





}
