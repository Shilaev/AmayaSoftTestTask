using System.Collections;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    private Configuration _config;
    private EventsHandler _eventsHandler;
    private CellContentScript _cellContents;
    private float _levelWidth;
    private float _levelHeight;
    private Vector2 _cellSize;
    private float _currentRow;

    private void Awake()
    {
        _eventsHandler = GetComponentInParent<EventsHandler>();
        InitGridValues();
    }

    public void GenerateGridLine()
    {
        if (_currentRow > 0)
        {
            Vector2 lastPosition = new Vector2((-_levelWidth * _cellSize.x) / 2 + _cellSize.x / 2,
                                               _levelHeight / _levelHeight * 2 - _currentRow * _cellSize.y);

            for (int x = 0; x < _levelWidth; x++)
            {
                var cell = Instantiate(_config.CellPrefab, transform);

                cell.transform.position = lastPosition;
                lastPosition.x += _cellSize.x;

                _cellContents.ActiveCells.Add(cell.GetComponent<Cell>());
            }

            _currentRow--;

            _cellContents.SelectRandomContentData();
        }
        else
        {
            _eventsHandler.FinishGame();
        }
    }

    private void InitGridValues()
    {
        _config = GetComponentInParent<Configuration>();
        _cellContents = GetComponent<CellContentScript>();

        _levelWidth = _config.Width;
        _levelHeight = _config.Height;
        _cellSize = _config.CellSize;
        _currentRow = _levelHeight;
        _config.SetGameState(true);
    }

    public void ResetGrid()
    {
        StartCoroutine(nameof(StartReset));
    }

    private float _fakeLoadingTime = 2;

    public IEnumerator StartReset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        _cellContents.ActiveCells.Clear();
        _cellContents.UsedTargetData.Clear();

        yield return new WaitForSecondsRealtime(_fakeLoadingTime);

        InitGridValues();
        GenerateGridLine();
    }
}