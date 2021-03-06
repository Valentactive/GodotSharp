#include "gd_mono_field.h"

#include <mono/metadata/attrdefs.h>

#include "gd_mono_class.h"
#include "gd_mono_marshal.h"

void GDMonoField::set_value_raw(MonoObject *p_object, void* p_ptr)
{
	mono_field_set_value(p_object, mono_field, &p_ptr);
}

void GDMonoField::set_value(MonoObject *p_object, const Variant &p_value)
{
	#define SET_FROM_STRUCT_AND_BREAK(m_type) { \
			const m_type& val = p_value.operator m_type(); \
			MARSHALLED_OUT(m_type, val, raw); \
			mono_field_set_value(p_object, mono_field, raw); \
			break; \
		}

	#define SET_FROM_PRIMITIVE(m_type) { \
			m_type val = p_value.operator m_type(); \
			mono_field_set_value(p_object, mono_field, &val); \
		}

	#define SET_FROM_ARRAY_AND_BREAK(m_type) { \
			MonoArray* managed = GDMonoMarshal::m_type ## _to_mono_array(p_value.operator m_type()); \
			mono_field_set_value(p_object, mono_field, &managed); \
			break; \
		}

	switch (type.type_encoding) {
		case MONO_TYPE_BOOLEAN: {
			SET_FROM_PRIMITIVE(bool);
		} break;

		case MONO_TYPE_CHAR: {
			SET_FROM_PRIMITIVE(CharType);
		} break;

		case MONO_TYPE_I1: {
			SET_FROM_PRIMITIVE(signed char);
		} break;
		case MONO_TYPE_I2: {
			SET_FROM_PRIMITIVE(signed short);
		} break;
		case MONO_TYPE_I4: {
			SET_FROM_PRIMITIVE(signed int);
		} break;
		case MONO_TYPE_I8: {
			SET_FROM_PRIMITIVE(int64_t);
		} break;

		case MONO_TYPE_U1: {
			SET_FROM_PRIMITIVE(unsigned char);
		} break;
		case MONO_TYPE_U2: {
			SET_FROM_PRIMITIVE(unsigned short);
		} break;
		case MONO_TYPE_U4: {
			SET_FROM_PRIMITIVE(unsigned int);
		} break;
		case MONO_TYPE_U8: {
			SET_FROM_PRIMITIVE(uint64_t);
		} break;

		case MONO_TYPE_R4: {
			SET_FROM_PRIMITIVE(float);
		} break;

		case MONO_TYPE_R8: {
			SET_FROM_PRIMITIVE(double);
		} break;

		case MONO_TYPE_STRING: {
			MonoString* mono_string = GDMonoMarshal::mono_string_from_godot(p_value);
			mono_field_set_value(p_object, mono_field, mono_string);
		} break;

		case MONO_TYPE_VALUETYPE: {
			GDMonoClass *tclass = type.type_class;

			if (tclass == CACHED_CLASS(Vector2))
				SET_FROM_STRUCT_AND_BREAK(Vector2);

			if (tclass == CACHED_CLASS(Rect2))
				SET_FROM_STRUCT_AND_BREAK(Rect2);

			if (tclass == CACHED_CLASS(Matrix32))
				SET_FROM_STRUCT_AND_BREAK(Matrix32);

			if (tclass == CACHED_CLASS(Vector3))
				SET_FROM_STRUCT_AND_BREAK(Vector3);

			if (tclass == CACHED_CLASS(Matrix3))
				SET_FROM_STRUCT_AND_BREAK(Matrix3);

			if (tclass == CACHED_CLASS(Quat))
				SET_FROM_STRUCT_AND_BREAK(Quat);

			if (tclass == CACHED_CLASS(Transform))
				SET_FROM_STRUCT_AND_BREAK(Transform);

			if (tclass == CACHED_CLASS(AABB))
				SET_FROM_STRUCT_AND_BREAK(AABB);

			if (tclass == CACHED_CLASS(Color))
				SET_FROM_STRUCT_AND_BREAK(Color);

			if (tclass == CACHED_CLASS(Plane))
				SET_FROM_STRUCT_AND_BREAK(Plane);

			if (tclass == CACHED_CLASS(InputEvent))
				SET_FROM_STRUCT_AND_BREAK(InputEvent);

			ERR_EXPLAIN(String() + "Attempted to set the value of a field of unmarshallable type: " + tclass->get_name());
			ERR_FAIL();
		} break;

		case MONO_TYPE_ARRAY: {
			MonoArrayType* array_type = mono_type_get_array_type(GDMonoClass::get_raw_type(type.type_class));

			if (array_type->eklass == CACHED_CLASS_RAW(MonoObject))
				SET_FROM_ARRAY_AND_BREAK(Array);

			if (array_type->eklass == CACHED_CLASS_RAW(int32_t))
				SET_FROM_ARRAY_AND_BREAK(IntArray);

			if (array_type->eklass == CACHED_CLASS_RAW(uint8_t))
				SET_FROM_ARRAY_AND_BREAK(ByteArray);

			if (array_type->eklass == real_t_MonoClass)
				SET_FROM_ARRAY_AND_BREAK(RealArray);

			if (array_type->eklass == CACHED_CLASS_RAW(String))
				SET_FROM_ARRAY_AND_BREAK(StringArray);

			if (array_type->eklass == CACHED_CLASS_RAW(Color))
				SET_FROM_ARRAY_AND_BREAK(ColorArray);

			if (array_type->eklass == CACHED_CLASS_RAW(Vector2))
				SET_FROM_ARRAY_AND_BREAK(Vector2Array);

			if (array_type->eklass == CACHED_CLASS_RAW(Vector3))
				SET_FROM_ARRAY_AND_BREAK(Vector3Array);

			ERR_EXPLAIN(String() + "Attempted to convert Variant to a managed array of unmarshallable element type.");
			ERR_FAIL();
		} break;

		case MONO_TYPE_CLASS: {
			GDMonoClass* type_class = type.type_class;

			// GodotObject
			if (CACHED_CLASS(GodotObject)->is_assignable_from(type_class)) {
				Object* unmanaged = p_value.operator Object *();
				MonoObject* managed = GDMonoUtils::unmanaged_get_managed(unmanaged);

				if (!managed) {
					GDMonoClass* native = NULL;
					if (type_class->get_assembly() == GDMono::get_singleton()->get_api_assembly())
						native = type_class;
					else
						native = GDMonoUtils::get_class_native_base(type_class);

					if (native)
						managed = GDMonoUtils::create_managed_for_godot_object(type_class, native->get_name(), unmanaged);
				}

				mono_field_set_value(p_object, mono_field, &managed);
				break;
			}

			if (CACHED_CLASS(NodePath) == type_class) {
				MonoObject* managed = GDMonoUtils::create_managed_from(p_value.operator NodePath());
				mono_field_set_value(p_object, mono_field, &managed);
				break;
			}

			if (CACHED_CLASS(Image) == type_class) {
				MonoObject* managed = GDMonoUtils::create_managed_from(p_value.operator Image());
				mono_field_set_value(p_object, mono_field, &managed);
				break;
			}

			if (CACHED_CLASS(RID) == type_class) {
				MonoObject* managed = GDMonoUtils::create_managed_from(p_value.operator RID());
				mono_field_set_value(p_object, mono_field, &managed);
				break;
			}

			ERR_EXPLAIN(String() + "Attempted to set the value of a field of unmarshallable type: " + type_class->get_name());
			ERR_FAIL();
		} break;

		case MONO_TYPE_OBJECT: {
			GDMonoClass* type_class = type.type_class;

			// Variant
			switch (p_value.get_type()) {
				case Variant::BOOL: {
					SET_FROM_PRIMITIVE(bool);
				} break;
				case Variant::INT: {
					SET_FROM_PRIMITIVE(int);
				} break;
				case Variant::REAL: {
#ifdef REAL_T_IS_DOUBLE
					SET_FROM_PRIMITIVE(double);
#else
					SET_FROM_PRIMITIVE(float);
#endif
				} break;
				case Variant::STRING: {
					MonoString* mono_string = GDMonoMarshal::mono_string_from_godot(p_value);
					mono_field_set_value(p_object, mono_field, mono_string);
				} break;
				case Variant::VECTOR2: SET_FROM_STRUCT_AND_BREAK(Vector2);
				case Variant::RECT2: SET_FROM_STRUCT_AND_BREAK(Rect2);
				case Variant::VECTOR3: SET_FROM_STRUCT_AND_BREAK(Vector3);
				case Variant::MATRIX32: SET_FROM_STRUCT_AND_BREAK(Matrix32);
				case Variant::PLANE: SET_FROM_STRUCT_AND_BREAK(Plane);
				case Variant::QUAT: SET_FROM_STRUCT_AND_BREAK(Quat);
				case Variant::_AABB: SET_FROM_STRUCT_AND_BREAK(AABB);
				case Variant::MATRIX3: SET_FROM_STRUCT_AND_BREAK(Matrix3);
				case Variant::TRANSFORM: SET_FROM_STRUCT_AND_BREAK(Transform);
				case Variant::COLOR: SET_FROM_STRUCT_AND_BREAK(Color);
				case Variant::IMAGE: {
					MonoObject* managed = GDMonoUtils::create_managed_from(p_value.operator Image());
					mono_field_set_value(p_object, mono_field, &managed);
				} break;
				case Variant::NODE_PATH: {
					MonoObject* managed = GDMonoUtils::create_managed_from(p_value.operator NodePath());
					mono_field_set_value(p_object, mono_field, &managed);
				} break;
				case Variant::_RID: {
					MonoObject* managed = GDMonoUtils::create_managed_from(p_value.operator RID());
					mono_field_set_value(p_object, mono_field, &managed);
				} break;
				case Variant::OBJECT: {
					Object* unmanaged = p_value.operator Object *();
					MonoObject* managed = GDMonoUtils::unmanaged_get_managed(unmanaged);

					if (!managed) {
						GDMonoClass* native = NULL;
						if (type_class->get_assembly() == GDMono::get_singleton()->get_api_assembly())
							native = type_class;
						else
							native = GDMonoUtils::get_class_native_base(type_class);

						if (native)
							managed = GDMonoUtils::create_managed_for_godot_object(type_class, native->get_name(), unmanaged);
					}

					mono_field_set_value(p_object, mono_field, managed);
					break;
				}
				case Variant::INPUT_EVENT: SET_FROM_STRUCT_AND_BREAK(InputEvent);
				case Variant::DICTIONARY: {
					MonoObject* managed = GDMonoMarshal::Dictionary_to_mono_object(p_value.operator Dictionary());
					mono_field_set_value(p_object, mono_field, &managed);
				} break;
				case Variant::ARRAY: SET_FROM_ARRAY_AND_BREAK(Array);
				case Variant::RAW_ARRAY: SET_FROM_ARRAY_AND_BREAK(ByteArray);
				case Variant::INT_ARRAY: SET_FROM_ARRAY_AND_BREAK(IntArray);
				case Variant::REAL_ARRAY: SET_FROM_ARRAY_AND_BREAK(RealArray);
				case Variant::STRING_ARRAY: SET_FROM_ARRAY_AND_BREAK(StringArray);
				case Variant::VECTOR2_ARRAY: SET_FROM_ARRAY_AND_BREAK(Vector2Array);
				case Variant::VECTOR3_ARRAY: SET_FROM_ARRAY_AND_BREAK(Vector3Array);
				case Variant::COLOR_ARRAY: SET_FROM_ARRAY_AND_BREAK(ColorArray);
				#undef SET_FROM_ARRAY_AND_BREAK
				default: break;
			}
		} break;

		case MONO_TYPE_GENERICINST: {
			if (CACHED_RAW_MONO_CLASS(Dictionary) == type.type_class->get_raw()) {
				MonoObject* managed = GDMonoMarshal::Dictionary_to_mono_object(p_value.operator Dictionary());
				mono_field_set_value(p_object, mono_field, &managed);
				break;
			}
		} break;

		default: {
			ERR_PRINTS(String() + "Attempted to set the value of a field of unexpected type encoding: " + itos(type.type_encoding));
		} break;
	}

	#undef SET_FROM_STRUCT_AND_BREAK
	#undef SET_FROM_PRIMITIVE
}

