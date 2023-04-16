using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public InputField nameInput;
    public Button saveButton;
    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        nameInput.onValueChanged.AddListener(ValueChangeCheck);
        saveButton.onClick.AddListener(SaveSettings);
    }

    public void ValueChangeCheck(string name)
    {
        playerName = name;
    }

    public void SaveSettings()
    {
        GameStates.setPlayerName(playerName);
        // Debug.Log(GameStates.getCurrentPlayerName());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetName(string name)
	{
        // Debug.Log(name);
		GameStates.setPlayerName(name);
	}
}