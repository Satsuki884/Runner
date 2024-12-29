using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxCount;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
    [SerializeField] private Transform _tileHolder;

    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _startSpawnBomb = 3;
    private float _timer;

    private bool _isEnable = true;

    public void SetTimer()
    {
        _timer = 0;
    }

    private void Start()
    {
        _tiles.First().SetSpeed(_speed);
        for (int i = 0; i < _maxCount; i++)
        {
            GenerateTile();
        }
    }

    void Update()
    {

        if (_isEnable == false)
        {
            return;
        }

        _timer += Time.deltaTime;
        //Debug.Log(_timer);

        if (_tiles.Count < _maxCount)
        {
            GenerateTile();
        }
    }

    public void SetEnablind(bool state)
    {
        _isEnable = state;
        foreach (Tile tile in _tiles)
        {
            tile.SetMoving(state);
        }
    }

    private void GenerateTile()
    {
        GameObject newTileObject = Instantiate(_tilePrefab, _tiles.Last().transform.position + Vector3.forward * _tilePrefab.transform.localScale.z, Quaternion.identity);
        Tile newTile = newTileObject.GetComponent<Tile>();
        newTile.Initialize(_coin, _bomb, _startSpawnBomb, _timer);
        newTile.SetSpeed(_speed);
        _tiles.Add(newTile);
        newTileObject.transform.parent = _tileHolder;
    }


    private void OnTriggerEnter(Collider other)
    {
        Tile tile = other.GetComponent<Tile>();
        if (tile != null && _tiles.Contains(tile))
        {
            _tiles.Remove(tile);
            Destroy(tile.gameObject);
        }
    }
}
