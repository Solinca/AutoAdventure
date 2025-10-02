using UnityEngine;

public class HandleGroundParallax : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _groundPrefab;

    [Header("Settings")]
    [SerializeField] private float _groundCreationEllapsedDistance = 1850;
    [SerializeField] private float _groundMoveStep = 200;

    private float ellapsedDistance = 0;

    private void Update()
    {
        if (DATA.GAME_STATUS.GameStatus == GAME_STATUS.RUNNING)
        {
            ellapsedDistance += _groundMoveStep * Time.deltaTime;

            transform.localPosition = transform.localPosition - _groundMoveStep * Time.deltaTime * Vector3.right;

            if (ellapsedDistance >= _groundCreationEllapsedDistance)
            {
                ellapsedDistance = 0;

                Instantiate(_groundPrefab, transform);
            }
        }
    }
}
