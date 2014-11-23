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

	[Tooltip("The gizmo to render")]
	public GIZMOTYPE _gizmoType;
	[Tooltip("Colour values to use for rendering the gizmos")]
	public Color _color = new Color(1, 1, 1, 1);

	[Tooltip("Dimensions for shape gizmos.\nThe x dimension is used for the radius.")]
	public Vector3 _dimensions;
	[Tooltip("Offset from the transform of the gameObject this is attached to")]
	public Vector3 _offset;

	[Tooltip("This looks for an icon image placed in Assets/Gizmos")]
	public string _iconImage = "icon.tif";
	[Tooltip("Should icons scale when you zoom in/out")]
	public bool _allowIconScaling = false;

	[Tooltip("When using a line gizmo, where is the end point?")]
	public Vector3 _endPoint;
	[Tooltip("Should the end point of a line be offset or not?")]
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

			// Use x value of _dimensions for the radius
			case GIZMOTYPE.SPHERE:
				Gizmos.DrawSphere(position, _dimensions.x);
				break;

			// Use x value of _dimensions for the radius
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
