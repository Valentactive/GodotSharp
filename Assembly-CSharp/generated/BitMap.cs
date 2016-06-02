/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace GodotEngine {

public class BitMap : Resource {

  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  
  internal BitMap(global::System.IntPtr cPtr, bool cMemoryOwn) : base(GodotEnginePINVOKE.BitMap_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }  
  
  protected BitMap(bool cMemoryOwn) : base(cMemoryOwn) {}
  
  new internal void internal_init(global::System.IntPtr cPtr) {
    base.internal_init(GodotEnginePINVOKE.BitMap_SWIGUpcast(cPtr));
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }
  
  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BitMap obj) {
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



  public void create(Vector2 size) {
    GodotEnginePINVOKE.BitMap_create(swigCPtr, Vector2.getCPtr(size));
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public void create_from_image_alpha(SWIGTYPE_p_Image image) {
    GodotEnginePINVOKE.BitMap_create_from_image_alpha(swigCPtr, SWIGTYPE_p_Image.getCPtr(image));
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public void set_bit(Vector2 pos, bool bit) {
    GodotEnginePINVOKE.BitMap_set_bit(swigCPtr, Vector2.getCPtr(pos), bit);
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public bool get_bit(Vector2 pos) {
    bool ret = GodotEnginePINVOKE.BitMap_get_bit(swigCPtr, Vector2.getCPtr(pos));
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void set_bit_rect(SWIGTYPE_p_Rect2 p_rect, bool bit) {
    GodotEnginePINVOKE.BitMap_set_bit_rect(swigCPtr, SWIGTYPE_p_Rect2.getCPtr(p_rect), bit);
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public int get_true_bit_count() {
    int ret = GodotEnginePINVOKE.BitMap_get_true_bit_count(swigCPtr);
    return ret;
  }

  public Vector2 get_size() {
    Vector2 ret = new Vector2(GodotEnginePINVOKE.BitMap_get_size(swigCPtr), true);
    return ret;
  }

  public BitMap() : this(true) {
    if (swigCPtr.Handle == global::System.IntPtr.Zero) {
      internal_init(GodotEnginePINVOKE.new_BitMap());
      InternalHelpers.TieManagedToUnmanaged(this, swigCPtr.Handle);
    }
  }

}

}