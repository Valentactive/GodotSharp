/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace GodotEngine {

public class CollisionShape : Spatial {

  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  
  internal CollisionShape(global::System.IntPtr cPtr, bool cMemoryOwn) : base(GodotEnginePINVOKE.CollisionShape_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }  
  
  protected CollisionShape(bool cMemoryOwn) : base(cMemoryOwn) {}
  
  new internal void internal_init(global::System.IntPtr cPtr) {
    base.internal_init(GodotEnginePINVOKE.CollisionShape_SWIGUpcast(cPtr));
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }
  
  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CollisionShape obj) {
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



  public void resource_changed(Object resource) {
    GodotEnginePINVOKE.CollisionShape_resource_changed(swigCPtr, Object.getCPtr(resource));
  }

  public void set_shape(Object shape) {
    GodotEnginePINVOKE.CollisionShape_set_shape(swigCPtr, Object.getCPtr(shape));
  }

  public Object get_shape() {
    global::System.IntPtr cPtr = GodotEnginePINVOKE.CollisionShape_get_shape(swigCPtr);
    Object ret = InternalHelpers.UnmanagedGetManaged(cPtr);
    if (ret == null) {
      ret = new Object(cPtr, false);
    }
    return ret;
  }

  public void set_trigger(bool enable) {
    GodotEnginePINVOKE.CollisionShape_set_trigger(swigCPtr, enable);
  }

  public bool is_trigger() {
    bool ret = GodotEnginePINVOKE.CollisionShape_is_trigger(swigCPtr);
    return ret;
  }

  public void make_convex_from_brothers() {
    GodotEnginePINVOKE.CollisionShape_make_convex_from_brothers(swigCPtr);
  }

  public int get_collision_object_shape_index() {
    int ret = GodotEnginePINVOKE.CollisionShape_get_collision_object_shape_index(swigCPtr);
    return ret;
  }

  public CollisionShape() : this(false) {
    if (swigCPtr.Handle == global::System.IntPtr.Zero) {
      internal_init(GodotEnginePINVOKE.new_CollisionShape());
      InternalHelpers.TieManagedToUnmanaged(this, swigCPtr.Handle);
    }
  }

}

}