using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour{
    public HexCoordinates coordinates;
    public Color color;
    [SerializeField]
    HexCell[] neighbours;

	public RectTransform uiRect;

	int elevation;

	public int Elevation {
		get {
			return elevation;
		}
		set {
			elevation = value;
			Vector3 position = transform.localPosition;
			position.y = value * HexStatics.elevationStep;
			transform.localPosition = position;

			Vector3 uiPosition = uiRect.localPosition;
			uiPosition.z = elevation * -HexStatics.elevationStep;
			uiRect.localPosition = uiPosition;
		}
	}

	public HexCell GetNeighbor(HexDirection direction) {
        return neighbours[(int)direction];
    }

    public void SetNeighbor(HexDirection direction, HexCell cell) {
        neighbours[(int)direction] = cell;
        cell.neighbours[(int)direction.Opposite()] = this;
    }

}
