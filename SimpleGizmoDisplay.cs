using UnityEngine;
using System.Collections;

public class SimpleGizmoDisplay : MonoBehaviour
{
	public enum GIZMOTYPE {
		CUBE,
		WIRECUBE,
		SPHERE,
		WIRESPHERE,
		ICON,
		LINE
	};

	public GIZMOTYPE _gizmoType;
	public Color _color = new Color(1, 1, 1, 1);

	public Vector3 _dimensions;
	public Vector3 _offset;

	// This looks for an icon image placed in Assets/Gizmos
	public string _iconImage = "icon.tif";
	public bool _allowIconScaling = false;

	public Vector3 _endPoint;
	public bool _offsetEnd;

	void OnDrawGizmos()
	{
		Gizmos.color = _color;

		// Apply the offset
		Vector3 position = transform.position + _offset;

		switch(_gizmoType)
		{
			case GIZMOTYPE.CUBE:
				Gizmos.DrawCube(position, _dimensions);
				break;

			case GIZMOTYPE.WIRECUBE:
				Gizmos.DrawWireCube(position, _dimensions);
				break;

			// Use x value of dimensions for the radius
			case GIZMOTYPE.SPHERE:
				Gizmos.DrawSphere(position, _dimensions.x);
				break;

			// Use x value of dimensions for the radius
			case GIZMOTYPE.WIRESPHERE:
				Gizmos.DrawWireSphere(position, _dimensions.x);
				break;

			case GIZMOTYPE.ICON:
				Gizmos.DrawIcon(position, _iconImage, _allowIconScaling);
				break;

			// Checks to see if we should offset the end as well as
			// the start point
			case GIZMOTYPE.LINE:
				Vector3 tmpEndPoint = _endPoint;
				if(_offsetEnd)
					tmpEndPoint += _offset;
				Gizmos.DrawLine(position, tmpEndPoint);
				break;
		}
	}	
}
