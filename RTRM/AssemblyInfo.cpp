#include "stdafx.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;

//
// ������� ���� �Ϲ� ������ ���� Ư�� ������ ���� 
// ����˴ϴ�. ������� ���õ� ������ �����Ϸ���
// �̷��� Ư�� ���� �����ϼ���.
//
[assembly:AssemblyTitleAttribute(L"RTRM")];
[assembly:AssemblyDescriptionAttribute(L"RouteTycoon Resource Manager")];
[assembly:AssemblyConfigurationAttribute(L"")];
[assembly:AssemblyCompanyAttribute(L"HawTech, Atus")];
[assembly:AssemblyProductAttribute(L"RTRM")];
[assembly:AssemblyCopyrightAttribute(L"? 2016. Team Atus, HawTech All rights reserved.")];
[assembly:AssemblyTrademarkAttribute(L"")];
[assembly:AssemblyCultureAttribute(L"")];

//
// ������� ���� ������ ���� �� ���� ������ �����˴ϴ�.
//
//      �� ����
//      �� ���� 
//      ���� ��ȣ
//      ���� ����
//
// ��� ���� �����ϰų� �Ʒ��� ���� '*'�� ����Ͽ� ���� ��ȣ �� ���� ������ �ڵ�����
// �����ǵ��� �� �� �ֽ��ϴ�.

[assembly:AssemblyVersionAttribute("1.0.*")];

[assembly:ComVisible(false)];

[assembly:CLSCompliantAttribute(true)];