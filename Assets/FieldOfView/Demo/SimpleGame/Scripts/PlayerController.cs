using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour 
{
    public GameObject NavigationSurface;
    
    private NavMeshAgent _navMeshAgent;

    private void Start() {
        this._navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            MovePlayerTo(Input.mousePosition);
        }
    }

    private void MovePlayerTo(Vector3 position)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject == this.NavigationSurface) {
                this._navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}