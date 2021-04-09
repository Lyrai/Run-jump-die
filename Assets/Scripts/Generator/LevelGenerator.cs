using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Destroyer))]
[RequireComponent(typeof(Mover))]
public class LevelGenerator : LevelGeneratorBase
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject[] blocks;
    private Destroyer _destroyer;
    private Mover _mover;
    [FormerlySerializedAs("_prevPartEnd")] [SerializeField] private Transform prevPartEnd;
    private const float DistanceToSpawn = 22f;
    private Transform _player;
    
    
    protected override void Start()
    {
        _player = Player.player.gameObject.transform;
        _destroyer = GetComponent<Destroyer>();
        _mover = GetComponent<Mover>();
        GenerateLevelPart();
    }

    protected override void Update()
    {
        if(prevPartEnd.position.x - _player.position.x < DistanceToSpawn)
            GenerateLevelPart();
    }

    protected override void GenerateLevelPart()
    {
        GameObject n = new GameObject();
        n.name = "Container";
        n.transform.position = prevPartEnd.position;
        GameObject newBlock = Instantiate(blocks[Random.Range(0, blocks.Length)], n.transform);
        newBlock.transform.localPosition = Vector3.zero;
        GameObject newBackground = Instantiate(background, n.transform);
        newBackground.transform.localPosition = Vector3.zero;

        _destroyer.Add(n);
        _mover.Add(n);
        
        prevPartEnd = newBlock.GetComponentsInChildren<Transform>()[2];
    }

    private GameObject ComposeLevelPart(int partsCount)
    {
        throw new NotImplementedException();
    }

    #if UNITY_EDITOR
    public void RefreshBlocks()
    {
        var n = Resources.LoadAll($"Gen{name.Split(' ')[1]}", typeof(GameObject));
        blocks = new GameObject[n.Length];
        for (int i = 0; i < n.Length; i++)
            blocks[i] = (GameObject) n[i];
    }
    #endif
}
