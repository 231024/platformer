using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInteractor : MonoBehaviour
{
	[SerializeField] private HeroPhysicsController _physics;
	
	public void OnInteract(InputAction.CallbackContext context)
	{
		if (context.performed && _physics.Interactable != null)
		{
			_physics.Interactable.Interact();
		}
	}
}
