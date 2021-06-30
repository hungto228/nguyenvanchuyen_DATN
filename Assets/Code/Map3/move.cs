        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float vantoc;
    private float tocdo = 5f;
    private Animator hoathoa;
    private Rigidbody2D rigidbody2D;
    public int rotationSpeedTurret = 0;
    Transform tankTurret;
    private bool huongquay = true;
    Transform tankBody;
    public int rotationSpeedTank = 0;
   public Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
      
        tankBody = transform.Find("tank");
        tankTurret = transform.Find("sung");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        Dichuyen();
      
    }



    void Dichuyen()
    {

        float phaitrai = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(vantoc * phaitrai, rigidbody2D.velocity.y);
        tocdo = Mathf.Abs(vantoc * phaitrai);

        float lenxuong = Input.GetAxis("Vertical");
        rigidbody2D.velocity = new Vector2(vantoc * lenxuong, rigidbody2D.velocity.x);
        tocdo = Mathf.Abs(vantoc * lenxuong);
        if (phaitrai > 0 && !huongquay) Huongquay();
        if (phaitrai < 0 && huongquay) Huongquay();

        if (lenxuong > 0 && !huongquay) Huongquay();
        if (lenxuong < 0 && huongquay) Huongquay();

    }
    void Huongquay()
    {

         Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, diff - tankTurret.position);
        //  desiredRotation = Quaternion.Euler(0, 0, desiredRotation.eulerAngles.z + 90);
        //  tankTurret.rotation = Quaternion.RotateTowards(tankTurret.rotation, desiredRotation, rotationSpeedTurret * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, desiredRotation.eulerAngles.z + 90);
        tankTurret.rotation = Quaternion.RotateTowards(tankTurret.rotation, desiredRotation, rotationSpeedTurret * Time.deltaTime);
    }
    public void RotateTankBody(float inputDirection)
    {
        float rotation = -inputDirection * rotationSpeedTank;
        tankBody.Rotate(Vector3.forward * rotation);

    }
}
