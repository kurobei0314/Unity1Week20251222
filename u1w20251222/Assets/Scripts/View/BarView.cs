using UnityEngine.UI; 
using UnityEngine;

public class BarView : MonoBehaviour
{
    [SerializeField] private Image gaugeImage;
    private float ratio;

    public void Update()
    {
        UpdateGaugeRatio();
        gaugeImage.fillAmount = ratio;
    }

    private void UpdateGaugeRatio()
    {
        ratio = ratio == 1.0f ?  0.0f : Mathf.Clamp( ratio + Time.deltaTime, 0.0f, 1.0f);
    }
    
}
