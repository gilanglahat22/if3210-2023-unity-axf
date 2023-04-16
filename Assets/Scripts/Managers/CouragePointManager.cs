using UnityEngine;
using TMPro;

public class CouragePointManager : MonoBehaviour
{
    private TMPro.TextMeshProUGUI courageCounter;

    void Awake ()
    {
        courageCounter = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update ()
    {
        courageCounter.text = "Courage: " + GameStates.getCurrentPoin();
    }
}
