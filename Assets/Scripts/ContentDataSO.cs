using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContentData
{
    [SerializeField] private string _identifier;
    [SerializeField] private Sprite _sprite;

    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;
}

[CreateAssetMenu(fileName = "Cell Content Data")]
public class ContentDataSO : ScriptableObject
{
    public ContentData[] _contentData;
}
