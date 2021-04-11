using System;
using Unity.Mathematics;
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
    [SerializeField] private Transform prevBackgroundEnd;
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
        if (prevBackgroundEnd.position.x - _player.position.x < 2 * DistanceToSpawn)
            GenerateBackground();
    }

    private void GenerateBackground()
    {
        GameObject newBackground = Instantiate(background, prevBackgroundEnd.position, quaternion.identity);
        
        _destroyer.Add(newBackground);
        _mover.Add(newBackground);
        
        prevBackgroundEnd = newBackground.GetComponentsInChildren<Transform>()[2];
    }

    protected override void GenerateLevelPart()
    {
        GameObject newBlock;
        if(Random.Range(0, 1f) < 0.6f)
            newBlock = Instantiate(blocks[0], prevPartEnd.position, Quaternion.identity);
        else
            newBlock = Instantiate(blocks[Random.Range(1, blocks.Length)], prevPartEnd.position, Quaternion.identity);

        _destroyer.Add(newBlock);
        _mover.Add(newBlock);
        
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
