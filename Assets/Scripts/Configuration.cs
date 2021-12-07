using UnityEngine;

public class Configuration : MonoBehaviour
{
    [Header("Grid Width is equivalent of available rounds")]
    [SerializeField] private Vector2 _gridSize;
    [Header("Add available for selection \"Contents\" here")]
    [SerializeField] private ContentDataSO[] _contentDataSOArray;
    [Header("Drag and drop \"Cell Prefab\" here")]
    [SerializeField] private GameObject _cellPrefab;
    [Header("temporary inconvenience")]
    [SerializeField] private Vector2 _cellSize;

    private ContentData _targetData;
    private UI_TargetText _TargetText;

    public enum GameState {Play, Pause };

    private GameState _gameState;
    
    public float Width => _gridSize.x;
    public float Height => _gridSize.y;
    public GameObject CellPrefab => _cellPrefab;
    public Vector2 CellSize => _cellSize;
    public ContentDataSO[] ContentDataSOArray => _contentDataSOArray;
    public ContentData TargetData => _targetData;
    public GameState GameStateMode => _gameState;

    private void Awake()
    {
        _TargetText = GetComponentInChildren<UI_TargetText>();
    }
    public void SetTargetData(ContentData targetData)
    {
        _targetData = targetData;
        _TargetText.SetTargetText(_targetData.Identifier);
    }

    public void SetGameState(bool state)
    {
        if(state)
        {
            _gameState = GameState.Play;
        }
        else
        {
            _gameState = GameState.Pause;
        }
    }
}
