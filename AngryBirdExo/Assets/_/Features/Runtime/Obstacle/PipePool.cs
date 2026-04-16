using System;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private int _pipeCapacity = 10;
    
    private List<GameObject> _list = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _pipeCapacity; i++)
        {
            GameObject pipe = Instantiate(_pipePrefab,transform);
            pipe.name = $"Pipe_{i}";
            pipe.SetActive(false);
            _list.Add(pipe);
        }
    }


    public GameObject GetFirstAvailablePipe()
    {
        foreach (GameObject pipe in _list)
        {
            if (pipe.activeSelf == false) return pipe;
        }
        
        GameObject newPipe = Instantiate(_pipePrefab, transform);
        newPipe.SetActive(false);
        _list.Add(newPipe);
        return newPipe;
    }
}
