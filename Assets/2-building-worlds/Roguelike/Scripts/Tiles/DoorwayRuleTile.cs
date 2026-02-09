using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "DoorwayRuleTile", menuName = "ScriptableObjects/DoorwayRuleTile")]
public class DoorwayRuleTile : Tile {

    [SerializeField] private Sprite vertical;
    [SerializeField] private Sprite horizontal;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = vertical;
        if ((tilemap.GetTile(position + new Vector3Int(-1,0,0)) != null)
            && (tilemap.GetTile(position + new Vector3Int(+1,0,0)) != null))
                tileData.sprite = horizontal;
    }
}