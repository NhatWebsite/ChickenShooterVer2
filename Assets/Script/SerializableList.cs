using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SerializableList<T> : List<T>, ISerializationCallbackReceiver

{
    [SerializeField] private List<T> _list = new List<T>();
    public SerializableList()
    {

    }
    public void OnBeforeSerialize()
    {
        _list.Clear();
        foreach (T element in this)
        {
            _list.Add(element);
        }
    }
    public void OnAfterDeserialize()
    {
        this.Clear();
        for (int i = 0; i < _list.Count; i++)
        {
            this.Add(_list[i]);
        }
    }
}