bool GDMonoField::get_bool_value(MonoObject *p_object)
{
	return UNBOX_BOOLEAN(get_value(p_object));
}

int GDMonoField::get_int_value(MonoObject *p_object)
{
	return UNBOX_INT32(get_value(p_object));
}

String GDMonoField::get_string_value(MonoObject *p_object)
{
	return GDMonoMarshal::mono_string_to_godot((MonoString*)get_value(p_object));
}

bool GDMonoField::has_attribute(GDMonoClass *p_attr_class)
{
	ERR_FAIL_COND_V(!p_attr_class, false);

	if (!attrs_updated)
		update_attrs();

	if (!attrs)
		return false;

	return mono_custom_attrs_has_attr(attrs, p_attr_class->get_raw());
}

MonoObject* GDMonoField::get_attribute(GDMonoClass *p_attr_class)
{
	ERR_FAIL_COND_V(!p_attr_class, NULL);

	if (!attrs_updated)
		update_attrs();

	if (!attrs)
		return NULL;

	return mono_custom_attrs_get_attr(attrs, p_attr_class->get_raw());
}

void GDMonoField::update_attrs()
{
	attrs = mono_custom_attrs_from_field(owner->get_raw(), get_raw());
	attrs_updated = true;
}

bool GDMonoField::is_static()
{
	return mono_field_get_flags(mono_field) & MONO_FIELD_ATTR_STATIC;
}

