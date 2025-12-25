using UnityEngine;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private BarView m_BarView;
    [SerializeField] private CharacterView m_Character;
    [SerializeField] private SnowView m_Snow;

    public void Initialize()
    {
        m_BarView.Initialize();
        m_Character.Initialize();
        m_Snow.Initialize();
    }

    public void UpdateView()
    {
        m_BarView.UpdateView();
    }
}
