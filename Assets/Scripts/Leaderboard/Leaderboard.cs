using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Transform leaderBoardContainer;
    public Transform leaderBoardTemplate;

    private void awake() {
        //leaderBoardContainer = transform.Find("leaderBoardContainer");
        //leaderBoardTemplate = leaderBoardContainer.Find("leaderBoardTemplate");

        leaderBoardTemplate.gameObject.SetActive(false);

        float templateHeight = 30f;
        for (int i = 0; i < 10; i++) {
            Transform entryTransform = Instantiate(leaderBoardTemplate, leaderBoardContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            entryTransform.Find("Name").GetComponent<Text>().text = "AAA";
            entryTransform.Find("Time").GetComponent<Text>().text = "12:30";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
