using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class slipperyWASD : MonoBehaviour {

	public string HorizontalAxis;
	public string VerticalAxis;
    public bool IsOn = false;
    public float SpeedCap = 2f;
    public float SquaredSpeedLimit = 4f;
    public float LessAccelSpeedLimit = 0.5f;
    public float Accel = 0.05f;
    public float Deccel = 0.05f;
    public float ReverseModifier = 2f;
    public float HighSpeedModifier = 0.25f;

    private Vector2 _speed;
    private Vector2 _stopPosition;
    private float _axisSign = 0f;
    private float _speedGain = 0f;

    private CircleCollider2D _cc;
    private RaycastHit2D[] _hits = new RaycastHit2D[10];
    private ContactFilter2D _filter = new ContactFilter2D(){};
    private List<RaycastHit2D> _hitList = new List<RaycastHit2D>();
    /*
	void OnEnable() 
    {
        GameEvents.current.onStartGamePoint += StartGamePoint;
        GameEvents.current.onPlayerDeath += PlayerDeath;
	}*/

    void Start()
    {
        GameEvents.current.onStartGamePoint += StartGamePoint;
        GameEvents.current.onPlayerDeath += PlayerDeath;

        _cc = GetComponent<CircleCollider2D>();

        _filter.useTriggers = false;
        _filter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        _filter.useLayerMask = true;
    }

    void OnDestroy()
    {
        GameEvents.current.onStartGamePoint -= StartGamePoint;
        GameEvents.current.onPlayerDeath -= PlayerDeath;
    }
	
	void FixedUpdate () {
        if (IsOn)
        {
            _axisSign = 0;
            if (Input.GetButton(HorizontalAxis))
            {
                // Get sign of axis
                _axisSign = Input.GetAxisRaw(HorizontalAxis);
                _speedGain = _axisSign * Accel;

                // double accel when reversing.
                if (_speed.x/_axisSign < 0){
                    _speedGain *= ReverseModifier;
                }
                // gain less speed after a certain threshold.
                else if(_speed.x * _speed.x > LessAccelSpeedLimit) {
                    _speedGain *= HighSpeedModifier;
                }
  
                _speed.x += _speedGain;
            }
            if (Input.GetButton(VerticalAxis))
            {
                _axisSign = Input.GetAxisRaw(VerticalAxis);
                _speedGain = _axisSign * Accel;

                if (_speed.y/_axisSign < 0){
                    _speedGain *= ReverseModifier;
                }
                else if(_speed.y * _speed.y > LessAccelSpeedLimit) {
                    _speedGain *= HighSpeedModifier;
                }
  
                _speed.y += _speedGain;
            }

            // Slowdown
            // As is, only occurs when holding no buttons. Probably shouldn't be like that.
            if(_axisSign == 0) {
                // reduce the magnitude by X.
                // normalize speed vector to a deccel magnitude.
                // that is how much speed should reduce by.
                Vector2 slowdown = _speed.normalized * Deccel;
                _speed -= slowdown;

                // If the total speed is below a threshold, stop.
                if(_speed.magnitude < Deccel) {
                    _speed.x = 0;
                    _speed.y = 0;
                }
            }
        }

        if(_speed.sqrMagnitude > SquaredSpeedLimit) {
            _speed = _speed.normalized * SpeedCap;
        }

        if(!CheckCollisions()) {
            float output_x_speed = _speed.x;
            float output_y_speed = _speed.y;

            Vector3 pos = this.transform.position;
            pos.x += output_x_speed;
            pos.y += output_y_speed;
            this.transform.position = pos;
        }
    }

    public void StartGamePoint()
    {
        IsOn = true;
    }

    public void PlayerDeath()
    {
        IsOn = false;
    }

    // Predicts collisions to prevent overlapping into colliders.
    private bool CheckCollisions() {
        if(_cc != null) {
            // Casts the collider ahead to check for collisions, then add them to a list.
            int numHits = _cc.Cast(_speed, _filter, _hits, _speed.magnitude);
            _hitList.Clear();
            for(int i = 0; i < numHits; i++) {
                _hitList.Add(_hits[i]);
            }

            // Evaluate all the collisions that occured.
            for(int i = 0; i < _hitList.Count; i++) {
                // A simple check for now.
                if(!_hitList[i].collider.isTrigger) {
                    // Get the (approximate) collision point.
                    // Maybe use Collider2D.ClosestPoint(...) instead? idk if it'd be faster or what, though
                    Vector2 collision_point = Physics2D.ClosestPoint(_hitList[i].point, _hitList[i].collider);

                    // fudge some numbers and effects to prevent collision from continuing.
                    Vector2 reflection = Vector2.Reflect(_speed, _hitList[i].normal);
                    _speed = reflection * 0.8f + _hitList[i].normal * 0.1f;

                    // Set this object to be just adjacent to the wall, not overlapping it.
                    _stopPosition = collision_point + (_hitList[i].normal * _cc.radius);
                    Vector3 pos = this.transform.position;
                    pos = _stopPosition;
                    this.transform.position = pos;

                    return true;
                }
            }
            return false;
        }

        return false;
    }

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D contact = other.GetContact(0);
        Vector2 reflection = Vector2.Reflect(speed, contact.normal);

        // fudge numbers to prevent collision from staying.
        speed = reflection * 0.8f + contact.normal * 0.1f;

        Vector3 pos = this.transform.position;
        pos = stop_position;
        this.transform.position = pos;

        //Debug.DrawRay(contact.point, reflection, Color.green, 1f);
    }
    */

    /*
    private void OnCollisionStay2D(Collision2D other) {
        ContactPoint2D contact = other.GetContact(0);

        Vector3 pos = this.transform.position;
        pos = stop_position;
        this.transform.position = pos;

        //Debug.Log(this.transform.position);

        Debug.DrawRay(contact.point, contact.normal * 2.3f, Color.blue, 0.1f);
    }*/
}
