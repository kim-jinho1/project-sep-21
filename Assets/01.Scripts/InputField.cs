using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public TMP_InputField tmpInputField;
    public string targetWord = "4";  // 사용자가 입력해야 할 단어
    public GameObject panel;
    public TextMeshProUGUI text;
    private int score = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(false);
        }
    }

    // InputField의 입력값을 확인하는 메서드
    private void CheckInput(string input)
    {
        // 사용자가 원하는 단어를 입력했을 때
        if (input.Equals(targetWord, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("특정 단어가 입력되었습니다: " + input);
            // 여기에 원하는 이벤트나 동작을 추가
            OnCorrectWordEntered();
            score++;
            text.text = $"score {score}";
            panel.SetActive(false);
        }
        else
        {
            Debug.Log("입력된 단어가 일치하지 않습니다.");
        }
    }

    // 원하는 단어가 입력되었을 때 발생하는 이벤트
    private void OnCorrectWordEntered()
    {
        // 예: UI 변경, 사운드 재생, 캐릭터 이동 등
        Debug.Log("이벤트 발생: 정답을 맞췄습니다!");
    }
}
