/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace GodotEngine {

public class ResourceImportMetadata : Reference {

  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  
  internal ResourceImportMetadata(global::System.IntPtr cPtr, bool cMemoryOwn) : base(GodotEnginePINVOKE.ResourceImportMetadata_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }  
  
  protected ResourceImportMetadata(bool cMemoryOwn) : base(cMemoryOwn) {}
  
  new internal void internal_init(global::System.IntPtr cPtr) {
    base.internal_init(GodotEnginePINVOKE.ResourceImportMetadata_SWIGUpcast(cPtr));
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }
  
  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ResourceImportMetadata obj) {
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



  public void set_editor(string name) {
    GodotEnginePINVOKE.ResourceImportMetadata_set_editor(swigCPtr, name);
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public string get_editor() {
    string ret = GodotEnginePINVOKE.ResourceImportMetadata_get_editor(swigCPtr);
    return ret;
  }

  public void add_source(string path, string md5) {
    GodotEnginePINVOKE.ResourceImportMetadata_add_source__SWIG_0(swigCPtr, path, md5);
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public void add_source(string path) {
    GodotEnginePINVOKE.ResourceImportMetadata_add_source__SWIG_1(swigCPtr, path);
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public string get_source_path(int idx) {
    string ret = GodotEnginePINVOKE.ResourceImportMetadata_get_source_path(swigCPtr, idx);
    return ret;
  }

  public string get_source_md5(int idx) {
    string ret = GodotEnginePINVOKE.ResourceImportMetadata_get_source_md5(swigCPtr, idx);
    return ret;
  }

  public void remove_source(int idx) {
    GodotEnginePINVOKE.ResourceImportMetadata_remove_source(swigCPtr, idx);
  }

  public int get_source_count() {
    int ret = GodotEnginePINVOKE.ResourceImportMetadata_get_source_count(swigCPtr);
    return ret;
  }

  public void set_option(string key, Variant value) {
    GodotEnginePINVOKE.ResourceImportMetadata_set_option(swigCPtr, key, Variant.getCPtr(value));
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public void get_option(string key) {
    GodotEnginePINVOKE.ResourceImportMetadata_get_option(swigCPtr, key);
    if (GodotEnginePINVOKE.SWIGPendingException.Pending) throw GodotEnginePINVOKE.SWIGPendingException.Retrieve();
  }

  public SWIGTYPE_p_StringArray get_options() {
    SWIGTYPE_p_StringArray ret = new SWIGTYPE_p_StringArray(GodotEnginePINVOKE.ResourceImportMetadata_get_options(swigCPtr), true);
    return ret;
  }

  public ResourceImportMetadata() : this(true) {
    if (swigCPtr.Handle == global::System.IntPtr.Zero) {
      internal_init(GodotEnginePINVOKE.new_ResourceImportMetadata());
      InternalHelpers.TieManagedToUnmanaged(this, swigCPtr.Handle);
    }
  }

}

}