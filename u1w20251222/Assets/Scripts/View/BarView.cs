using UnityEngine.UI; 
using UnityEngine;

public class BarView : MonoBehaviour
{
    [SerializeField] private Image m_gaugeImage;
    private float m_ratio;

    public void Initialize()
    {
        m_ratio = 0;
    }

    public void UpdateView()
    {
        UpdateGaugeRatio();
        m_gaugeImage.fillAmount = m_ratio;
    }

    private void UpdateGaugeRatio()
    {
        m_ratio = m_ratio == 1.0f ?  0.0f : Mathf.Clamp( m_ratio + Time.deltaTime, 0.0f, 1.0f);
    }
    
}
