/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace GodotEngine {

public class Generic6DOFJoint : Joint {
  public static readonly int PARAM_LINEAR_LOWER_LIMIT = 0;
  public static readonly int PARAM_LINEAR_UPPER_LIMIT = 1;
  public static readonly int PARAM_LINEAR_LIMIT_SOFTNESS = 2;
  public static readonly int PARAM_LINEAR_RESTITUTION = 3;
  public static readonly int PARAM_LINEAR_DAMPING = 4;
  public static readonly int PARAM_ANGULAR_LOWER_LIMIT = 5;
  public static readonly int PARAM_ANGULAR_UPPER_LIMIT = 6;
  public static readonly int PARAM_ANGULAR_LIMIT_SOFTNESS = 7;
  public static readonly int PARAM_ANGULAR_DAMPING = 8;
  public static readonly int PARAM_ANGULAR_RESTITUTION = 9;
  public static readonly int PARAM_ANGULAR_FORCE_LIMIT = 10;
  public static readonly int PARAM_ANGULAR_ERP = 11;
  public static readonly int PARAM_ANGULAR_MOTOR_TARGET_VELOCITY = 12;
  public static readonly int PARAM_ANGULAR_MOTOR_FORCE_LIMIT = 13;
  public static readonly int PARAM_MAX = 14;
  public static readonly int FLAG_ENABLE_LINEAR_LIMIT = 0;
  public static readonly int FLAG_ENABLE_ANGULAR_LIMIT = 1;
  public static readonly int FLAG_ENABLE_MOTOR = 2;
  public static readonly int FLAG_MAX = 3;

  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  
  internal Generic6DOFJoint(global::System.IntPtr cPtr, bool cMemoryOwn) : base(GodotEnginePINVOKE.Generic6DOFJoint_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }  
  
  protected Generic6DOFJoint(bool cMemoryOwn) : base(cMemoryOwn) {}
  
  new internal void internal_init(global::System.IntPtr cPtr) {
    base.internal_init(GodotEnginePINVOKE.Generic6DOFJoint_SWIGUpcast(cPtr));
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }
  
  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Generic6DOFJoint obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }



  public void set_param_x(int param, float value) {
    GodotEnginePINVOKE.Generic6DOFJoint_set_param_x(swigCPtr, param, value);
  }

  public float get_param_x(int param) {
    float ret = GodotEnginePINVOKE.Generic6DOFJoint_get_param_x(swigCPtr, param);
    return ret;
  }

  public void set_param_y(int param, float value) {
    GodotEnginePINVOKE.Generic6DOFJoint_set_param_y(swigCPtr, param, value);
  }

  public float get_param_y(int param) {
    float ret = GodotEnginePINVOKE.Generic6DOFJoint_get_param_y(swigCPtr, param);
    return ret;
  }

  public void set_param_z(int param, float value) {
    GodotEnginePINVOKE.Generic6DOFJoint_set_param_z(swigCPtr, param, value);
  }

  public float get_param_z(int param) {
    float ret = GodotEnginePINVOKE.Generic6DOFJoint_get_param_z(swigCPtr, param);
    return ret;
  }

  public void set_flag_x(int flag, bool value) {
    GodotEnginePINVOKE.Generic6DOFJoint_set_flag_x(swigCPtr, flag, value);
  }

  public bool get_flag_x(int flag) {
    bool ret = GodotEnginePINVOKE.Generic6DOFJoint_get_flag_x(swigCPtr, flag);
    return ret;
  }

  public void set_flag_y(int flag, bool value) {
    GodotEnginePINVOKE.Generic6DOFJoint_set_flag_y(swigCPtr, flag, value);
  }

  public bool get_flag_y(int flag) {
    bool ret = GodotEnginePINVOKE.Generic6DOFJoint_get_flag_y(swigCPtr, flag);
    return ret;
  }

  public void set_flag_z(int flag, bool value) {
    GodotEnginePINVOKE.Generic6DOFJoint_set_flag_z(swigCPtr, flag, value);
  }

  public bool get_flag_z(int flag) {
    bool ret = GodotEnginePINVOKE.Generic6DOFJoint_get_flag_z(swigCPtr, flag);
    return ret;
  }

  public Generic6DOFJoint() : this(false) {
    if (swigCPtr.Handle == global::System.IntPtr.Zero) {
      internal_init(GodotEnginePINVOKE.new_Generic6DOFJoint());
      InternalHelpers.TieManagedToUnmanaged(this, swigCPtr.Handle);
    }
  }

}

}