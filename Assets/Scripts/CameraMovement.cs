using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private BallMovement _ballMovement;

    private void Start()
    {
        _ballMovement = FindObjectOfType<BallMovement>();
    }

    private void Update()
    {
        transform.position = new Vector3(_ballMovement.transform.position.x, 0, -10);
    }
}
