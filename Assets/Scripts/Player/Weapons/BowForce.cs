using UnityEngine.UI;
using UnityEngine;

public class BowForce : MonoBehaviour
{
    public int maxBowForceHoldTime;
    public BowArrow bowArrow;
    public Slider bowForceSlider;

    void Start() {
       UpdateBowForce(0f);
    }

    public void UpdateBowForce(float holdDownTime)
    {
        float currentBowForce = CalculateBowForce(holdDownTime);
        bowForceSlider.value = currentBowForce;
        bowArrow.currentBowForce = currentBowForce;
    }

    public void UpdateBowForceBar(float value)
    {
        bowForceSlider.value = value;
    }

    float CalculateBowForce(float holdDownTime)
    {
        float holdTimeNormalized = Mathf.Clamp01(holdDownTime / maxBowForceHoldTime);
        float currentBowForce = holdTimeNormalized * bowForceSlider.maxValue;
        return currentBowForce;
    }
}
