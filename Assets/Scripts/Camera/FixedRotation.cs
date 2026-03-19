using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    [SerializeField] private Transform player_position;
    [SerializeField] private Vector3 offset = new Vector3(0, -0.2f, 0);
    [SerializeField] private float speedrotation = 10f;
    private Vector3 Lastposition;

    void Start()
    {
        Lastposition = player_position.position;
    }

    void Update()
    {
        //Keep Position
        transform.position = player_position.position + offset;
        
        //Calculate player movment direction
        Vector3 moveDirection = player_position.position - transform.position;
        moveDirection.y = 0f;
        moveDirection.Normalize();
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            //Move the player depending on the movment direction
            float TargetY = Quaternion.LookRotation(moveDirection).eulerAngles.y;
            
            Quaternion targetRotation = Quaternion.Euler(0f, TargetY, 0f);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedrotation * Time.deltaTime);
        }
        Lastposition = player_position.position;
    }
}
