﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    public int width = 10, height = 10;

    public HexCell cellPrefab;
    public Text cellLabelPrefab;
    HexCell[] cells;
    Canvas gridCanvas;
    HexMesh hexMesh;

    public Color defaultColor = Color.white;
	public Color touchedColor = Color.magenta;

    void Awake(){
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();
        cells = new HexCell[height * width];

        for(int z = 0, i = 0; z < height; z++){
            for(int x = 0; x < width; x++){
                CreateCell(x,z,i++);
            }
        }
    }

    void Start(){
        hexMesh.Triangulate(cells);
    }

    void CreateCell(int x, int z, int i){
        Vector3 position;
        position.x = (x + 0.5f * z - z/2) * (HexStatics.innerRadius * 2f);
        position.y = 0;
        position.z = z * (HexStatics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        cell.color = defaultColor;

        if(x > 0) {
            cell.SetNeighbor(HexDirection.W, cells[i - 1]);
        }

        if(z > 0) {
            if((z & 1) == 0) {
                cell.SetNeighbor(HexDirection.SE, cells[i - width]);
                if(x > 0) {
                    cell.SetNeighbor(HexDirection.SW, cells[i - width - 1]);
                }
            }
            else {
                cell.SetNeighbor(HexDirection.SW, cells[i - width]);
                if(x < width - 1) {
                    cell.SetNeighbor(HexDirection.SE, cells[i - width + 1]);
                }
            }
        }

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();

    }
	
	public void ColorCell (Vector3 position, Color color) {
		position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
		HexCell cell = cells[index];
		cell.color = color;
		hexMesh.Triangulate(cells);
	}
}