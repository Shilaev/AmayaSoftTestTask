using UnityEngine;
using UnityEngine.Events;

public class EventsHandler : MonoBehaviour
{
    private Configuration _config;
    [SerializeField] private UnityEvent OnCorrectCellClicked;
    [SerializeField] private UnityEvent OnGameRestart;
    [SerializeField] private UnityEvent OnGameStart;
    [SerializeField] private UnityEvent OnGameFinish;
    private const string CELL_TAG = "Cell";
    private Camera _camera;

    private void Awake()
    {
        _config = GetComponent<Configuration>();
        _camera = Camera.main;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }

    public void RestartGame()
    {
        OnGameRestart?.Invoke();
    }

    public void FinishGame()
    {
        OnGameFinish?.Invoke();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
#if UNITY_ANDROID
            Vector2 ray = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
#else
            Vector2 ray = _camera.ScreenToWorldPoint(Input.mousePosition);
#endif
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (_config.GameStateMode == Configuration.GameState.Play)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag(CELL_TAG))
                    {
                        if (hit.collider.name == _config.TargetData.Identifier)
                        {
                            hit.collider.GetComponent<Cell>().PlayFX();
                            OnCorrectCellClicked?.Invoke();
                        }
                        else
                        {
                            hit.collider.GetComponent<Cell>().ClickBounce();
                        }
                    }
                }
            }
        }
    }
}