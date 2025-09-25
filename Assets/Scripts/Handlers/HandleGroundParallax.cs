using UnityEngine;

public class HandleGroundParallax : MonoBehaviour
{
    [SerializeField] private GameObject m_GroundPrefab;
    [SerializeField] private GameObject m_GroundObject;
    [SerializeField] private float m_GroundCreationEllapsedDistanceSetting;
    [SerializeField] private float m_GroundCreationStep;

    private float ellapsedDistance = 0;

    private void Update()
    {
        if (!Data.IsPaused)
        {
            ellapsedDistance += m_GroundCreationStep * Time.deltaTime * 1000;

            m_GroundObject.transform.localPosition = m_GroundObject.transform.localPosition - m_GroundCreationStep * Time.deltaTime * Vector3.right * 1000;

            if (ellapsedDistance >= m_GroundCreationEllapsedDistanceSetting)
            {
                ellapsedDistance = 0;

                Instantiate(m_GroundPrefab, m_GroundObject.transform);
            }
        }
    }
}
