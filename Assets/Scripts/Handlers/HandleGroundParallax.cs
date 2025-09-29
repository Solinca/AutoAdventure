using UnityEngine;

public class HandleGroundParallax : MonoBehaviour
{
    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private GameObject _groundObject;
    [SerializeField] private float _groundCreationEllapsedDistanceSetting;
    [SerializeField] private float _groundCreationStep;

    private float ellapsedDistance = 0;

    private void Update()
    {
        if (DATA.GAME_STATUS.GameState == GameStatus.GAME_STATE.RUNNING)
        {
            ellapsedDistance += _groundCreationStep * Time.deltaTime * 1000;

            _groundObject.transform.localPosition = _groundObject.transform.localPosition - _groundCreationStep * Time.deltaTime * Vector3.right * 1000;

            if (ellapsedDistance >= _groundCreationEllapsedDistanceSetting)
            {
                ellapsedDistance = 0;

                Instantiate(_groundPrefab, _groundObject.transform);
            }
        }
    }
}
