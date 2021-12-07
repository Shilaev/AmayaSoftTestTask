using System.Collections.Generic;
using UnityEngine;

public class CellContentScript : MonoBehaviour
{
    private Configuration _config;
    private ContentDataSO _currentData;
    private List<ContentData> _availableContent = new List<ContentData>();
    private List<Cell> _activeCells = new List<Cell>();
    private List<ContentData> _usedData = new List<ContentData>();
    private List<ContentData> _usedTargetData = new List<ContentData>();

    public List<Cell> ActiveCells => _activeCells;
    public List<ContentData> UsedTargetData => _usedTargetData;


    private void Awake()
    {
        _config = GetComponentInParent<Configuration>();
    }

    public void SelectRandomContentData()
    {
        _currentData = _config.ContentDataSOArray[Random.Range(0, _config.ContentDataSOArray.Length)];
        
        PopulateAvailableContentList();
    }

    private void PopulateAvailableContentList()
    {
        _availableContent.Clear();
        _usedData.Clear();

        foreach (var item in _currentData._contentData)
        {
            _availableContent.Add(item);
        }

        foreach (var item in _usedTargetData)
        {
            if(_availableContent.Contains(item))
            {
                _availableContent.Remove(item);
            }
        }

        SetCellsValues();
    }

    private void SetCellsValues()
    {
        for (int i = 0; i < _activeCells.Count; i++)
        {
            int tmpIndex = Random.Range(0, _availableContent.Count);
            
            _activeCells[i].SetCellIdentifier(_availableContent[tmpIndex].Identifier);
            _activeCells[i].SetCellSprite(_availableContent[tmpIndex].Sprite);
            
            _usedData.Add(_availableContent[tmpIndex]);
            _availableContent.RemoveAt(tmpIndex);
        }
        
        int tmpTargetIndex = Random.Range(0, _usedData.Count);
        _config.SetTargetData(_usedData[tmpTargetIndex]);
        _usedTargetData.Add(_usedData[tmpTargetIndex]);
    }
}
