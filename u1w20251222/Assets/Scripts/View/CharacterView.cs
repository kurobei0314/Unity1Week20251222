using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Transform[] m_playerRenderers;
    public void Initialize()
    {
        m_playerRenderers[0].gameObject.SetActive(true);
        for (var i = 1; i < m_playerRenderers.Length; i++)
        {
            m_playerRenderers[i].gameObject.SetActive(false);
        }
    }
}
