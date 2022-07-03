using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace CM.UI
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        // CONFIG
        [SerializeField] private float typingSpeed = 0.06f;
        public void SetDialogueText(string content, bool isTyping = false)
        {
            text.SetText("");
            if (!isTyping)
            {
                text.SetText(content); 
            }
            else
            {
                StartCoroutine(TypeTextAnim(content));
            }
        }

        private IEnumerator TypeTextAnim(string content)
        {
            string curContent = "";
            foreach (char contentChar in content)
            {
                curContent += contentChar;
                if(contentChar == ' ') continue;
                yield return new WaitForSeconds(typingSpeed);
                text.SetText(curContent);
            }
        }
    }
}