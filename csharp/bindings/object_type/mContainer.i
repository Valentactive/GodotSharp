/* mContainer.i */
%module mContainer


%typemap(csbody_derived) Container %{
  public static readonly int NOTIFICATION_SORT_CHILDREN = 50;

  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  
  internal $csclassname(global::System.IntPtr cPtr, bool cMemoryOwn) : base($imclassname.$csclazznameSWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }  
  
  protected $csclassname(bool cMemoryOwn) : base(cMemoryOwn) {}
  
  new internal void internal_init(global::System.IntPtr cPtr) {
    base.internal_init($imclassname.$csclazznameSWIGUpcast(cPtr));
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }
  
  internal static global::System.Runtime.InteropServices.HandleRef getCPtr($csclassname obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }
%}

%typemap(cscode) Container %{

%}

%typemap(csconstruct, excode=SWIGEXCODE) Container %{: this(false) {
    if (swigCPtr.Handle == global::System.IntPtr.Zero) {
      internal_init($imcall);
      InternalHelpers.TieManagedToUnmanaged(this, swigCPtr.Handle);
    }$excode
  }
%}

%nodefaultdtor Container;

class Container : public Control {
public:
  %extend {
    void queue_sort() {
  Object* self_obj = static_cast<Object*>($self);
  self_obj->call("queue_sort");
    }
  }
  %extend {
    void fit_child_in_rect(Control* child, const Rect2& rect) {
  Object* self_obj = static_cast<Object*>($self);
  self_obj->call("fit_child_in_rect", child, rect);
    }
  }
  Container();

};