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
        [Range(0.01f, 0.10f)]
        [SerializeField] private float typingSpeed = 0.06f;
        public IEnumerator SetDialogueText(string content, bool isTyping = false)
        {
            text.SetText("");
            if (!isTyping)
            {
                text.SetText(content); 
                yield return null;
            }
            else
            {
                yield return StartCoroutine(TypeTextAnim(content));
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