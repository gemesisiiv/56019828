using UnityEngine;
using System.Collections;

public class GridDrawer : MonoBehaviour {

	public int CellSize = 1;
	public Color GridColor = new Color(1, 1, 1, 0.45f);
	
	void OnDrawGizmos() {
		Gizmos.color = GridColor;
		//Draw Horizontal (naewnon)
		for (int z=-100; z<=100; z+=CellSize) {
			Vector3 p1 = new Vector3(-100, 0, z);
			Vector3 p2 = new Vector3(100, 0, z);
			Gizmos.DrawLine(p1, p2);
		}
		// Draw Vertical (narewtung)
		for (int x=-100; x<=100; x+=CellSize) {
			Vector3 p1 = new Vector3(x, 0, -100);
			Vector3 p2 = new Vector3(x, 0, 100);
			Gizmos.DrawLine(p1, p2);
		}
	
	}
}