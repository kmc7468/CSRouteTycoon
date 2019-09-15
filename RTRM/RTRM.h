// RTRM.h

#pragma once

#include <msclr/marshal.h>
#include <string.h>
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

namespace RTRM {

	public ref class ResourceManager
	{
	public: static System::IO::MemoryStream^ Get(String^ filename, String^ entity, int k1, int k2, int k3, int k4, String^ password);
	public: static void Pack(String^ filename, System::Collections::Generic::List<String^>^ paths, System::Collections::Generic::List<String^>^ names, int k1, int k2, int k3, int k4, String^ password);
	public: static System::Collections::Generic::List<String^>^ Items(String^ filename, int k1, int k2, int k3, int k4, String^ password);
	public: static int GetSize(String^ filename, String^ entity, int k1, int k2, int k3, int k4, String^ password);
	public: static void ReplaceEntity(String^ filename, String^ entity, String^ newentity, String^ newentityname, int k1, int k2, int k3, int k4, String^ password);
	};
}