GDMono::MemberVisibility GDMonoField::get_visibility()
{
	switch (mono_field_get_flags(mono_field) & MONO_FIELD_ATTR_FIELD_ACCESS_MASK) {
		case MONO_FIELD_ATTR_PRIVATE:
			return GDMono::PRIVATE;
		case MONO_FIELD_ATTR_FAM_AND_ASSEM:
			return GDMono::PROTECTED_AND_INTERNAL;
		case MONO_FIELD_ATTR_ASSEMBLY:
			return GDMono::INTERNAL;
		case MONO_FIELD_ATTR_FAMILY:
			return GDMono::PROTECTED;
		case MONO_FIELD_ATTR_PUBLIC:
			return GDMono::PUBLIC;
		default:
			ERR_FAIL_V(GDMono::PRIVATE);
	}
}

GDMonoField::GDMonoField(MonoClassField* p_raw_field, GDMonoClass* p_owner)
{
	owner = p_owner;
	mono_field = p_raw_field;
	name = mono_field_get_name(mono_field);
	MonoType* field_type = mono_field_get_type(mono_field);
	type.type_encoding = mono_type_get_type(field_type);
	MonoClass* field_type_class = mono_class_from_mono_type(field_type);
	type.type_class = GDMono::get_singleton()->get_class(field_type_class);

	attrs_updated = false;
	attrs = NULL;
}

