using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour{
    public HexCoordinates coordinates;
    public Color color;
    [SerializeField]
    HexCell[] neighbours;

    public HexCell GetNeighbor(HexDirection direction) {
        return neighbours[(int)direction];
    }

    public void SetNeighbor(HexDirection direction, HexCell cell) {
        neighbours[(int)direction] = cell;
        cell.neighbours[(int)direction.Opposite()] = this;
    }

}
