// 기본 DLL 파일입니다.

#include "stdafx.h"

#include "RTRM.h"

#include <npk.h>
#include <npk_base.h>
#include <npk_dev.h>
#include <npk_conf.h>

#include <string.h>

#pragma comment(lib, "libnpk.lib")

#include "Utility.h"

namespace RTRM
{
	MemoryStream^ ResourceManager::Get(String^ filename, String^ entitystr, int k1, int k2, int k3, int k4, String^ password)
	{
		if (password != "RTRMPASSWORD-RTHONEYJAM")
		{
			return nullptr;
		}
		NPK_PACKAGE pack;
		NPK_ENTITY entity;

		std::string fname, ent;
		MarshalString(filename, fname);
		MarshalString(entitystr, ent);

		int teakey[4] = { k1, k2, k3, k4 };

		pack = npk_package_open(fname.c_str(), teakey);
		entity = npk_package_get_entity(pack, ent.c_str());

		void* temp;
		size_t len = npk_entity_get_size(entity);
		temp = malloc(len);

		npk_entity_read(entity, temp);

		npk_package_close(pack);

		IntPtr point(temp);
		cli::array<unsigned char, 1>^ bytes = gcnew cli::array<unsigned char, 1>(len);

		System::Runtime::InteropServices::Marshal::Copy(point, bytes, 0, len);

		free(temp);

		MemoryStream^ ms = gcnew MemoryStream(bytes);

		return ms;
	}

	void ResourceManager::Pack(String^ filename, System::Collections::Generic::List<String^>^ paths, System::Collections::Generic::List<String^>^ names, int k1, int k2, int k3, int k4, String^ password)
	{
		if (password != "RTRMPASSWORD-RTHONEYJAM")
		{
			return;
		}

		int key[4] = { k1, k2, k3, k4 };
		NPK_PACKAGE pack;

		npk_package_alloc(&pack, key);

		for (int i = 0; i < paths->Count; i++)
		{
			std::string p_tmp; MarshalString(paths[i], p_tmp);
			std::string n_tmp; MarshalString(names[i], n_tmp);
			NPK_CSTR p = p_tmp.c_str();
			NPK_CSTR n = n_tmp.c_str();

			NPK_ENTITY e;

			npk_package_add_file(pack, p, n, &e);
		}

		std::string fn_tmp; MarshalString(filename, fn_tmp);
		NPK_CSTR fn = fn_tmp.c_str();

		npk_package_save(pack, fn, true);
		npk_package_close(pack);
	}

	System::Collections::Generic::List<String^>^ ResourceManager::Items(String ^ filename, int k1, int k2, int k3, int k4, String ^ password)
	{
		if (password != "RTRMPASSWORD-RTHONEYJAM")
		{
			return nullptr;
		}

		System::Collections::Generic::List<String^>^ items = gcnew System::Collections::Generic::List<String^>();

		NPK_PACKAGE myPackage;
		NPK_ENTITY myEntity;
		NPK_CSTR myString;

		std::string _filename;
		String^ myConvertString;
		int key[4] = { k1, k2, k3, k4 };

		MarshalString(filename, _filename);

		myPackage = npk_package_open(_filename.c_str(), key);
		myEntity = npk_package_get_first_entity(myPackage);

		while (myEntity)
		{
			if (myEntity == NULL)
			{
				break;
			}

			myString = npk_entity_get_name(myEntity);
			myConvertString = gcnew String(myString);

			items->Add(myConvertString);

			myEntity = npk_entity_next(myEntity);
		}

		npk_package_close(myPackage);
		return items;
	}

	int ResourceManager::GetSize(String^ filename, String^ entity, int k1, int k2, int k3, int k4, String^ password)
	{
		if (password != "RTRMPASSWORD-RTHONEYJAM")
		{
			return 0;
		}

		NPK_PACKAGE myPackage;
		NPK_ENTITY myEntity;

		int key[4] = { k1, k2, k3, k4 };
		int size;
		std::string fname, ent;

		MarshalString(filename, fname);
		MarshalString(entity, ent);

		myPackage = npk_package_open(fname.c_str(), key);
		myEntity = npk_package_get_entity(myPackage, ent.c_str());

		size = npk_entity_get_size(myEntity);

		npk_package_close(myPackage);
		return size;
	}

	void ResourceManager::ReplaceEntity(String^ filename, String^ entity, String^ newentity, String^ newentityname, int k1, int k2, int k3, int k4, String^ password)
	{
		if (password != "RTRMPASSWORD-RTHONEYJAM")
		{
			return;
		}

		NPK_PACKAGE myPackage;
		NPK_ENTITY myEntity;
		NPK_ENTITY newEntity;

		int key[4] = { k1, k2, k3, k4 };
		int size;
		std::string fname, ent, nent, nent_name;

		MarshalString(filename, fname);
		MarshalString(entity, ent);
		MarshalString(newentity, nent);
		MarshalString(newentityname, nent_name);

		myPackage = npk_package_open(fname.c_str(), key);
		myEntity = npk_package_get_entity(myPackage, ent.c_str());

		npk_package_remove_entity(myPackage, myEntity);
		npk_package_add_file(myPackage, nent.c_str(), nent_name.c_str(), &newEntity);

		npk_package_save(myPackage, fname.c_str(), true);
		npk_package_close(myPackage);
	}
}