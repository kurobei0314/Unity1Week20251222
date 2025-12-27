using UnityEngine;

public class SnowView : MonoBehaviour
{
    [SerializeField] private Transform[] m_snowRenderers;

    public void Initialize()
    {
        m_snowRenderers[0].gameObject.SetActive(true);
        for (var i = 0; i < m_snowRenderers.Length; i++)
        {
            m_snowRenderers[i].gameObject.SetActive(false);
        }
    }
}
