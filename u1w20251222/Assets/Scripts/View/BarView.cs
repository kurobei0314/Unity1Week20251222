using UnityEngine.UI; 
using UnityEngine;

public class BarView : MonoBehaviour
{
    [SerializeField] private Image m_gaugeImage;

    public void Initialize()
    {
        m_gaugeImage.fillAmount = 0;
    }

    public void UpdateView(float ratio)
    {
        m_gaugeImage.fillAmount = ratio;
    }
    
}
