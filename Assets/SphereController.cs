using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour {

	public Rigidbody Sphere;
	
	public Slider Slider;
	public Button Top;
	public Button Bottom;
	public Button Left;
	public Button Right;
	public Toggle Stop;

	
	private float speed = 1f;

	void Start () {
		
	}
	
	
	void Update () {
		Slider.onValueChanged.AddListener(delegate {UpdateSphereSpeed ();});
		Top.onClick.AddListener(TopClick);
		Bottom.onClick.AddListener(BottomClick);
		Left.onClick.AddListener(LeftClick);
		Right.onClick.AddListener(RightClick);
		Stop.onValueChanged.AddListener(delegate {StopSphere ();});
	}

	public void UpdateSphereSpeed() {
		speed = GetComponent<Slider>().value;

	}

	public void TopClick() {
		Sphere.AddForce(transform.forward * speed/10, ForceMode.Impulse);
	}

	public void BottomClick() {
		Sphere.AddForce(transform.forward * -(speed)/10, ForceMode.Impulse);
	}

	public void LeftClick() {
		Sphere.AddForce(transform.right * -(speed)/10, ForceMode.Impulse);
	}

	public void RightClick() {
		Sphere.AddForce(transform.right * speed/10, ForceMode.Impulse);
	}

	public void StopSphere() {
		Vector3 velocity = Sphere.velocity; 
		Sphere.AddForce(-velocity, ForceMode.Impulse);
		if (Stop.isOn) {
			Sphere.constraints = RigidbodyConstraints.FreezeAll;
		} else {
			Sphere.constraints = RigidbodyConstraints.FreezeRotation;
			Sphere.constraints = RigidbodyConstraints.FreezePositionY; 
		}
	}
}