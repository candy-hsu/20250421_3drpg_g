
using UnityEngine;
using UnityEngine.Events;

namespace Uzai
{
    /// <summary>
    /// 互動系統：偵測玩家是否進入並且執行互動行為
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("對話資料")]
        private DialogueData dataDialogue;
        [SerializeField, Header("對話結束後的事件")]
        private UnityEvent onDialogueFinish;

        [SerializeField, Header("啟動道具")]
        private GameObject propActive;
        [SerializeField, Header("啟動後的對話資料")]
        private DialogueData dataDialogueActive;

        private string nameTarget = "Player";
        private DialogueSystem dialogueSystem;

        [SerializeField, Header("啟動後對話結束的事件")]
        private UnityEvent onDialogueFinishAfterActive;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
        }

        //3D物件適用
        //兩個碰撞物件必須其中一個勾選 Is Trigger
        //碰撞開始
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameTarget))
            {
                print(other.name);

                //如果 不需要啟動道具 或是 啟動道具是顯示的 就執行 第一行對話
                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StarDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StarDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                }

            }

        }

        ///<summary>
        ///隱藏物件
        ///</summary>
        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }

    }
}

