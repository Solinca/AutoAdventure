using UnityEngine;

public class HandleGroundParallax : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private RectTransform _groundPrefab;

    [Header("Settings")]
    [SerializeField] private float _groundMoveStep = 200;

    private float ellapsedDistance = 0;

    private void Start()
    {
        Instantiate(_groundPrefab, transform).sizeDelta = new Vector2(Screen.width, 0);
        Instantiate(_groundPrefab, transform).sizeDelta = new Vector2(Screen.width, 0);
    }

    private void Update()
    {
        if (DATA.GAME_STATUS.GameStatus == GAME_STATUS.RUNNING)
        {
            ellapsedDistance += _groundMoveStep * Time.deltaTime;

            transform.localPosition = transform.localPosition - _groundMoveStep * Time.deltaTime * Vector3.right;

            if (ellapsedDistance >= Screen.width)
            {
                ellapsedDistance = 0;

                Instantiate(_groundPrefab, transform).sizeDelta = new Vector2(Screen.width, 0);
            }
        }
    }
}
