using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunObservableImpl : MonoBehaviour,IPunObservable
{
    // Start is called before the first frame update
    private Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        //SendRate default = 30
        //PhotonNetwork.SendRate = 30;
        //SerializationRate default = 10
        //PhotonNetwork.SerializationRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(rig.position);
            stream.SendNext(rig.rotation);
            stream.SendNext(rig.velocity);
        }
        else
        {
            
            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            rig.position = (Vector3)stream.ReceiveNext();
            rig.rotation = (Quaternion)stream.ReceiveNext();
            rig.velocity = (Vector3)stream.ReceiveNext();


            rig.position += rig.velocity * lag;
            
            
        }
    }
}
