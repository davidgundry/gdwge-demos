using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "InstantiateWithTilePositionTile", menuName = "ScriptableObjects/InstantiateWithTilePositionTile")]
public class InstantiateWithTilePositionTile : Tile {

    public override bool StartUp(Vector3Int position, ITilemap iTilemap, GameObject go)
    {
        if (go != null)
        {
            TilePosition tp = go.GetComponent<TilePosition>();
            if (tp != null)
            {
                tp.position = position;
                tp.tilemap = iTilemap.GetComponent<Tilemap>();
            }
        }

        return base.StartUp(position, iTilemap, go);
    }
}