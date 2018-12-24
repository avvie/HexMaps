using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class HexMapEditor : MonoBehaviour{
    public Color[] colors;

    public HexGrid hexGrid;

    private Color activeColor;
	int activeElevation;

    void Awake() {
        SelectColor(0);
    }

    void Update() {
        if(Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            HandleInput();
        }
    }

    void HandleInput() {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay, out hit)) {
            EditCell(hexGrid.GetCell(hit.point));
        }
    }

	void EditCell(HexCell cell) {
		cell.color = activeColor;
		cell.Elevation = activeElevation;
		hexGrid.Refresh();
	}

	public void SetElevation(Slider slide) {
		activeElevation = (int)slide.value;
	}

	public void SelectColor(int index) {
        activeColor = colors[index];
    }
}
