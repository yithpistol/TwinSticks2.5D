using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {
    private const int bufferSize = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferSize];
    private Rigidbody rigidBody;

    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = Object.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
      
        if (gameManager.recording)
        {
            Record();
        } else { PlayBack(); }
    }

    private void PlayBack() {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferSize;
        Debug.Log("Reading frame: " + frame);
        transform.position = keyFrames[frame].pos;
        transform.rotation = keyFrames[frame].rot;

    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferSize;
        float time = Time.time;
        print("Writing Frame: " + frame);

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, position, and rotation.
/// </summary>
public struct MyKeyFrame {

    public float frameTime;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float time, Vector3 apos, Quaternion arot) {
        frameTime = time;
        pos = apos;
        rot = arot;

    }




}
