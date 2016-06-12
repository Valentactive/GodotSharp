/**********************************************************************************/
/* csharp_gc_handle.cpp                                                           */
/**********************************************************************************/
/* The MIT License (MIT)                                                          */
/*                                                                                */
/* Copyright (c) 2016 Ignacio Etcheverry                                          */
/*                                                                                */
/* Permission is hereby granted, free of charge, to any person obtaining a copy   */
/* of this software and associated documentation files (the "Software"), to deal  */
/* in the Software without restriction, including without limitation the rights   */
/* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell      */
/* copies of the Software, and to permit persons to whom the Software is          */
/* furnished to do so, subject to the following conditions:                       */
/*                                                                                */
/* The above copyright notice and this permission notice shall be included in all */
/* copies or substantial portions of the Software.                                */
/*                                                                                */
/* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR     */
/* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,       */
/* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE    */
/* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER         */
/* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,  */
/* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE  */
/* SOFTWARE.                                                                      */
/**********************************************************************************/

#include "csharp_gc_handle.h"

MonoObject *CSharpGCHandle::get_object() const
{
	return mono_gchandle_get_target(handle);
}

CSharpGCHandle::CSharpGCHandle(uint32_t p_handle)
{
	handle = p_handle;
}

CSharpGCHandle::CSharpGCHandle(MonoObject *p_object)
{
	handle = mono_gchandle_new(p_object, FALSE);
}

CSharpGCHandle::~CSharpGCHandle()
{
	CSharpLanguage* script_lang = CSharpLanguage::get_singleton();
	if (script_lang && !script_lang->mono_jit_cleaned)
		mono_gchandle_free(handle);
}